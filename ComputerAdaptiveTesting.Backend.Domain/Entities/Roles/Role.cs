using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Roles
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class Role : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Активна?
        /// </summary>
        [Display(Name = "Активна?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
        /// <summary>
        /// Для отображения?
        /// </summary>
        [Display(Name = "Для отображения?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsView")]
        public bool IsView { get; set; }
    }
}
