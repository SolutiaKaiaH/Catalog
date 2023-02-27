using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using System.Collections.Generic;
using System;

namespace Catalog.Controllers{

    [ApiController]
    //to which HTTP route we are responding to
    [Route("items")]

    public class ItemsController : ControllerBase{
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository){
            //receive the repository (DI)
            this.repository = repository;
        }

        //GET /items 
            //return all the items when someone requests them
            //When we say execute in Swagger this is what is returned!
        [HttpGet]
        public IEnumerable<Item> GetItems(){
            var items = repository.GetItems();
            return items;
        }

        //GET /item/{id}
            //return one specific item
            //actionResult lets up return HTTP 
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = repository.GetItem(id);

            //return proper status code to tell us we found the item
            if (item is null){
                return NotFound();
            }
            return item;
        }
    }
}