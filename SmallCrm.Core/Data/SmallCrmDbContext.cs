﻿using Microsoft.EntityFrameworkCore;
using SmallCrm.Core.Model;

namespace SmallCrm.Core.Data
{
    public class SmallCrmDbContext : DbContext
    {

        private readonly string connectionString_;

        public SmallCrmDbContext():base()
        {
            //conectionString_ = "Server=localhost;Database=SmallCrm;Integrated Security=True)";
            connectionString_ = "Server=localhost;Database=smallcrm;User Id=sa;Password=QWE123!@#";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString_);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Product>().
                ToTable("Product");

            modelBuilder.
                Entity<Customer>().
                ToTable("Customer");

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.VatNumber)
                .HasMaxLength(9)
                .IsRequired();

            modelBuilder
                .Entity<Customer>()
                .HasIndex(c => c.VatNumber)
                .IsUnique();


            modelBuilder.
                Entity<Order>().
                ToTable("Order");

            modelBuilder.
                Entity<ContactPerson>().
                ToTable("ContactPerson");

            modelBuilder.
                Entity<OrderProduct>().
                HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}
