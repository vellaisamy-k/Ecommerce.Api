using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateAsync(CategoryRequestDto categoryRequestDto);
        Task DeleteAsync(CategoryRequestDto categoryRequestDto);
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, CategoryRequestDto categoryRequestDto);
    }
}
