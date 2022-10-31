using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_Management_System.Data;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Repositories
{
    public class LoanRepository 
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetLoansCustomerId(int customerId)
        {
            return await _context.Loans.Where(a => a.CustomerId==customerId).ToListAsync();
        }

        public async Task<Loan> GetLoanById(int LoanId)
        {
            return await _context.Loans.FirstOrDefaultAsync(a => a.LoanId==LoanId);
        }

        public async Task<List<PaidInstallment>> GetPaidInstallmentsByLoanId(int LoanId)
        {
            return await _context.PaidInstallment.Where(a => a.LoanId==LoanId).ToListAsync();
        }

        public async Task<List<Loan>> GetLoans()
        {
            return await _context.Loans.ToListAsync();;
        }

        public async Task<bool> UpdateLoan(Loan loan)
        {
            _context.Attach(loan).State = EntityState.Modified;
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


    }
}
