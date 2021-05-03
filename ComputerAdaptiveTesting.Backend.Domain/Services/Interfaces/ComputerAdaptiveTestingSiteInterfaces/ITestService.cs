using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Tests;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с тестами
    /// </summary>
    public interface ITestService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса тестов
        /// </summary>
        /// <returns>Интерфейс для запроса тестов</returns>
        IQueryable<Test> GetQueryable();
    }
}
