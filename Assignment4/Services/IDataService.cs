using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public interface IDataService
    {
        List<Category> GetCategories();
        Category GetCategory(int value);
        Category CreateCategory(string newCatName, string newCatDescription); 

        bool DeleteCategory(int categoryId);
        bool UpdateCategory(int categoryId, string categoryName, string categoryDescription);
        Product GetProduct(int value);

        List<Product> GetProductByCategory(int catId);
        List<Product> GetProductByName(string name);
  
        List<Order> GetOrders();
        Order GetOrder(int value);
        List<OrderDetails> GetOrderDetailsByOrderId(int id);
        List<OrderDetails> GetOrderDetailsByProductId(int id);
    }
}
