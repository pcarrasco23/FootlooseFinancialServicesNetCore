namespace FootlooseFS.Models
{
    public interface IFootlooseFSUnitOfWorkFactory
    {
        IFootlooseFSUnitOfWork CreateUnitOfWork();
    }
}
