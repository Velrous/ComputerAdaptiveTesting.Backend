using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
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
    /// Сервис работы с ролями пользователей
    /// </summary>
    public class RoleService : BaseService, IRoleService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<RoleDao, int> _roleRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с ролями пользователей
        /// </summary>
        public RoleService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _roleRepository = kernel.Get<IEntityWithIdRepository<RoleDao, int>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса брендов
        /// </summary>
        /// <returns>Интерфейс для запроса брендов</returns>
        public IQueryable<Role> GetQueryable()
        {
            var roleQueryable = _roleRepository.GetQueryable().Where(x=>x.IsActive).Where(x=>x.IsView);
            return _mapper.ProjectTo<Role>(roleQueryable);
        }
    }
}
