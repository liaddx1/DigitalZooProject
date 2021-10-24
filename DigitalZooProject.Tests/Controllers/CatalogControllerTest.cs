using DigitalZooProject.Controllers;
using DigitalZooProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DigitalZooProject.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTest
    {
        [TestMethod]
        public void ShouldBeAnimals_Catalog_Index_Model()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _catalogController = new CatalogController(_fakeRepository);


            // Act
            var result = _catalogController.Index() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Animal>), result.Model.GetType());
        }

        [TestMethod]
        public void ShouldBeCategories_Catalog_Index_ViewBag()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _catalogController = new CatalogController(_fakeRepository);
            var expected = _fakeRepository.GetCategories();

            //Act
            var result = _catalogController.Index() as ViewResult;
            var actual = (IEnumerable<Category>)result.ViewData["Categories"];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldBeOneAnimal_Catalog_AnimalPage()
        {
            // Arange
            var _fakeRepository = new FakeRepository();
            var _catalogController = new CatalogController(_fakeRepository);

            //Act
            var result = _catalogController.AnimalPage(1) as ViewResult;

            //Assert
            Assert.AreEqual(typeof(Animal), result.Model.GetType());
        }
    }
}
