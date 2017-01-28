using System.ComponentModel.DataAnnotations;

namespace FootlooseFS.Models
{
    public class PersonLogin
    {
        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginID { get; set; }

        [Required]
        [StringLength(64)]
        public string HashedPassword { get; set; }

        [Required]
        [StringLength(64)]
        public string Salt { get; set; }

        public virtual Person Person { get; set; }
    }
}
