using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public async Task<ProductResponseDto> CreateAsync(ProductRequestDto productRequestDto)
        {
            var product = _mapper.Map<Product>(productRequestDto);
            await _productRepository.CreateAsync(product);
            return _mapper.Map<ProductResponseDto>(product);

        }
        public async Task UpdateAsync(int id, ProductRequestDto productRequestDto)
        {
            var product = await _productRepository.GetAsync(id);

            if (product != null)
            {
                _mapper.Map(productRequestDto, product);
                _productRepository.UpdateAsync(product);
            }
        }

        public async Task DeleteAsync(ProductRequestDto productRequestDto)
        {
            var product = _mapper.Map<Product>(productRequestDto);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return _mapper.Map<List<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task SaveChanges()
        {
            await _productRepository.SaveChanges();
        }
    }
}
