using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupOptionRelations;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.BaseImplementations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using ComputerAdaptiveTesting.Backend.Infrastructure.Contexts;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;
using ComputerAdaptiveTesting.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Ninject;
using Ninject.Parameters;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.ComputerAdaptiveTestingSiteImplementations
{ 
    /// <summary>
    /// Сервис работы со связями тестов, групп и настроек
    /// </summary>
    public class TestGroupOptionRelationService : BaseService, ITestGroupOptionRelationService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityRepository<TestGroupOptionRelationDao> _testGroupOptionRelationRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы со связями тестов, групп и настроек
        /// </summary>
        public TestGroupOptionRelationService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _testGroupOptionRelationRepository = kernel.Get<IEntityRepository<TestGroupOptionRelationDao>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса связей тестов, групп и настроек
        /// </summary>
        /// <returns>Интерфейс для запроса связей тестов, групп и настроек</returns>
        public IQueryable<TestGroupOptionRelation> GetQueryable()
        {
            var testGroupOptionRelationQueryable = _testGroupOptionRelationRepository.GetQueryable();
            return _mapper.ProjectTo<TestGroupOptionRelation>(testGroupOptionRelationQueryable);
        }
    }
}
