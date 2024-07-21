using AutoMapper;
using Ecommerce.Api.DTOs;
using Ecommerce.Api.DTOs.RequestDtos;
using Ecommerce.Api.DTOs.ResponseDto;
using Ecommerce.Api.Models;

namespace Ecommerce.Api.Helper
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<Customer,CustomerRequestDto>().ReverseMap();
            CreateMap<Customer,CustomerResponseDto>().ReverseMap();
            CreateMap<Cart,CartRequestDto>().ReverseMap();
            CreateMap<Cart,CartResponseDto>().ReverseMap();
            CreateMap<Category,CategoryRequestDto>().ReverseMap();
            CreateMap<Category,CategoryResponseDto>().ReverseMap();
            CreateMap<Order,OrderRequestDto>().ReverseMap();
            CreateMap<Order, OrderResponseDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemRequestDto>().ReverseMap();
            CreateMap<OrderItem,OrderItemResponseDto>().ReverseMap();
            CreateMap<Payment,PaymentRequestDto>().ReverseMap();
            CreateMap<Payment, PaymentResponseDto>().ReverseMap();
            CreateMap<Product,ProductRequestDto>().ReverseMap();    
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<Shipment,ShipmentRequestDto>().ReverseMap();
            CreateMap<Shipment, ShipmentResponseDto>().ReverseMap();
            CreateMap<Wishlist, WishlistRequestDto>().ReverseMap();
            CreateMap<Wishlist,WishlistResponseDto>().ReverseMap();
        }
    }
}
