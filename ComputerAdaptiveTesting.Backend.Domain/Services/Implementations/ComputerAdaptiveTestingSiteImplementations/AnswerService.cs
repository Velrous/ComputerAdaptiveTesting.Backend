using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Answers;
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
    /// Сервис работы с ответами пользователей
    /// </summary>
    public class AnswerService : BaseService, IAnswerService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<AnswerDao, long> _answerRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с ответами пользователей
        /// </summary>
        public AnswerService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _answerRepository = kernel.Get<IEntityWithIdRepository<AnswerDao, long>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Возвращает интерфейс для запроса ответов пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса ответов пользователей</returns>
        public IQueryable<Answer> GetQueryable()
        {
            var answerQueryable = _answerRepository.GetQueryable();
            return _mapper.ProjectTo<Answer>(answerQueryable);
        }
    }
}
