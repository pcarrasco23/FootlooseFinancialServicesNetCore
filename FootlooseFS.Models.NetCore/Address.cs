using System.ComponentModel.DataAnnotations;

namespace FootlooseFS.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(5)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string Zip { get; set; }
    }
}
