using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IOrderItemService
    {
        Task<OrderItemResponseDto> CreateAsync(OrderItemRequestDto orderItemRequestDto);
        Task DeleteAsync(OrderItemRequestDto orderItemRequestDto);
        Task<List<OrderItemResponseDto>> GetAllAsync();
        Task<OrderItemResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, OrderItemRequestDto orderItemRequestDto);
    }
}
