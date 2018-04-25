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
            Console.WriteLine("press Enter to exit");
            Console.ReadLine();
        }

        //Luodaan pankki
        static void CreateBank()
        {
            BankRepository bankRepository = new BankRepository();
            Bank bank = new Bank("PANKKI7", "PANK7FIHH");
            bankRepository.Create(bank);
        }
        static void updateBank()
        { 
            //Update pankki
                BankRepository bankRepository = new BankRepository();
                Bank updateBank = bankRepository.GetBankById(2);
                updateBank.Name = "KAKKOSPANKKI2";
                updateBank.Bic = "PANKKAKKOSFIHH";
                bankRepository.Update(updateBank);
        }
        static void DeleteBank()
        {
            //Delete pankki
            BankRepository bankRepository = new BankRepository();
            bankRepository.Delete(5);
        }
        static void CreateCustomer()
        {
            //lissee asiakas
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = new Customer("Allu", "Ankka");
          
            customerRepository.CreateCustomer(customer);
        }
        static void UpdateCustomer()
        {
            //päivitä asaikas
            CustomerRepository customerRepository = new CustomerRepository();
            Customer updateCustomer = customerRepository.GetCustomerById(2);
            updateCustomer.Firstname = "Taavi";
            updateCustomer.Lastname = "Ankka";
            customerRepository.UpdateCustomer(updateCustomer, 3);
        }
        static void DeleteCustomer()
        {
            //deletoi asiakas
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteCustomer(5);
        }
        static void CreateTransaction()
        {
            //tilitapahtuma
            AccountRepository accountRepository = new AccountRepository();

            TransactionRepository transactionRepository = new TransactionRepository();
            Transaction transaction = new Transaction
            {
                Iban = "FI85 5428 0820 0343 48",
                Amount = -500,
                TimeStamp = DateTime.Today

            };
            accountRepository.CreateTransaction(transaction);
        }
        static void PrintAllBanks() // kaikki pankit
        {
            BankView bankView = new BankView();
            bankView.PrintAllBanks();
        }

        static void PrintAllAccounts(string name) //hae tilit
        {
            BankView bankView = new BankView();
            bankView.PrintBankAccounts(name);
        }
    static void PrintBankCustomers(string name) // hae pankin asiakkaat
        {
            BankView bankView = new BankView();
            bankView.PrintBankCustomers(name);
        }
        static void PrintCustomerInfo(string firstname, string lastname) // hae asiakkaat
        {
            CustomerView customerView = new CustomerView();
            customerView.PrintCustomerInfo(firstname, lastname);
        }
      


    }
    
}
