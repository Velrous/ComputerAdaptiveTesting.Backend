using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupOptionRelations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы со связями тестов, групп и настроек
    /// </summary>
    public interface ITestGroupOptionRelationService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса связей тестов, групп и настроек
        /// </summary>
        /// <returns>Интерфейс для запроса связей тестов, групп и настроек</returns>
        IQueryable<TestGroupOptionRelation> GetQueryable();
    }
}
