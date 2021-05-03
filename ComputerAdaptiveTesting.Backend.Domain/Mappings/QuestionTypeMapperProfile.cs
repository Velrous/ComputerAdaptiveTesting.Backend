using ComputerAdaptiveTesting.Backend.Domain.Entities.QuestionTypes;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class QuestionTypeMapperProfile : AutoMapper.Profile
    {
        public QuestionTypeMapperProfile()
        {
            CreateMap<QuestionTypeDao, QuestionType>()
                .ForMember(p => p.Id, a => a.MapFrom(p => p.Id))
                .ForMember(p => p.Name, a => a.MapFrom(p => p.Name))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
