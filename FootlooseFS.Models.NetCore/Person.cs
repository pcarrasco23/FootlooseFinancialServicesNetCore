using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootlooseFS.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        public virtual List<PersonAccount> Accounts { get; set; }
        public virtual List<Phone> Phones { get; set; }
        public virtual List<PersonAddressAssn> Addresses { get; set; }
        public virtual PersonLogin Login { get; set; }
    }
}
