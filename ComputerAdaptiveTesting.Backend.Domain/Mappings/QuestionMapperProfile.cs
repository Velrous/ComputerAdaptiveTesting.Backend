using ComputerAdaptiveTesting.Backend.Domain.Entities.Questions;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class QuestionMapperProfile : AutoMapper.Profile
    {
        public QuestionMapperProfile()
        {
            CreateMap<QuestionDao, Question>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.TestId, a => a.MapFrom(p => p.TestId))
                .ForMember(p => p.Json, a => a.MapFrom(p => p.Json))
                .ForMember(p => p.Level, a => a.MapFrom(p => p.Level))
                .ForMember(p => p.Section, a => a.MapFrom(p => p.Section))
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.QuestionTypeId, a => a.MapFrom(p => p.QuestionTypeId))
                .ForMember(p => p.Created, a => a.MapFrom(p => p.Created))
                .ForMember(p => p.Time, a => a.MapFrom(p => p.Time))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
