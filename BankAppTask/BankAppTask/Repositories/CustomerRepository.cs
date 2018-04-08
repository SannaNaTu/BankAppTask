using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAppTask.Repositories
{
    class CustomerRepository: AccountRepository // perii Accountin jotta vois samalla lisää tilinron..? 
    {
        private static BankdbContext _context = new BankdbContext();

      

        public static void Create(Customer customer) //Lisää
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }


    
    }
}
