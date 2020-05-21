using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinappStation
{
    public partial class Form_station : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;

        private TcpListener listener;
        private readonly Dictionary<int, TcpClient> tcpClients = new Dictionary<int, TcpClient>();
        private readonly Dictionary<int, Config> cfgClients = new Dictionary<int, Config>();
        private List<Thread> clientThreads = new List<Thread>();

        private string serverIp = string.Empty;
        private int serverPort = 55555;
        private int clientStatusIndex = -1;
        private int clientDataIndex = -1;

        private enum iStatus : int { Id, Name, Software, Ip, Port, Button, }
        private enum iData : int { Name, Firmware, Credits, Session, LastAction, Button, }
        private Form_dialog dialog;

        private ContextMenuStrip contextMenu = new ContextMenuStrip();
        private ToolStripMenuItem lockToolStrip = new ToolStripMenuItem("Lock");
        private ToolStripMenuItem unlockToolStrip = new ToolStripMenuItem("Unlock");
        private ToolStripMenuItem logoutToolStrip = new ToolStripMenuItem("Logout");
        private ToolStripMenuItem muteToolStrip = new ToolStripMenuItem("Mute");
        private ToolStripMenuItem unmuteToolStrip = new ToolStripMenuItem("Unmute");
        private ToolStripMenuItem shutdownToolStrip = new ToolStripMenuItem("Shutdown");

        public Form_station()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + Application.ProductVersion;
            contextMenu.Items.Add(lockToolStrip);
            contextMenu.Items.Add(unlockToolStrip);
            contextMenu.Items.Add(logoutToolStrip);
            contextMenu.Items.Add(muteToolStrip);
            contextMenu.Items.Add(unmuteToolStrip);
            contextMenu.Items.Add(shutdownToolStrip);

            lockToolStrip.Click += LockToolStrip_Click;
            unlockToolStrip.Click += UnlockToolStrip_Click;
            logoutToolStrip.Click += LogoutToolStrip_Click;
            muteToolStrip.Click += MuteToolStrip_Click;
            unmuteToolStrip.Click += UnmuteToolStrip_Click;
            shutdownToolStrip.Click += ShutdownToolStrip_Click;
        }
        
        private void ShutdownToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=SHUTDOWN");
        }
        private void UnmuteToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=UNMUTE");
        }
        private void MuteToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=MUTE");
        }
        private void LogoutToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=LOGOUT");
        }
        private void UnlockToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=UNLOCK");
        }
        private void LockToolStrip_Click(object sender, EventArgs e)
        {
            TcpClient client = tcpClients[clientDataId];
            SendToClient(client, "COMM=LOCK");
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Mtx.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                listener.Stop();
                foreach (Thread t in clientThreads)
                    t.Abort();

                foreach(TcpClient c in tcpClients.Values)
                {
                    c.Client.Shutdown(SocketShutdown.Both);
                    c.Client.Dispose();
                    c.Client.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Dispose();
            base.OnFormClosing(e);
        }
        private void Form_station_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            string hostname = Dns.GetHostName();
            IPHostEntry iphost = Dns.Resolve(hostname);
            IPAddress[] addresses = iphost.AddressList;
            StringBuilder addressList = new StringBuilder();
            foreach (IPAddress address in addresses) 
            {
                if (address.ToString().StartsWith("192"))
                {
                    addText("My IP address: " + address);
                    serverIp = address.ToString();
                }
            }

            Text += "  |  " + hostname + "  @  " + serverIp;
            //label2.Text = hostname + " | " + serverIp;

            try
            {
                listener = new TcpListener(IPAddress.Parse(serverIp), serverPort);
                listener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            addText("Waiting for clients to connect...");

            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();

                        Thread thread = new Thread(handle_clients);
                        Config config = new Config();

                        tcpClients.Add(thread.ManagedThreadId, client);
                        cfgClients.Add(thread.ManagedThreadId, config);

                        thread.Start(thread.ManagedThreadId);
                        clientThreads.Add(thread);
                    }
                }
                catch { }
            });
        }

        private void handle_clients(object threadId)
        {
            try
            {
                int clientId = (int)threadId;
                TcpClient tcpClient = tcpClients[clientId];
                Config cfgClient = cfgClients[clientId];
                bool connected = false;
                bool stop = false;

                string remoteEndPoint = tcpClient.Client.RemoteEndPoint.ToString();
                cfgClient.IPADDRESS = remoteEndPoint.Substring(0, remoteEndPoint.IndexOf(":"));
                cfgClient.PORT = remoteEndPoint.Substring(remoteEndPoint.IndexOf(":") + 1);

                byte[] buffer = new byte[4096];
                NetworkStream stream = tcpClient.GetStream();
                
                while (!stop)
                {
                    try
                    {
                        int byte_count = stream.Read(buffer, 0, buffer.Length);
                        stream.Flush();
                        if (byte_count == 0)
                        {
                            addText(tcpClient.Client.RemoteEndPoint + " [" + cfgClient.PCNAME + "]" + " disconnected unexpectedly");
                            stop = true;
                            break;
                        }

                        string clientData = Encoding.ASCII.GetString(buffer, 0, byte_count);
                        List<string> parsedData = clientData.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                        foreach (string data in parsedData)
                        {
                            if (data.Contains("="))
                            {
                                string comm = data.Substring(0, data.IndexOf("="));
                                string value = data.Substring(data.IndexOf("=") + 1);
                                switch (comm.ToUpper())
                                {
                                    case "PC":
                                        {
                                            cfgClient.PCNAME = value;
                                            statusAddRow(threadId, cfgClient.PCNAME, cfgClient.SOFTWARE, cfgClient.IPADDRESS, cfgClient.PORT, "Connect");
                                            break;
                                        }
                                    case "SW":
                                        {
                                            cfgClient.SOFTWARE = value;
                                            break;
                                        }
                                    case "PW":
                                        {
                                            if (value == "K")
                                            {
                                                statusAddRowValue(clientId, iStatus.Button, "Disconnect");
                                                dataAddRow(cfgClient.PCNAME, "", "", "", "", "Settings");
                                                connected = true;
                                                addText("Client " + cfgClient.PCNAME + " added");
                                            }
                                            else
                                            {
                                                addText("Cannot connect to " + cfgClient.PCNAME);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            if (connected) Task.Run(() => ClientDataNegotiate(comm, value, cfgClient));
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (data.ToUpper())
                                {
                                    case "STOP":
                                        {
                                            addText(cfgClient.PCNAME + " disconnected successfully");
                                            stop = true;
                                            break;
                                        }
                                }
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        addText(cfgClient.PCNAME + " : " + e.Message);
                        break;
                    }
                }
                
                dataRemoveRow(cfgClient.PCNAME);
                statusRemoveRow(clientId);
                tcpClients.Remove(clientId);
                cfgClients.Remove(clientId);
                addText(cfgClient.PCNAME + " removed");

                int index = 0;
                for (int i = 0; i < clientThreads.Count(); i++)
                    if (clientThreads[i].ManagedThreadId == clientId) index = i;

                clientThreads.RemoveAt(index);
                tcpClient.Client.Shutdown(SocketShutdown.Both);
                tcpClient.Client.Close();
                tcpClient.Client.Dispose();
            }
            catch (Exception e)
            {
                addText("ERROR : " + e.Message);
            }
        }
        private void ClientDataNegotiate(string comm, string value, Config config)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in clientDataGridView.Rows)
            {
                if (row.Cells[(int)iData.Name].Value.ToString().Equals(config.PCNAME))
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            switch (comm.ToUpper())
            {
                case "CD":
                    {
                        dataAddRowValue(config.PCNAME, iData.Credits, TimeToString(value));
                        break;
                    }
                case "SE":
                    {
                        dataAddRowValue(config.PCNAME, iData.Session, value);
                        break;
                    }
                case "FW":
                    {
                        dataAddRowValue(config.PCNAME, iData.Firmware, value);
                        break;
                    }
                case "LA":
                    {
                        dataAddRowValue(config.PCNAME, iData.LastAction, value);
                        break;
                    }
                case CASE.SD:
                    {
                        config.SHUTDOWN = value;
                        break; 
                    }
                case CASE.HK:
                    {
                        config.HOTKEYCODE = value;
                        break;
                    }
                case CASE.PA:
                    {
                        config.PASSWORD = value;
                        break;
                    }
                case CASE.EM:
                    {
                        config.EMAIL = value;
                        break;
                    }
                case CASE.AT:
                    {
                        config.LOGINATTEMPT = value;
                        break;
                    }
                case CASE.LI:
                    {
                        config.LOCKIMAGE = value;
                        break;
                    }
                case CASE.TM:
                    {
                        config.TIMER = value;
                        break;
                    }
                case CASE.SN:
                    {
                        config.SOUND = value;
                        break;
                    }
                case CASE.SV:
                    {
                        config.SAVEDATA = value;
                        break;
                    }
                case CASE.LG:
                    {
                        config.LOG = value;
                        break;
                    }
                case CASE.SU:
                    {
                        config.STARTUP = value;
                        break;
                    }
                case CASE.TK:
                    {
                        config.TASKMGR = value;
                        break;
                    }
                case CASE.PN:
                    {
                        config.PORTNUMBER = value;
                        break;
                    }
                case CASE.BR:
                    {
                        config.BAUDRATE = value;
                        break;
                    }
                case CASE.CS:
                    {
                        config.COINSLOT = value;
                        break;
                    }
                case CASE.IV:
                    {
                        config.INTERVAL = value;
                        break;
                    }
                case CASE.C1:
                    {
                        config.COIN1 = value;
                        break;
                    }
                case CASE.C2:
                    {
                        config.COIN2 = value;
                        break;
                    }
                case CASE.C3:
                    {
                        config.COIN3 = value;
                        break;
                    }
                case CASE.P1:
                    {
                        config.PULSE1 = value;
                        break;
                    }
                case CASE.P2:
                    {
                        config.PULSE2 = value;
                        break;
                    }
                case CASE.P3:
                    {
                        config.PULSE3 = value;
                        break;
                    }
            }
        }
        private bool SendToClient(TcpClient client, string text)
        {
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(text + ";");
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void statusRemoveRow(int clientId)
        {
            int rowIndex = -1;
            for (int i = 0; i < clientStatusGridView.Rows.Count; i++)
            {
                if ((int)clientStatusGridView.Rows[i].Cells[(int)iStatus.Id].Value == clientId)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == -1) return;

            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() => 
                {
                    this.clientStatusGridView.Rows.RemoveAt(rowIndex);
                    this.clientStatusGridView.ClearSelection();
                }));
            }
            else
            {
                this.clientStatusGridView.Rows.RemoveAt(rowIndex);
                this.clientStatusGridView.ClearSelection();
            }

            clientStatusIndex = -1;
        }
        private void statusAddRow(params object[] values)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() => 
                {
                    this.clientStatusGridView.Rows.Add(values);
                    this.clientStatusGridView.ClearSelection();
                }));
            }
            else
            {
                this.clientStatusGridView.Rows.Add(values);
                this.clientStatusGridView.ClearSelection();
            }
            clientStatusIndex = -1;
        }
        private void statusAddRowValue(int clientId, iStatus cellIndex, string value)
        {
            int index = -1;
            for (int i = 0; i < clientStatusGridView.Rows.Count; i++)
            {
                if ((int)clientStatusGridView.Rows[i].Cells[(int)iStatus.Id].Value == clientId)
                {
                    index = i;
                }
            }

            if (index == -1) return;

            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() => clientStatusGridView.Rows[index].Cells[(int)cellIndex].Value = value));
            }
            else
            {
                clientStatusGridView.Rows[index].Cells[(int)cellIndex].Value = value;
            }

        }
        private void dataRemoveRow(string pcName)
        {
            int rowIndex = -1;
            for (int i=0; i < clientDataGridView.Rows.Count; i++)
            {
                if (clientDataGridView.Rows[i].Cells[(int)iData.Name].Value.ToString() == pcName)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex == -1) return;
            
            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() =>
                {
                    this.clientDataGridView.Rows.RemoveAt(rowIndex);
                    this.clientDataGridView.ClearSelection();
                }));
            }
            else
            {
                this.clientDataGridView.Rows.RemoveAt(rowIndex);
                this.clientDataGridView.ClearSelection();
            }

            clientDataIndex = -1;
        }
        private void dataAddRow(params object[] values)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() =>
                {
                    this.clientDataGridView.Rows.Add(values);
                    this.clientDataGridView.ClearSelection();
                    //this.clientStatusGridView.ClearSelection();
                }));
            }
            else
            {
                this.clientDataGridView.Rows.Add(values);
                this.clientDataGridView.ClearSelection();
                //this.clientStatusGridView.ClearSelection();
            }

            clientDataIndex = -1;
        }
        private void dataAddRowValue(string pcName, iData cellIndex, string value)
        {
            int index = -1;

            for (int i=0; i < clientDataGridView.Rows.Count; i++)
            {
                if ((string)clientDataGridView.Rows[i].Cells[(int)iData.Name].Value == pcName)
                {
                    index = i;
                }
            }

            if (index == -1) return;

            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() => clientDataGridView.Rows[index].Cells[(int)cellIndex].Value = value));
            }
            else
            {
                clientDataGridView.Rows[index].Cells[(int)cellIndex].Value = value;
            }
        }
        private void addText(string text)
        {
            string dateTime = "[" + DateTime.Now.ToString("yyyy-MM-dd") + "][" + DateTime.Now.ToString("hh:mm:ss.fff tt") + "] ";

            if (InvokeRequired)
            {
                this.BeginInvoke((Action)(() =>
                {
                    richTextBox1.AppendText(dateTime + text + "\n");
                    SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
                }));
            }
            else
            {
                richTextBox1.AppendText(dateTime + text + "\n");
                SendMessage(richTextBox1.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
            }
        }
        private void clientStatusGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string pcName = clientStatusGridView.Rows[e.RowIndex].Cells[(int)iStatus.Name].Value.ToString();
                string buttonName = clientStatusGridView.Rows[e.RowIndex].Cells[(int)iStatus.Button].Value.ToString();
                int clientId = (int)clientStatusGridView.Rows[e.RowIndex].Cells[(int)iStatus.Id].Value;

                if (buttonName == "Connect")
                {
                    dialog = new Form_dialog();
                    string password = dialog.ShowDialog(pcName);

                    if (password == string.Empty)
                    {
                        return;
                    }

                    SendToClient(tcpClients[clientId], password);
                    addText("Connecting to " + pcName + "...");
                }
                else
                {
                    DialogResult result = MessageBox.Show(this, "Do you really want to disconnect " + pcName + "?", "Disconnect", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;

                    SendToClient(tcpClients[clientId], "STOP");
                    addText("Disconecting to " + pcName + "...");
                }
            }
        }
        private void clientStatusGridView_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = clientStatusGridView.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow < 0)
            {
                clientStatusGridView.ClearSelection();
                clientStatusIndex = -1;
            }
        }

        private void clientDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Form_settings settings = new Form_settings(cfgClients[clientDataId]);
                settings.ShowDialog(this);
            }
        }
        private void clientDataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = clientDataGridView.HitTest(e.X, e.Y).RowIndex;
            if (currentMouseOverRow >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverColumn = clientDataGridView.HitTest(e.X, e.Y).ColumnIndex;
                    if (currentMouseOverColumn >= 0 && currentMouseOverColumn < 5)
                    {
                        clientDataIndex = currentMouseOverRow;
                        contextMenu.Show(clientDataGridView, new Point(e.X, e.Y));
                    }
                }
            }
            else
            {
                clientDataIndex = -1;
                clientDataGridView.ClearSelection();
                textBoxCom.Clear();
                if (textBoxCom.Enabled)
                    textBoxCom.Enabled = false;

                if (buttonSend.Enabled)
                    buttonSend.Enabled = false;
            }
        }
        private void clientDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 5 )
                {
                    clientDataIndex = e.RowIndex;
                    clientDataGridView.CurrentCell = clientDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    clientDataGridView.Rows[e.RowIndex].Selected = true;
                    clientDataGridView.Focus();

                    if (!textBoxCom.Enabled)
                        textBoxCom.Enabled = true;
                }
                else
                {
                    clientDataIndex = -1;
                    textBoxCom.Clear();
                    if (textBoxCom.Enabled)
                        textBoxCom.Enabled = false;
                }
            }
        }
        private void clientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clientDataIndex = e.RowIndex;
                if (!textBoxCom.Enabled)
                    textBoxCom.Enabled = true;
            }
        }

        private int clientDataId
        {
            get
            {
                string pcName = clientDataGridView.Rows[clientDataIndex].Cells[(int)iData.Name].Value.ToString();
                int rowIndex = -1;
                for (int i = 0; i < clientStatusGridView.Rows.Count; i++)
                {
                    if ((string)clientStatusGridView.Rows[i].Cells[(int)iStatus.Name].Value == pcName)
                    {
                        rowIndex = i;
                        break;
                    }
                }

                return (int)clientStatusGridView.Rows[rowIndex].Cells[(int)iStatus.Id].Value;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Clients: " + tcpClients.Count + " | Threads: " + clientThreads.Count();
        }
        private string TimeToString(string data)
        {
            if (int.TryParse(data, out int time))
            {
                if (time == 0) return "No credits";

                int seconds = time % 60;
                int minutes = (time - time % 60) / 60 % 60;
                int hours = (int)((time - (seconds + minutes * 60)) / (double)3600 % 60);

                return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
            }

            return data;
            
        }
        private void textBoxCom_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxCom.Text)) buttonSend.Enabled = true;
            else buttonSend.Enabled = false;
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendCommand();
        }
        private void textBoxCom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && buttonSend.Enabled == true)
            {
                SendCommand();
            }
        }
        private void SendCommand()
        {
            if (clientDataIndex >= 0)
            {
                List<string> text = textBoxCom.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

                string pcName = clientDataGridView.Rows[clientDataIndex].Cells[(int)iData.Name].Value.ToString();

                int rowIndex = -1;
                for (int i = 0; i < clientStatusGridView.Rows.Count; i++)
                {
                    if ((string)clientStatusGridView.Rows[i].Cells[(int)iStatus.Name].Value == pcName)
                    {
                        rowIndex = i;
                        break;
                    }
                }

                int id = (int)clientStatusGridView.Rows[rowIndex].Cells[(int)iStatus.Id].Value;
                
                TcpClient client = tcpClients[id];
                Config cfg = cfgClients[id];
                
                if (text.Count() > 1)
                {
                    if (!COM.IsValidCom(text[0]))
                    {
                        addText("Invalid " + text[0].ToUpper() + " command.");
                    }
                    else
                    {
                        SendToClient(client, text[0].ToUpper() + "=" + text[1]);
                        if (text[0].ToUpper().Equals(COM.SERIAL))
                            addText("Sent " + text[1].ToUpper() + " serial command to client " + cfg.PCNAME);
                        else if (text[0].ToUpper().Equals(COM.COMM)) 
                            addText("Sent " + text[0].ToUpper() + " command to " + cfg.PCNAME);
                    }
                }
                else
                {
                    if (COM.IsValidCom(text[0])) addText("No value for " + text[0].ToUpper() + " command");
                    else addText("Invalid " + text[0].ToUpper() + " command");
                }
            }
            else 
            {
                addText("Please select a client and try again.");
            }

            textBoxCom.Clear();
            buttonSend.Enabled = false;
        }

        //private void clientStatusGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        clientStatusIndex = e.RowIndex;
        //        var senderGrid = (DataGridView)sender;
        //        if (senderGrid.Rows[e.RowIndex].Cells[(int)iStatus.Button].Value.ToString().Equals("Disconnect"))
        //        {
        //            if (!textBoxCom.Enabled)
        //                textBoxCom.Enabled = true;
        //        }
        //        else
        //        {
        //            if (textBoxCom.Enabled)
        //                textBoxCom.Enabled = false;
        //        }

        //    }
        //}

        //private void clientStatusGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            clientStatusIndex = e.RowIndex;
        //            clientStatusGridView.CurrentCell = clientStatusGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            clientStatusGridView.Rows[e.RowIndex].Selected = true;
        //            clientStatusGridView.Focus();

        //            var senderGrid = (DataGridView)sender;
        //            if (senderGrid.Rows[e.RowIndex].Cells[(int)iStatus.Button].Value.ToString().Equals("Disconnect"))
        //            {
        //                if (!textBoxCom.Enabled)
        //                    textBoxCom.Enabled = true;
        //            }
        //            else
        //            {
        //                if (textBoxCom.Enabled)
        //                    textBoxCom.Enabled = false;
        //            }
        //        }
        //    }
        //}

        //private void clientDataGridView_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        this.BeginInvoke((Action)(() =>
        //        {
        //            clientDataGridView.ClearSelection();
        //        }));
        //    }
        //    else
        //    {
        //        clientDataGridView.ClearSelection();
        //    }
        //}
    }

    public class CASE
    {
        public const string
            SD = "SD",
            HK = "HK",
            PA = "PA",
            EM = "EM",
            AT = "AT",
            LI = "LI",
            TM = "TM",
            SN = "SN",
            SV = "SV",
            LG = "LG",

            SU = "SU",
            TK = "TK",

            PN = "PN",
            BR = "BR",
            CS = "CS",
            IV = "IV",
            C1 = "C1",
            C2 = "C2",
            C3 = "C3",
            P1 = "P1",
            P2 = "P2",
            P3 = "P3";
    }

    public class COM
    {
        public const string
            SERIAL = "SERIAL",
            COMM = "COMM";
            //LOGOUT = "LOGOUT",
            //LOCK = "LOCK",
            //UNLOCK = "UNLOCK",
            //SHUTDOWN = "SHUTDOWN";

        public static bool IsValidCom(string text)
        {
            switch (text.ToUpper())
            {
                case SERIAL: return true;
                case COMM: return true;
                //case LOGOUT: return true;
                //case LOCK: return true;
                //case UNLOCK: return true;
                //case SHUTDOWN: return true;
                default: return false;
            }
        }

    }
}
