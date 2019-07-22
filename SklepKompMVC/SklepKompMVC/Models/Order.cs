using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserDataId { get; set; }

        public string OrderHistoryId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string AddresCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItem { get; set; }

    }
    public enum OrderState
    {
        New,
        Processing,
        Shipped

    }
}