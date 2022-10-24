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
        public DbSet<Deposite> Deposites { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<PaidInstallment> PaidInstallment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Withdraw>().HasKey(table => new { table.AccountId, table.Date });
            builder.Entity<Deposite>().HasKey(table => new { table.AccountId, table.Date });
            builder.Entity<PaidInstallment>().HasKey(table => new { table.LoanId, table.PaymentDate });

            base.OnModelCreating(builder);
        }
    }
}
