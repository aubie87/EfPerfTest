using EfPerfTest.Common.Interfaces;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.EfCore.Sqlite
{
    public class EfCoreSqliteRepository : IEfPerfTestRepository
    {
        public void SaveOncePerCustomer(IEnumerable<Customer> customers)
        {
            var context = new EfCoreSqliteContext();
            foreach(var customer in customers)
            {
                Console.WriteLine(customer);
                context.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
