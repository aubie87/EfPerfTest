using EfPerfTest.Common.Models;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.MySqlEf6
{
    /// <summary>
    /// To enable EF 6 code first migrations
    /// > Enable-Migrations
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlEf6Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MySqlEf6Context()
            : base("server=localhost;database=CustomerEf6;user=root;password=Gillen93!!")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
