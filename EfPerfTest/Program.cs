using EfPerfTest.Common.Models;
using EfPerfTest.EfCore.Sqlite;
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
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-17), Accounts = new List<Account>
                {
                    new Account { AcctNumber="5", AcctType="T", Transactions = new List<Transaction>
                    {
                        new Transaction { TransType = "D", Amount = 1.23m, Date = DateTime.UtcNow },
                        new Transaction { TransType = "D", Amount = 14.23m, Date = DateTime.UtcNow },
                        new Transaction { TransType = "D", Amount = 166.23m, Date = DateTime.UtcNow },
                        new Transaction { TransType = "D", Amount = 1888.23m, Date = DateTime.UtcNow }
                    }},
                }},
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-19)},
                new Customer { Name = Guid.NewGuid().ToString(), Birthday = DateTime.UtcNow.AddYears(-21)}
            };

            new EfCoreSqliteRepository().SaveOncePerCustomer(customers);

            Console.WriteLine("End of the World!");
        }
    }
}
