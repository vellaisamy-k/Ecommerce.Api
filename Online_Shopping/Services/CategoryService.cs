using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;

        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryRequestDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            await _CategoryRepository.CreateAsync(Category);
            await SaveChanges();

            return _mapper.Map<CategoryResponseDto>(Category);

        }
        public async Task UpdateAsync(int id, CategoryRequestDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);

            var res = await _CategoryRepository.GetAsync(id);

            var cus = _mapper.Map<Category>(res);

            _CategoryRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(CategoryRequestDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            await _CategoryRepository.DeleteAsync(Category);
            await SaveChanges();
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            var Categorys = await _CategoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryResponseDto>>(Categorys);
        }

        public async Task<CategoryResponseDto> GetAsync(int id)
        {
            var Category = await _CategoryRepository.GetAsync(id);

            return _mapper.Map<CategoryResponseDto>(Category);
        }

        //public bool IsRecordExists(CategoryRequestDto CategoryDto)
        //{
        //    return _CategoryRepository.IsRecordExists(x => x.n.ToLower().Trim() == CategoryDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _CategoryRepository.SaveChanges();
        }
    }
}
