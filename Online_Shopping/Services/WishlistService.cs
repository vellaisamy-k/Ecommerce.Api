using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _WishlistRepository;
        private readonly IMapper _mapper;

        public WishlistService(IWishlistRepository WishlistRepository, IMapper mapper)
        {
            _WishlistRepository = WishlistRepository;
            _mapper = mapper;

        }

        public async Task<WishlistResponseDto> CreateAsync(WishlistRequestDto WishlistDto)
        {
            var Wishlist = _mapper.Map<Wishlist>(WishlistDto);
            await _WishlistRepository.CreateAsync(Wishlist);
            await SaveChanges();

            return _mapper.Map<WishlistResponseDto>(Wishlist);

        }
        public async Task UpdateAsync(int id, WishlistRequestDto WishlistDto)
        {
            var Wishlist = _mapper.Map<Wishlist>(WishlistDto);

            var res = await _WishlistRepository.GetAsync(id);

            var cus = _mapper.Map<Wishlist>(res);

            _WishlistRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(WishlistRequestDto WishlistDto)
        {
            var Wishlist = _mapper.Map<Wishlist>(WishlistDto);
            await _WishlistRepository.DeleteAsync(Wishlist);
            await SaveChanges();
        }

        public async Task<List<WishlistResponseDto>> GetAllAsync()
        {
            var Wishlists = await _WishlistRepository.GetAllAsync();

            return _mapper.Map<List<WishlistResponseDto>>(Wishlists);
        }

        public async Task<WishlistResponseDto> GetAsync(int id)
        {
            var Wishlist = await _WishlistRepository.GetAsync(id);

            return _mapper.Map<WishlistResponseDto>(Wishlist);
        }

        //public bool IsRecordExists(WishlistRequestDto WishlistDto)
        //{
        //    return _WishlistRepository.IsRecordExists(x => x.n.ToLower().Trim() == WishlistDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _WishlistRepository.SaveChanges();
        }
    }
}
