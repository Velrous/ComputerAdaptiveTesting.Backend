using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupRelations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы со связями тестов и групп
    /// </summary>
    public interface ITestGroupRelationService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса связей тестов и групп
        /// </summary>
        /// <returns>Интерфейс для запроса связей тестов и групп</returns>
        IQueryable<TestGroupRelation> GetQueryable();
    }
}
