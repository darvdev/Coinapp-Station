using Firebase.Auth;
using System;
using System.Net;

namespace CoinappStation
{
    public class Brain
    {
        public static Form_station form_station;
        
        public static bool InternetAvailable
        {
            get
            {
                try
                {
                    WebClientEx client = new WebClientEx(5000);
                    client.OpenRead("https://www.google.com");
                    client.Dispose();
                    return true;
                }
                catch { }
                return false;
            }
        }
    }

    class WebClientEx : WebClient
    {
        public int Timeout { get; set; }

        public WebClientEx(int timeOut)
        {
            Timeout = timeOut;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    }
}
