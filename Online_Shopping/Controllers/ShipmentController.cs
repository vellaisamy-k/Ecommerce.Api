using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddShipment(ShipmentRequestDto shipmentRequestDto)
        {            
            var shipment = await _shipmentService.CreateAsync(shipmentRequestDto);

            return Ok(shipment);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllShipment()
        {
            var result = await _shipmentService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(int id)
        {
            var result = await _shipmentService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(int id, ShipmentRequestDto shipmentRequestDto)
        {
            // Get Shipment by id
            var result = await _shipmentService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _shipmentService.UpdateAsync(id, shipmentRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShipment(ShipmentRequestDto shipmentRequestDto)
        {
            var result = _shipmentService.DeleteAsync(shipmentRequestDto);

            return Ok(result);
        }

    }
}
