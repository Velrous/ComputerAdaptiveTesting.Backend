using ComputerAdaptiveTesting.Backend.Domain.Entities.Answers;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class AnswerMapperProfile : AutoMapper.Profile
    {
        public AnswerMapperProfile()
        {
            CreateMap<AnswerDao, Answer>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.QuestionId, a => a.MapFrom(p => p.QuestionId))
                .ForMember(p => p.Json, a => a.MapFrom(p => p.Json))
                .ForMember(p => p.IsRight, a => a.MapFrom(p => p.IsRight))
                .ForMember(p => p.UserId, a => a.MapFrom(p => p.UserId))
                .ForMember(p => p.Created, a => a.MapFrom(p => p.Created))
                ;
        }
    }
}
