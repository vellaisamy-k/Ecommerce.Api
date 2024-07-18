using AutoMapper;
using Ecommerce.Api.DTOs;
using Ecommerce.Api.Models;

namespace Ecommerce.Api.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
        }
    }
}
