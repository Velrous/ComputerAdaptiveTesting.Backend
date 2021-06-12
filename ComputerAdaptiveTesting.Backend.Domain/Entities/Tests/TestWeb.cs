using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Questions;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Tests
{
    /// <summary>
    /// Тест для фронта
    /// </summary>
    [DataContract]
    [Serializable]
    public class TestWeb : IEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Список вопросов
        /// </summary>
        [Display(Name = "Список вопросов")]
        [DataMember]
        [JsonProperty(PropertyName = "Questions")]
        public List<QuestionWeb> Questions { get; set; }
    }
}
