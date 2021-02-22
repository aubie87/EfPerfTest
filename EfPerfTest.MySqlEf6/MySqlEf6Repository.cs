using EfPerfTest.Common.Interfaces;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.MySqlEf6
{
    public class MySqlEf6Repository : IEfPerfTestRepository
    {
        /// <summary>
        /// This should be the worst performing option of any.
        /// </summary>
        /// <param name="customers"></param>
        public void SaveOncePerCustomer(IEnumerable<Customer> customers)
        {
            using var context = new MySqlEf6Context();
            
            // pre-migration testing
            context.Database.CreateIfNotExists();

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
