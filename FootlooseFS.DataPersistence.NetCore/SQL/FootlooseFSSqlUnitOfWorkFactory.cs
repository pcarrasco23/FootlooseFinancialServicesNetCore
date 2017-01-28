using FootlooseFS.Models;
using Microsoft.Extensions.Options;

namespace FootlooseFS.DataPersistence
{
    public class FootlooseFSSqlUnitOfWorkFactory : IFootlooseFSUnitOfWorkFactory
    {
        private readonly IOptions<FootlooseFSConfiguration> options;

        public FootlooseFSSqlUnitOfWorkFactory(IOptions<FootlooseFSConfiguration> options)
        {
            this.options = options;
        }

        public IFootlooseFSUnitOfWork CreateUnitOfWork()
        {
            return new FootlooseFSSqlUnitOfWork(options.Value.SQLConnectionString);
        }
    }
}
