using FootlooseFS.Models;
using FootlooseFS.Service;
using FootlooseFS.Web.Service.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FootlooseFS.Web.Service.Controllers
{
    public class AccountsController : FootloseFSApiController
    {
        public AccountsController(IFootlooseFSService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor) { }

        // GET api/accounts        
        public HolderAccountsViewModel Get()
        {
            // Get Person data model from the data service
            var person = service.GetPersonByUsername(authenticatedUser, new PersonIncludes { Accounts = true, Addressses = false, Phones = false, AccountTransactions = true });

            // Create a Holder view model and populate data from Person data model
            var holderAccounts = new HolderAccountsViewModel();

            // Get the holder's accounts
            holderAccounts.Accounts = (from a in person.Accounts
                               select new AccountViewModel
                               {
                                   AccountNumber = a.Account.AccountNumber,
                                   AccountBalance = a.Account.AccountBalance,
                                   AccountName = a.Account.AccountName,
                                   AccountType = a.Account.AccountType.Name
                               });

            // Calculate the total
            holderAccounts.Total = (from a in holderAccounts.Accounts select a.AccountBalance).Sum();

            // Ge thte holder's account transactions
            holderAccounts.Transactions = (from a in person.Accounts
                                   from t in a.Account.Transactions
                                   orderby t.Date descending
                                   select new TransactionViewModel
                                   {
                                       AccountNumber = a.Account.AccountNumber,
                                       AccountName = a.Account.AccountName,
                                       Date = t.Date,
                                       TransactionType = t.TransactionType.Name,
                                       Amount = t.Amount
                                   });

            return holderAccounts;
        }
    }
}
