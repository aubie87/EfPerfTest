using EfPerfTest.Core.Interfaces;
using EfPerfTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfPerfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IList<Customer> customers = new List<Customer>
            {
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-17)}
            };

            IEfPerfTestRepository repo = new MySqlEf6.MySqlEf6Repository();
            repo.Save1PerCustomer(customers);
            
            Console.WriteLine("End of the World!");
        }
    }
}
