using ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupOptionRelations;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class TestGroupOptionRelationMapperProfile : AutoMapper.Profile
    {
        public TestGroupOptionRelationMapperProfile()
        {
            CreateMap<TestGroupOptionRelationDao, TestGroupOptionRelation>()
                .ForMember(p => p.TestId, a => a.MapFrom(p => p.TestId))
                .ForMember(p => p.GroupId, a => a.MapFrom(p => p.GroupId))
                .ForMember(p => p.OptionId, a => a.MapFrom(p => p.OptionId))
                .ForMember(p => p.Value, a => a.MapFrom(p => p.Value))
                .ForMember(p => p.IsActive, a => a.MapFrom(p => p.IsActive))
                ;
        }
    }
}
