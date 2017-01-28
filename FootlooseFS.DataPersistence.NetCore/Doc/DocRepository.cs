using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using FootlooseFS.Models;
using MongoDB.Driver;

namespace FootlooseFS.DataPersistence
{
    public abstract class DocRepository<T> : BaseRepository<T>, IRepository<T> where T : EntityDocument
    {
        private IMongoDatabase _database;
        private string _tableName;
        private IMongoCollection<T> _collection;

        public DocRepository(IMongoDatabase database, string tableName)
        {
            _database = database;
            _tableName = tableName;

            _collection = _database.GetCollection<T>(tableName);
        }

        #region IRepository<T> Members

        public override void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public override void AddBatch(IEnumerable<T> entities)
        {
            _collection.InsertMany(entities);
        }

        public override void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
            _collection.DeleteOne(filter);
        }

        public override void DeleteAll()
        {
            // Delete all record where the ID is greater than 0 (which should be all records)
            var filter = Builders<T>.Filter.Gt(s => s.Id, 0);
            _collection.DeleteMany(filter);
        }

        public override T Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
            _collection.ReplaceOneAsync(filter, entity);

            return entity;
        }

        public override IQueryable<T> GetQueryable()
        {
            return _collection.AsQueryable<T>();
        }              

        #endregion
    }
}
