using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;

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
        public IEnumerable<ItemDto> GetItems(){
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        //GET /item/{id}
            //return one specific item
            //actionResult lets up return HTTP 
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item = repository.GetItem(id);

            //return proper status code to tell us we found the item
            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }

        //POST /items
            //will add an item to items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
    }
}