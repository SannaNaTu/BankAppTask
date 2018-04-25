using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppTask.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(long id)
        {
            Id = id;
        }

        public Customer(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public Customer(string firstname, string lastname, long bankId)
        {
            Firstname = firstname;
            Lastname = lastname;
            BankId = bankId;
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Account> Account { get; set; }



        public override string ToString()
        {
            return $"{Id}, {Firstname} {Lastname}";
        }
    }
}
