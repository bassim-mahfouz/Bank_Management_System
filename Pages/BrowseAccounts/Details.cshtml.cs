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

namespace Bank_Management_System.Pages.BrowseAccounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class DetailsModel : PageModel
    {
        public AccountRepository _repository{get;set;}

        
        [BindProperty(SupportsGet=true)]
        public int id{get;set;}

        [BindProperty(SupportsGet=true)]
        public int show{get;set;}
        public List<Transaction> Transactions{get;set;}
        
        public DetailsModel(AccountRepository repository)
        {
            _repository=repository;
        }

       public async Task<IActionResult> OnGet()
        {
            Transactions=await _repository.GetTransactions(id);
            if(show!=2)
            {
                List<Transaction> filterTransactions=new List<Transaction>();
                if(show==1){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==1)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
                if(show==0){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==0)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
                Transactions=filterTransactions;
            }
            return Page();
        }

 
    


    }
    
}
