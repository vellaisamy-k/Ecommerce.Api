using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;

        }

        public async Task<PaymentResponseDto> CreateAsync(PaymentRequestDto paymentRequestDto)
        {
            var payment = _mapper.Map<Payment>(paymentRequestDto);
            await _paymentRepository.CreateAsync(payment);            
            return _mapper.Map<PaymentResponseDto>(payment);

        }
        public async Task UpdateAsync(int id, PaymentRequestDto paymentRequestDto)
        {
            var payment = await _paymentRepository.GetAsync(id);

            if (payment != null)
            {
                _mapper.Map(paymentRequestDto, payment);
                _paymentRepository.UpdateAsync(payment);
            }
        }

        public async Task DeleteAsync(PaymentRequestDto paymentRequestDto)
        {
            var payment = _mapper.Map<Payment>(paymentRequestDto);
            await _paymentRepository.DeleteAsync(payment);          
        }

        public async Task<List<PaymentResponseDto>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();

            return _mapper.Map<List<PaymentResponseDto>>(payments);
        }

        public async Task<PaymentResponseDto> GetAsync(int id)
        {
            var payment = await _paymentRepository.GetAsync(id);

            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task SaveChanges()
        {
            await _paymentRepository.SaveChanges();
        }
    }
}
