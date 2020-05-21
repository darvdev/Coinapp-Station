namespace CoinappStation
{
    partial class Form_station
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_station));
            this.clientStatusGridView = new System.Windows.Forms.DataGridView();
            this.clientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientSoftwareVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.clientDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDeviceVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientCredits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientLastAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxCom = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.clientStatusGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientStatusGridView
            // 
            this.clientStatusGridView.AllowUserToAddRows = false;
            this.clientStatusGridView.AllowUserToDeleteRows = false;
            this.clientStatusGridView.AllowUserToResizeColumns = false;
            this.clientStatusGridView.AllowUserToResizeRows = false;
            this.clientStatusGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.clientStatusGridView.ColumnHeadersHeight = 28;
            this.clientStatusGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.clientStatusGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientId,
            this.clientName,
            this.clientSoftwareVersion,
            this.clientIp,
            this.clientPort,
            this.clientButton});
            this.clientStatusGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientStatusGridView.Location = new System.Drawing.Point(15, 5);
            this.clientStatusGridView.MultiSelect = false;
            this.clientStatusGridView.Name = "clientStatusGridView";
            this.clientStatusGridView.ReadOnly = true;
            this.clientStatusGridView.RowHeadersVisible = false;
            this.clientStatusGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clientStatusGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientStatusGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientStatusGridView.Size = new System.Drawing.Size(598, 131);
            this.clientStatusGridView.TabIndex = 3;
            this.clientStatusGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientStatusGridView_CellContentClick);
            this.clientStatusGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clientStatusGridView_MouseClick);
            // 
            // clientId
            // 
            this.clientId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientId.DefaultCellStyle = dataGridViewCellStyle1;
            this.clientId.HeaderText = "ID";
            this.clientId.MinimumWidth = 50;
            this.clientId.Name = "clientId";
            this.clientId.ReadOnly = true;
            this.clientId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientId.Width = 50;
            // 
            // clientName
            // 
            this.clientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clientName.HeaderText = "Name";
            this.clientName.MinimumWidth = 100;
            this.clientName.Name = "clientName";
            this.clientName.ReadOnly = true;
            this.clientName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clientSoftwareVersion
            // 
            this.clientSoftwareVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientSoftwareVersion.DefaultCellStyle = dataGridViewCellStyle2;
            this.clientSoftwareVersion.HeaderText = "Software";
            this.clientSoftwareVersion.MinimumWidth = 80;
            this.clientSoftwareVersion.Name = "clientSoftwareVersion";
            this.clientSoftwareVersion.ReadOnly = true;
            this.clientSoftwareVersion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientSoftwareVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientSoftwareVersion.Width = 80;
            // 
            // clientIp
            // 
            this.clientIp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clientIp.HeaderText = "IP Address";
            this.clientIp.MinimumWidth = 110;
            this.clientIp.Name = "clientIp";
            this.clientIp.ReadOnly = true;
            this.clientIp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientIp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientIp.Width = 110;
            // 
            // clientPort
            // 
            this.clientPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clientPort.FillWeight = 50F;
            this.clientPort.HeaderText = "Port";
            this.clientPort.MinimumWidth = 50;
            this.clientPort.Name = "clientPort";
            this.clientPort.ReadOnly = true;
            this.clientPort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientPort.Width = 50;
            // 
            // clientButton
            // 
            this.clientButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clientButton.HeaderText = "";
            this.clientButton.MinimumWidth = 80;
            this.clientButton.Name = "clientButton";
            this.clientButton.ReadOnly = true;
            this.clientButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientButton.Text = "";
            this.clientButton.Width = 80;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(15, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(598, 32);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // clientDataGridView
            // 
            this.clientDataGridView.AllowUserToAddRows = false;
            this.clientDataGridView.AllowUserToDeleteRows = false;
            this.clientDataGridView.AllowUserToResizeColumns = false;
            this.clientDataGridView.AllowUserToResizeRows = false;
            this.clientDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.clientDataGridView.ColumnHeadersHeight = 28;
            this.clientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.clientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clientDeviceVersion,
            this.clientCredits,
            this.clientSession,
            this.clientLastAction,
            this.clientDataButton});
            this.clientDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientDataGridView.Location = new System.Drawing.Point(15, 5);
            this.clientDataGridView.MultiSelect = false;
            this.clientDataGridView.Name = "clientDataGridView";
            this.clientDataGridView.ReadOnly = true;
            this.clientDataGridView.RowHeadersVisible = false;
            this.clientDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clientDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientDataGridView.ShowEditingIcon = false;
            this.clientDataGridView.Size = new System.Drawing.Size(598, 177);
            this.clientDataGridView.TabIndex = 3;
            this.clientDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientDataGridView_CellClick);
            this.clientDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientDataGridView_CellContentClick);
            this.clientDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.clientDataGridView_CellMouseDown);
            this.clientDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clientDataGridView_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clientDeviceVersion
            // 
            this.clientDeviceVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientDeviceVersion.DefaultCellStyle = dataGridViewCellStyle3;
            this.clientDeviceVersion.FillWeight = 80F;
            this.clientDeviceVersion.HeaderText = "Firmware";
            this.clientDeviceVersion.MinimumWidth = 80;
            this.clientDeviceVersion.Name = "clientDeviceVersion";
            this.clientDeviceVersion.ReadOnly = true;
            this.clientDeviceVersion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientDeviceVersion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientDeviceVersion.Width = 80;
            // 
            // clientCredits
            // 
            this.clientCredits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientCredits.DefaultCellStyle = dataGridViewCellStyle4;
            this.clientCredits.FillWeight = 80F;
            this.clientCredits.HeaderText = "Credits";
            this.clientCredits.MinimumWidth = 80;
            this.clientCredits.Name = "clientCredits";
            this.clientCredits.ReadOnly = true;
            this.clientCredits.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientCredits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clientCredits.Width = 80;
            // 
            // clientSession
            // 
            this.clientSession.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clientSession.HeaderText = "Session";
            this.clientSession.MinimumWidth = 100;
            this.clientSession.Name = "clientSession";
            this.clientSession.ReadOnly = true;
            this.clientSession.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientSession.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clientLastAction
            // 
            this.clientLastAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clientLastAction.HeaderText = "Last Action";
            this.clientLastAction.MinimumWidth = 100;
            this.clientLastAction.Name = "clientLastAction";
            this.clientLastAction.ReadOnly = true;
            this.clientLastAction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientLastAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clientDataButton
            // 
            this.clientDataButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clientDataButton.HeaderText = "";
            this.clientDataButton.MinimumWidth = 80;
            this.clientDataButton.Name = "clientDataButton";
            this.clientDataButton.ReadOnly = true;
            this.clientDataButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clientDataButton.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(10, 439);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(624, 17);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(133, 12);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.clientDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            this.panel2.Size = new System.Drawing.Size(628, 192);
            this.panel2.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSend, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxCom, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 192);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(628, 30);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // buttonSend
            // 
            this.buttonSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(531, 3);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(82, 24);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxCom
            // 
            this.textBoxCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCom.Enabled = false;
            this.textBoxCom.Location = new System.Drawing.Point(15, 5);
            this.textBoxCom.Margin = new System.Windows.Forms.Padding(15, 5, 15, 0);
            this.textBoxCom.Name = "textBoxCom";
            this.textBoxCom.Size = new System.Drawing.Size(498, 20);
            this.textBoxCom.TabIndex = 1;
            this.textBoxCom.TextChanged += new System.EventHandler(this.textBoxCom_TextChanged);
            this.textBoxCom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCom_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(628, 408);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer2.Size = new System.Drawing.Size(628, 367);
            this.splitContainer2.SplitterDistance = 141;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clientStatusGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.panel1.Size = new System.Drawing.Size(628, 141);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(628, 222);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15, 0, 15, 5);
            this.panel3.Size = new System.Drawing.Size(628, 37);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(634, 461);
            this.tableLayoutPanel4.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(15, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "...";
            // 
            // Form_station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "Form_station";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form_station_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientStatusGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView clientStatusGridView;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView clientDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientSoftwareVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientPort;
        private System.Windows.Forms.DataGridViewButtonColumn clientButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDeviceVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientCredits;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientLastAction;
        private System.Windows.Forms.DataGridViewButtonColumn clientDataButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
    }
}

