using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;

namespace Ecommerce.Api.Services.ISevices
{
    public interface IShipmentService
    {
        Task<ShipmentResponseDto> CreateAsync(ShipmentRequestDto ShipmentDto);
        Task DeleteAsync(ShipmentRequestDto ShipmentDto);
        Task<List<ShipmentResponseDto>> GetAllAsync();
        Task<ShipmentResponseDto> GetAsync(int id);
        Task UpdateAsync(int id, ShipmentRequestDto ShipmentDto);
    }
}
