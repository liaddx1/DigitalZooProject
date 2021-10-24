using DigitalZooProject.Controllers;
using DigitalZooProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DigitalZooProject.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void ShouldBeAnimals_Home_Index_Model()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _homeController = new HomeController(_fakeRepository);

            // Act
            var result = _homeController.Index() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Animal>), result.Model.GetType());
        }
    }
}
