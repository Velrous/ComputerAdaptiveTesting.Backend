using ComputerAdaptiveTesting.Backend.Domain.Entities.Tests;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using ComputerAdaptiveTesting.Backend.WebApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace ComputerAdaptiveTesting.Backend.WebApi.Controllers
{
    /// <summary>
    /// Web Api контроллер для работы с тестированием
    /// </summary>
    [HttpBearerAuthorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        #region Логгер

        private readonly ILogger<TestsController> _logger;

        #endregion

        #region Сервисы

        private readonly ITestService _testService;

        #endregion

        /// <summary>
        /// Web Api контроллер для работы с тестированием
        /// </summary>
        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;

            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _testService = kernel.Get<ITestService>();

            #endregion
        }

        [HttpPost]
        [Route("Create")]
        public void Create(TestWeb newTest)
        {
            var test = 1;
        }
    }
}
