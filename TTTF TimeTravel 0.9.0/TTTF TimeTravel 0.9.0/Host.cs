using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace TTTF_TimeTravel_0._9._0
{
    class Host
    {

        static SimpleTCP.SimpleTcpServer server = new SimpleTCP.SimpleTcpServer();
        //static bool sendpeds = true;
        public static void Start_server(string port)
        {
            server.DataReceived += server_data;
            server.Start(int.Parse(port));
        }

        private static void server_data(object sender, Message e)
        {
            if (e.MessageString == "Send all peds")
            {

            }
        }

        public static void gametick()
        {

        }
    }
}
