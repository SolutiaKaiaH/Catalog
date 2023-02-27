using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories{
    //interface for InMemItemsRepository
     public interface IItemsRepository{
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        //route for creating an item
        void CreateItem(Item item);
        //update item
        void UpdateItem(Item item);
        //delete item
        void DeleteItem(Guid id);
    }
}