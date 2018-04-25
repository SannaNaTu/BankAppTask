using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppTask.Model
{
    public partial class Bank
    {
        public Bank()
        {
            Account = new HashSet<Account>();
            Customer = new HashSet<Customer>();
        }



        public Bank(string name, string bic)
        {
            Name = name;
            Bic = bic;
        }

        public Bank(string name, string bic, ICollection<Account> account, ICollection<Customer> customer)
        {
            Name = name;
            Bic = bic;
            Account = account;
            Customer = customer;
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("BIC", TypeName = "nchar(10)")]
        public string Bic { get; set; }

        [InverseProperty("Bank")]
        public ICollection<Account> Account { get; set; }
        [InverseProperty("Bank")]
        public ICollection<Customer> Customer { get; set; }

        public override string ToString()
        {
            return $"{Name},{Bic}";
        }
    }
}
