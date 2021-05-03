using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class QuestionDao : EntityWithIdDao<long>
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
        /// Json
        /// </summary>
        [MaxLength]
        public string Json { get; set; }
        /// <summary>
        /// Уровень вопроса
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Секция вопроса
        /// </summary>
        public int? Section { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }
        /// <summary>
        /// Идентификатор типа вопроса
        /// </summary>
        public int QuestionTypeId { get; set; }
        /// <summary>
        /// Тип вопроса
        /// </summary>
        public QuestionTypeDao QuestionType { get; set; }
        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Время ответа на вопрос
        /// </summary>
        public DateTime? Time { get; set; }
        /// <summary>
        /// Активен?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
