using DigitalZooProject.Controllers;
using DigitalZooProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DigitalZooProject.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        private Mock<IWebHostEnvironment> _hostEnvironment = new Mock<IWebHostEnvironment>();
        [TestMethod]
        public void ShouldBeAnimals_Admin_Index_Model()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _adminController = new AdminController(_fakeRepository, _hostEnvironment.Object);

            // Act
            var result = _adminController.Index() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Animal>), result.Model.GetType());
        }

        [TestMethod]
        public void ShouldBeOneAnimal_Admin_NewAnimal()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _adminController = new AdminController(_fakeRepository, _hostEnvironment.Object);

            // Act
            var result = _adminController.NewAnimal(1) as ViewResult;

            // Assert
            Assert.AreEqual(typeof(Animal), result.Model.GetType());
        }
    }
}
