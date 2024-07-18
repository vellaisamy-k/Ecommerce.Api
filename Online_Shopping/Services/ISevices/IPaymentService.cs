using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreateAsync(CartRequestDto CartDto);
        Task DeleteAsync(CartRequestDto CartDto);
        Task<List<CartResponseDto>> GetAllAsync();
        Task<CartResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, CartRequestDto CartDto);
    }
}
