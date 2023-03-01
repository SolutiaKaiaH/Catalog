using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories{
    //interface for InMemItemsRepository
     public interface IItemsRepository{
        //<Task> makes sure each methods returns task, now an async methods 
            //when you get item you wont get it right away you will get a task
            // and you will get it when it's done
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        //route for creating an item
        Task CreateItemAsync(Item item);
        //update item
        Task UpdateItemAsync(Item item);
        //delete item
        Task DeleteItemAsync(Guid id);
    }
}