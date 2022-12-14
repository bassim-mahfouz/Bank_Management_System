using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }
       
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)).+$", ErrorMessage = "Password should contain numbers, symbols, and characters")]
        [MaxLength(128)]
        public string Password { get; set; }

        public string LastLoginDate{get;set;}

        public List<EmployeeAction> Actions{get;set;}
    }
}
