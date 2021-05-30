using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Auth;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace ComputerAdaptiveTesting.Backend.WebApi.Controllers
{
    /// <summary>
    /// Web Api контроллер для авторизации
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        #region Логгер

        private readonly ILogger<AuthController> _logger;

        #endregion

        #region Сервисы

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        #endregion

        /// <summary>
        /// Web Api контроллер для авторизации
        /// </summary>
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;

            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _userService = kernel.Get<IUserService>();
            _roleService = kernel.Get<IRoleService>();

            #endregion
        }

        [HttpPost, AllowAnonymous]
        [Route("Login")]
        public AuthInfo Login(LoginModel model)
        {
            return _userService.GetByLoginAndPassword(model.Login, model.Password);
        }

        [HttpPost, AllowAnonymous]
        [Route("Register")]
        public void Register(EditUser editUser)
        { 
            _userService.SaveUser(editUser);
        }

        [HttpGet, AllowAnonymous]
        [Route("Roles")]
        public IQueryable<Role> Get()
        {
            return _roleService.GetQueryable();
        }

        [HttpPost, AllowAnonymous]
        [Route("ValidateToken")]
        public bool ValidateToken(TokenModel token)
        {
            var user = _userService.GetUserByToken(token.Token);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
