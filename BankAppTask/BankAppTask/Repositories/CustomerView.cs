using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using BankAppTask.Model;

namespace BankAppTask.Repositories
{
    class CustomerView
    {
        public void PrintCustomerInfo(string Firstname, string Lastname)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = customerRepository.GetCustomer(Firstname, Lastname);
            var customerdata = customerRepository.GetCustomerAccounts(customer);

            foreach (var cD in customerdata)
            {
                Console.WriteLine(cD.ToString());
                foreach (var c in cD.Account)
                {
                    Console.WriteLine($"\t{c.ToString()}");
                }
            }
        }

        
    }
}
