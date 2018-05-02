using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace ThriftSpeakClient
{
    public class SpeakListener : SpeakService.Iface
    {
        public static readonly SpeakListener Instance = new SpeakListener();
        private Action<string> MsgArrivedAction;
        public void Start(int port = 10002)
        {
            SpeakService.Processor processor = new SpeakService.Processor(Instance);
            TServerTransport transport = new TServerSocket(port);
            TServer server = new TThreadPoolServer(processor, transport);
            Console.WriteLine("server 10002 starting...");
            server.Serve();
            transport.Close();
        }

        public void MessageArrived(Action<string> msgAct)
        {
            MsgArrivedAction = msgAct;
        }

        public void Speakwords(string msg)
        {
            //Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} client say:{msg}");
            MsgArrivedAction?.BeginInvoke(msg, null, null);
        }
    }
}
