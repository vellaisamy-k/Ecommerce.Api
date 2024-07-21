using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;

        }

        public async Task<OrderItemResponseDto> CreateAsync(OrderItemRequestDto orderItemRequestDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemRequestDto);
            await _orderItemRepository.CreateAsync(orderItem);
            return _mapper.Map<OrderItemResponseDto>(orderItem);

        }
        public async Task UpdateAsync(int id, OrderItemRequestDto orderItemRequestDto)
        {
            var orderItem = await _orderItemRepository.GetAsync(id);
            if (orderItem != null)
            {
                _mapper.Map(orderItemRequestDto, orderItem);
                _orderItemRepository.UpdateAsync(orderItem);
            }
        }


        public async Task DeleteAsync(OrderItemRequestDto orderItemRequestDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemRequestDto);
            await _orderItemRepository.DeleteAsync(orderItem);
        }

        public async Task<List<OrderItemResponseDto>> GetAllAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();

            return _mapper.Map<List<OrderItemResponseDto>>(orderItems);
        }

        public async Task<OrderItemResponseDto> GetAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetAsync(id);

            return _mapper.Map<OrderItemResponseDto>(orderItem);
        }

        public async Task SaveChanges()
        {
            await _orderItemRepository.SaveChanges();
        }
    }
}
