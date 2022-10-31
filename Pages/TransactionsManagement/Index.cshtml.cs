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

namespace Bank_Management_System.Pages.TransactionsManagement
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       
        [BindProperty]
        public customerModel customer  { get; set; }
          

        public CustomerRepository _repository{get;set;}

        public IndexModel(CustomerRepository repository)
        {
            _repository=repository;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

     public async Task<IActionResult> OnPost()
        {
      
            var Costumer = await _repository.GetCustomerAsync(customer.Id,customer.FirstName,customer.Password);
            if (Costumer == null)
            {
                 ModelState.AddModelError(string.Empty, "no existing Customer ");
                 return await this.OnGet();
            }
            
            return RedirectToPage("./transaction",new {id=Costumer.Id});
            

        }
         
    
    }

    public class customerModel{
        [Required]
        public int Id{get;set;}
        
        public string FirstName{get;set;}
        
        [DataType(DataType.Password)]
        public string Password { get; set; }     

    }
    

}