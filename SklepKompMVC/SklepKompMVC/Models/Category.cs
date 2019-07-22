using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CatIconFileName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}