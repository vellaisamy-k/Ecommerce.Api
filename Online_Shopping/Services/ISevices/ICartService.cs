using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface ICartService
    {
        Task<CartResponseDto> CreateAsync(CartRequestDto cartRequestDto);
        Task DeleteAsync(CartRequestDto cartRequestDto);
        Task<List<CartResponseDto>> GetAllAsync();
        Task<CartResponseDto> GetAsync(int id);       
        Task UpdateAsync(int id, CartRequestDto cartRequestDto);
    }
}
