using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bank_Management_System.Models;
using Bank_Management_System.Repositories;
using Bank_Management_System.Services;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Bank_Management_System.Pages.Accounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class CreateModel : PageModel
    {
        public CustomerRepository _repository{get;set;}

        [BindProperty(SupportsGet=true)]
        public int id{get;set;}

        [BindProperty]
        public Account account{get;set;}

        public Employee employee{get;set;}

        public List<SelectListItem> correncyList  {get;set;}

        public CreateModel(CustomerRepository repository)
        {
            _repository=repository;
        }  
       
       public async Task<IActionResult> OnGet()
        {
            correncyList = Currency.getCurrencyList();
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(){

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            correncyList = Currency.getCurrencyList();

            Customer customer=await _repository.GetCustomerById(id);
            DateTime localDate = DateTime.Now;

            account.CreationDate=localDate.ToString();
            
            customer.PersonalAccount=account;
            try
            {
                await _repository.UpdateCustemer(customer);

            }
            catch (System.Exception)
            {
                return RedirectToPage("./Message",new {id=customer.Id});
            }
            return RedirectToPage("./index");



        }


    }
    
}
