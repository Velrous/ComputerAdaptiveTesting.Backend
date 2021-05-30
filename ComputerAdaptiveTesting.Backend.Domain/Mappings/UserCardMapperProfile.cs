using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserCardMapperProfile : AutoMapper.Profile
    {
        public UserCardMapperProfile()
        {
            CreateMap<UserDao, UserCard>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Login, a => a.MapFrom(p => p.Login))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.RoleId, a => a.MapFrom(p => p.RoleId))
                .ForMember(p => p.Email, a => a.MapFrom(p => p.Email))
                ;
        }
    }
}
