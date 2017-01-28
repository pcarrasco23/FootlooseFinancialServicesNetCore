using Microsoft.Extensions.Options;

namespace FootlooseFS.Models
{
    public interface IFootlooseFSUnitOfWorkFactory
    {
        IFootlooseFSUnitOfWork CreateUnitOfWork();
    }
}
