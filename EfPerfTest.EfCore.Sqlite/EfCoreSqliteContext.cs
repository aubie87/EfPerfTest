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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(p => p.AcctNumber)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(p => p.TransType)
                .IsRequired();
        }
    }
}
