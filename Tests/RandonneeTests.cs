using System.Collections.Generic;
using System.Threading.Tasks;
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
            var mockRandonneeService = new Mock<Randonn�esService>();
            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnees();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<Randonn�e>>));
            Assert.IsNotNull(result.Value);
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

        [TestMethod]
        public async Task GetRandonnee_WithValidId_ShouldReturnRandonnee()
        {
            // Arrange
            var mockRandonneeService = new Mock<Randonn�esService>();
            mockRandonneeService.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>()))
                               .ReturnsAsync(new Randonn�e { id = 1, nom = "TestRandonnee" });

            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnee(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Randonn�e>));
            Assert.IsNotNull(result.Value);
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

        [TestMethod]
        public async Task GetRandonnee_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var mockRandonneeService = new Mock<Randonn�esService>();
            mockRandonneeService.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>()))
                               .ReturnsAsync((Randonn�e)null);

            var controller = new RandonneeController(null, mockRandonneeService.Object);

            // Act
            var result = await controller.GetRandonnee(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
            // Ajoutez d'autres assertions en fonction de vos besoins
        }

        // �crivez des tests similaires pour les autres actions du contr�leur
    }
}