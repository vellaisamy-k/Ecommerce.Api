using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequestDto orderRequestDto)
        {
            var order = await _orderService.CreateAsync(orderRequestDto);

            return Ok(order);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await _orderService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderRequestDto orderRequestDto)
        {
            // Get Order by id
            var result = await _orderService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _orderService.UpdateAsync(id, orderRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(OrderRequestDto orderRequestDto)
        {
            var result = _orderService.DeleteAsync(orderRequestDto);

            return Ok(result);
        }

    }
}
