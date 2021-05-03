using System;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Тест выбранный пользователем
    /// </summary>
    public class UserTestDao : EntityWithIdDao<long>
    {
        /// <summary>
        /// Идентификатор теста
        /// </summary>
        public long TestId { get; set; }
        /// <summary>
        /// Тест
        /// </summary>
        public TestDao Test { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }
        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Дата и время начала теста
        /// </summary>
        public DateTime? Start { get; set; }
        /// <summary>
        /// Дата и время завершения теста
        /// </summary>
        public DateTime? Finish { get; set; }
        /// <summary>
        /// Затраченное время на выполнение теста
        /// </summary>
        public DateTime? ElapsedTime { get; set; }
        /// <summary>
        /// Завершен?
        /// </summary>
        public bool IsFinish { get; set; }
    }
}
