using EfPerfTest.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace EfPerfTest.EfCore.Sqlite
{
    public class EfCoreSqliteContext : DbContext
    {
        DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFilename = Path.Combine(dbLocation, "Customers.sqlite3");
            optionsBuilder.UseSqlite($"Data Source={dbFilename}");
        }
    }
}
