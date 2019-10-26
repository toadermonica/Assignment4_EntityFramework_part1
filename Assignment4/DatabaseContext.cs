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


        //there is a way to make Entity map automatically and it could work here 
        //but on larger projects it is better to manually map things. 
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
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(o => o.RequiredDate).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(o => o.ShippedDate).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");
            //modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("customerid");
            //modelBuilder.Entity<Order>().Property(o => o.EmployeeId).HasColumnName("employeeid");
            //modelBuilder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
            //modelBuilder.Entity<Order>().Property(o => o.ShipAddress).HasColumnName("shipaddress");
            //modelBuilder.Entity<Order>().Property(o => o.ShipPostalcode).HasColumnName("shippostalcode");
            //modelBuilder.Entity<Order>().Property(o => o.ShipCountry).HasColumnName("shipcountry");

            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(o => o.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().HasKey(o => new { o.ProductId, o.OrderId });            // FK constraints

            modelBuilder.Entity<Employees>().ToTable("employees");
            modelBuilder.Entity<Employees>().Property(e => e.ID).HasColumnName("employeeid");
            modelBuilder.Entity<Employees>().Property(e => e.LastName).HasColumnName("lastname");
            modelBuilder.Entity<Employees>().Property(e => e.FirstName).HasColumnName("firstname");
            modelBuilder.Entity<Employees>().Property(e => e.Title).HasColumnName("title");
            modelBuilder.Entity<Employees>().Property(e => e.BirthDate).HasColumnName("birthdate");
            modelBuilder.Entity<Employees>().Property(e => e.HireDate).HasColumnName("hiredate");
            modelBuilder.Entity<Employees>().Property(e => e.Address).HasColumnName("address");
            modelBuilder.Entity<Employees>().Property(e => e.City).HasColumnName("city");
            modelBuilder.Entity<Employees>().Property(e => e.PostalCode).HasColumnName("postalcode");
            modelBuilder.Entity<Employees>().Property(e => e.Country).HasColumnName("country");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}
