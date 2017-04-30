using System;
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
            var connectionString = string.Format("Data Source={0}/{1}", AppContext.BaseDirectory, options.Value.SQLConnectionString);
            var allowUpdates = options.Value.AllowUpdates;
            return new FootlooseFSSqlUnitOfWork(connectionString, allowUpdates);
        }
    }
}
