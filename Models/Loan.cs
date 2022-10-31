using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Management_System.Models
{
    public class Loan
    {
        [Key]
        public int LoanId{get;set;}

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public float Amount{get;set;}

        [Required]
        public float PaidAmount{get;set;}

        public string LoanDate {get;set;}

        [Required]
        public string  Currency{get;set;}

        public string LastPaidInstallment {get;set;}

        [Required]
        public string LoanDeadline {get;set;}

        [Required]
        public int AmountPaidPerInstallment {get;set;}
        
        public List<PaidInstallment> PaidInstallments { get; set; }

        }
        
}
