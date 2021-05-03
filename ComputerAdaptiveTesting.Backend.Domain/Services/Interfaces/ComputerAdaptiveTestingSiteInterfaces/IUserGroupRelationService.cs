using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.UserGroupRelations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы со связи групп с пользователями
    /// </summary>
    public interface IUserGroupRelationService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса связей групп с пользователями
        /// </summary>
        /// <returns>Интерфейс для запроса связей групп с пользователями</returns>
        IQueryable<UserGroupRelation> GetQueryable();
    }
}
