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

namespace Bank_Management_System.Pages.EmployeeManagement
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class EmployeeManagementModel : PageModel
    {
       public IEnumerable<Employee> Employees{get;set;}
       
       public EmployeeRepository _repository{get;set;}
       
       [BindProperty(SupportsGet=true)]
       public String? name{get;set;}

       [BindProperty(SupportsGet=true)]
       public String? delete{get;set;}

       public EmployeeManagementModel(EmployeeRepository repository)
       {
            _repository=repository;
       }

       public async Task<IActionResult>  OnGet()
        {
             if(delete!="" && delete!=null)
            {
            await _repository.DeleteEmployee(delete);
            }

            Employees= await _repository.GetEmployees();
   
            return Page();
        } 

        public async Task<IActionResult>  OnPost()
        {
  
            if(name=="" || name==null)
            {
                Employees= await _repository.GetEmployees();
            }
            else{
                Employees= await _repository.GetEmployeeByName(name);
            }
            return Page();
        } 


    }
    
}
