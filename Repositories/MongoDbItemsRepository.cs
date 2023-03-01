using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Driver;
using MongoDB.Bson;


//interact with MongoDB Database
//now we really don't have to touch the itemsController
    //because now we have an items repository 
namespace Catalog.Repositories{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient){
            //reference to database
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            itemsCollection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            //build the filter
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
           return itemsCollection.Find(new BsonDocument()).ToList();
        }


        public void UpdateItem(Item item)
        {
            //implement filter 
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter,item);
        }
    }
}
