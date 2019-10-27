using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }    //Might need to be some other type to allow for 4.99
        public int Quantity { get; set; }
        public int Discount { get; set; }    //Same as unitprice ???

        /// <summary>
        /// Tables that have their PK as FK in this OrderDetails table
        /// </summary>
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
