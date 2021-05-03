using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Ответ на вопрос
    /// </summary>
    public class AnswerDao : EntityWithIdDao<long>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public long QuestionId { get; set; }
        /// <summary>
        /// Вопрос
        /// </summary>
        public QuestionDao Question { get; set; }
        /// <summary>
        /// Json
        /// </summary>
        [MaxLength]
        public string Json { get; set; }
        /// <summary>
        /// Правильный ответ?
        /// </summary>
        public bool IsRight { get; set; }
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
    }
}
