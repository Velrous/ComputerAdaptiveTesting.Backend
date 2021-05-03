using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.QuestionTypes;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с типами вопросов
    /// </summary>
    public interface IQuestionTypeService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса типов вопросов
        /// </summary>
        /// <returns>Интерфейс для запроса типов вопросов</returns>
        IQueryable<QuestionType> GetQueryable();
    }
}
