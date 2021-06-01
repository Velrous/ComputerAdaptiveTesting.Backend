using System;
using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Common.Base.Helpers;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Auth;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.BaseImplementations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using ComputerAdaptiveTesting.Backend.Infrastructure.Contexts;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;
using ComputerAdaptiveTesting.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Parameters;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.ComputerAdaptiveTestingSiteImplementations
{
    /// <summary>
    /// Сервис работы с пользователями
    /// </summary>
    public class UserService : BaseService, IUserService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<UserDao, int> _userRepository;
        private readonly IEntityRepository<UserTokenDao> _userTokenRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с пользователями
        /// </summary>
        public UserService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _userRepository = kernel.Get<IEntityWithIdRepository<UserDao, int>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));
            _userTokenRepository = kernel.Get<IEntityRepository<UserTokenDao>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Создаёт пользователя
        /// </summary>
        /// <returns>Интерфейс для создания пользователя</returns>
        public void Create(EditUser editUser)
        {
            if(editUser != null &&  !string.IsNullOrEmpty(editUser.Login))
            {
                if(!_userRepository.GetQueryable().Any(x=>x.Login == editUser.Login))
                {
                    var saltAndPassword = CreatePassword(editUser.Password);
                    var newUser = new UserDao()
                    {
                        Login = editUser.Login,
                        Name = editUser.Name,
                        Email = editUser.Email,
                        PasswordHash = saltAndPassword.passwordHash,
                        Salt = saltAndPassword.salt,
                        RoleId = editUser.RoleId,
                        IsActive = editUser.IsActive
                    };
                    _userRepository.Create(newUser);
                    _computerAdaptiveTestingSiteContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Создаёт или редактирует пользователя
        /// </summary>
        /// <returns>Интерфейс для создания или редактирования пользователя</returns>
        public void SaveUser(EditUser editUser)
        {
            if (editUser != null)
            {
                var userDao = new UserDao();
                if (editUser.Id.HasValue)
                {
                    userDao = _userRepository.GetById(editUser.Id.Value);
                }
                if (editUser.Id == null || userDao == null)
                {
                    var saltAndPassword = CreatePassword(editUser.Password);
                    var newUser = new UserDao()
                    {
                        Login = editUser.Login,
                        Name = editUser.Name,
                        Email = editUser.Email,
                        PasswordHash = saltAndPassword.passwordHash,
                        Salt = saltAndPassword.salt,
                        RoleId = editUser.RoleId,
                        IsActive = editUser.IsActive
                    };
                    _userRepository.Create(newUser);
                    _computerAdaptiveTestingSiteContext.SaveChanges();
                }
                else
                {
                    if (!editUser.IsActive)
                    {
                        userDao.IsActive = false;
                        _userRepository.Update(userDao);
                        _computerAdaptiveTestingSiteContext.SaveChanges();
                    }
                    else
                    {
                        (string salt, string passwordHash) saltAndPassword = (string.Empty, string.Empty);
                        if (!string.IsNullOrEmpty(editUser.Password))
                        {
                            saltAndPassword = CreatePassword(editUser.Password);
                        }
                        userDao.Login = editUser.Login;
                        userDao.Name = editUser.Name;
                        userDao.Email = editUser.Email;
                        userDao.PasswordHash = string.IsNullOrEmpty(saltAndPassword.passwordHash)
                            ? userDao.PasswordHash
                            : saltAndPassword.passwordHash;
                        userDao.Salt = string.IsNullOrEmpty(saltAndPassword.salt)
                            ? userDao.Salt
                            : saltAndPassword.salt;
                        userDao.RoleId = editUser.RoleId;
                        userDao.IsActive = editUser.IsActive;
                        _userRepository.Update(userDao);
                        _computerAdaptiveTestingSiteContext.SaveChanges();
                    }
                }
            }
            else
            {
                throw new Exception("Передан пустой объект");
            }
        }

        /// <summary>
        /// Возвращает интерфейс для запроса пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей</returns>
        public IQueryable<User> GetQueryable()
        {
            var userQueryable = _userRepository.GetQueryable();
            return _mapper.ProjectTo<User>(userQueryable);
        }

        /// <summary>
        /// Возвращает интерфейс для запроса пользователей без пароля и соли
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей без пароля и соли</returns>
        public IQueryable<UserCard> GetQueryableForView()
        {
            var userCardQueryable = _userRepository.GetQueryable().Where(x => x.IsActive);
            return _mapper.ProjectTo<UserCard>(userCardQueryable);
        }

        /// <summary>
        /// Ищет пользователя по его логину и паролю
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь</returns>
        public AuthInfo GetByLoginAndPassword(string login, string password)
        {
            var userDao = _userRepository.GetQueryable()
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Login == login);
            if (userDao != null)
            {
                var passwordHash = Md5Helper.CalculateMd5Hash(userDao.Salt + "$-" + password + "-$" + userDao.Salt);
                if (userDao.PasswordHash == passwordHash && userDao.IsActive)
                {
                    var token = string.Empty;
                    var userTokenList = _userTokenRepository.GetQueryable().Where(x => x.UserId == userDao.Id).ToList();
                    if (userTokenList.Any()) //Если у пользователя есть сохранённые токены
                    {
                        var filteredUserTokenList = userTokenList.Where(x => x.ExpirationDate > DateTime.Now).ToList(); //Фильтруем чтобы найти действующий токен
                        if (filteredUserTokenList.Any()) //Если есть действующие токены
                        {
                            token = filteredUserTokenList.OrderByDescending(x => x.ExpirationDate).First().Token; //Взяли самый длинный по времени действия токен
                        }
                        else //Если нет действующих токенов
                        {
                            _userTokenRepository.DeleteRange(userTokenList); //Удаляем ненужные токены
                            _computerAdaptiveTestingSiteContext.SaveChanges();
                            token = CreateToken(userDao.Id); //Создаём новый токен
                        }
                    }
                    else //Пользователь аутентифицирован, но у него нет токена :(
                    {
                        token = CreateToken(userDao.Id); //Создаём новый токен :)
                    }

                    return new AuthInfo
                    {
                        Id = userDao.Id,
                        Name = userDao.Name,
                        RoleId = userDao.RoleId,
                        RoleName = userDao.Role.Name,
                        Token = token
                    };
                }
            }
            return null; //Аутентификация не прошла
        }

        /// <summary>
        /// Ищет пользователя по его токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Пользователь</returns>
        public User GetUserByToken(string token)
        {
            var userId = _userTokenRepository.GetQueryable().FirstOrDefault(x=> x.Token == token)?.UserId;
            if (userId != null)
            {
                var userDao = _userRepository.GetById(userId.Value);
                if (userDao != null && userDao.IsActive)
                {
                    return _mapper.Map<UserDao, User>(userDao);
                }
            }
            return null;
        }

        private string CreateToken(int userId)
        {
            var token = Md5Helper.CalculateMd5Hash(userId + "/" + Guid.NewGuid());
            var userToken = new UserTokenDao()
            {
                Token = token,
                UserId = userId,
                ExpirationDate = DateTime.Now.AddMonths(1)
            };
            _userTokenRepository.Create(userToken);
            _computerAdaptiveTestingSiteContext.SaveChanges();
            return token;
        }

        private (string salt, string passwordHash) CreatePassword(string password)
        {
            var salt = Md5Helper.CalculateMd5Hash(Guid.NewGuid().ToString()).Substring(0, 8);
            var passwordHash = Md5Helper.CalculateMd5Hash(salt + "$-" + password + "-$" + salt);
            return (salt, passwordHash);
        }
    }
}
