using FootlooseFS.Models;
using MongoDB.Driver;
using FootlooseFS.DataPersistence.Doc;
using Microsoft.Extensions.Options;

namespace FootlooseFS.DataPersistence
{
    public class FootlooseFSDocUnitOfWork
    {
        private IMongoDatabase _database;

        protected DocRepository<PersonDocument> _persons;

        public FootlooseFSDocUnitOfWork(string connectionString)
        {
            var client = new MongoClient(connectionString);   
            var databaseName = "footloosefs";
            _database = client.GetDatabase(databaseName);            
        }

        public IRepository<PersonDocument> Persons
        {
            get
            {
                if (_persons == null)
                    _persons = new PersonDocumentRepository(_database, "persons");

                return _persons;
            }
        }        
    }
}
