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
using Bank_Management_System.Services;


namespace Bank_Management_System.Pages.Loans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class CreateModel : PageModel
    {
        public CustomerRepository _repository{get;set;}

        public LoanRepository _loanRepository{get;set;}

        [BindProperty(SupportsGet=true)]
        public int id{get;set;}

        [BindProperty]
        public int duration{get;set;}
        
        [BindProperty]
        public int click{get;set;}

        [BindProperty]
        public Loan loan{get;set;}


        public List<SelectListItem> correncyList  {get;set;}

        public CreateModel(CustomerRepository repository,LoanRepository loanRepository)
        {
            _repository=repository;
            _loanRepository=loanRepository;
        }  
       
       public async Task<IActionResult> OnGet()
        {
            correncyList = Currency.getCurrencyList();
            
            int count;
            List<Loan> list= await _loanRepository.GetLoansCustomerId(id);
            try
            {
                count=list.Count;
                Console.WriteLine("1--"+count);

            }
            catch (System.Exception)
            {
                count=0;
            }
            
            Console.WriteLine("2--"+count);

            if(count==2)
            {
                return RedirectToPage("./Message");
            }

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(){
            
            correncyList = Currency.getCurrencyList();


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
