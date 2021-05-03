using ComputerAdaptiveTesting.Backend.Common.Base.Entities;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Базовый абстрактный класс для всех DAO сущностей с идентификатором
    /// </summary>
    public abstract class EntityWithIdDao<TKey> : EntityDao, IEntityWithId<TKey>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TKey Id { get; set; }
    }
}
