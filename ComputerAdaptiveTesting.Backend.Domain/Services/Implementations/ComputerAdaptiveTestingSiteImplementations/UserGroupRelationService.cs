using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.UserGroupRelations;
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
    /// Сервис работы со связями групп с пользователями
    /// </summary>
    public class UserGroupRelationService : BaseService, IUserGroupRelationService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityRepository<UserGroupRelationDao> _userGroupRelationRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы со связями групп с пользователями
        /// </summary>
        public UserGroupRelationService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _userGroupRelationRepository = kernel.Get<IEntityRepository<UserGroupRelationDao>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса связей групп с пользователями
        /// </summary>
        /// <returns>Интерфейс для запроса связей групп с пользователями</returns>
        public IQueryable<UserGroupRelation> GetQueryable()
        {
            var userGroupRelationQueryable = _userGroupRelationRepository.GetQueryable();
            return _mapper.ProjectTo<UserGroupRelation>(userGroupRelationQueryable);
        }
    }
}
