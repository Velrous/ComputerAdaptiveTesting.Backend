using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.UserTests;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с тестами выбранными пользователями
    /// </summary>
    public interface IUserTestService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса тестов выбранных пользователями
        /// </summary>
        /// <returns>Интерфейс для запроса тестов выбранных пользователями</returns>
        IQueryable<UserTest> GetQueryable();
    }
}
