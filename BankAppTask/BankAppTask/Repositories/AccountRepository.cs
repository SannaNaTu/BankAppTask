using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAppTask.Repositories
{
    class AccountRepository
    {
      
        private readonly BankdbContext _context = new BankdbContext();

        //Print Accounts
        public List<Account> Read()
        {
            List<Account> accounts = _context.Account.ToListAsync().Result;
            return accounts;
        }

        //Find account by id
        public Account GetAccountById(string iban)
        {
            var account = _context.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        //Create new Account
        public void CreateAccount(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        //Delete an account
        public void DeleteAccount(string iban)
        {
            var delAccount = _context.Account.FirstOrDefault(a => a.Iban == iban);
            if (delAccount != null)
                _context.Account.Remove(delAccount);
            _context.SaveChanges();
        }


        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                
                _context.Transaction.Add(transaction);
                var account = GetAccountById(transaction.Iban);
                account.Balance += transaction.Amount;
                _context.Account.Update(account);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

