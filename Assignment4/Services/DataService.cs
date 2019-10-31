using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService : IDataService
    {
        public List<Category> GetCategories()
        {
            using var DB = new DatabaseContext();
            return DB.Categories.ToList();
        }
        public Category GetCategory(int value)
        {
            using var DB = new DatabaseContext();
            return DB.Categories.Find(value);
        }
      
        public Category CreateCategory(string newCatName, string newCatDescription)
        {
            using var DB = new DatabaseContext();
            var nextId = DB.Categories.Max(x => x.Id) + 1;
            var newCategory = new Category
            {
                Id = nextId,
                Name = newCatName,
                Description = newCatDescription
            };
            DB.Categories.Add(newCategory);
            DB.SaveChanges();
            return GetCategory(newCategory.Id);
        }

        public bool DeleteCategory(int categoryId)
        {
            using var DB = new DatabaseContext();
            try
            {
                var itemToDelete = GetCategory(categoryId);
                DB.Categories.Remove(itemToDelete);
                DB.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public bool UpdateCategory(int categoryId, string categoryName, string categoryDescription)
        {
            using var DB = new DatabaseContext();
            try
            {
                var catToUpdate = DB.Categories.Find(categoryId);
                catToUpdate.Name = categoryName;
                catToUpdate.Description = categoryDescription;
                DB.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
           
        }
        public Product GetProduct(int value)
        {
            using var DB = new DatabaseContext();
            var result = DB.Products.Where(product => product.Id == value).Include(product => product.Category).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// This test makes use of ProductDto
        /// The assigned unit test expects CategoryName instead of Name for Category
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public List<ProductDto> GetProductByCategory(int catId)
        {
            using var DB = new DatabaseContext();
            var result = DB.Products
                        .Where(Products => Products.CategoryId == catId)
                        .Include(Products => Products.Category)
                        .Select(x => new ProductDto()
                        {
                            Name = x.Name,
                            CategoryName = x.Category.Name
                        })
                        .ToList();
            return result;
        }

        /// <summary>
        /// This method makes use of the new instance of ProductDto
        /// The test expects both ProductName and Name from the same list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ProductDto> GetProductByName(string name)
        {
            using var DB = new DatabaseContext();
            var result = DB.Products
                        .Where(p => p.Name.Contains(name))
                        .Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            ProductName = p.Name
                        })
                        .ToList();
            return result;
        }
        public List<Order> GetOrders()
        {
            using var DB = new DatabaseContext();
            return DB.Orders.ToList();
        }

        public Order GetOrder(int value)
        {
            using var DB = new DatabaseContext();

            var results = DB.Orders
                .Where(m => m.Id == value)
                .Include(m => m.OrderDetails)
                .ThenInclude(m => m.Product)
                .ThenInclude(m => m.Category)
                .FirstOrDefault();
            return results;
        }
 
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using var db = new DatabaseContext();
            return db.OrderDetails
            .Where(m => m.OrderId == id)
            .Include(m => m.Product)
            .ToList();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using var db = new DatabaseContext();
            return db.OrderDetails
            .Where(m => m.ProductId == id)
            .Include(m => m.Order)
            .ToList();
        }

    }
}

