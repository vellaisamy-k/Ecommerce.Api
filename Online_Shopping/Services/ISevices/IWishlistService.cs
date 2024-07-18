using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IWishlistService
    {
        Task<WishlistResponseDto> CreateAsync(WishlistRequestDto WishlistDto);
        Task DeleteAsync(WishlistRequestDto WishlistDto);
        Task<List<WishlistResponseDto>> GetAllAsync();
        Task<WishlistResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, WishlistRequestDto WishlistDto);
    }
}
