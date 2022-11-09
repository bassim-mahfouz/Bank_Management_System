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


namespace Bank_Management_System.Pages.BrowseLoans
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {
       public List<Loan> Loans{get;set;}
       public List<String> cssClasses{get;set;}
       
       public LoanRepository _repository{get;set;}
       
       [BindProperty(SupportsGet=true)]
       public int id{get;set;}

       public string cssClass{get;set;}
 

       public IndexModel(LoanRepository repository)
       {
            _repository=repository;
       }

       public async Task<IActionResult>  OnGet()
        {
            cssClasses=new List<String>(){};
            Loans= await _repository.GetLoans();
            DateTime Today=DateTime.Now;
            
            foreach(var loan in Loans)
            {
                DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
                if(Convert.ToInt16(Today.Date.Subtract(LastPaid).Days)>30)
                {
                    cssClasses.Add("coloring");
                }
                else
                    cssClasses.Add(" ");
            }
            return Page();
        } 
        public async Task<IActionResult>  OnGetDelete()
        {
            await _repository.DeleteLoans(id);
            cssClasses=new List<String>(){};
            Loans= await _repository.GetLoans();
            DateTime Today=DateTime.Now;
            
            foreach(var loan in Loans)
            {
                DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
                if(Convert.ToInt16(Today.Date.Subtract(LastPaid).Days)>30)
                {
                    cssClasses.Add("coloring");
                }
                else
                    cssClasses.Add(" ");
            }
            return Page();
        } 

        public async Task<IActionResult>  OnPost()
        {
            cssClasses=new List<String>(){};
            if(id==0)
            {
                Loans= await _repository.GetLoans();
            }
            else{
                Loans= new List<Loan>(){await _repository.GetLoanById(id)};
            }
            DateTime Today=DateTime.Now;
            
            foreach(var loan in Loans)
            {
                DateTime LastPaid=DateTime.Parse(loan.LastPaidInstallment);
                if(Convert.ToInt16(Today.Date.Subtract(LastPaid).Days)>30)
                {
                    cssClasses.Add("coloring");
                }
                else
                    cssClasses.Add(" ");
            }
            return Page();
        }



        public async Task<IActionResult>  OnGetDownload()
        {
            Loans= await _repository.GetLoans();

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Loans.xlsx";
            try
                {
                 using (var workbook = new XLWorkbook())
                {
                     IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Loans");
                    worksheet.Cell(1, 1).Value = "Loan Id";
                    worksheet.Cell(1, 2).Value = "Customer Id";
                    worksheet.Cell(1, 3).Value = "Amount";
                    worksheet.Cell(1, 4).Value = "PaidAmount";
                    worksheet.Cell(1, 5).Value = "LoanDate";
                    worksheet.Cell(1, 6).Value = "Currency";
                    worksheet.Cell(1, 7).Value = "LastPaidInstallment";
                    worksheet.Cell(1, 8).Value = "LoanDeadline";
                    worksheet.Cell(1, 9).Value = "AmountPaidPerInstallment";
                    int index=1;
                    foreach (var loan in Loans)
                    {
                        worksheet.Cell(1 + index, 1).Value =loan.LoanId;
                        worksheet.Cell(1 + index, 2).Value =loan.CustomerId;
                        worksheet.Cell(1 + index, 3).Value =loan.Amount;                        
                        worksheet.Cell(1 + index, 4).Value =loan.PaidAmount;                        
                        worksheet.Cell(1 + index, 5).Value =loan.LoanDate.Split(" ")[0];                        
                        worksheet.Cell(1 + index, 6).Value =loan.Currency;                        
                        worksheet.Cell(1 + index, 7).Value =loan.LastPaidInstallment;                        
                        worksheet.Cell(1 + index, 8).Value =loan.LoanDeadline;                        
                        worksheet.Cell(1 + index, 9).Value =loan.AmountPaidPerInstallment;                        
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
