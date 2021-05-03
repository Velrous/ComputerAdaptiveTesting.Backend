using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.UserGroupRelations
{
    /// <summary>
    /// Связь пользователя и группы
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserGroupRelation : IEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Display(Name = "Id пользователя")]
        [DataMember]
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        [Display(Name = "Id группы")]
        [DataMember]
        [JsonProperty(PropertyName = "GroupId")]
        public int GroupId { get; set; }
    }
}
