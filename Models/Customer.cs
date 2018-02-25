using System;
using System.ComponentModel.DataAnnotations;

namespace RazorWebApp.Models
{
    public class Customer
    {
        public int Id
        {
            get;
            set;
        }

        [Required, StringLength(10)]
        public string Name
        {
            get;
            set;
        }

        public Customer()
        {
        }
    }
}
