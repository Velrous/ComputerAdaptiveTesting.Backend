using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Answers;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с ответами пользователей
    /// </summary>
    public interface IAnswerService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса ответов пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса ответов пользователей</returns>
        IQueryable<Answer> GetQueryable();
    }
}
