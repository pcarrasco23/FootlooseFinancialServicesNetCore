using FootlooseFS.Models;

namespace FootlooseFS.Service.Tests
{
    public class FootlooseFSTestUnitOfWorkFactory : IFootlooseFSUnitOfWorkFactory
    {
        public IFootlooseFSUnitOfWork CreateUnitOfWork()
        {
            return new FootlooseFSTestUnitOfWork();
        }
    }
}
