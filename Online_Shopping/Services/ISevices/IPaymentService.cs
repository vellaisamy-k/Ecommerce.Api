using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreateAsync(PaymentRequestDto paymentRequestDto);
        Task DeleteAsync(PaymentRequestDto paymentRequestDto);
        Task<List<PaymentResponseDto>> GetAllAsync();
        Task<PaymentResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, PaymentRequestDto paymentRequestDto);
    }
}
