using ComputerAdaptiveTesting.Backend.Domain.Entities.Groups;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class GroupMapperProfile : AutoMapper.Profile
    {
        public GroupMapperProfile()
        {
            CreateMap<GroupDao, Group>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
