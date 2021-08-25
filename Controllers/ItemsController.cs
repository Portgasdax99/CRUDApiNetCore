using AutoMapper;
using Catalog;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDProject.Controllers
{
   // GET /item/list
    [ApiController]
    [Route("item")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository  repository;
        private readonly IMapper _mapper;

        public ItemsController(IItemsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        //Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}",Name = "GetItem")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ItemDto>(item));
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
          
            var itemModel = _mapper.Map<Item>(createItemDto);
            repository.CreateItem(itemModel);
            repository.SaveChange();

            var ItemDto = _mapper.Map<ItemDto>(itemModel);

           return CreatedAtRoute(nameof(GetItem),new { id = itemModel.Id }, itemModel.AsDto()); 

            // return CreatedAtAction(nameof(GetItem), new { id = itemModel.Id }, itemModel.AsDto());
        }
        //Put/items/
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto UpdateItemDto)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateItemDto, existingItem);
            repository.UpdateItem(existingItem);
            repository.SaveChange();
            return NoContent();
        }


        //path api/item/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialItemUpdate(Guid id, JsonPatchDocument<UpdateItemDto> patchDoc)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            var itemToPatch = _mapper.Map<UpdateItemDto>(existingItem);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(itemToPatch, existingItem);

            repository.UpdateItem(existingItem);
            repository.SaveChange();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id) 
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(existingItem);
            repository.SaveChange();
            return NoContent();

        }
    }
}
