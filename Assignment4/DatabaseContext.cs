using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public class DatabaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "host=localhost;db=northwind;uid=postgres;pwd=Pisi2828");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(p=> p.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");


            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("orderid");
           // modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customerid");
            modelBuilder.Entity<Order>().Property(o => o.EmployeeId).HasColumnName("employeeid");
            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(o => o.RequiredDate).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(o => o.ShippedDate).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");

            modelBuilder.Entity<Order>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Id).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Discount).HasColumnName("discount");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
