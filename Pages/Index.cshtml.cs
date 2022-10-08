using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Bank_Management_System.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public AdminInputClass AdminInput { get; set; }
        [BindProperty]
        public InputClass Input { get; set; }

        public IEnumerable<string> Departments{get;set;}


        public IndexModel()
        {
            Departments=new List<string>(){"informatic","statistic","Math"};
        }

        public void OnGet()
        {

        }

        public class InputClass {

            public string DepartmentName{get;set;}
            public string Password{get;set;}
        }

        public class AdminInputClass {

            public string Name{get;set;}
            public string Password{get;set;}
        }
    }
    
}
