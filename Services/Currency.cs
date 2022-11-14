using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bank_Management_System.Models;
using Bank_Management_System.Repositories;
using Bank_Management_System.Services;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bank_Management_System.Services
{
    

    public class Currency 
    {
       
       public static List<SelectListItem> getCurrencyList()
        {
            return new()
            {
                new SelectListItem { Value = "LB", Text = "LB (not recomended)" , Selected = true},
                new SelectListItem { Value = "USD", Text = "USD" },
                new SelectListItem { Value = "EURO", Text = "EURO" },
            };
        }



    }
    
}
