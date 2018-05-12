using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace TTTF_TimeTravel_0._9._0
{
    class Client
    {
        public static SimpleTCP.SimpleTcpClient client;

        public static void start(string ip)
        {
            client = new SimpleTCP.SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += clientData;
            client.Connect(ip, 10757);
            client.WriteLineAndGetReply("Send all peds", new TimeSpan(0, 0, 20));
        }

        private static void clientData(object sender, Message e)
        {
            
        }
    }
}
