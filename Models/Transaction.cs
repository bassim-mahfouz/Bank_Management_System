using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Transaction  
    {
        [Key]
        public int id{get;set;}

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public float amount{get;set;}

        public string Date {get;set;}

        public int type{get;set;}
    }
}
