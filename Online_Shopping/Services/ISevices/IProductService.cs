using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateAsync(ProductRequestDto productRequestDto);
        Task DeleteAsync(ProductRequestDto productRequestDto);
        Task<List<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, ProductRequestDto productRequestDto);
    }
}
