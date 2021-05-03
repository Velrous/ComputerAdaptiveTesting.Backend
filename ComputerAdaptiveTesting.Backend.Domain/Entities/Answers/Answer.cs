using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Answers
{
    /// <summary>
    /// Ответ на вопрос
    /// </summary>
    [DataContract]
    [Serializable]
    public class Answer : IEntityWithId<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        [JsonProperty(PropertyName = "Id")]
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        [Display(Name = "Id вопроса")]
        [DataMember]
        [JsonProperty(PropertyName = "QuestionId")]
        public long QuestionId { get; set; }
        /// <summary>
        /// Json
        /// </summary>
        [Display(Name = "Json")]
        [DataMember]
        [JsonProperty(PropertyName = "Json")]
        public string Json { get; set; }
        /// <summary>
        /// Правильный ответ?
        /// </summary>
        [Display(Name = "Правильный ответ?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsRight")]
        public bool IsRight { get; set; }
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
    }
}
