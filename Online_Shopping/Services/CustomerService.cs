using AutoMapper;
using Ecommerce.Api.DTOs;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;
using Ecommerce.Api.Repositories.IRepository;
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

        public async Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);           
            await _customerRepository.CreateAsync(customer);
            await SaveChanges();

            return _mapper.Map<CustomerResponseDto>(customer);

        }
        public async Task UpdateAsync(int id, CustomerRequestDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            var res = await _customerRepository.GetAsync(id);

            var cus =  _mapper.Map<Customer>(res);

               _customerRepository.UpdateAsync(id, cus);
            //await SaveChanges();           
        }


        public async Task DeleteAsync(CustomerRequestDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.DeleteAsync(customer);
            await SaveChanges();
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
