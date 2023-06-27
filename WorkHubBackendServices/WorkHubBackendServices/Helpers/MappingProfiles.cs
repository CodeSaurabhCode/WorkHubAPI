using AutoMapper;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.Identity;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Item, ItemToReturnDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<EmployeeDetails, EmployeeDetailsDto>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.OrderType, o => o.MapFrom(s => s.OrderType.TypeName));  
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ItemId, o => o.MapFrom(s => s.ItemOrdered.MenuItemId))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemOrdered.ItemName))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.ItemOrdered.CategoryType));
        }
    }
}
