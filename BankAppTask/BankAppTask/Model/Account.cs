using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppTask.Model
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Account(string iban)
        {
            Iban = iban;
        }

        public Account(string iban, long customerId)
        {
            Iban = iban;
            CustomerId = customerId;
        }

        public Account(string iban, string name, long bankId, long customerId, decimal balance, Bank bank, Customer customer, ICollection<Transaction> transaction)
        {
            Iban = iban;
            Name = name;
            BankId = bankId;
            CustomerId = customerId;
            Balance = balance;
            Bank = bank;
            Customer = customer;
            Transaction = transaction;
        }

        [Key]
        [Column("IBAN", TypeName = "nchar(25)")]
        public string Iban { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Account")]
        public Customer Customer { get; set; }
        [InverseProperty("IbanNavigation")]
        public ICollection<Transaction> Transaction { get; set; }
    }
}
