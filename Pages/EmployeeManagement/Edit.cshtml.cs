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

    public class EditModel : PageModel
    {
        public EmployeeRepository _repository{get;set;}

        [BindProperty]
        public Employee employee{get;set;}

        [BindProperty]
        [Required]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)).+$", ErrorMessage = "Password should contain numbers, symbols, and characters")]
        [MaxLength(128)]
        public String password{get;set;}

        [BindProperty]
        [Required]
        public String confirmpassword{get;set;}

        [BindProperty(SupportsGet=true)]
        public String name{get;set;}
       

        public EditModel(EmployeeRepository repository)
        {
            _repository=repository;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            employee=await _repository.GetSingleEmployeeByName(name);
            password=employee.Password;
            confirmpassword=employee.Password;
            return Page();
        }

            public async Task<IActionResult> OnPostAsync(){

            if (!ModelState.IsValid)
            {
                return Page();
            }            

            if(String.Compare(confirmpassword,password)!=0)
            {
                ModelState.AddModelError("","The confimation password don't match the password");
                return await this.OnGet();

            }

            employee.Password=password;
     
            await _repository.UpdateEmployee(employee);
    
            return RedirectToPage("./EmployeeManagement");

        }    
        




    }
    
}
