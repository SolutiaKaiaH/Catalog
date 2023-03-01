using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync(){
            var items = (await repository.GetItemsAsync())
            .Select(item => item.AsDto());
            return items;
        }

        //GET /item/{id}
            //return one specific item
            //actionResult lets up return HTTP 
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id){
            var item = await repository.GetItemAsync(id);

            //return proper status code to tell us we found the item
            if (item is null){
                return NotFound();
            }
            return item.AsDto();
        }

        //POST /items
            //will add an item to items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDto itemDto){
            //find item
            var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null){
                return NotFound();
            }

            //with means we are creating a copy, and modifying with these new values 
                //this is why records are fun
            Item updatedItem = existingItem with{
                Name = itemDto.Name,
                Price = itemDto.Price
            };

           await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id){
            var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null){
                return NotFound();
            }

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}