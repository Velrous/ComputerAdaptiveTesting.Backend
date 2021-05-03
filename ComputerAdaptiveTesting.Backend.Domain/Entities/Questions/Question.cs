using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Questions
{
    /// <summary>
    /// Вопрос
    /// </summary>
    [DataContract]
    [Serializable]
    public class Question : IEntityWithId<long>
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
        /// Json
        /// </summary>
        [Display(Name = "Json")]
        [DataMember]
        [JsonProperty(PropertyName = "Json")]
        public string Json { get; set; }
        /// <summary>
        /// Уровень вопроса
        /// </summary>
        [Display(Name = "Уровень вопроса")]
        [DataMember]
        [JsonProperty(PropertyName = "Level")]
        public int Level { get; set; }
        /// <summary>
        /// Секция вопроса
        /// </summary>
        [Display(Name = "Секция вопроса")]
        [DataMember]
        [JsonProperty(PropertyName = "Section")]
        public int? Section { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Display(Name = "Id пользователя")]
        [DataMember]
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор типа вопроса
        /// </summary>
        [Display(Name = "Id типа вопроса")]
        [DataMember]
        [JsonProperty(PropertyName = "QuestionTypeId")]
        public int QuestionTypeId { get; set; }
        /// <summary>
        /// Дата и время создания
        /// </summary>
        [Display(Name = "Дата и время создания")]
        [DataMember]
        [JsonProperty(PropertyName = "Created")]
        public DateTime Created { get; set; }
        /// <summary>
        /// Время ответа на вопрос
        /// </summary>
        [Display(Name = "Время ответа на вопрос")]
        [DataMember]
        [JsonProperty(PropertyName = "Time")]
        public DateTime? Time { get; set; }
        /// <summary>
        /// Активен?
        /// </summary>
        [Display(Name = "Активен?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
    }
}
