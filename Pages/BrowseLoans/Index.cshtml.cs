using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bank_Management_System.Models;
using System.Collections.Generic;
using Bank_Management_System.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bank_Management_System.Pages.BrowseLoans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       public List<Loan> Loans{get;set;}
       public List<String> cssClasses{get;set;}
       
       public LoanRepository _repository{get;set;}
       
       [BindProperty(SupportsGet=true)]
       public int id{get;set;}

       public string cssClass{get;set;}


       public IndexModel(LoanRepository repository)
       {
            _repository=repository;
       }

       public async Task<IActionResult>  OnGet()
        {
            cssClasses=new List<String>(){};
            Loans= await _repository.GetLoans();
            DateTime Today=DateTime.Now;
            
            foreach(var loan in Loans)
            {
                DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
                if(Convert.ToInt16(Today.Date.Subtract(LastPaid).Days)>30)
                {
                    cssClasses.Add("coloring");
                }
                else
                    cssClasses.Add(" ");
            }
            return Page();
        } 

        public async Task<IActionResult>  OnPost()
        {
            cssClasses=new List<String>(){};
            if(id==0)
            {
                Loans= await _repository.GetLoans();
            }
            else{
                Loans= new List<Loan>(){await _repository.GetLoanById(id)};
            }
            DateTime Today=DateTime.Now;
            
            foreach(var loan in Loans)
            {
                DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
                if(Convert.ToInt16(Today.Date.Subtract(LastPaid).Days)>30)
                {
                    cssClasses.Add("coloring");
                }
                else
                    cssClasses.Add(" ");
            }
            return Page();
        } 


    }
    
}
