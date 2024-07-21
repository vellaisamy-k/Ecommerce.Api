using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Services.ISevices;
using Ecommerce.Api.Models;

namespace Ecommerce.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }

        public async Task<OrderResponseDto> CreateAsync(OrderRequestDto orderRequestDto)
        {
            var order = _mapper.Map<Order>(orderRequestDto);
            await _orderRepository.CreateAsync(order);
            return _mapper.Map<OrderResponseDto>(order);

        }
        public async Task UpdateAsync(int id, OrderRequestDto orderRequestDto)
        {
            var order = await _orderRepository.GetAsync(id);
            if (order != null)
            {
                _mapper.Map(orderRequestDto, order);
                _orderRepository.UpdateAsync(order);
            }
        }

        public async Task DeleteAsync(OrderRequestDto orderRequestDto)
        {
            var order = _mapper.Map<Order>(orderRequestDto);
            await _orderRepository.DeleteAsync(order);
        }

        public async Task<List<OrderResponseDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<List<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto> GetAsync(int id)
        {
            var order = await _orderRepository.GetAsync(id);

            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task SaveChanges()
        {
            await _orderRepository.SaveChanges();
        }

    }
}
