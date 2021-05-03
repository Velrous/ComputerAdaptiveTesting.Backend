using ComputerAdaptiveTesting.Backend.Domain.Entities.UserGroupRelations;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserGroupRelationMapperProfile : AutoMapper.Profile
    {
        public UserGroupRelationMapperProfile()
        {
            CreateMap<UserGroupRelationDao, UserGroupRelation>()
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.GroupId, a => a.MapFrom(p => p.GroupId))
                ;
        }
    }
}
