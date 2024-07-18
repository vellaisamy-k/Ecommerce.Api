using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateAsync(CategoryRequestDto CategoryDto);
        Task DeleteAsync(CategoryRequestDto CategoryDto);
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, CategoryRequestDto CategoryDto);
    }
}
