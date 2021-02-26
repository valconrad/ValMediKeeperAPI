using AutoMapper;
using MediKeeper.API.Models;
using MediKeeper.Domain;

namespace MediKeeper.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Item, AddItemViewModel>().ReverseMap();
        }
    }
}
