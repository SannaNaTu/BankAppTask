using System;
using BankAppTask.Model;
using BankAppTask.Repositories;



namespace BankAppTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            //Bank bank = new Bank("PANKKI3", "PANK3FIHH");
            //BankRepository.Create(bank);
            //var banks = BankRepository.Get();
            //foreach (var b in banks)
            //{
            //    Console.WriteLine(b.ToString());
            //}

            //Customer customer = new Customer("Aku", "Ankka",2);
            //CustomerRepository.Create(customer);

            Account account = new Account("FI85 5428 0820 0343 48 ", 5);
            AccountRepository.Create(account);

            Console.WriteLine("press Enter to exit");
            Console.ReadLine();
        }
    }
}
