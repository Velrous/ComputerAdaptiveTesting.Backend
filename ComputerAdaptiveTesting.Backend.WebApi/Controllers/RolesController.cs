using System.Linq;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Roles;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace ComputerAdaptiveTesting.Backend.WebApi.Controllers
{
    /// <summary>
    /// OData Web Api контроллер работы с ролями пользователей
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        #region Логгер

        private readonly ILogger<RolesController> _logger;

        #endregion

        #region Сервисы

        private readonly IRoleService _roleService;

        #endregion

        /// <summary>
        /// OData Web Api контроллер работы с брендами
        /// </summary>
        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;

            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _roleService = kernel.Get<IRoleService>();

            #endregion
        }

        [HttpGet]
        public IQueryable<Role> Get()
        {
            return _roleService.GetQueryable();
        }
    }
}
