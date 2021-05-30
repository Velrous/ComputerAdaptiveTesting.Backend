using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Токен авторизации пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserToken : IEntity
    {
        /// <summary>
        /// Токен
        /// </summary>
        [Display(Name = "Токен")]
        [DataMember]
        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Display(Name = "Id пользователя")]
        [DataMember]
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }
        /// <summary>
        /// Дата окончания действия пользователя
        /// </summary>
        [Display(Name = "Дата окончания действия пользователя")]
        [DataMember]
        [JsonProperty(PropertyName = "ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
