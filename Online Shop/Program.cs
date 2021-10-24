using System;
using System.Collections.Generic;

namespace Online_Shop
{
    class Program
    {
        public static int nBuyers, nSuppliers, nProducts;
        static void Main(string[] args)
        {
            nBuyers = 100;
            nSuppliers = 5;
            nProducts = 20;

            List<double> items = new List<double>();

            for (int i = 0; i < 100000; i++)
            {
                Random temp = new Random();
                items.Add(temp.Next(10000));
            }


            long time1 = Tasks.runSynchronous(items, nBuyers, nSuppliers, nProducts);
            long time2 = Tasks.runParallel(items, nBuyers, nSuppliers, nProducts);


            Console.WriteLine($"synchronous tasks: {time1}");
            Console.WriteLine($"parallel tasks: {time2}");



            Console.ReadLine();
        }
    }
}
