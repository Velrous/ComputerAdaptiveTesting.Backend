using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComputerAdaptiveTesting.Backend.Common.Base.Contexts;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Answers;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Questions;
using ComputerAdaptiveTesting.Backend.Domain.Entities.Tests;
using ComputerAdaptiveTesting.Backend.Domain.Enums;
using ComputerAdaptiveTesting.Backend.Domain.Ninject;
using ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.BaseImplementations;
using ComputerAdaptiveTesting.Backend.Domain.Services.Interfaces.ComputerAdaptiveTestingSiteInterfaces;
using ComputerAdaptiveTesting.Backend.Infrastructure.Contexts;
using ComputerAdaptiveTesting.Backend.Infrastructure.Entities;
using ComputerAdaptiveTesting.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Ninject;
using Ninject.Parameters;

namespace ComputerAdaptiveTesting.Backend.Domain.Services.Implementations.ComputerAdaptiveTestingSiteImplementations
{
    /// <summary>
    /// Сервис работы с тестами
    /// </summary>
    public class TestService : BaseService, ITestService
    {
        #region Контексты

        private readonly ComputerAdaptiveTestingSiteContext _computerAdaptiveTestingSiteContext;

        #endregion

        #region Репозитории

        private readonly IEntityWithIdRepository<TestDao, long> _testRepository;
        private readonly IEntityWithIdRepository<QuestionDao, long> _questionRepository;
        private readonly IEntityWithIdRepository<AnswerDao, long> _answerRepository;

        #endregion

        #region Мапперы

        private readonly IMapper _mapper;

        #endregion

        /// <summary>
        /// Сервис работы с тестами
        /// </summary>
        public TestService()
        {
            #region Получаем экземпляры NinjectModule

            IKernel kernel = new StandardKernel(new ComputerAdaptiveTestingSiteModule());

            #endregion

            #region Получаем экземпляры EF контекстов

            _computerAdaptiveTestingSiteContext = kernel.Get<ComputerAdaptiveTestingSiteContext>();

            #endregion

            #region Получаем экземпляры требуемых репозиториев

            _testRepository = kernel.Get<IEntityWithIdRepository<TestDao, long>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));
            _questionRepository = kernel.Get<IEntityWithIdRepository<QuestionDao, long>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));
            _answerRepository = kernel.Get<IEntityWithIdRepository<AnswerDao, long>>(new ConstructorArgument("context", _computerAdaptiveTestingSiteContext));

            #endregion

            #region Получаем экземпляр маппера

            _mapper = kernel.Get<IMapper>();

            #endregion
        }

        /// <summary>
        /// Создаёт новый тест
        /// </summary>
        ///<param name="testWeb">Новый тест</param>
        public void CreateTest(TestWeb testWeb)
        {
            if (testWeb != null)
            {
                var newTest = new TestDao()
                {
                    Name = testWeb.Name,
                    UserId = ServerContext.UserId,
                    Created = DateTime.Now,
                    IsActive = true
                };
                _testRepository.Create(newTest);
                _computerAdaptiveTestingSiteContext.SaveChanges();
                var testId = _testRepository.GetQueryable().FirstOrDefault(x => x.Name == testWeb.Name && x.UserId == ServerContext.UserId)?.Id;
                if (testId.HasValue && testWeb.Questions.Any())
                {
                    foreach (var questionWeb in testWeb.Questions)
                    {
                        var newQuestion = new QuestionDao()
                        {
                            TestId = testId.Value,
                            Json = questionWeb.Name,
                            Level = 1,
                            Section = null,
                            UserId = ServerContext.UserId,
                            QuestionTypeId = (int) QuestionTypes.TextQuestion,
                            Created = DateTime.Now,
                            Time = null,
                            IsActive = true
                        };
                        _questionRepository.Create(newQuestion);
                        _computerAdaptiveTestingSiteContext.SaveChanges();
                        var questionId = _questionRepository.GetQueryable().FirstOrDefault(x => x.Json == questionWeb.Name && x.UserId == ServerContext.UserId)?.Id;
                        if (questionId.HasValue && questionWeb.Answers.Any())
                        {
                            foreach (var answerWeb in questionWeb.Answers)
                            {
                                var newAnswer = new AnswerDao()
                                {
                                    QuestionId = questionId.Value,
                                    Json = answerWeb.Name,
                                    IsRight = answerWeb.IsRight,
                                    UserId = ServerContext.UserId,
                                    Created = DateTime.Now
                                };
                                _answerRepository.Create(newAnswer);
                            }
                            _computerAdaptiveTestingSiteContext.SaveChanges();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает интерфейс для запроса тестов
        /// </summary>
        /// <returns>Интерфейс для запроса тестов</returns>
        public IQueryable<Test> GetQueryable()
        {
            var testQueryable = _testRepository.GetQueryable();
            return _mapper.ProjectTo<Test>(testQueryable);
        }

        /// <summary>
        /// Возвращает интерфейс для запроса тестов для фронта
        /// </summary>
        /// <returns>Интерфейс для запроса тестов для фронта</returns>
        public List<TestWeb> GetListForWeb()
        {
            var testList = _testRepository.GetQueryable()
                .Where(x => x.UserId == ServerContext.UserId)
                .OrderBy(x=>x.Created)
                .ToList();
            if (testList.Any())
            {
                var testWebList = new List<TestWeb>();
                foreach (var test in testList)
                {
                    var questionList = _questionRepository.GetQueryable()
                        .Where(x => x.TestId == test.Id)
                        .OrderBy(x=>x.Created)
                        .ToList();
                    if (questionList.Any())
                    {
                        var questionWebList = new List<QuestionWeb>();
                        foreach (var question in questionList)
                        {
                            var answerList = _answerRepository.GetQueryable()
                                .Where(x => x.QuestionId == question.Id)
                                .OrderBy(x=>x.Created)
                                .ToList();
                            if (answerList.Any())
                            {
                                var answerWebList = new List<AnswerWeb>();
                                foreach (var answer in answerList)
                                {
                                    var answerWeb = new AnswerWeb()
                                    {
                                        Id = answer.Id,
                                        Name = answer.Json,
                                        IsRight = answer.IsRight
                                    };
                                    answerWebList.Add(answerWeb);
                                }
                                var questionWeb = new QuestionWeb()
                                {
                                    Id = question.Id,
                                    Name = question.Json,
                                    Answers = answerWebList
                                };
                                questionWebList.Add(questionWeb);
                            }
                        }
                        var testWeb = new TestWeb()
                        {
                            Id = test.Id,
                            Name = test.Name,
                            Questions = questionWebList
                        };
                        testWebList.Add(testWeb);
                    }
                }

                if (testWebList.Any())
                {
                    return testWebList;
                }
            }
            return new List<TestWeb>();
        }
    }
}
