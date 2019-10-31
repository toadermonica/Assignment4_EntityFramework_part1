using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DatabaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /// These tests run very slow against this remote connection and some are passing and some are not. 
            /// Suggestion, first try the test against localhost and see them passing
            string ConnRemote = "host=mazeet.ddns.net;port=32999;db=northwind;uid=raw6;pwd=J8cxYN";
            string ConnLocal = "host=localhost;db=northwind;uid=postgres;pwd=//addpass"; 
            optionsBuilder.UseNpgsql(connectionString: ConnRemote);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

       /// <summary>
       /// Kept the manual way of mapping instead of AutoMapper
       /// </summary>
       /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");

            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(o => o.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");

            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(od => od.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(od => od.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(od => od.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(od => od.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(od => od.Discount).HasColumnName("discount");
            //Composite key definition for the two FK from OrderDetails in DB
            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.OrderId, od.ProductId });          

        }
       
    }
}
