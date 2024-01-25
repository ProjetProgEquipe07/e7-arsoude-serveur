using System.Collections.Generic;
using System.Threading.Tasks;
using arsoudeServeur.Controllers;
using arsoudeServeur.Models;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Tests.Controllers
{
    [TestClass]
    public class RandonneeControllerTests
    {
        [TestMethod]
        public async Task GetRandonnees_ShouldReturnListOfRandonnees()
        {
            // Arrange
            var mockRandonneeService = new Mock<RandonneesService>();
            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnees();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<Randonnee>>));
            Assert.IsNotNull(result.Value);
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

        [TestMethod]
        public async Task GetRandonnee_WithValidId_ShouldReturnRandonnee()
        {
            // Arrange
            var mockRandonneeService = new Mock<RandonneesService>();
            mockRandonneeService.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>()))
                               .ReturnsAsync(new Randonnee { id = 1, nom = "TestRandonnee" });

            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnee(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Randonnee>));
            Assert.IsNotNull(result.Value);
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

        [TestMethod]
        public async Task GetRandonnee_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var mockRandonneeService = new Mock<RandonneesService>();
            mockRandonneeService.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>()))
                               .ReturnsAsync((Randonnee)null);

            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnee(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

    }
}