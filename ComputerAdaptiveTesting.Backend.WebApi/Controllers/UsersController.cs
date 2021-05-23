using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Auth;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Users;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace ComputerAdaptiveTesting.Backend.WebApi.Controllers
{
    /// <summary>
    /// Web Api контроллер работы с пользователями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        #region Логгер

        private readonly ILogger<UsersController> _logger;

        #endregion

        #region Сервисы



        #endregion

        /// <summary>
        /// Web Api контроллер работы с пользователями
        /// </summary>
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;

            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры требуемых репозиториев



            #endregion
        }
    }
}
