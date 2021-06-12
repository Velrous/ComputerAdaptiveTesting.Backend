using System;

namespace ComputerAdaptiveTesting.Backend.Common.Base.Contexts
{
    /// <summary>
    /// Контекст сервера
    /// </summary>
    public static class ServerContext
    {
        [ThreadStatic]
        private static int _userId;
        [ThreadStatic]
        private static int _userRoleId;
        [ThreadStatic]
        private static string _userName;
        [ThreadStatic]
        private static string _language;

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public static int UserId
        {
            get
            {
                if (_userId > 0) return _userId;
                return 1; // ETL пользователь
            }
            set
            {
                if (value.Equals(_userId)) return;
                _userId = value;
            }
        }

        /// <summary>
        /// Идентификатор роли пользователя
        /// </summary>
        public static int UserRoleId
        {
            get
            {
                if (_userRoleId > 0) return _userRoleId;
                return 1; // ETL пользователь
            }
            set
            {
                if (value.Equals(_userRoleId)) return;
                _userRoleId = value;
            }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public static string UserName
        {
            get => _userName;
            set
            {
                if (value != null)
                {
                    if (value.Equals(_userName)) return;
                    _userName = value;
                }
                else
                {
                    _userName = string.Empty;
                }
            }
        }

        /// <summary>
        /// Локаль пользователя
        /// </summary>
        public static string Language
        {
            get => _language; //string.IsNullOrWhiteSpace(_language) ? "ru" : _language;
            set
            {
                if (value.Equals(_language)) return;
                _language = value;
            }
        }
    }
}
