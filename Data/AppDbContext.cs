using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bank_Management_System.Models;

namespace Bank_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<EmployeeAction> Actions { get; set; }
        public DbSet<PaidInstallment> PaidInstallment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
