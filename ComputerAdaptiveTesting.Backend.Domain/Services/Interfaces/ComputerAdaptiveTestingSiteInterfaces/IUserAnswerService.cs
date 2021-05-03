using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.UserAnswers;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с ответами пользователей на вопросы
    /// </summary>
    public interface IUserAnswerService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса ответов пользователей на вопросы
        /// </summary>
        /// <returns>Интерфейс для запроса ответов пользователей на вопросы</returns>
        IQueryable<UserAnswer> GetQueryable();
    }
}
