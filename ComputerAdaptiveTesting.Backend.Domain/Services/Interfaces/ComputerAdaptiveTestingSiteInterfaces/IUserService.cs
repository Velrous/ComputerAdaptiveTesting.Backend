using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Auth;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с пользователями
    /// </summary>
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// Создаёт или редактирует пользователя
        /// </summary>
        /// <returns>Интерфейс для создания или редактирования пользователя</returns>
        void SaveUser(EditUser editUser);
        /// <summary>
        /// Возвращает интерфейс для запроса пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей</returns>
        IQueryable<User> GetQueryable();
        /// <summary>
        /// Возвращает интерфейс для запроса пользователей без пароля и соли
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей без пароля и соли</returns>
        IQueryable<UserCard> GetQueryableForView();
        /// <summary>
        /// Ищет пользователя по его логину и паролю
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь</returns>
        AuthInfo GetByLoginAndPassword(string login, string password);

        /// <summary>
        /// Ищет пользователя по его токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Пользователь</returns>
        User GetUserByToken(string token);
    }
}
