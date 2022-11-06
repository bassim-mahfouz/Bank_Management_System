using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_Management_System.Data;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Repositories
{
    public class AccountRepository 
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByCustomerId(int customerId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.CustomerId==customerId);
        }

        public async Task<Account> GetAccountByAccountId(int AccountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId==AccountId);
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }
        
        public async Task<List<Transaction>> GetTransactions(int id)
        {
            return await _context.Transactions.Where(a=> a.AccountId==id).ToListAsync();
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            _context.Attach(account).State = EntityState.Modified;
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

        public async Task<int> GetLastTransactionId()
        {
            return  _context.Transactions.Max(a => a.id);
        }



    }
}
