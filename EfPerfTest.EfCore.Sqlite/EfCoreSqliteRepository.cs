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
        private readonly string dbFilename;

        public EfCoreSqliteRepository(string dbFilename)
        {
            this.dbFilename = dbFilename;
        }

        public void SaveAllAtOnce(IEnumerable<Customer> customers)
        {
            EfCoreSqliteContext context = CreateContext();
            context.AddRange(customers);
            context.SaveChanges();
        }

        public void SaveOncePerCustomer(IEnumerable<Customer> customers)
        {
            EfCoreSqliteContext context = CreateContext();
            foreach(var customer in customers)
            {
                context.Add(customer);
                context.SaveChanges();
            }
        }

        private EfCoreSqliteContext CreateContext()
        {
            var context = new EfCoreSqliteContext(dbFilename);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
