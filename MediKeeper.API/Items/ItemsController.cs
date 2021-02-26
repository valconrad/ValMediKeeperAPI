using System;
using AutoMapper;
using MediKeeper.API.Models;
using MediKeeper.Application.Item;
using MediKeeper.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MediKeeper.API.Items
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemManager _itemManager;
        private readonly IMapper _mapper;

        public ItemsController(IItemManager itemManager, IMapper mapper)
        {
            _itemManager = itemManager;
            _mapper = mapper;
        }      

        [HttpGet]
        public IActionResult Get([FromQuery]bool showMaxPriceOnly)
        {
            try
            {
                var items = showMaxPriceOnly ? _itemManager.GetItemsWithMaxPriceOnly() : _itemManager.GetItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get items." + ex.ToString());
            }           
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)  
        {
            try
            {
                var item = _itemManager.GetItem(id);

                return item != null ? Ok(item) : (IActionResult)NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get items." + ex.ToString());
            }
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var item = _itemManager.GetItemWithMaxPrice(name);
                return item != null ? Ok(item.Cost) : (IActionResult)NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get items." + ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var newItem = _mapper.Map<AddItemViewModel, Item>(model);
                    
                    if (_itemManager.AddItem(newItem))
                    {
                        return Created($"/api/items/{newItem.Name}", _mapper.Map<Item, ItemViewModel>(newItem));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add item " + ex.ToString());
            }
            return BadRequest("Failed to save new item");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, [FromBody]ItemViewModel model)
        {
            try
            {
                var oldItem = _itemManager.GetItem(id);
                if (oldItem == null) return NotFound($"Could not find an item with id = {id}");

                _mapper.Map(model, oldItem);

                if (_itemManager.UpdateItem(oldItem))
                {
                    return Ok(_mapper.Map<ItemViewModel>(oldItem));
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update item " + ex.ToString());
            }

            return BadRequest("Failed to update");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var oldItem = _itemManager.GetItem(id);
                if (oldItem == null) return NotFound($"Could not find an item with id = {id}");
                if (_itemManager.Delete(oldItem)) return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete item " + ex.ToString());
            }

            return BadRequest("Failed to delete");
        }
    }
}