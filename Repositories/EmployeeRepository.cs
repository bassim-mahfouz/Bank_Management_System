using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_Management_System.Data;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Repositories
{
    public class EmployeeRepository 
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeAsync(string userName, string password)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.Name == userName && a.Password == password);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByName(string userName)
        {
            return await _context.Employees.Where(a => a.Name == userName).ToListAsync();
        }
        public async Task<List<EmployeeAction>> GetEmployeeActions(string name)
        {
            return await _context.Actions.Where(a => a.EmployeeName == name).ToListAsync();
        }

        public async Task<Employee> GetSingleEmployeeByName(string userName)
        {
            return await _context.Employees.FirstOrDefaultAsync(a => a.Name == userName);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();;
        }

         public async Task<bool> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        
                await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _context.Attach(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteEmployee(string name)
        {
            var employee = await _context.Employees.FindAsync(name);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }




    }
}
