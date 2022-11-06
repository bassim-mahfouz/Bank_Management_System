using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class EmployeeAction  
    {
        [Key]
        public int id{get;set;}

        [ForeignKey("Employee")]
        public string EmployeeName { get; set; }
        public Employee Employee { get; set; }

        public int type{get;set;}

        public int ActionId{get;set;}

        public string Date {get;set;}

    }
}
