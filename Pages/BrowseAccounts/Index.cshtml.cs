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

namespace Bank_Management_System.Pages.BrowseAccounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       public List<Account> accounts{get;set;}
       
       public AccountRepository _repository{get;set;}
       
       [BindProperty(SupportsGet=true)]
       public int id{get;set;}


       public IndexModel(AccountRepository repository)
       {
            _repository=repository;
       }

       public async Task<IActionResult>  OnGet()
        {
            accounts= await _repository.GetAccounts();
            
            return Page();
        } 

        public async Task<IActionResult>  OnPost()
        {
            if(id==0)
                accounts= await _repository.GetAccounts();
            
            else
                accounts= new List<Account>(){ await _repository.GetAccountByAccountId(id)};
        
            return Page();
        } 


    }
    
}
