using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MultiThreadingPractice
{
    internal class Program
    {
        private static readonly object lockObject = new object();
        private static int count = 1;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintNumbers);
            Thread t2 = new Thread(PrintNumbers);

            t1.Name = "1";
            t2.Name = "2";


            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            Console.Read();
                
        }
        static void PrintNumbers()
        {
            while (count <= 10)
            {
                lock (lockObject) // Lock to prevent interleaving
                {
                    if (count <= 10)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {count}");
                        count++;
                    }
                }
            }
        }
    }
}
