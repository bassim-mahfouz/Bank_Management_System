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
using Microsoft.AspNetCore.Http;

namespace Bank_Management_System.Pages.loanManagement
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class LoanPayModel : PageModel
    {
       
        [BindProperty(SupportsGet=true)]
        public int id{get;set;}
        
        [BindProperty(SupportsGet=true)]
        public int loanNb{get;set;}          

        [BindProperty]
        public Loan loan{get;set;}
        
        [BindProperty]
        public float payAmount{get;set;}
        
        [BindProperty]
        public float afterPayAmount{get;set;}

        [BindProperty]
        public float remaind{get;set;}

        [BindProperty]
        public string added{get;set;}

        public List<Loan> loans{get;set;}

        public string Name{get;set;}

        public LoanRepository _repository{get;set;}

        public EmployeeRepository _employeeRepository{get;set;}

        public LoanPayModel(LoanRepository repository,EmployeeRepository employeeRepository,IHttpContextAccessor _httpContextAccessor)
        {
            _repository=repository;
            _employeeRepository=employeeRepository;
            Name=_httpContextAccessor.HttpContext.User.Identity.Name;
        }   

        public async Task<IActionResult> OnGet()
        {
            loans=await _repository.GetLoansCustomerId(id);
            if(loanNb==1)
                loan=loans[0];
            else{
                if(loans.Count>1)
                   loan=loans[1];
                else
                   loan=null;
            }
            if(loan!=null)
            {

            payAmount=0;
            remaind=loan.Amount-loan.PaidAmount;
            afterPayAmount=loan.Amount-loan.PaidAmount;

            if(remaind >= loan.AmountPaidPerInstallment)
                added="  it should be at least "+loan.AmountPaidPerInstallment;
            else{
                payAmount=remaind;
                added="  last installement "+remaind;
            }
            
            }
            Employee employee=await _employeeRepository.GetSingleEmployeeByName(Name);
            employee.LastLoginDate=(DateTime.Now).ToString();
            await _employeeRepository.UpdateEmployee(employee);
            return Page();
        }

      public async Task<IActionResult> OnPost()
        {
            Loan changedLoan=await _repository.GetLoanById(loan.LoanId);
               
            DateTime localDate = DateTime.Now;
            changedLoan.LastPaidInstallment=localDate.ToString();
            changedLoan.PaidAmount=changedLoan.PaidAmount+payAmount;
            PaidInstallment paidInstallment=new PaidInstallment();
            paidInstallment.amount=payAmount;
            paidInstallment.LoanId=loan.LoanId;
            paidInstallment.PaymentDate=localDate.ToString();
            try{
                changedLoan.PaidInstallments.Add(paidInstallment);
            }
            catch
            {
                 changedLoan.PaidInstallments=new List<PaidInstallment>(){paidInstallment};
            }
            await _repository.UpdateLoan(changedLoan);
            Employee employee=await _employeeRepository.GetSingleEmployeeByName(Name);
            EmployeeAction action=new EmployeeAction();
            action.type=0;
            action.Date=(DateTime.Now).ToString();
            action.ActionId= await _repository.GetLastIntstallementId();
            employee.LastLoginDate=(DateTime.Now).ToString();
            
            try{
                employee.Actions.Add(action);
            }
            catch
            {
                 employee.Actions=new List<EmployeeAction>(){action};
            }
            await _employeeRepository.UpdateEmployee(employee);

            return RedirectToPage("./LoanPay",new {id=changedLoan.CustomerId,loanNb=loanNb});
        }
         
    
    }


    

}