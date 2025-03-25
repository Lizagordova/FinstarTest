using AutoMapper;
using Finstar.Domain.Models;
using FinstarTest.Models.Requests;

namespace FinstarTest.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetListRequest, ItemQueryOptions>()
                .ForMember(dest => dest.Page, src => src.MapFrom(opt => opt.Page ?? 1))
                .ForMember(dest => dest.PageSize, src => src.MapFrom(opt => opt.PageSize ?? 10));
        }
    }
}