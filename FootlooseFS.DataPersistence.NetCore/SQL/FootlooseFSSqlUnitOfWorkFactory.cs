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
            var connectionString = string.Format("Data Source={0}/{1}", options.Value.AppPath, options.Value.SQLConnectionString);            
            return new FootlooseFSSqlUnitOfWork(connectionString);
        }
    }
}
