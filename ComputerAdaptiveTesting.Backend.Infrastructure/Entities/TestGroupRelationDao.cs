namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Связь теста и группы
    /// </summary>
    public class TestGroupRelationDao : EntityDao
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
    }
}
