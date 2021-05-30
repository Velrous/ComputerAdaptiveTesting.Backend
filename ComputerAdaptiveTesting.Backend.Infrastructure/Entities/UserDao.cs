using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Логин
        /// </summary>
        [MaxLength(32)]
        public string Login { get; set; }
        /// <summary>
        /// Хэш пароля
        /// </summary>
        [MaxLength(256)]
        public string PasswordHash { get; set; }
        /// <summary>
        /// Соль
        /// </summary>
        [MaxLength(32)]
        public string Salt { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public RoleDao Role { get; set; }
        /// <summary>
        /// Активен?
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Электронный адрес
        /// </summary>
        [MaxLength(64)]
        public string Email { get; set; }
    }
}
