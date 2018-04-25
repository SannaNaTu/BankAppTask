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

        //Tulosta pankit
        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            List<Bank> banks = _context.Bank
                .Include(b => b.Customer)
                .Include(b => b.Account)
                .Include(b => b.Account).ThenInclude(a => a.Transaction)
                .ToListAsync().Result;
            return banks;
        }
  
        public Bank GetBankById(long id) //Eti pankki
        {
            var bank = _context.Bank.FirstOrDefault(b => b.Id == id);
            return bank;
        }

        public  void Create(Bank bank) //Lisää
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }
       
        public void Update(Bank bank) // Update
        { 
            var updateBank = GetBankById(bank.Id);
            if (updateBank != null)
        
            {
                updateBank.Name = bank.Name;
                updateBank.Bic = bank.Bic;
                _context.Bank.Update(bank);

            }
            _context.SaveChanges(); //execute

        }
        public void Delete(int id)  //poistaminen
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null) 
            _context.Bank.Remove(delBank); 
            _context.SaveChanges();
        }
 
    }
}
