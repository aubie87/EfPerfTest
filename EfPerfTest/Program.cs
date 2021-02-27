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
            
            Console.WriteLine("Hello World! ");

            IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-17)},
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-19)},
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-21)}
            };

            Console.WriteLine("Save to: MySqlEf6Repository");

            //Console.WriteLine("Save to: SQLiteEf6Repository");
            //new SQLiteEf6Repository().SaveOncePerCustomer(customers);

            Console.WriteLine("End of the World!");
        }
    }
}
