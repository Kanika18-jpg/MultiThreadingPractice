using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace MultiThreadingPractice
{
    internal class Bank
    {
        private static readonly object lockObject = new object();
        private static int balance = 1000;
        public static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(WithDraw));
            Thread t2 = new Thread(new ParameterizedThreadStart(WithDraw));

            t1.Start(300);
            t2.Start(1100);
            t1.Join();
            t2.Join();

            Console.Read();
        }
        static void WithDraw(object num)
        {
            lock (lockObject)
            {
                int withdrawalAmount = (int)num;
                if(balance >= withdrawalAmount)
                {
                    balance -= withdrawalAmount;
                    Console.WriteLine($"Balance : {balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance...");
                }
            }

        }
    }
}
