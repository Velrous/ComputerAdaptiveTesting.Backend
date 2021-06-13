using System.Collections.Generic;
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
        /// Создаёт новый тест
        /// </summary>
        ///<param name="testWeb">Новый тест</param>
        void CreateTest(TestWeb testWeb);
        /// <summary>
        /// Возвращает интерфейс для запроса тестов
        /// </summary>
        /// <returns>Интерфейс для запроса тестов</returns>
        IQueryable<Test> GetQueryable();

        /// <summary>
        /// Возвращает интерфейс для запроса тестов для фронта
        /// </summary>
        /// <returns>Интерфейс для запроса тестов для фронта</returns>
        List<TestWeb> GetListForWeb();
    }
}
