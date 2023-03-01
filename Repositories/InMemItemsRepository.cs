using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;


namespace Catalog.Repositories{

    public class InMemItemsRepository: IItemsRepository {

        //CREATES A SCHEMA IN SWAGGER
         private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        //ALL OF THE ACTIONS IN OUR REPOSITORY 

        //return a collection of items
        public async Task<IEnumerable<Item>> GetItemsAsync(){
            return await Task.FromResult(items);
        }

        //return one item
        public async Task<Item> GetItemAsync (Guid id){
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        //create an item
        public async Task CreateItemAsync(Item item){
           items.Add(item);
           await Task.CompletedTask;
        }

        //update item
        public async Task UpdateItemAsync(Item item){
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item; 
            await Task.CompletedTask;
        }

        //delete item
        public async Task DeleteItemAsync(Guid id){
             var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index); 
            await Task.CompletedTask;
        }
    }
}