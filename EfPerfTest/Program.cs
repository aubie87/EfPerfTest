using Bogus;
using EfPerfTest.Common.Models;
using EfPerfTest.EfCore.Sqlite;
using EfPerfTest.Source;
using EfPerfTest.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var timer = Stopwatch.StartNew();

            var fake = new Fake();

            int customerCount = 8500;
            int batches = 10;
            Console.WriteLine($"Loading {customerCount*batches}");
            Console.WriteLine();

            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // 1,000 to 10+ minutes
            // new EfCoreSqliteRepository().SaveOncePerCustomer(fake.LoadCustomers(customerCount * batches));

            // 1,000 - 21 seconds
            // 4,000 - 1:26
            // 10,000 - 3:04
            //new EfCoreSqliteRepository(Path.Combine(myDocuments, "Customers.sqlite3"))
            //    .SaveAllAtOnce(fake.LoadCustomers(customerCount * batches));

            // 10 * 100 - 22 seconds
            // 10 * 400 - 1:16
            // 10 * 1000 - 3:11
            //var repo = new EfCoreSqliteRepository();
            //for (int i = 0; i < batches; i++)
            //{
            //    Console.WriteLine($"Saving batch {i}");
            //    repo.SaveAllAtOnce(fake.LoadCustomers(customerCount));        
            //}

            new XmlSaveRepository(Path.Combine(myDocuments, "Customers_85000.xml"))
                .SaveAllAtOnce(fake.LoadCustomers(customerCount * batches));

            Console.WriteLine();
            Console.WriteLine("Loading took: " + timer.Elapsed);
        }
    }
}
