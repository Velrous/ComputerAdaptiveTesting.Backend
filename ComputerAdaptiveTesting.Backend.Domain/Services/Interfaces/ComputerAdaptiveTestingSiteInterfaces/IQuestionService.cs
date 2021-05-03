using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Questions;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с вопросами
    /// </summary>
    public interface IQuestionService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса вопросов
        /// </summary>
        /// <returns>Интерфейс для запроса вопросов</returns>
        IQueryable<Question> GetQueryable();
    }
}
