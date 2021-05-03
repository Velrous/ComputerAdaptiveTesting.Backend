using ComputerAdaptiveTesting.Backend.Domain.Entities.Options;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class OptionMapperProfile : AutoMapper.Profile
    {
        public OptionMapperProfile()
        {
            CreateMap<OptionDao, Option>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
