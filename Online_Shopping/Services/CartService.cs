
using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartResponseDto> CreateAsync(CartRequestDto cartRequestDto)
        {
            var cart = _mapper.Map<Cart>(cartRequestDto);
            await _cartRepository.CreateAsync(cart);
            return _mapper.Map<CartResponseDto>(cart);

        }
        public async Task UpdateAsync(int id, CartRequestDto cartRequestDto)
        {
            Cart? cart = await _cartRepository.GetAsync(id);

            if (cart == null)
            {
                _mapper.Map(cartRequestDto, cart);
                _cartRepository.UpdateAsync(cart);
            }
        }


        public async Task DeleteAsync(CartRequestDto cartRequestDto)
        {
            var cart = _mapper.Map<Cart>(cartRequestDto);
            await _cartRepository.DeleteAsync(cart);
        }

        public async Task<List<CartResponseDto>> GetAllAsync()
        {
            var carts = await _cartRepository.GetAllAsync();
            return _mapper.Map<List<CartResponseDto>>(carts);
        }

        public async Task<CartResponseDto> GetAsync(int id)
        {
            var cart = await _cartRepository.GetAsync(id);

            return _mapper.Map<CartResponseDto>(cart);
        }
        public async Task SaveChanges()
        {
            await _cartRepository.SaveChanges();
        }
    }
}
