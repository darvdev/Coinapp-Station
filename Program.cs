using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CoinappStation
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, false))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_station());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                Mtx.PostMessage((IntPtr)Mtx.HWND_BROADCAST,Mtx.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
                Mtx.PostMessage((IntPtr)Mtx.HWND_BROADCAST,Mtx.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
                Mtx.PostMessage((IntPtr)Mtx.HWND_BROADCAST,Mtx.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
                Mtx.PostMessage((IntPtr)Mtx.HWND_BROADCAST,Mtx.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
                Mtx.PostMessage((IntPtr)Mtx.HWND_BROADCAST,Mtx.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
            }
        }
    }

    public class Mtx
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }

    public class Config
    {
        public Config(){}

        public string ID { get; set; }
        public string PCNAME { get; set; }
        public string IPADDRESS { get; set; }
        public string PORT { get; set; }
        public string SOFTWARE { get; set; }
        public string FIRMWARE { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string STARTUP { get; set; }
        public string TASKMGR { get; set; }
        public string PORTNUMBER { get; set; }
        public string BAUDRATE { get; set; }
        public string COINSLOT { get; set; }
        public string COIN1 { get; set; }
        public string COIN2 { get; set; }
        public string COIN3 { get; set; }
        public string PULSE1 { get; set; }
        public string PULSE2 { get; set; }
        public string PULSE3 { get; set; }
        public string SHUTDOWN { get; set; }
        public string LOGINATTEMPT { get; set; }
        public string HOTKEYCODE { get; set; }
        public string TIMER { get; set; }
        public string SOUND { get; set; }
        public string INTERVAL { get; set; }
        public string SAVEDATA { get; set; }
        public string LOCKIMAGE { get; set; }
        public string LOG { get; set; }
    }

}
