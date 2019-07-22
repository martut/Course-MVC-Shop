using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProducerId { get; set; }
        public DateTime DateAdded { get; set; }
        public string ProductCoverFileName { get; set; }
        public decimal Price { get; set; }
        public bool IsHidden { get; set; }
        public bool IsBestseller { get; set; }

        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }

    }
}