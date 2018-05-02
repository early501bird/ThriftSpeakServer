using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftSpeakServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeakListener.Instance.MessageArrived(RecvMessage);
            SpeakListener.Instance.Start();

            Console.ReadKey();
        }

        static void RecvMessage(string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} client say:{msg}");
            SpeakSender.Say("server feedback msg:" + msg);
        }

    }
}
