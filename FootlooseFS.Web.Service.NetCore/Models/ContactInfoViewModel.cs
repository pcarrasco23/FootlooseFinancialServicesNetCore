using System.Collections.Generic;

namespace FootlooseFS.Web.Service.Models
{
    public class ContactInfoViewModel
    {        
        public string EmailAddress { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public List<PhoneViewModel> PhoneNumbers { get; set; }
    }
}