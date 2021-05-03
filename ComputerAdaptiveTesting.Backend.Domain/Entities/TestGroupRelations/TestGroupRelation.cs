using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.TestGroupRelations
{
    /// <summary>
    /// Связь теста и группы
    /// </summary>
    [DataContract]
    [Serializable]
    public class TestGroupRelation : IEntity
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
    }
}
