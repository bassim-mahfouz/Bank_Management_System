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
using System.IO;
using System;
using ClosedXML;
using ClosedXML.Excel;


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
        
        [BindProperty]
        public List<EmployeeAction> actions{get;set;}


        public DetailsModel(EmployeeRepository repository)
        {
            _repository=repository;

        }

       public async Task<IActionResult> OnGet()
        {
            employee=await _repository.GetSingleEmployeeByName(name);
            actions=await _repository.GetEmployeeActions(name);
            return Page();
        }

         public async Task<IActionResult>  OnGetDownload()
        {
            actions=await _repository.GetEmployeeActions(name);

            String contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            String fileName = name+"_Actions.xlsx";
            try
                {
                 using (var workbook = new XLWorkbook())
                {
                     IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Actions");
                    worksheet.Cell(1, 1).Value = "Action Id";
                    worksheet.Cell(1, 2).Value = "type";
                    worksheet.Cell(1, 3).Value = " Action Date  ";
                    int index=1;

                    foreach (var action in actions)
                    {
                        string type=" ";
                        if(action.type==0)
                            type="Loan Installment";
                        if(action.type==1)
                            type="Deposite";
                        if(action.type==2)
                            type="Withdraw";
                        worksheet.Cell(1 + index, 1).Value =action.ActionId;
                        worksheet.Cell(1 + index, 2).Value =type;
                        worksheet.Cell(1 + index, 3).Value =action.Date.Split(" ")[0];                        
                        index++;
                    }
                 
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
             }
         }
            catch (IOException ioException)
            {
                return Page();
            }

            
        } 
    


    }
    
}
