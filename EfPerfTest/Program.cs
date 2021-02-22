using EfPerfTest.Common.Interfaces;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfPerfTest
{
    /// <summary>
    /// By design - this project should have NO dependencies on any EntityFramework 
    /// library. The only dependencies should be on common Interfaces and the classes
    /// that implement them.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-17)}
            };

            IEfPerfTestRepository repo = new MySqlEf6.MySqlEf6Repository();
            repo.SaveOncePerCustomer(customers);
            
            Console.WriteLine("End of the World!");
        }
    }
}
