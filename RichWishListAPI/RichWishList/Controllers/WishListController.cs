using Microsoft.AspNetCore.Mvc;
using RichWishList.Models;
using RichWishList.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RichWishList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : ControllerBase
    {
        private IWishListService _service;

        public WishListController(IWishListService service)
        {
            _service = service;
        }

        /// <summary>
        /// Adds an item to the Wish List
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddWishListItem(WishListItem item)
        {
            var result = await _service.Create(item);
            return Ok(result);
        }


        /// <summary>
        /// Gets all items from the Wish List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWishListItems()
        {
            var results = await _service.GetAll();
            return Ok(results);
        }


        /// <summary>
        /// Gets a Wish List item by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetWishListItemById(Guid id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Updates an item in the Wish List
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateItem(WishListItem item)
        {
            var result = await _service.Update(item);
            return Ok(result);
        }

        [HttpDelete]
        /// <summary>
        /// Deletes an item from the Wish List
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteItem(Guid Id)
        {
            var result = await _service.Delete(Id);
            return Ok(result);
        }
    }
}
