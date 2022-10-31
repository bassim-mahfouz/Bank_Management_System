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

namespace Bank_Management_System.Pages.TransactionsManagement
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class TransactionModel : PageModel
    {
       
        [BindProperty(SupportsGet=true)]
        public int id{get;set;}          

        [BindProperty]
        public Account account{get;set;}

        [BindProperty]
        public int AccountId{get;set;}


        [BindProperty]
        public int amount {get;set;}

        [BindProperty]
        public string transactionType{get;set;}

        public string operation{get;set;}

        public string [] transactionTypes=new[]{"deposite","withdraw"};

        public AccountRepository _repository{get;set;}

        public TransactionModel(AccountRepository repository)
        {
            _repository=repository;
        }

        public async Task<IActionResult> OnGet()
        {
            account = await _repository.GetAccountByCustomerId(id);
            AccountId=account.AccountId;
            operation="+";

            if (account == null)
            {
                 return RedirectToPage("./Message",new {id=id});
            }
            
            return Page();
        }

      public async Task<IActionResult> OnPost()
        {
            account = await _repository.GetAccountByAccountId(AccountId);

            if(String.Compare(transactionType,"deposite")==0){
                Deposite deposite=new Deposite();
                deposite.AccountId=AccountId;
                deposite.amount=amount;
                account.Amount=account.Amount+amount;
                DateTime localDate = DateTime.Now;
                deposite.Date=localDate.ToString();
                try
                {
                    account.Deposites.Add(deposite);
                }
                catch (System.Exception)
                {
                    account.Deposites=new List<Deposite>(){deposite};
                }
                await _repository.UpdateAccount(account);
            }

            if(String.Compare(transactionType,"withdraw")==0){

                Withdraw withdraw=new Withdraw();
                withdraw.AccountId=AccountId;
                withdraw.amount=amount;
                account.Amount=account.Amount-amount;
                DateTime localDate = DateTime.Now;
                withdraw.Date=localDate.ToString();
                try
                {
                    account.Withdraws.Add(withdraw);
                }
                catch (System.Exception)
                {
                    account.Withdraws=new List<Withdraw>(){withdraw};
                }
                await _repository.UpdateAccount(account);
            }

            return RedirectToPage("./transaction",new {id=account.CustomerId});

        }
         
    
    }


    

}