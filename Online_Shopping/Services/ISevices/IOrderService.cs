using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateAsync(OrderRequestDto orderRequestDto);
        Task DeleteAsync(OrderRequestDto orderRequestDto);
        Task<List<OrderResponseDto>> GetAllAsync();
        Task<OrderResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, OrderRequestDto orderRequestDto);
    }
}
