
using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository CartRepository, IMapper mapper)
        {
            _CartRepository = CartRepository;
            _mapper = mapper;

        }

        public async Task<CartResponseDto> CreateAsync(CartRequestDto CartDto)
        {
            var Cart = _mapper.Map<Cart>(CartDto);
            await _CartRepository.CreateAsync(Cart);
            await SaveChanges();

            return _mapper.Map<CartResponseDto>(Cart);

        }
        public async Task UpdateAsync(int id, CartRequestDto CartDto)
        {
            var Cart = _mapper.Map<Cart>(CartDto);

            var res = await _CartRepository.GetAsync(id);

            var cus = _mapper.Map<Cart>(res);

            _CartRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(CartRequestDto CartDto)
        {
            var Cart = _mapper.Map<Cart>(CartDto);
            await _CartRepository.DeleteAsync(Cart);
            await SaveChanges();
        }

        public async Task<List<CartResponseDto>> GetAllAsync()
        {
            var Carts = await _CartRepository.GetAllAsync();

            return _mapper.Map<List<CartResponseDto>>(Carts);
        }

        public async Task<CartResponseDto> GetAsync(int id)
        {
            var Cart = await _CartRepository.GetAsync(id);

            return _mapper.Map<CartResponseDto>(Cart);
        }

        //public bool IsRecordExists(CartRequestDto CartDto)
        //{
        //    return _CartRepository.IsRecordExists(x => x.n.ToLower().Trim() == CartDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _CartRepository.SaveChanges();
        }
    }
}
