using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    public class Order
    {
        public int Id { get; set; }
       // public string CustomerId { get; set; }
        public int EmployeeId { get; set; }

        //public DateTime OrderDate { get; set; }
        //[Column("orderdate")]
        public DateTime Date { get; set; }

        public DateTime RequiredDate { get; set; }
        [Column("requireddate")]
        public DateTime Required { get; set; }

        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalcode { get; set; }
        public string ShipCountry { get; set; }


        public List<OrderDetails> OrderDetails { get; set; }

    }
}
