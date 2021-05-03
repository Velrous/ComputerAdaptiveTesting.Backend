using ComputerAdaptiveTesting.Backend.Domain.Entities.UserTests;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserTestMapperProfile : AutoMapper.Profile
    {
        public UserTestMapperProfile()
        {
            CreateMap<UserTestDao, UserTest>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.TestId, a => a.MapFrom(p => p.TestId))
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.Created, a => a.MapFrom(p => p.Created))
                .ForMember(p => p.Start, a => a.MapFrom(p => p.Start))
                .ForMember(p => p.Finish, a => a.MapFrom(p => p.Finish))
                .ForMember(p => p.ElapsedTime, a => a.MapFrom(p => p.ElapsedTime))
                .ForMember(p => p.IsFinish, a => a.MapFrom(p => p.IsFinish))
                ;
        }
    }
}
