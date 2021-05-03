using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.UserAnswers
{
    /// <summary>
    /// Ответ пользователя на вопрос 
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserAnswer : IEntityWithId<long>
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
        /// Идентификатор вопроса
        /// </summary>
        [Display(Name = "Id вопроса")]
        [DataMember]
        [JsonProperty(PropertyName = "QuestionId")]
        public long QuestionId { get; set; }
        /// <summary>
        /// Идентификатор ответа на вопрос
        /// </summary>
        [Display(Name = "Id ответа на вопрос")]
        [DataMember]
        [JsonProperty(PropertyName = "AnswerId")]
        public long? AnswerId { get; set; }
        /// <summary>
        /// Json ответа на вопрос
        /// </summary>
        [Display(Name = "Id Json ответа на вопрос")]
        [DataMember]
        [JsonProperty(PropertyName = "Json")]
        public string Json { get; set; }
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
        /// Время затраченное на ответ
        /// </summary>
        [Display(Name = "Время затраченное на ответ")]
        [DataMember]
        [JsonProperty(PropertyName = "ElapsedTime")]
        public DateTime? ElapsedTime { get; set; }
    }
}
