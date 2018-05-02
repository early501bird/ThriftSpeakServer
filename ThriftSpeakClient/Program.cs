using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftSpeakClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeakListener.Instance.MessageArrived(RecvMessage);
            Task.Run(() => { SpeakListener.Instance.Start(); });
            LoopSpeak();
            Console.ReadKey();
        }

        private static void LoopSpeak()
        {
            while (true)
            {
                try
                {
                    var msg = Console.ReadLine();
                    SpeakSender.Say(msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("speak error:" + ex.StackTrace);
                }
            }
        }

        static void RecvMessage(string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} server say:{msg}");
            Console.WriteLine("client can say something:");
        }
    }
}
