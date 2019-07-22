using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerShortName { get; set; }
        public string ProducerName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}