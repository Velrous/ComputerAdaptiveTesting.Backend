using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserTokenMapperProfile : AutoMapper.Profile
    {
        public UserTokenMapperProfile()
        {
            CreateMap<UserTokenDao, UserToken>()
                .ForMember(p => p.Token, a => a.MapFrom(p => p.Token))
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.ExpirationDate, a => a.MapFrom(p => p.ExpirationDate))
                ;
        }
    }
}
