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

namespace Bank_Management_System.Pages.Loans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       
        [BindProperty]
        public customerModel customer  { get; set; }
        
        [BindProperty]
        public Customer newCustomer {get;set;}

        [BindProperty]
        [DataType(DataType.Password)]
        public string confirmPassword{get;set;}    

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
            
            return RedirectToPage("./Create",new {id=Costumer.Id});
            

        }
         

         public async Task<IActionResult> OnPostNew()
        {
            
            if (!ModelState.IsValid)
             {
                 return await this.OnGet();
             }
            
             if(String.Compare(confirmPassword,newCustomer.Password)!=0)
             {
                 ModelState.AddModelError("","The confimation password don't match the password");
               return await this.OnGet();  
             }
            
            int id=await _repository.CreateCustomer(newCustomer);

            return RedirectToPage("./Create",new {id=id});
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