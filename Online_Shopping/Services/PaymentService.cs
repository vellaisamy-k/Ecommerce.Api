using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;

        public PaymentService(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;

        }

        public async Task<OrderResponseDto> CreateAsync(OrderRequestDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            await _OrderRepository.CreateAsync(Order);
            await SaveChanges();

            return _mapper.Map<OrderResponseDto>(Order);

        }
        public async Task UpdateAsync(int id, OrderRequestDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);

            var res = await _OrderRepository.GetAsync(id);

            var cus = _mapper.Map<Order>(res);

            _OrderRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(OrderRequestDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            await _OrderRepository.DeleteAsync(Order);
            await SaveChanges();
        }

        public async Task<List<OrderResponseDto>> GetAllAsync()
        {
            var Orders = await _OrderRepository.GetAllAsync();

            return _mapper.Map<List<OrderResponseDto>>(Orders);
        }

        public async Task<OrderResponseDto> GetAsync(int id)
        {
            var Order = await _OrderRepository.GetAsync(id);

            return _mapper.Map<OrderResponseDto>(Order);
        }

        //public bool IsRecordExists(OrderRequestDto OrderDto)
        //{
        //    return _OrderRepository.IsRecordExists(x => x.n.ToLower().Trim() == OrderDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _OrderRepository.SaveChanges();
        }
    }
}
