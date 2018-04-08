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

        public static void Create(Bank bank) //Lisää
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
        public static void Update(int id, Bank bank) // Update
        { 
            var updateBank = GetBankById(id);
            if (updateBank != null)
        
            {
                _context.Bank.Update(bank);

            }
            _context.SaveChanges(); //execute

        }
        public static void Delete(int id)  //poistaminen
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null) 
            _context.Bank.Remove(delBank); 
            _context.SaveChanges();
        }
        
    }
}
