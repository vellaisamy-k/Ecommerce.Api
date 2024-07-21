using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController( ICustomerService customerService) 
        {
            _customerService = customerService;
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequestDto customerDto)
        {
            var result =  _customerService.IsRecordExists(customerDto);
            if (result) 
            {
               return Conflict("Customer already exists");
            }

            var customer = await _customerService.CreateAsync(customerDto);

            return Ok(customer);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _customerService.GetAllAsync();
            if(result == null)
            {
                return Ok("Users is Empty");
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetAsync(id);
            if (result != null) 
            { 
                return Ok(result);
            }
            return BadRequest("User is not exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id , CustomerRequestDto customerDto)
        {
            // Get customer by id
            var result = await _customerService.GetAsync(id);
            // check if exist else return error
            if(result is null)
            {
                return BadRequest("Not found");
            }
           
            if (result != null) 
            {
                await _customerService.UpdateAsync(id, customerDto);

                return Ok("Update success fulled...!");
            }            

            return BadRequest("user not exists");    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(CustomerRequestDto customerDto)
        {
            var result =  _customerService.DeleteAsync(customerDto);

            return Ok(result);
        }

    }
}
