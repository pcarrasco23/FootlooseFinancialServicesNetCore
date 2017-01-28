using System.ComponentModel.DataAnnotations;

namespace FootlooseFS.Models
{
    public class Phone
    {
        public int PersonID { get; set; }
        public int PhoneTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Number { get; set; }

        public virtual PhoneType PhoneType { get; set; }
    }
}
