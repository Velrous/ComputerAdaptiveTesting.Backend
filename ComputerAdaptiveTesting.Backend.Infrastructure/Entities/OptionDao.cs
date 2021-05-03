﻿using System.ComponentModel.DataAnnotations;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Entities
{
    /// <summary>
    /// Настройка
    /// </summary>
    public class OptionDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// Активна?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
