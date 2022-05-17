using System.Text.RegularExpressions;

namespace LemmanaClient.API
{
    class URL
    {
                                                        // serverURL : https://api.lemmana.com:8080/console/signin
        public string protocol;                         // https
        public string serverAddress;                    // api.lemmana.com
        public string port;                             // 8080 (if present)
        public string serverURL;                        // https://api.lemmana.com:8080
        public string fullServerURL;                    // https://api.lemmana.com:8080/console/signin
        public string serverURLNoPort;                  // https://api.lemmana.com

        public URL(string serverURL)
        {
            //Console.Out.WriteLine("Building Server URL : " + serverURL);

            this.fullServerURL = serverURL;
            this.protocol = getStringFromURL("[^:]+(?=:\\/\\/)", serverURL);
            this.serverAddress = getStringFromURL("[\\/][\\/][0-9A-Za-z.]*", serverURL).Replace("/", "");
            this.port = getStringFromURL("(?:\\:\\d{2,4})", serverURL).Replace(":", "");
            this.serverURL = protocol + "://" + serverAddress + ":" + port;
            this.serverURLNoPort = protocol + "://" + serverAddress;

            //Console.Out.WriteLine("  > protocol        : " + this.protocol);
            //Console.Out.WriteLine("  > serverAddress   : " + this.serverAddress);
            //Console.Out.WriteLine("  > port            : " + this.port);
            //Console.Out.WriteLine("  > serverURL       : " + this.serverURL);
            //Console.Out.WriteLine("  > fullServerURL   : " + this.fullServerURL);
            //Console.Out.WriteLine("  > serverURLNoPort : " + this.serverURLNoPort);
        }

        private string getStringFromURL(string regex, string searchString)
        {
            Regex regexObj = new Regex(@regex);
            Match match = regexObj.Match(searchString);

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }
    }
}
