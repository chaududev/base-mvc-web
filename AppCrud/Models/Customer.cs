using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AppCrud.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; private set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; private set; } 
        public DateTime Birthday { get; private set; }
        public DateTime Date { get; private set; } 
        [MaxLength(20)]
        [Phone(ErrorMessage = "You have to enter a valid phone")]
        public string Phone { get; private set; } 
        [MaxLength(100)]
        public string Address { get; private set; } 
        [EmailAddress(ErrorMessage = "You have to enter a valid email address")]
        [MaxLength(100)]
        public string Email { get; private set; } 

        public Customer(string fullName, DateTime birthday, DateTime date, string phone, string address, string email)
        {
            Update(fullName, birthday, date, phone, address, email);
        }
        public void Update(string fullName, DateTime birthday, DateTime date, string phone, string address, string email)
        {
            FullName = fullName.Trim();
            Birthday = birthday;
            Date = date;
            Phone = phone.Trim();
            Address = address.Trim();
            Email = email.Trim();
        }

        public Customer()
        {
        }
    }
}
