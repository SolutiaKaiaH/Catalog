using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Item> GetItems(){
            return items;
        }

        //return one item
        public Item GetItem (Guid id){
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        //create an item
        public void CreateItem(Item item){
           items.Add(item);
        }
    }
}