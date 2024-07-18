using AutoMapper;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Repositories.IRepository;
using Ecommerce.Api.Models;
using Ecommerce.Api.Services.ISevices;

namespace Ecommerce.Api.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _ShipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IShipmentRepository ShipmentRepository, IMapper mapper)
        {
            _ShipmentRepository = ShipmentRepository;
            _mapper = mapper;

        }

        public async Task<ShipmentResponseDto> CreateAsync(ShipmentRequestDto ShipmentDto)
        {
            var Shipment = _mapper.Map<Shipment>(ShipmentDto);
            await _ShipmentRepository.CreateAsync(Shipment);
            await SaveChanges();

            return _mapper.Map<ShipmentResponseDto>(Shipment);

        }
        public async Task UpdateAsync(int id, ShipmentRequestDto ShipmentDto)
        {
            var Shipment = _mapper.Map<Shipment>(ShipmentDto);

            var res = await _ShipmentRepository.GetAsync(id);

            var cus = _mapper.Map<Shipment>(res);

            _ShipmentRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(ShipmentRequestDto ShipmentDto)
        {
            var Shipment = _mapper.Map<Shipment>(ShipmentDto);
            await _ShipmentRepository.DeleteAsync(Shipment);
            await SaveChanges();
        }

        public async Task<List<ShipmentResponseDto>> GetAllAsync()
        {
            var Shipments = await _ShipmentRepository.GetAllAsync();

            return _mapper.Map<List<ShipmentResponseDto>>(Shipments);
        }

        public async Task<ShipmentResponseDto> GetAsync(int id)
        {
            var Shipment = await _ShipmentRepository.GetAsync(id);

            return _mapper.Map<ShipmentResponseDto>(Shipment);
        }

        //public bool IsRecordExists(ShipmentRequestDto ShipmentDto)
        //{
        //    return _ShipmentRepository.IsRecordExists(x => x.n.ToLower().Trim() == ShipmentDto.Email.ToLower().Trim());
        //}

        public async Task SaveChanges()
        {
            await _ShipmentRepository.SaveChanges();
        }
    }
}
