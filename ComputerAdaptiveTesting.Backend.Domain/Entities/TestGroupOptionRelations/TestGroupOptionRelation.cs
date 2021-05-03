using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupOptionRelations
{
    /// <summary>
    /// Связь теста, группы и настройки
    /// </summary>
    [DataContract]
    [Serializable]
    public class TestGroupOptionRelation : IEntity
    {
        /// <summary>
        /// Идентификатор теста
        /// </summary>
        [Display(Name = "Id теста")]
        [DataMember]
        [JsonProperty(PropertyName = "TestId")]
        public long TestId { get; set; }
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [Display(Name = "Id группы")]
        [DataMember]
        [JsonProperty(PropertyName = "GroupId")]
        public int GroupId { get; set; }
        /// <summary>
        /// Идентификатор настройки
        /// </summary>
        [Display(Name = "Id настройки")]
        [DataMember]
        [JsonProperty(PropertyName = "OptionId")]
        public int OptionId { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        [Display(Name = "Значение")]
        [DataMember]
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
        /// <summary>
        /// Активна?
        /// </summary>
        [Display(Name = "Активна?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
    }
}
