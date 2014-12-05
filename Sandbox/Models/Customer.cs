using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandbox.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
         [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
         [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
         [Display(Name = "Title")]
        public string ContactTitle { get; set; }      
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
           [Display(Name = "Postcode")]
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}