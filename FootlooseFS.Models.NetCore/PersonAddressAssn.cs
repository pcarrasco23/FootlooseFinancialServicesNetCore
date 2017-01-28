namespace FootlooseFS.Models
{
    public class PersonAddressAssn
    {
        public int PersonID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }

        public virtual Address Address { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
