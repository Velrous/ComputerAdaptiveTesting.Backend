using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Answers;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Questions
{
    /// <summary>
    /// Вопрос для фронта
    /// </summary>
    [DataContract]
    [Serializable]
    public class QuestionWeb : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        [JsonProperty(PropertyName = "Id")]
        public long? Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Список ответов
        /// </summary>
        [Display(Name = "Список ответов")]
        [DataMember]
        [JsonProperty(PropertyName = "Answers")]
        public List<AnswerWeb> Answers { get; set; }
    }
}
