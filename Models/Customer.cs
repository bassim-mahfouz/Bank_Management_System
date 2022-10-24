using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(20)]
        public String LastName { get; set; }
        
        [Required]
        [RegularExpression("^([0-9]{8})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)).+$", ErrorMessage = "Password should contain numbers, symbols, and characters")]
        [MaxLength(128)]
        public string Password { get; set; }

        public List<Loan> Loans { get; set; }

        public Account PersonalAccount{get;set;}

        
    }
}
