using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class PaidInstallment
    {

        [ForeignKey("Loan")]
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
        [Required]
        public float amount{get;set;}
        [Required]
        public string PaymentDate {get;set;}
        }
}