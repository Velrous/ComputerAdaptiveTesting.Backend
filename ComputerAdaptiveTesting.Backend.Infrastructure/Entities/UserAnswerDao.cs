using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Ответ пользователя на вопрос
    /// </summary>
    public class UserAnswerDao : EntityWithIdDao<long>
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
        /// Идентификатор вопроса
        /// </summary>
        public long QuestionId { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public QuestionDao Question { get; set; }
        /// <summary>
        /// Идентификатор ответа на вопрос
        /// </summary>
        public long? AnswerId { get; set; }
        /// <summary>
        /// Ответ на вопрос
        /// </summary>
        public AnswerDao Answer { get; set; }
        /// <summary>
        /// Json ответа на вопрос
        /// </summary>
        [MaxLength]
        public string Json { get; set; }
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
        /// Время затраченное на ответ
        /// </summary>
        public DateTime? ElapsedTime { get; set; }
    }
}
