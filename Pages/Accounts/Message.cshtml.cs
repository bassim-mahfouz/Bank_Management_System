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


namespace Bank_Management_System.Pages.Accounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class MessageModel : PageModel
    {
        public CustomerRepository _repository{get;set;}

        [BindProperty(SupportsGet=true)]
        public int id{get;set;}


        public MessageModel(CustomerRepository repository)
        {
            _repository=repository;
        }  
       
       public async Task<IActionResult> OnGet()
        {
            

            
            return Page();
        }



    }
    
}
