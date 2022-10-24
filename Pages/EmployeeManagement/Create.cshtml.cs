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

    public class CreateModel : PageModel
    {
        public EmployeeRepository _repository{get;set;}

        [BindProperty]
        public Employee employee{get;set;}

        [BindProperty]
        [DataType(DataType.Password)]
        [Required]
        public String confirmpassword{get;set;}
       
       public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public CreateModel(EmployeeRepository repository)
        {
            _repository=repository;
        }

        public async Task<IActionResult> OnPostAsync(){

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employee e=await _repository.GetSingleEmployeeByName(employee.Name);


            
            if(e!=null)
            {
                ModelState.AddModelError("employee.Name","Another Employee already exists with this Name.");
            }

            if(String.Compare(confirmpassword,employee.Password)!=0)
            {
                ModelState.AddModelError("","The confimation password don't match the password");
                return await this.OnGet();

            }
       
            await _repository.CreateEmployee(employee);
            return RedirectToPage("./EmployeeManagement");



        }


    }
    
}
