using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _OrderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository OrderItemRepository, IMapper mapper)
        {
            _OrderItemRepository = OrderItemRepository;
            _mapper = mapper;

        }

        public async Task<OrderItemResponseDto> CreateAsync(OrderItemRequestDto OrderItemDto)
        {
            var OrderItem = _mapper.Map<OrderItem>(OrderItemDto);
            await _OrderItemRepository.CreateAsync(OrderItem);
            await SaveChanges();

            return _mapper.Map<OrderItemResponseDto>(OrderItem);

        }
        public async Task UpdateAsync(int id, OrderItemRequestDto OrderItemDto)
        {
            var OrderItem = _mapper.Map<OrderItem>(OrderItemDto);

            var res = await _OrderItemRepository.GetAsync(id);

            var cus = _mapper.Map<OrderItem>(res);

            _OrderItemRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(OrderItemRequestDto OrderItemDto)
        {
            var OrderItem = _mapper.Map<OrderItem>(OrderItemDto);
            await _OrderItemRepository.DeleteAsync(OrderItem);
            await SaveChanges();
        }

        public async Task<List<OrderItemResponseDto>> GetAllAsync()
        {
            var OrderItems = await _OrderItemRepository.GetAllAsync();

            return _mapper.Map<List<OrderItemResponseDto>>(OrderItems);
        }

        public async Task<OrderItemResponseDto> GetAsync(int id)
        {
            var OrderItem = await _OrderItemRepository.GetAsync(id);

            return _mapper.Map<OrderItemResponseDto>(OrderItem);
        }

        //public bool IsRecordExists(OrderItemRequestDto OrderItemDto)
        //{
        //    return _OrderItemRepository.IsRecordExists(x => x.n.ToLower().Trim() == OrderItemDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _OrderItemRepository.SaveChanges();
        }
    }
}
