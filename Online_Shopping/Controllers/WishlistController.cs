using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {

        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpPost]
        public async Task<IActionResult> AddWishlist(WishlistRequestDto wishlistRequestDto)
        {

            var wishlist = await _wishlistService.CreateAsync(wishlistRequestDto);

            return Ok(wishlist);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWishlist()
        {
            var result = await _wishlistService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishlistById(int id)
        {
            var result = await _wishlistService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWishlist(int id, WishlistRequestDto wishlistRequestDto)
        {
            // Get Wishlist by id
            var result = await _wishlistService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _wishlistService.UpdateAsync(id, wishlistRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWishlist(WishlistRequestDto wishlistRequestDto)
        {
            var result = _wishlistService.DeleteAsync(wishlistRequestDto);

            return Ok(result);
        }

    }
}
