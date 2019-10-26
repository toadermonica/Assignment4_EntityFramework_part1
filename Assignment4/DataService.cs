using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        //public DatabaseContext DB => new DatabaseContext(); when this is here and not inside the functions, the tests won't all pass. Left it here for now. 

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

        public List<Product> GetProductByCategory(int catId)
        {
            using var DB = new DatabaseContext();
            var result = DB.Products
                        .Where(Products => Products.CategoryId == catId)
                        .Include(Products => Products.Category).ToList();

            Console.WriteLine(result);
            return result;
        }

        public List<Product> GetProductByName(string name)
        {
            using var DB = new DatabaseContext();
            var result = DB.Products
                        .Where(product => product.Name.Contains(name)).ToList();
            return result;
        }
        public List<Order> GetOrders()
        {
            using var DB = new DatabaseContext();
            return DB.Orders.ToList(); // this call works for Products but not Orders and I dont know why. 
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

       

    }
}
