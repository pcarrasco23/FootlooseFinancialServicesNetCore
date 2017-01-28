using System.Collections.Generic;

namespace FootlooseFS.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public int AccountTypeID { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<AccountTransaction> Transactions { get; set; }
    }
}
