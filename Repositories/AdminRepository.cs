using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_Management_System.Data;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Repositories
{
    public class AdminRepository 
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetAdminAsync(string userName, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Name == userName && a.Password == password);
        }

        public async Task<IEnumerable<string>> GetAdmins()
        {
            var Admins = await _context.Admins.ToListAsync();
            return Admins.Select(d => new String(d.Name));
        }

    }
}
