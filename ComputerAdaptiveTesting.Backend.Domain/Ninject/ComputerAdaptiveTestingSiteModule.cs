using AutoMapper;
using ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.ComputerAdaptiveTestingSiteImplementations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using ComputerAdaptiveTesting.Backend.Infrastructure.Contexts;
using ComputerAdaptiveTesting.Backend.Infrastructure.Repositories.Implementations.BaseImplementations;
using ComputerAdaptiveTesting.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject;
using Ninject.Modules;

namespace ComputerAdaptiveTesting.Backend.Domain.Ninject
{
    /// <summary>
    /// Модуль, который определяет привязки для системы.
    /// </summary>
    public class ComputerAdaptiveTestingSiteModule : NinjectModule
    {
        public ComputerAdaptiveTestingSiteModule()
        {
        }

        public override void Load()
        {
            AddContextBindings();
            AddRepositoryBindings();
            AddServiceBindings();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx =>
                new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        /// <summary>
        /// Добавляем связи реализаций сервисов и их интерфейсов
        /// </summary>
        public void AddContextBindings()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var computerAdaptiveTestingConnectionString = configuration.GetConnectionString("ComputerAdaptiveTestingSiteConnectionString");

            var computerAdaptiveTestingOptionsBuilder = new DbContextOptionsBuilder<ComputerAdaptiveTestingSiteContext>();
            var computerAdaptiveTestingOptions = computerAdaptiveTestingOptionsBuilder
                .UseSqlServer(computerAdaptiveTestingConnectionString)
                .Options;

            Bind<ComputerAdaptiveTestingSiteContext>().ToSelf().InTransientScope()
                .WithConstructorArgument("options", computerAdaptiveTestingOptions);
        }

        /// <summary>
        /// Добавляем связи реализаций репозиториев и их интерфейсов EF контекста
        /// </summary>
        private void AddRepositoryBindings()
        {
            Bind(typeof(IEntityRepository<>)).To(typeof(EntityRepository<>));
            Bind(typeof(IEntityWithIdRepository<,>)).To(typeof(EntityWithIdRepository<,>));
            Bind(typeof(IReadOnlyEntityRepository<>)).To(typeof(ReadOnlyEntityRepository<>));
            Bind(typeof(IReadOnlyEntityWithIdRepository<,>)).To(typeof(ReadOnlyEntityWithIdRepository<,>));
        }

        /// <summary>
        /// Добавляем связи реализаций сервисов и их интерфейсов
        /// </summary>
        public void AddServiceBindings()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            //Bind<IBrandService>().To<BrandService>();
        }

        /// <summary>
        /// Создаём конфигурацию для AutoMapper
        /// </summary>
        /// <returns></returns>
        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddMaps(GetType().Assembly);
            });
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
