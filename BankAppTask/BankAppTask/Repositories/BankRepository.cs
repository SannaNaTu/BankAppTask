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
       
        public void UpdateBank(Bank bank) // Update
        {
            using (var context = new BankdbContext())
            {
                try
                {

                    context.Update(bank);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message}");
                }
            }

        }
        public void Delete(long id)  //poistaminen
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null) 
            _context.Bank.Remove(delBank); 
            _context.SaveChanges();
        }
 
    }
}
