using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerAdaptiveTesting.Backend.Infrastructure.Contexts
{
    /// <summary>
    /// EF DbContext для подключения к БД сайта компьютерного тестирования
    /// </summary>
    public class ComputerAdaptiveTestingSiteContext : BaseDbContext
    {
        #region Наборы сущностей

        ///// <summary>
        ///// Бренды
        ///// </summary>
        //public DbSet<BrandDao> Brands { get; set; }

        /// <summary>
        /// Ответы на вопросы
        /// </summary>
        public DbSet<AnswerDao> Answers { get; set; }
        /// <summary>
        /// Группы
        /// </summary>
        public DbSet<GroupDao> Groups { get; set; }
        /// <summary>
        /// Настройки
        /// </summary>
        public DbSet<OptionDao> Options { get; set; }
        /// <summary>
        /// Вопросы
        /// </summary>
        public DbSet<QuestionDao> Questions { get; set; }
        /// <summary>
        /// Типы вопросов
        /// </summary>
        public DbSet<QuestionTypeDao> QuestionTypes { get; set; }
        /// <summary>
        /// Роли пользователей
        /// </summary>
        public DbSet<RoleDao> Roles { get; set; }
        /// <summary>
        /// Связи тестов, групп и настроек
        /// </summary>
        public DbSet<TestGroupOptionRelationDao> TestGroupOptionRelations { get; set; }
        /// <summary>
        /// Связи тестов и групп
        /// </summary>
        public DbSet<TestGroupRelationDao> TestGroupRelations { get; set; }
        /// <summary>
        /// Тесты
        /// </summary>
        public DbSet<TestDao> Tests { get; set; }
        /// <summary>
        /// Ответы пользователей
        /// </summary>
        public DbSet<UserAnswerDao> UserAnswers { get; set; }
        /// <summary>
        /// Связи пользователей и групп
        /// </summary>
        public DbSet<UserGroupRelationDao> UserGroupRelations { get; set; }
        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<UserDao> Users { get; set; }
        /// <summary>
        /// Тесты пользователей
        /// </summary>
        public DbSet<UserTestDao> UserTests { get; set; }


        #endregion

        /// <summary>
        /// EF DbContext для подключения к БД сайта компьютерного тестирования
        /// </summary>
        public ComputerAdaptiveTestingSiteContext(DbContextOptions options)
            : base(options)
        {
            //Database.Log = sql => Debug.Write(sql);
            //Database.SetInitializer<VernoContext>(null);
            //Database.CommandTimeout = 60 * 60;
            //Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Указываем связанные с сущностями таблицы в БД

            //modelBuilder.Entity<BrandDao>().ToTable("Brands", "dbo");
            modelBuilder.Entity<AnswerDao>().ToTable("Answers", "dbo");
            modelBuilder.Entity<GroupDao>().ToTable("Groups", "dbo");
            modelBuilder.Entity<OptionDao>().ToTable("Options", "dbo");
            modelBuilder.Entity<QuestionDao>().ToTable("Questions", "dbo");
            modelBuilder.Entity<QuestionTypeDao>().ToTable("QuestionTypes", "dbo");
            modelBuilder.Entity<RoleDao>().ToTable("Roles", "dbo");
            modelBuilder.Entity<TestGroupOptionRelationDao>().ToTable("TestGroupOptionRelations", "dbo");
            modelBuilder.Entity<TestGroupRelationDao>().ToTable("TestGroupRelations", "dbo");
            modelBuilder.Entity<TestDao>().ToTable("Tests", "dbo");
            modelBuilder.Entity<UserAnswerDao>().ToTable("UserAnswers", "dbo");
            modelBuilder.Entity<UserGroupRelationDao>().ToTable("UserGroupRelations", "dbo");
            modelBuilder.Entity<UserDao>().ToTable("Users", "dbo");
            modelBuilder.Entity<UserTestDao>().ToTable("UserTests", "dbo");
            modelBuilder.Entity<UserTokenDao>().ToTable("UserTokens", "dbo");

            #endregion

            #region Указываем первичные ключи

            #region AnswerDao

            modelBuilder.Entity<AnswerDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region GroupDao

            modelBuilder.Entity<GroupDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region OptionDao

            modelBuilder.Entity<OptionDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region QuestionDao

            modelBuilder.Entity<QuestionDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region QuestionTypeDao

            modelBuilder.Entity<QuestionTypeDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region RoleDao

            modelBuilder.Entity<RoleDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region TestGroupOptionRelationDao

            modelBuilder.Entity<TestGroupOptionRelationDao>()
                .HasKey(x => new {x.TestId, x.GroupId, x.OptionId});

            #endregion

            #region TestGroupRelationDao

            modelBuilder.Entity<TestGroupRelationDao>()
                .HasKey(x => new { x.TestId, x.GroupId });

            #endregion

            #region TestDao

            modelBuilder.Entity<TestDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region UserAnswerDao

            modelBuilder.Entity<UserAnswerDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region UserGroupRelationDao

            modelBuilder.Entity<UserGroupRelationDao>()
                .HasKey(x => new { x.UserId, x.GroupId });

            #endregion

            #region UserDao

            modelBuilder.Entity<UserDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region UserTestDao

            modelBuilder.Entity<UserTestDao>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region UserTokenDao

            modelBuilder.Entity<UserTokenDao>()
                .HasKey(p => p.Token);

            #endregion

            #endregion

            #region Указываем внешние ключи

            #region AnswerDao

            modelBuilder.Entity<AnswerDao>()
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<AnswerDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion

            #region QuestionDao

            modelBuilder.Entity<QuestionDao>()
                .HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<QuestionDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<QuestionDao>()
                .HasOne(x => x.QuestionType)
                .WithMany()
                .HasForeignKey(x => x.QuestionTypeId);

            #endregion

            #region TestGroupOptionRelationDao

            modelBuilder.Entity<TestGroupOptionRelationDao>()
                .HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<TestGroupOptionRelationDao>()
                .HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            modelBuilder.Entity<TestGroupOptionRelationDao>()
                .HasOne(x => x.Option)
                .WithMany()
                .HasForeignKey(x => x.OptionId);

            #endregion

            #region TestGroupRelationDao

            modelBuilder.Entity<TestGroupRelationDao>()
                .HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<TestGroupRelationDao>()
                .HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            #endregion

            #region TestDao

            modelBuilder.Entity<TestDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion

            #region UserAnswerDao

            modelBuilder.Entity<UserAnswerDao>()
                .HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<UserAnswerDao>()
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<UserAnswerDao>()
                .HasOne(x => x.Answer)
                .WithMany()
                .HasForeignKey(x => x.AnswerId)
                .IsRequired(false);

            modelBuilder.Entity<UserAnswerDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion

            #region UserGroupRelationDao

            modelBuilder.Entity<UserGroupRelationDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserGroupRelationDao>()
                .HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            #endregion

            #region UserDao

            modelBuilder.Entity<UserDao>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);

            #endregion

            #region UserTestDao

            modelBuilder.Entity<UserTestDao>()
                .HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<UserTestDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion

            #region UserTokenDao

            modelBuilder.Entity<UserTokenDao>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public static readonly ILoggerFactory ComputerAdaptiveTestingLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddDebug();
            //builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(ComputerAdaptiveTestingLoggerFactory);
            if (optionsBuilder.IsConfigured == false)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
