using AutoMapper;
using efcoreRestFull.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Mappers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Product, BasketItemProductDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.imageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.seq, opt => opt.MapFrom(src => src.Seq)).ReverseMap();

        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.imageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.seq, opt => opt.MapFrom(src => src.Seq))
            .ForMember(dest => dest.categoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.stock, opt => opt.MapFrom(src => src.Stock))
            .ForMember(dest => dest.categoryName, opt => opt.MapFrom(src => src.Category)).ReverseMap();

        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest=>dest.id, opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest=>dest.name, opt=>opt.MapFrom(src=>src.Name))
            .ForMember(dest=>dest.email, opt=>opt.MapFrom(src=>src.Email))
            .ForMember(dest=>dest.surname, opt=>opt.MapFrom(src=>src.Surname))
            .ForMember(dest=>dest.password, opt=>opt.MapFrom(src=>src.Password))
            .ForMember(dest=>dest.address, opt=>opt.MapFrom(src=>src.Address)).ReverseMap();
            
        
        CreateMap<BasketItem, BasketItemDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.basketId, opt => opt.MapFrom(src => src.BasketId))
            .ForMember(dest => dest.product, opt => opt.MapFrom(src => src.Product)).ReverseMap();
        
        
    }
}