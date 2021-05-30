using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Токен пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class TokenModel
    {
        /// <summary>
        /// Токен
        /// </summary>
        [Display(Name = "Токен")]
        [DataMember]
        [JsonProperty(PropertyName = "Token")]
        public string Token { get; set; }
    }
}
