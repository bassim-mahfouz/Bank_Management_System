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


namespace Bank_Management_System.Pages.BrowseAccounts
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class DetailsModel : PageModel
    {
        public AccountRepository _repository{get;set;}

        
        [BindProperty(SupportsGet=true)]
        public int id{get;set;}

        [BindProperty(SupportsGet=true)]
        public int show{get;set;}
        public List<Transaction> Transactions{get;set;}
        
        public DetailsModel(AccountRepository repository)
        {
            _repository=repository;
        }

       public async Task<IActionResult> OnGet()
        {
                Transactions=await _repository.GetTransactions(id);
            if(show!=2)
            {
                List<Transaction> filterTransactions=new List<Transaction>();
                if(show==1){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==1)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
                if(show==0){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==0)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
                Transactions=filterTransactions;
            }
            return Page();
        }

        public async Task<IActionResult>  OnGetDownload()
        {
            Transactions=await _repository.GetTransactions(id);
            List<Transaction> filterTransactions=new List<Transaction>();
            if(show!=2)
            {
                if(show==1){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==1)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
                if(show==0){
                    foreach(Transaction transaction in Transactions)
                    {
                        if(transaction.type==0)
                        {
                            filterTransactions.Add(transaction);
                        }
                    }
                }
            Transactions=filterTransactions;
            }
    
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Transactions.xlsx";
            try
                {
                 using (var workbook = new XLWorkbook())
                {
                     IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Loans");
                    worksheet.Cell(1, 1).Value = "Account Id";
                    worksheet.Cell(1, 2).Value = "amount";
                    worksheet.Cell(1, 3).Value = "Date";
                    worksheet.Cell(1, 4).Value = "type";


                    int index=1;

                    foreach (var transaction in Transactions)
                    {
                        String type=" ";
                        if(transaction.type==0)
                            type="deposite";
                        else
                            type="withdraw";
                        worksheet.Cell(1 + index, 1).Value =transaction.AccountId;
                        worksheet.Cell(1 + index, 2).Value =transaction.amount;
                        worksheet.Cell(1 + index, 3).Value =transaction.Date.Split(" ")[0];                        
                        worksheet.Cell(1 + index, 4).Value =type;                        
                       
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


            return Page();
        } 
     
        }
    }
    
    

