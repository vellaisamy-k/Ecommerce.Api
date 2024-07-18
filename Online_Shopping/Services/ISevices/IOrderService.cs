using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateAsync(OrderRequestDto OrderDto);
        Task DeleteAsync(OrderRequestDto OrderDto);
        Task<List<OrderResponseDto>> GetAllAsync();
        Task<OrderResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, OrderRequestDto OrderDto);
    }
}
