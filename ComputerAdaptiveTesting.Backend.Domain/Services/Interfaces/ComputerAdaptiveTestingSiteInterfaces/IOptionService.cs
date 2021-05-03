using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Options;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с настроек
    /// </summary>
    public interface IOptionService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса настроек
        /// </summary>
        /// <returns>Интерфейс для запроса настроек</returns>
        IQueryable<Option> GetQueryable();
    }
}
