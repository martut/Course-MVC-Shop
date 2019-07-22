using SklepKompMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKompMVC.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Bestsellers { get; set; }
        public IEnumerable<Product> NewArrivals { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}