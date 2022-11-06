using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bank_Management_System.Models;
using System.Collections.Generic;
using Bank_Management_System.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using ClosedXML;
using ClosedXML.Excel;


namespace Bank_Management_System.Pages.BrowseAccounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       public List<Account> accounts{get;set;}
       
       public AccountRepository _repository{get;set;}
       
       [BindProperty(SupportsGet=true)]
       public int id{get;set;}


       public IndexModel(AccountRepository repository)
       {
            _repository=repository;
       }

       public async Task<IActionResult>  OnGet()
        {
            accounts= await _repository.GetAccounts();
            
            return Page();
        }
        

        public async Task<IActionResult>  OnPost()
        {
            if(id==0)
                accounts= await _repository.GetAccounts();
            
            else
                accounts= new List<Account>(){ await _repository.GetAccountByAccountId(id)};
        
            return Page();
        }

        public async Task<IActionResult>  OnGetDownload()
        {
            accounts= await _repository.GetAccounts();

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Accounts.xlsx";
            try
                {
                 using (var workbook = new XLWorkbook())
                {
                     IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Accounts");
                    worksheet.Cell(1, 1).Value = "Customer Id";
                    worksheet.Cell(1, 2).Value = "Account Id   ";
                    worksheet.Cell(1, 3).Value = "Balance";
                    worksheet.Cell(1, 5).Value = "Currency";
                    worksheet.Cell(1, 4).Value = "CreationDate";
                    int index=1;
                    foreach (var account in accounts)
                    {
                        worksheet.Cell(1 + index, 1).Value =account.CustomerId;
                        worksheet.Cell(1 + index, 2).Value =account.AccountId;
                        worksheet.Cell(1 + index, 3).Value =account.Amount;                        
                        worksheet.Cell(1 + index, 5).Value =account.Currency;                        
                        worksheet.Cell(1 + index, 4).Value =account.CreationDate.Split(" ")[0];    
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
    
