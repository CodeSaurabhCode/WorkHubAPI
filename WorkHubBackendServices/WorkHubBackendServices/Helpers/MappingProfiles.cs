using AutoMapper;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Item, ItemToReturnDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
        }
    }
}
