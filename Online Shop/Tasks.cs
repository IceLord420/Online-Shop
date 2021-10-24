using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Online_Shop
{
    class Tasks
    {
        private static Stopwatch stopwatch = new Stopwatch();
        
        public static long runSynchronous(List<double> items, int nBuyers, int nSuppliers, int nProducts)
        {
            stopwatch.Restart();

            orderItems(items);
            restockItems(items);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long runParallel(List<double> items, int nBuyers, int nSuppliers, int nProducts)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < nBuyers; i++)
            {
                threads.Add(new Thread(orderItems));
            }
            for (int i = 0; i < nSuppliers; i++)
            {
                threads.Add(new Thread(restockItems));
            }

            stopwatch.Restart();
            foreach (var thread in threads) thread.Start(items);

            foreach (var thread in threads) thread.Join();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static void orderItems(object obj)
        {
            List<double> items = (List<double>)obj;
            for (int i = 0; i < 20; i++)
            {
                double temp = items.Count - 1;
                try
                {
                    items.RemoveAt(items.Count - 1);
                }
                catch (Exception)
                {
                    Console.WriteLine("Nqma kak da se dostapi tozi element");
                    throw;
                }
              
                Console.WriteLine("order item: " + temp);
            }
                
            
        }

        private static void restockItems(object obj)
        {
            List<double> items = (List<double>)obj;
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                items.Add(69420);
                Console.WriteLine("item added: " + items.Count);
            }
        }
    }
}
