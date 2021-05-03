using ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupRelations;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;

namespace ComputerAdaptiveTesting.Backend.Domain.Mappings
{
    public class TestGroupRelationMapperProfile : AutoMapper.Profile
    {
        public TestGroupRelationMapperProfile()
        {
            CreateMap<TestGroupRelationDao, TestGroupRelation>()
                .ForMember(p => p.TestId, a => a.MapFrom(p => p.TestId))
                .ForMember(p => p.GroupId, a => a.MapFrom(p => p.GroupId))
                ;
        }
    }
}
