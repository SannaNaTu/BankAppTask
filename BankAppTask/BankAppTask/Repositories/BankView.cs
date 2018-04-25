using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankAppTask.Repositories
{
    class BankView
    {
        public void PrintAllBanks()
        {
            BankRepository bankRepository = new BankRepository();
            var bank = bankRepository.GetTransactionsFromBankCustomersAccounts();

            foreach (var bC in bank)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount.ToString()}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn.ToString()}");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }
       
    }
}
