using System;
using System.ComponentModel.DataAnnotations;

namespace AppCrud.ViewModel
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Date { get;  set; }
        [Phone(ErrorMessage = "You have to enter a valid phone")]
        public string Phone { get; set; } 
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "You have to enter a valid email address")]
        public string Email { get; set; } 
    }
}
