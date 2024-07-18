using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerDto);
        Task DeleteAsync(CustomerRequestDto customerDto);
        Task<List<CustomerResponseDto>> GetAllAsync();
        Task<CustomerResponseDto> GetAsync(int id);
        bool IsRecordExists(CustomerRequestDto customerDto);
        Task UpdateAsync(int id, CustomerRequestDto customerDto);
    }
}
