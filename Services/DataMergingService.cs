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

namespace Bank_Management_System.Services
{
    public class DataMergingService 
    {

        public static void InsertCSVRecords(DataTable csvdt)
        {
            SqlConnection con;

            string sqlconn;
            sqlconn = "Server=DESKTOP-MB7KB44;Database=Bank_Management_System;Trusted_Connection=True;";
            con = new SqlConnection(sqlconn);

            SqlBulkCopy objbulk = new SqlBulkCopy(con);

            objbulk.DestinationTableName = "Customers";
            objbulk.ColumnMappings.Add("Id", "Id");
            objbulk.ColumnMappings.Add("FirstName", "FirstName");
            objbulk.ColumnMappings.Add("LastName", "LastName");
            objbulk.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
            objbulk.ColumnMappings.Add("Email", "Email");
            objbulk.ColumnMappings.Add("Password", "Password");

            con.Open();

            objbulk.WriteToServer(csvdt);


            con.Close();
        }



    }
    
}
