using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost]
        public async Task<IActionResult> Addcart(CartRequestDto cartRequestDto)
        {
            var cart = await _cartService.CreateAsync(cartRequestDto);

            return Ok(cart);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllcart()
        {
            var result = await _cartService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetcartById(int id)
        {
            var result = await _cartService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatecart(int id, CartRequestDto cartRequestDto)
        {
            // Get cart by id
            var result = await _cartService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _cartService.UpdateAsync(id, cartRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> Deletecart(CartRequestDto cartRequestDto)
        {
            var result = _cartService.DeleteAsync(cartRequestDto);

            return Ok(result);
        }

    }
}
