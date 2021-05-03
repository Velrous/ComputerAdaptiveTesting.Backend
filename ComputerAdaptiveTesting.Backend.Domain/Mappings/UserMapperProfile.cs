using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserMapperProfile : AutoMapper.Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDao, User>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Login, a => a.MapFrom(p => p.Login))
                .ForMember(p => p.PasswordHash, a => a.MapFrom(p => p.PasswordHash))
                .ForMember(p => p.Salt, a => a.MapFrom(p => p.Salt))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.RoleId, a => a.MapFrom(p => p.RoleId))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
