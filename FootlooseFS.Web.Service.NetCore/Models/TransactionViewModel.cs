using System;

namespace FootlooseFS.Web.Service.Models
{
    public class TransactionViewModel
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}