using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftSpeakClient
{
    public class SpeakSender
    {
        static TTransport transport;
        public static void Say(string msg, int port = 10001, string ip = "127.0.0.1")
        {
            try
            {
                transport = new TSocket(ip, port);
                TProtocol protocol = new TBinaryProtocol(transport);
                SpeakService.Client client = new SpeakService.Client(protocol);
                transport.Open();
                client.Speakwords(msg);
            }
            catch (TApplicationException ex)
            {
                Console.WriteLine("client say error,stack:" + ex.StackTrace);
            }
            finally
            {
                transport.Close();
            }
        }
    }
}
