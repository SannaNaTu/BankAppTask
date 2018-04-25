using System;
using System.Collections.Generic;
using System.Text;
using BankAppTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAppTask.Repositories
{
    class CustomerRepository
    {
        private static BankdbContext _context = new BankdbContext();

        public Customer GetCustomerById(int id) // Eti asiakas
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            return customer;
        }


        public void CreateCustomer(Customer customer) //Lisää
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer, int id) //Update henkilö
        {
            var updateCustomer = GetCustomerById(id);
            if (updateCustomer != null)
            {
                updateCustomer.Firstname = customer.Firstname;
                updateCustomer.Lastname = customer.Lastname;
                _context.Customer.Update(customer);
            }
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id) //Delete henkilö
        {
            var delCustomer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (delCustomer != null)
                _context.Customer.Remove(delCustomer);
            _context.SaveChanges();
        }

        public List<Customer> Read() //lista 
        {
            List<Customer> customers = _context.Customer.ToListAsync().Result;
            return customers;
        }
        public Customer GetCustomer(string firstName, string lastName)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    var customer = context.Customer.FirstOrDefault(a => a.Firstname == firstName && a.Lastname == lastName);
                    return customer;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }
        public List<Customer> GetCustomerAccounts(Customer customer)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Customer> customers = context.Customer
                        .Include(c => c.Account)
                        .Where(c => c.Id == customer.Id)
                        .ToListAsync().Result;
                    return customers;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }
        public List<Bank> GetBankAccounts(string name)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(a => a.Account)
                        .Where(a => a.Name == name)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }

        public List<Bank> GetBankCustomers(string name)
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .Where(b => b.Name == name)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }
            }
        }



    }
}
