using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Deposite
    {

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public float amount{get;set;}

        public string Date {get;set;}
        }
}
