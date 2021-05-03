using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с ролями пользователей
    /// </summary>
    public interface IRoleService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса ролей пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса ролей пользователей</returns>
        IQueryable<Role> GetQueryable();
    }
}
