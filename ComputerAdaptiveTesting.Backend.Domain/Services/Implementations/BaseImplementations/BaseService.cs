﻿using System;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.BaseImplementations
{
    /// <summary>
    /// Абстрактный базовый UnitOfWork-сервис
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        #region IDisposable

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
