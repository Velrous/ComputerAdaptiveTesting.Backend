namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Связь пользователей и группы
    /// </summary>
    public class UserGroupRelationDao : EntityDao
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public GroupDao Group { get; set; }
    }
}
