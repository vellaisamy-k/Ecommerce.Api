using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerRequestDto);
        Task DeleteAsync(CustomerRequestDto customerRequestDto);
        Task<List<CustomerResponseDto>> GetAllAsync();
        Task<CustomerResponseDto> GetAsync(int id);
        bool IsRecordExists(CustomerRequestDto customerRequestDto);
        Task UpdateAsync(int id, CustomerRequestDto customerRequestDto);
    }
}
