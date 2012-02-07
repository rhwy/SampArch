using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web;
using Rhino.Mocks;
using SampArch.Presentation.Area.Ideas.Controllers;
using SampArch.Domain.Ideas;
using System.Web.Mvc;
using System.Web.Routing;
using SampArch.Presentation.Area.Ideas.Models;

namespace SampArch.Presentation.Area.Ideas.Tests
{
    [TestFixture]
    public class SiteIdeasControllerTests
    {
        [Test]
        public void Given_DefaultRoute_When_RequestCalles_Then_IGetTheResult()
        {

        }
    }

    

    [TestFixture] 
    public class MyControllerTest 
    {
        private SiteIdeasController controller;
        private IIdeaRepository repository;  
        private HttpContextMock httpContextMock; 
        private Idea resultIdea;
        private IdeaInList ideaVM;
 
        [SetUp] 
        public void Setup() 
        {
            repository = MockRepository.GenerateStub<IIdeaRepository>();
            controller = new SiteIdeasController(repository);
            httpContextMock = new HttpContextMock();

            controller.ControllerContext = new ControllerContext(httpContextMock.Context, new RouteData(), controller);

            resultIdea = new Idea() { Id = 1, Title = "test" };

            
            httpContextMock.Request.Stub(x => x.HttpMethod).Return("GET");
            resultIdea = new Idea() { Id = 1, Title = "test" };
            ideaVM = new IdeaInList(resultIdea);
            repository.Stub(x => x.GetById(1)).Return(resultIdea);
        } 
 
 
        [Test] 
        public void Given_SiteIdeasController_When_CallDetails_Then_TypeIsViewResult() 
        { 
            ViewResult actionResult = controller.Details(1) as ViewResult;
            Assert.That(actionResult, Is.Not.Null);
        }

        [Test]
        public void Given_SiteIdeasController_When_CallDetails_Then_RepositoryIsCalled()
        {
            ViewResult actionResult = controller.Details(1) as ViewResult;
            repository.AssertWasCalled(x => x.GetById(1));
        }

        [Test]
        public void Given_SiteIdeasController_When_CallDetails_Then_ModelResultIsModel()
        {
            ViewResult actionResult = controller.Details(1) as ViewResult;
            Idea ideaActionResult = actionResult.Model as Idea;

            Assert.That(ideaActionResult, Is.Not.Null);
            Assert.That(ideaVM.Title, Is.EqualTo(ideaActionResult.Title));

        } 
    } 
}
