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
using Microsoft.AspNetCore.Http;
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

        public EmployeeRepository _employeeRepository{get;set;}

        public string Name{get;set;}


        public TransactionModel(AccountRepository repository,IHttpContextAccessor _httpContextAccessor,EmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
            _repository=repository;
            Name=_httpContextAccessor.HttpContext.User.Identity.Name;
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
            Employee employee=await _employeeRepository.GetSingleEmployeeByName(Name);
            employee.LastLoginDate=(DateTime.Now).ToString();
            await _employeeRepository.UpdateEmployee(employee);

            return Page();
        }

      public async Task<IActionResult> OnPost()
        {
            account = await _repository.GetAccountByAccountId(AccountId);
            EmployeeAction action=new EmployeeAction();
            action.Date=(DateTime.Now).ToString();

            if(String.Compare(transactionType,"deposite")==0){
                Transaction deposite=new Transaction();
                deposite.AccountId=AccountId;
                deposite.amount=amount;
                account.Amount=account.Amount+amount;
                DateTime localDate = DateTime.Now;
                deposite.type=1;
                deposite.Date=localDate.ToString();
                try
                {
                    account.Transactions.Add(deposite);
                }
                catch (System.Exception)
                {
                    account.Transactions=new List<Transaction>(){deposite};
                }
                action.type=1;
                action.ActionId= await _repository.GetLastTransactionId();

                await _repository.UpdateAccount(account);
            }

            if(String.Compare(transactionType,"withdraw")==0){

                Transaction withdraw=new Transaction();
                withdraw.AccountId=AccountId;
                withdraw.amount=amount;
                account.Amount=account.Amount-amount;
                DateTime localDate = DateTime.Now;
                withdraw.Date=localDate.ToString();
                withdraw.type=0;
                try
                {
                    account.Transactions.Add(withdraw);
                }
                catch (System.Exception)
                {
                    account.Transactions=new List<Transaction>(){withdraw};
                }
                action.type=2;
                action.ActionId= await _repository.GetLastTransactionId();
                await _repository.UpdateAccount(account);
            }

            Employee employee=await _employeeRepository.GetSingleEmployeeByName(Name);
            employee.LastLoginDate=(DateTime.Now).ToString();
            
            try{
                employee.Actions.Add(action);
            }
            catch
            {
                employee.Actions=new List<EmployeeAction>(){action};
            }
            await _employeeRepository.UpdateEmployee(employee);

            return RedirectToPage("./transaction",new {id=account.CustomerId});

        }
         
    
    }


    

}