using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bank_Management_System.Models;
using Bank_Management_System.Repositories;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Pages.BrowseLoans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class DetailsModel : PageModel
    {
        public LoanRepository _repository{get;set;}

        
        [BindProperty(SupportsGet=true)]
        public int id{get;set;}


        [BindProperty]
        public int dateDifference {get;set;}
        
        [BindProperty]
        public Loan loan{get;set;}
        
        public DetailsModel(LoanRepository repository)
        {
            _repository=repository;
        }

       public async Task<IActionResult> OnGet()
        {
            loan=await _repository.GetLoanById(id);
            DateTime Today=DateTime.Now;
            DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
            dateDifference=Convert.ToInt16(Today.Date.Subtract(LastPaid).Days);
            loan.PaidInstallments=await _repository.GetPaidInstallmentsByLoanId(id);
            return Page();
        }

 
    


    }
    
}
