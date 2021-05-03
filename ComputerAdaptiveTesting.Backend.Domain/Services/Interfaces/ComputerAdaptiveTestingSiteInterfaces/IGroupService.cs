using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Groups;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с группами
    /// </summary>
    public interface IGroupService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса групп
        /// </summary>
        /// <returns>Интерфейс для запроса групп</returns>
        IQueryable<Group> GetQueryable();
    }
}
