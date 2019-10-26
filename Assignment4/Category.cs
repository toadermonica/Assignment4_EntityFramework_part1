using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Since 1 product can belong to many Categories
        /// Then 1 Category can have many products -> A list of products
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
