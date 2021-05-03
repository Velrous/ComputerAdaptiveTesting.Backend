using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.UserTests
{
    /// <summary>
    /// Тест выбранный пользователем
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserTest : IEntityWithId<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        [JsonProperty(PropertyName = "Id")]
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор теста
        /// </summary>
        [Display(Name = "Id теста")]
        [DataMember]
        [JsonProperty(PropertyName = "TestId")]
        public long TestId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Display(Name = "Id пользователя")]
        [DataMember]
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        /// <summary>
        /// Дата и время создания
        /// </summary>
        [Display(Name = "Дата и время создания")]
        [DataMember]
        [JsonProperty(PropertyName = "Created")]
        public DateTime Created { get; set; }
        /// <summary>
        /// Дата и время начала теста
        /// </summary>
        [Display(Name = "Дата и время начала теста")]
        [DataMember]
        [JsonProperty(PropertyName = "Start")]
        public DateTime? Start { get; set; }
        /// <summary>
        /// Дата и время завершения теста
        /// </summary>
        [Display(Name = "Дата и время завершения теста")]
        [DataMember]
        [JsonProperty(PropertyName = "Finish")]
        public DateTime? Finish { get; set; }
        /// <summary>
        /// Затраченное время на выполнение теста
        /// </summary>
        [Display(Name = "Затраченное время на выполнение теста")]
        [DataMember]
        [JsonProperty(PropertyName = "ElapsedTime")]
        public DateTime? ElapsedTime { get; set; }
        /// <summary>
        /// Завершен?
        /// </summary>
        [Display(Name = "Завершен?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsFinish")]
        public bool IsFinish { get; set; }
    }
}
