using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Answers
{
    /// <summary>
    /// Ответ на вопрос для фронта
    /// </summary>
    [DataContract]
    [Serializable]
    public class AnswerWeb : IEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Правильный ответ?
        /// </summary>
        [Display(Name = "Правильный ответ?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsRight")]
        public bool IsRight { get; set; }
    }
}
