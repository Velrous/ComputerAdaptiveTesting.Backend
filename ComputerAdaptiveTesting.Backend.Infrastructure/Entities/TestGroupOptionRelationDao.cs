using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Связь теста, группы и настройки
    /// </summary>
    public class TestGroupOptionRelationDao : EntityDao
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
        /// Идентификатор группы
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public GroupDao Group { get; set; }
        /// <summary>
        /// Идентификатор настройки
        /// </summary>
        public int OptionId { get; set; }
        /// <summary>
        /// Настройка
        /// </summary>
        public OptionDao Option { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        [MaxLength(32)]
        public string Value { get; set; }
        /// <summary>
        /// Активна?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
