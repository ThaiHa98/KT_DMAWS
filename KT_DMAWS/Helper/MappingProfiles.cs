using AutoMapper;
using KT_DMAWS.Dto;
using KT_DMAWS.Model;

namespace KT_DMAWS.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Order,OrderDto>();
        }
    }
}
