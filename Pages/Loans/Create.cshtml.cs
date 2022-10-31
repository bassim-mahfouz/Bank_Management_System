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
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Bank_Management_System.Pages.Loans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class CreateModel : PageModel
    {
        public CustomerRepository _repository{get;set;}

        [BindProperty(SupportsGet=true)]
        public int id{get;set;}

        [BindProperty]
        public int duration{get;set;}
        
        [BindProperty]
        public int click{get;set;}

        [BindProperty]
        public Loan loan{get;set;}


        public List<SelectListItem> correncyList  {get;set;}

        public CreateModel(CustomerRepository repository)
        {
            _repository=repository;
        }  
       
       public async Task<IActionResult> OnGet()
        {
            correncyList = new()
            {
                new SelectListItem { Value = "LB", Text = "LB (not recomended)" , Selected = true},
                new SelectListItem { Value = "USD", Text = "USD" },
                new SelectListItem { Value = "EURO", Text = "EURO" },
            };
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(){
            
            correncyList = new()
            {
                new SelectListItem { Value = "LB", Text = "LB (not recomended)" , Selected = true},
                new SelectListItem { Value = "USD", Text = "USD" },
                new SelectListItem { Value = "EURO", Text = "EURO" },
            };

            if(loan.Amount<=0)
            {
                 ModelState.AddModelError("", "The DeadLine Date should be greater then current day ");
                 return Page();
            }
            if(loan.AmountPaidPerInstallment<=0)
            {
                ModelState.AddModelError("", "The amount paid per installement should be greater than 0");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }


            Customer customer=await _repository.GetCustomerById(id);
            DateTime localDate = DateTime.Now;

            loan.LoanDate=localDate.ToString();
            loan.LastPaidInstallment=localDate.ToString();
            loan.PaidAmount=0;
            try
            {
                customer.Loans.Add(loan);

            }
            catch (System.Exception)
            {
                customer.Loans=new List<Loan>(){loan};
            }
        
            await _repository.UpdateCustemer(customer);


            return RedirectToPage("./index");


        }


    }
    
}
