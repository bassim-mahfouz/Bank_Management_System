using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Management_System.Pages
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class AdminIndexModel : PageModel
    {
        
       
       public IActionResult  OnGet()
        {
      
            return Page();
         

            
        } 
    }
    
}
