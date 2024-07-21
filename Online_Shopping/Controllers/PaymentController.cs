using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
                _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentRequestDto paymentRequestDto)
        {
            var payment = await _paymentService.CreateAsync(paymentRequestDto);

            return Ok(payment);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayment()
        {
            var result = await _paymentService.GetAllAsync();
            if (result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var result = await _paymentService.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentRequestDto paymentRequestDto)
        {
            // Get Payment by id
            var result = await _paymentService.GetAsync(id);
            // check if exist else return error
            if (result is null)
            {
                return BadRequest("Not found");
            }

            if (result != null)
            {
                await _paymentService.UpdateAsync(id, paymentRequestDto);

                return Ok("Update success fulled...!");
            }

            return BadRequest("user not exists");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(PaymentRequestDto paymentRequestDto)
        {
            var result = _paymentService.DeleteAsync(paymentRequestDto);

            return Ok(result);
        }
    }
}
