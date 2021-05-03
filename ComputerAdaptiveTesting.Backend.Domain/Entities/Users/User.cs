using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ComputerAdaptiveTesting.Backend.Common.Base.Entities;
using Newtonsoft.Json;

namespace ComputerAdaptiveTesting.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [DataContract]
    [Serializable]
    public class User : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [DataMember]
        [JsonProperty(PropertyName = "Login")]
        public string Login { get; set; }
        /// <summary>
        /// Хэш пароля
        /// </summary>
        [Display(Name = "Хэш пароля")]
        [DataMember]
        [JsonProperty(PropertyName = "PasswordHash")]
        public string PasswordHash { get; set; }
        /// <summary>
        /// Соль
        /// </summary>
        [Display(Name = "Соль")]
        [DataMember]
        [JsonProperty(PropertyName = "Salt")]
        public string Salt { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [Display(Name = "ФИО")]
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
        /// Активен?
        /// </summary>
        [Display(Name = "Активен?")]
        [DataMember]
        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
    }
}
