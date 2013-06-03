using System;
using System.Collections.Generic;

namespace ManualRefactoring.ClassLibrary
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new List<Order>();
        }

        public void PrintOwing()
        {
            decimal outstanding = 0.0m;

            // print banner
            Console.WriteLine("**************************");
            Console.WriteLine("***** Customer Owes ******");
            Console.WriteLine("**************************");

            // calculate outstanding
            foreach (var order in this.Orders)
            {
                outstanding += order.Amount;
            }

            //print details
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Amount:" + outstanding);
        }
    }
}
