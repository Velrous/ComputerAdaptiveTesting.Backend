using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Модель для авторизации
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthModel : IEntity
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [DataMember]
        [JsonProperty(PropertyName = "Login")]
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль")]
        [DataMember]
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }
    }
}
