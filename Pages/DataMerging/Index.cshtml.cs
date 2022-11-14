using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Bank_Management_System.Services;

namespace Bank_Management_System.Pages.DataMerging
{
    
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class IndexModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage = "no file choosed")]
        public IFormFile file { get; set; } 

        public int choose {get;set;}

        public List<string> duplicated {get;set;}


        SqlConnection con;

        string sqlconn;

        private void connection()
        {
            sqlconn = "Server=DESKTOP-MB7KB44;Database=Bank_Management_System;Trusted_Connection=True;";
            con = new SqlConnection(sqlconn);
        }

        public void OnGet()
        {
            duplicated=new List<string>();
        }

        public void OnPostAdd()
        {
            DataTable tblcsv = new DataTable();
            tblcsv.Columns.Add("Id");
            tblcsv.Columns.Add("FirstName");
            tblcsv.Columns.Add("LastName");
            tblcsv.Columns.Add("PhoneNumber");
            tblcsv.Columns.Add("Email");
            tblcsv.Columns.Add("Password");

           System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
           
           using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                duplicated = new List<string>();
                using(var reader = new StreamReader(stream))
                {
                        int counter = 1;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (counter != 1)
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                tblcsv.Rows.Add();
                                int count = 0;
                                foreach (string FileRec in line.Split(','))
                                {
                                    connection();

                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandType = CommandType.Text;

                                    cmd.CommandText = "SELECT Id FROM Customers";
                                    cmd.Connection = con;

                                    con.Open();


                                    SqlDataReader sdr = cmd.ExecuteReader();

                                    ArrayList id_list = new ArrayList();

                                    while (sdr.Read())
                                    {
                                        id_list.Add(sdr["Id"]+"");
                                    }
                                 con.Close();


                                if (id_list.Contains(FileRec+""))
                                {
                                    tblcsv.Rows[tblcsv.Rows.Count-1].Delete();
                                    duplicated.Add(line);
                                    break;
                                }
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                count++;
                                
                            }
                        }
                
                           }
                         counter++;

                    }

                }

            }
            
            choose = 1; 

            DataMergingService.InsertCSVRecords(tblcsv);
            
            
        }






    }
}
