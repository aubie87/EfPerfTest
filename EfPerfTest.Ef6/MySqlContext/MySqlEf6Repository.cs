using EfPerfTest.Common.Interfaces;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace EfPerfTest.Ef6.MySqlContext
{
    public class MySqlEf6Repository : IEfPerfTestRepository
    {
        /// <summary>
        /// This should be the worst performing option of any.
        /// </summary>
        /// <param name="customers"></param>
        public void SaveOncePerCustomer(IEnumerable<Customer> customers)
        {
            using var context = new MySqlContext();
            
            // pre-migration testing
            // context.Database.CreateIfNotExists();

            foreach (var customer in customers)
            {
                WriteLine("Saving " + customer);
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
