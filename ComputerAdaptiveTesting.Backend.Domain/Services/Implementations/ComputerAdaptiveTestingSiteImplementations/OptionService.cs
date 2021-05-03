using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Options;
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
    /// Сервис работы с настройками
    /// </summary>
    public class OptionService : BaseService, IOptionService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<OptionDao, int> _optionRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с настройками
        /// </summary>
        public OptionService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _optionRepository = kernel.Get<IEntityWithIdRepository<OptionDao, int>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса настроек
        /// </summary>
        /// <returns>Интерфейс для запроса настроек</returns>
        public IQueryable<Option> GetQueryable()
        {
            var optionQueryable = _optionRepository.GetQueryable();
            return _mapper.ProjectTo<Option>(optionQueryable);
        }
    }
}
