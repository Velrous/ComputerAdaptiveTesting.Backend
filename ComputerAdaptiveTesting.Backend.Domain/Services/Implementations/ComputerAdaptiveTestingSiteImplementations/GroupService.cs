using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Groups;
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
    /// Сервис работы с группами
    /// </summary>
    public class GroupService : BaseService, IGroupService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<GroupDao, int> _groupRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с группами
        /// </summary>
        public GroupService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _groupRepository = kernel.Get<IEntityWithIdRepository<GroupDao, int>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса групп
        /// </summary>
        /// <returns>Интерфейс для запроса групп</returns>
        public IQueryable<Group> GetQueryable()
        {
            var groupQueryable = _groupRepository.GetQueryable();
            return _mapper.ProjectTo<Group>(groupQueryable);
        }
    }
}
