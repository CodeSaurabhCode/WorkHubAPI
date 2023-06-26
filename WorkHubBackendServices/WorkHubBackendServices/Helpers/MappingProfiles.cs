using AutoMapper;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.Identity;

namespace WorkHubBackEndServices.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Item, ItemToReturnDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<EmployeeDetails, EmployeeDetailsDto>().ReverseMap();
        }
    }
}
