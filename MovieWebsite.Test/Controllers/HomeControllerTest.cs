using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieWebsite.Controllers;
using MovieWebsite.Service.Interfaces;
using MovieWebsite.Service;
using MovieWebsite.Domain.Interfaces;
using MovieWebsite.Domain;
using System.Web.Mvc;
using Moq;
using MovieWebsite.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MovieWebsite.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController controller;
        ViewResult result;
        Mock<IMoviesService> mock;

        [TestInitialize]
        public void SetupContext()
        {
            var mock = new Mock<IMoviesService>();
            mock.Setup(m => m.GetMoviesList("", "Title", "asc")).Returns(new List<Movie>().OrderBy(m => m));
            mock.Setup(m => m.GetMovie(1)).Returns(new Movie());

            controller = new HomeController(mock.Object);
        }

        [TestMethod]
        public void Index()
        {
            //Arrange
            //var controller = new HomeController(SetupMock().Object);

            //Act
            ViewResult result = controller.Index(new Models.MovieListViewModel(), "", 1) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            //Arrange
            //var controller = new HomeController(SetupMock().Object);

            //Act
            ViewResult result = controller.Details(1) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsNull()
        {
            //Arrange
           //var controller = new HomeController(SetupMock().Object);

            //Act
            ViewResult result = controller.Details(null) as ViewResult;

            //Assert
            Assert.IsInstanceOfType(result, new HttpStatusCodeResult(HttpStatusCode.BadRequest).GetType());
        }
    }
}
