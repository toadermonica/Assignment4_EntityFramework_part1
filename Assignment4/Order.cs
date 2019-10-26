using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }

        /// <summary>
        /// Order Detail table is built on Orders; Order.Id is the value of OrdersDetail.OrderId;
        /// </summary>
        public List<OrderDetails> OrderDetails { get; set; }

        /// <summary>
        /// Not needed yet
        /// </summary>
        //public string CustomerId { get; set; }
        //public int EmployeeId { get; set; }
        //public DateTime ShippedDate { get; set; }
        //public int Freight { get; set; }
        //public string ShipAddress { get; set; }
        //public string ShipPostalcode { get; set; }
        //public string ShipCountry { get; set; }

    }
}
