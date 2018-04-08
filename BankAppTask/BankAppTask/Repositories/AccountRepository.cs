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
        private static BankdbContext _context = new BankdbContext();

        public static Account GetAccountByCustomerId(int CustomerId)
        {
            var account = _context.Account.FirstOrDefault(i => i.CustomerId == CustomerId);
            return account;
        }
        public static void Update(int IBAN, Account account) // Update
        {
            var updateAccount = GetAccountByCustomerId(IBAN);
            if (updateAccount != null)

            {
                _context.Account.Update(account);

            }
            _context.SaveChanges(); //execute
        }
        public static void Create(Account account) //Lisää
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }
    }
}
