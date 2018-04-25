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
        public Account GetAccountByIban(string iban)
        {
            using (var context = new BankdbContext())
                try
                {
                    var account = context.Account.FirstOrDefault(a => a.Iban == iban);
                    return account;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }

        //Create new Account
        public void CreateAccount(Account account)
        {
            using (var context = new BankdbContext())
                try
                {
                    context.Add(account);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }
            //Delete an account
            public void DeleteAccount(Account account)
        {
            using (var context = new BankdbContext())
                try
                {
                    context.Remove(account);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
        }


        public void CreateTransaction(Transaction transaction)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                   
                    context.Add(transaction);

                    
                    var account = GetAccountByIban(transaction.Iban);
                   
                    account.Balance += transaction.Amount;
                  
                    context.Account.Update(account);
                    
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }
        }
    }
}

