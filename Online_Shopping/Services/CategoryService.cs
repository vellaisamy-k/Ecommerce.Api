using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryRequestDto categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);
            await _categoryRepository.CreateAsync(category);
            return _mapper.Map<CategoryResponseDto>(category);

        }
        public async Task UpdateAsync(int id, CategoryRequestDto categoryRequestDto)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category != null)
            {
                _mapper.Map(categoryRequestDto, category);
                _categoryRepository.UpdateAsync(category);
            }
        }

        public async Task DeleteAsync(CategoryRequestDto categoryRequestDto)
        {
            var category = _mapper.Map<Category>(categoryRequestDto);
            await _categoryRepository.DeleteAsync(category);

        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            var categorys = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryResponseDto>>(categorys);
        }

        public async Task<CategoryResponseDto> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task SaveChanges()
        {
            await _categoryRepository.SaveChanges();
        }
    }
}
