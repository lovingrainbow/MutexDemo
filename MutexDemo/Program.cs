using System;
using System.Threading;
using System.Threading.Tasks;

namespace MutexDemo
{
    class Program
    {
        static int seq = 0;
        static Mutex mut = new Mutex();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    MThread();
                });
            }
            Console.Read();
        }
        static void MThread()
        {
            int seqId = ++seq;
            //進入保護區間
            mut.WaitOne();
            Console.WriteLine(seqId + "進入MThread Mutex.");

            Thread.Sleep(100);

            Console.WriteLine(seqId + "離開MThread Mutex.");
            //離開保護區間
            mut.ReleaseMutex();
        }
    }
}
