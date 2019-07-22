using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Models
{
    public class UserData
    {
        [Key]
        public string UserDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string AddresCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}