using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAppTask.Repositories
{
    class TransactionRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        
        public List<Transaction> Read() //tiedot
        {
            List<Transaction> transactions = _context.Transaction.ToListAsync().Result;
            return transactions;
        }

    }
}
