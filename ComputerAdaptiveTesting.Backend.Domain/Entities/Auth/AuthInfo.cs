using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Данные аутентификации
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthInfo
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
        /// Идентификатор роли
        /// </summary>
        [Display(Name = "Id роли")]
        [DataMember]
        [JsonProperty(PropertyName = "RoleId")]
        public int RoleId { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        [Display(Name = "Роль")]
        [DataMember]
        [JsonProperty(PropertyName = "RoleName")]
        public string RoleName { get; set; }
        /// <summary>
        /// Токен
        /// </summary>
        [Display(Name = "Токен")]
        [DataMember]
        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }
    }
}
