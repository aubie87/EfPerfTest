﻿using EfPerfTest.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace EfPerfTest.EfCore.Sqlite
{
    public class EfCoreSqliteContext : DbContext
    {
        private readonly string _dbFilename;

        public DbSet<Customer> Customers => Set<Customer>();

        public EfCoreSqliteContext(string dbFilename)
        {
            _dbFilename = dbFilename;
            //SavingChanges += SavingChangesHandler;
        }

        //private void SavingChangesHandler(object sender, SavingChangesEventArgs e)
        //{
        //    Console.WriteLine("SavingChangesHandler");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Data Source={_dbFilename}")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            //modelBuilder.Entity<Customer>()
            //    .Property(p => p.Name)
            //    .IsRequired();

            //modelBuilder.Entity<Account>()
            //    .Property(p => p.AcctNumber)
            //    .IsRequired();

            //modelBuilder.Entity<Transaction>()
            //    .Property(p => p.TransType)
            //    .IsRequired();
        }
    }
}
