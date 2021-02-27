using EfPerfTest.Common.Models;
using EfPerfTest.Ef6.Configuration;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Ef6.MySqlContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MySqlContext()
            //: base("server=localhost;database=CustomerEf6;user=root;password=Gillen93!!")
            : base(new MySqlConnection("server=localhost;database=CustomerEf6;user=root;password=Gillen93!!"), true)
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
