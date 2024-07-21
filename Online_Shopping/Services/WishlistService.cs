using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IMapper _mapper;

        public WishlistService(IWishlistRepository wishlistRepository, IMapper mapper)
        {
            _wishlistRepository = wishlistRepository;
            _mapper = mapper;
        }

        public async Task<WishlistResponseDto> CreateAsync(WishlistRequestDto wishlistRequestDto)
        {
            var wishlist = _mapper.Map<Wishlist>(wishlistRequestDto);
            await _wishlistRepository.CreateAsync(wishlist);

            return _mapper.Map<WishlistResponseDto>(wishlist);

        }
        public async Task UpdateAsync(int id, WishlistRequestDto wishlistRequestDto)
        {
            var wishlist = await _wishlistRepository.GetAsync(id);
            if (wishlist != null)
            {
                _mapper.Map(wishlistRequestDto, wishlist);
                _wishlistRepository.UpdateAsync(wishlist);
            }
        }

        public async Task DeleteAsync(WishlistRequestDto wishlistRequestDto)
        {
            var wishlist = _mapper.Map<Wishlist>(wishlistRequestDto);
            await _wishlistRepository.DeleteAsync(wishlist);
        }

        public async Task<List<WishlistResponseDto>> GetAllAsync()
        {
            var wishlists = await _wishlistRepository.GetAllAsync();

            return _mapper.Map<List<WishlistResponseDto>>(wishlists);
        }

        public async Task<WishlistResponseDto> GetAsync(int id)
        {
            var wishlist = await _wishlistRepository.GetAsync(id);

            return _mapper.Map<WishlistResponseDto>(wishlist);
        }

        public async Task SaveChanges()
        {
            await _wishlistRepository.SaveChanges();
        }
    }
}
