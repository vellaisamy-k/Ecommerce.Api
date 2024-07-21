using AutoMapper;
using Ecommerce.Api.DTOs;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Services.ISevices;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace Ecommerce.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        public async Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerRequestDto)
        {
            var customer = _mapper.Map<Customer>(customerRequestDto);
            await _customerRepository.CreateAsync(customer);
            return _mapper.Map<CustomerResponseDto>(customer);

        }
        public async Task UpdateAsync(int id, CustomerRequestDto customerRequestDto)
        {
            var customer = await _customerRepository.GetAsync(id);

            if (customer != null)
            {
                _mapper.Map(customerRequestDto, customer);
                _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task DeleteAsync(CustomerRequestDto customerRequestDto)
        {
            var customer = _mapper.Map<Customer>(customerRequestDto);
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task<List<CustomerResponseDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomerResponseDto>>(customers);
        }

        public async Task<CustomerResponseDto> GetAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(id);

            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public bool IsRecordExists(CustomerRequestDto customerDto)
        {
            return _customerRepository.IsRecordExists(x => x.Email.ToLower().Trim() == customerDto.Email.ToLower().Trim());
        }

        public async Task SaveChanges()
        {
            await _customerRepository.SaveChanges();
        }

    }
}
