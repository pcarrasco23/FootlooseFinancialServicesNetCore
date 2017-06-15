using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootlooseFS.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        public decimal AccountBalance { get; set; }
        public int AccountTypeID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<AccountTransaction> Transactions { get; set; }
    }
}
