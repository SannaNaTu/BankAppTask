using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAppTask.Repositories
{
    class BankRepository
    {
        private static BankdbContext _context = new BankdbContext();

        public static void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }
        public static List<Bank> Get()
        {
            List<Bank> banks = _context.Bank.ToListAsync().Result;
            return banks;
        }
        public static Bank GetBankById(int id)
        {
            var bank = _context.Bank.FirstOrDefault(b => b.Id == id);
            return bank;
        }
        public static void Update(int id, Bank bank)
        { 
            var updateBank = GetBankById(id);
            if (updateBank != null)
        
            {
                _context.Bank.Update(updateBank);

            }
            _context.SaveChanges();

        }
        
    }
}
