namespace FootlooseFS.Models
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Find(int personId, PersonIncludes personIncludes);
    }
}
