using ComputerAdaptiveTesting.Backend.Domain.Entities.UserAnswers;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class UserAnswerMapperProfile : AutoMapper.Profile
    {
        public UserAnswerMapperProfile()
        {
            CreateMap<UserAnswerDao, UserAnswer>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.TestId, a => a.MapFrom(p => p.TestId))
                .ForMember(p => p.QuestionId, a => a.MapFrom(p => p.QuestionId))
                .ForMember(p => p.AnswerId, a => a.MapFrom(p => p.AnswerId))
                .ForMember(p => p.Json, a => a.MapFrom(p => p.Json))
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.Created, a => a.MapFrom(p => p.Created))
                .ForMember(p => p.ElapsedTime, a => a.MapFrom(p => p.ElapsedTime))
                ;
        }
    }
}
