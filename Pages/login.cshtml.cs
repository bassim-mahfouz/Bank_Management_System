using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bank_Management_System.Data;
using Bank_Management_System.Repositories;

namespace Bank_Management_System.Pages
{

    public class LoginModel : PageModel
    {

        [BindProperty]
        public AdminInputClass AdminInput { get; set; }
        
        [BindProperty]
        public EmployeeInputClass EmployeeInput { get; set; }

        public IEnumerable<string> Admins{get;set;}

        public AdminRepository _repository{get;set;}
        public EmployeeRepository _EmployeeRepository{get;set;}

        public LoginModel(AdminRepository repository,EmployeeRepository EmployeeRepository)
        {
            _repository=repository;
            _EmployeeRepository=EmployeeRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Admins=await _repository.GetAdmins();
            return Page();
        }

     public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _EmployeeRepository.GetEmployeeAsync(EmployeeInput.Name,EmployeeInput.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return await this.OnGet();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Role,"Employee")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                    IssuedUtc = DateTimeOffset.UtcNow
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                
                
                return RedirectToPage("/EmployeeIndex");
            }
            return await this.OnGet();
        }
 

         public async Task<IActionResult> OnPostAdmin()
        {
            if (ModelState.IsValid)
            {
                var user = await _repository.GetAdminAsync(AdminInput.Name,AdminInput.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return await this.OnGet();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Role,"Employee")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                    IssuedUtc = DateTimeOffset.UtcNow
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToPage("/AdminIndex");
            }
            return await this.OnGet();
        }
    
    }

    public class EmployeeInputClass {

        public string Name{get;set;}
        public string Password{get;set;}
    }

    public class AdminInputClass {

        public string Name{get;set;}
        public string Password{get;set;}
    }
    
}
