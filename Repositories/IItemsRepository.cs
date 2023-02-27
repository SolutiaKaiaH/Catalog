using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories{
    //interface for InMemItemsRepository
     public interface IItemsRepository{
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}