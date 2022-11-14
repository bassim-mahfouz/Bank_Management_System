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
using Microsoft.AspNetCore.Http;

namespace Bank_Management_System.Services
{
    

    public class LoginManager 
    {
       
        public static LoginManager loginManager;


        public LoginManager()
        {     
        }

        public static LoginManager getLoginManager()
        {

            if(loginManager==null)
                loginManager=new LoginManager();
            return loginManager;
        }

        public async Task saveLoginDate(EmployeeRepository employeeRepository,
        String Name)
        {
            Console.WriteLine("---"+Name);
            Employee employee=await employeeRepository.GetSingleEmployeeByName(Name);
            employee.LastLoginDate=(DateTime.Now).ToString();
            await employeeRepository.UpdateEmployee(employee);
        }


    }
    
}
