using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;

        }

        public async Task<ShipmentResponseDto> CreateAsync(ShipmentRequestDto shipmentRequestDto)
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequestDto);
            await _shipmentRepository.CreateAsync(shipment);
            return _mapper.Map<ShipmentResponseDto>(shipment);

        }
        public async Task UpdateAsync(int id, ShipmentRequestDto shipmentRequestDto)
        {
            var shipment = await _shipmentRepository.GetAsync(id);
            if (shipment != null)
            {
                _mapper.Map(shipmentRequestDto, shipment);

                _shipmentRepository.UpdateAsync(shipment);
            }
        }

        public async Task DeleteAsync(ShipmentRequestDto shipmentRequestDto)
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequestDto);
            await _shipmentRepository.DeleteAsync(shipment);
        }

        public async Task<List<ShipmentResponseDto>> GetAllAsync()
        {
            var shipments = await _shipmentRepository.GetAllAsync();

            return _mapper.Map<List<ShipmentResponseDto>>(shipments);
        }

        public async Task<ShipmentResponseDto> GetAsync(int id)
        {
            var shipment = await _shipmentRepository.GetAsync(id);

            return _mapper.Map<ShipmentResponseDto>(shipment);
        }

        public async Task SaveChanges()
        {
            await _shipmentRepository.SaveChanges();
        }
    }
}
