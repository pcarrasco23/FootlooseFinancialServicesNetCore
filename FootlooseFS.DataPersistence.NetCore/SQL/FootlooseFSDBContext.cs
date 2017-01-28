using FootlooseFS.Models;
using Microsoft.EntityFrameworkCore;

namespace FootlooseFS.DataPersistence
{
    /// <summary>
    /// DB context
    /// The Entity Framework connection string: FootlooseFSContext must be defined in application configuration
    /// </summary>
    public class FootlooseFSDBContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonLogin> PersonLogin { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PersonAccount> PersonAccount { get; set; }
        public DbSet<AccountTransaction> AccountTransaction { get; set; }

        public FootlooseFSDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<AccountTransaction>().ToTable("AccountTransaction");
            modelBuilder.Entity<AccountType>().ToTable("AccountType");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<AddressType>().ToTable("AddressType");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PersonAccount>().ToTable("PersonAccount");
            modelBuilder.Entity<PersonAddressAssn>().ToTable("PersonAddressAssn");
            modelBuilder.Entity<PersonLogin>().ToTable("PersonLogin");
            modelBuilder.Entity<Phone>().ToTable("Phone");
            modelBuilder.Entity<PhoneType>().ToTable("PhoneType");
            modelBuilder.Entity<TransactionType>().ToTable("TransactionType");

            modelBuilder.Entity<PersonAccount>()
                .HasKey(p => new { p.PersonID, p.AccountID });

            modelBuilder.Entity<PersonAddressAssn>()
                .HasKey(p => new { p.PersonID, p.AddressID, p.AddressTypeID });

            modelBuilder.Entity<PersonLogin>()
               .HasKey(p => new { p.PersonID });

            modelBuilder.Entity<Phone>()
               .HasKey(p => new { p.PersonID, p.PhoneTypeID });
        }
    }
}
