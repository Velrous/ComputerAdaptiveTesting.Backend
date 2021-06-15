using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Result
{
    /// <summary>
    /// Базовый ответ для фронта
    /// </summary>
    [DataContract]
    [Serializable]
    public class BaseResult : IEntity
    {
        /// <summary>
        /// Текст
        /// </summary>
        [Display(Name = "Текст")]
        [DataMember]
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
    }
}
