using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
                _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem(OrderItemRequestDto orderItemRequestDto)
        {
            
            var orderItem = await _orderItemService.CreateAsync(orderItemRequestDto);

            return Ok(orderItem);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItem()
        {
            var result = await _orderItemService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var result = await _orderItemService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemRequestDto orderItemRequestDto)
        {
            // Get OrderItem by id
            var result = await _orderItemService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _orderItemService.UpdateAsync(id, orderItemRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(OrderItemRequestDto orderItemRequestDto)
        {
            var result = _orderItemService.DeleteAsync(orderItemRequestDto);

            return Ok(result);
        }

    }
}
