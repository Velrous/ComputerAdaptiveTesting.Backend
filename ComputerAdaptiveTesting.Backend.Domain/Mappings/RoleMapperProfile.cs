using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class RoleMapperProfile : AutoMapper.Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<RoleDao, Role>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                .ForMember(p=>p.IsView, a=>a.MapFrom(p=>p.IsView))
                ;
        }
    }
}
