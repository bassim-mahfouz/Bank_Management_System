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


namespace Bank_Management_System.Pages.EmployeeManagement
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class DetailsModel : PageModel
    {
        public EmployeeRepository _repository{get;set;}

        public Employee employee{get;set;}

        public String? password{get;set;}

        
        [BindProperty(SupportsGet=true)]
        public String name{get;set;}
        
        public DetailsModel(EmployeeRepository repository)
        {
            _repository=repository;
        }

       public async Task<IActionResult> OnGet()
        {
            employee=await _repository.GetSingleEmployeeByName(name);
            password=employee.Password;
            return Page();
        }

 
    


    }
    
}
