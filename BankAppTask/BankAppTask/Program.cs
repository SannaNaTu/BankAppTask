using System;
using BankAppTask.Model;
using BankAppTask.Repositories;




namespace BankAppTask
{
    class Program
    {
       
        
     
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Bank app ");

            //CreateBank("PANKKI8", "PANK8FIHH");

            //UpdateBank("PANKKI8", "UPDATE8FIHH");

            //DeleteBank(8);

            //CreateCustomer("Allu", "Ankka",2);

            //UpdateCustomer("Jallu", "Ankka", 2);

            //DeleteCustomer(1);

            //CreateAccount("FI8554280820034350",2,5,600);

            //DeleteAccount("FI8554280820034350",2,5,600);

            //CreateTransaction();

            //PrintAllBanks();

            Console.WriteLine("press Enter to exit");
            Console.ReadLine();
        }

        //Luodaan pankki // TOIMII Testattu
        static void CreateBank(string name, string bic)
        {
            BankRepository bankRepository = new BankRepository();
            Bank bank = new Bank(name,bic);
            bankRepository.Create(bank);
        }
        static void UpdateBank(string name, string bic)
        { 
            //Update pankki //TOIMII Testattu
            BankRepository bankRepository = new BankRepository();
            Bank bank = new Bank(name, bic);
            bankRepository.UpdateBank(bank);
        }
        static void DeleteBank(long id)
        {
            //Delete pankki //TOIMII Testattu
            Bank bank = new Bank(id);
            BankRepository bankRepository = new BankRepository();
            bankRepository.Delete(id);
        }
        static void CreateCustomer(string Firstname, string Lastname,long bankid)
        {
            //lissee asiakas //TOIMII Testattu
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = new Customer(Firstname,Lastname,bankid);
            customerRepository.CreateCustomer(customer);
        }
        static void UpdateCustomer(string firstname, string lastname, long bankId)
        {
            //päivitä asaikas //TOIMII Testattu

            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = new Customer(firstname, lastname, bankId);
            customerRepository.UpdateCustomer(customer);

        }
        static void DeleteCustomer(long id)
        {
            //deletoi asiakas // TOIMII Testattu
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = new Customer(id);
            customerRepository.DeleteCustomer(id);
        }
        static void CreateAccount(string iban, long bankId, long customerId, decimal balance)
        {
            //lissee tili // Jotain häikkää
            Account account = new Account(iban, bankId, customerId, balance);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.CreateAccount(account);
        }
        static void DeleteAccount(string iban, long bankId, long customerId, decimal balance)
        {
            //deletoi tili // Jotain häikkää
            Account account = new Account(iban, bankId, customerId, balance);
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.DeleteAccount(account);
        }

        static void CreateTransaction()
        {
            //tilitapahtuma // TOIMII Testattu
            AccountRepository accountRepository = new AccountRepository();

            
            var account = accountRepository.GetAccountByIban("FI8554280820034349");
            Transaction transaction = new Transaction
            {
                Iban = "FI8554280820034349",
                Amount = 500,
                TimeStamp = DateTime.Today

            };
            accountRepository.CreateTransaction(transaction);
        }
        static void PrintAllBanks() // hakee kaikki tehtävän hae- tiedot // TOIMII Testattu
        {
            BankView bankView = new BankView();
            bankView.PrintAllBanks();
        }

    }
    
}
