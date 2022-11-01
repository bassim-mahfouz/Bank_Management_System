using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Account
    {
        [Key]
        public int AccountId{get;set;}

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [Required]
        public float Amount{get;set;}

        public string CreationDate {get;set;}

        [Required]
        public string  Currency{get;set;}


        public List<Transaction> Transactions { get; set; }
        
        }
}
