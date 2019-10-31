using Assignment4.Models;
using System.Collections.Generic;

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

        List<ProductDto> GetProductByCategory(int catId);
        List<ProductDto> GetProductByName(string name);
  
        List<Order> GetOrders();
        Order GetOrder(int value);
        List<OrderDetails> GetOrderDetailsByOrderId(int id);
        List<OrderDetails> GetOrderDetailsByProductId(int id);
    }
}
