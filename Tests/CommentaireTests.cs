using arsoudServeur.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using arsoudeServeur.Models.DTOs;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging.Signing;
using System.Security.Claims;
using static arsoudeServeur.Services.CommentaireService;
using static arsoudeServeur.Services.AvertissementService;

namespace Tests.Controllers
{
    /// <summary>
    /// Ce commentaire n'existe pas
    /// </summary>
    public class NullCommentaireException : Exception { }

    /// <summary>
    /// Cette randonnée n'existe pas
    /// </summary>
    public class NullRandonneeException : Exception { }

    /// <summary>
    /// Utilisateurs non trouvés
    /// </summary>
    public class NullUtilisateursException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à créer ce commentaire
    /// </summary>
    public class UnauthorizedCreateCommentaireException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à supprimer ce commentaire
    /// </summary>
    public class UnauthorizedDeleteCommentaireException : Exception { }

    /// <summary>
    /// Vous n'êtes pas autorisé à modifier ce commentaire
    /// </summary>
    public class UnauthorizedModifyCommentaireException : Exception { }

    /// <summary>
    /// Ce commentaire a déjà été effacé
    /// </summary>
    public class AlreadyDeletedException : Exception { }

    /// <summary>
    /// Un commentaire à déjà été fait par l'utilisateur dans la randonnée
    /// </summary>
    public class AlreadyExistsCommentaireExeption : Exception { }

    /// <summary>
    /// Vous avez déjà like ce commentaire
    /// </summary>
    public class AlreadyLikedCommentaireException : Exception { }

    /// <summary>
    /// Vous avez déjà enlevé votre like de ce commentaire
    /// </summary>
    public class AlreadyUnlikedCommentaireException : Exception { }

    /// <summary>
    /// Pas fait le tracé de la randonnée
    /// </summary>
    public class NoTraceFoundException : Exception { }

    /// <summary>
    /// La randonnée n'est pas publique donc on ne peut pas commenter
    /// </summary>
    public class RandonneeNotPublicException : Exception { }

    [TestClass]
    public class CommentaireTest
    {
        DbContextOptions<ApplicationDbContext> options;
        public CommentaireTest()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CommentaireService")
                .Options;
        }

        private static Mock<UtilisateursService> UserMock(ApplicationDbContext dbContext)
        {
            var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
            userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                    .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "J8K 9L9" });
            return userMock;
        }

        [TestMethod]
        public async Task GetCommentaires_Controller_Ok()
        {
            //var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };
            //var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };

            //avertissementMock.Setup(s => s.CreateAvertissementAsync(It.IsAny<AvertissementDTO>())).ThrowsAsync(new RandonneeNotFoundException());

            //var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
            //}));

            //avertissementController.ControllerContext = new ControllerContext()
            //{
            //    HttpContext = new DefaultHttpContext() { User = user }
            //};

            //AvertissementDTO avertissementDTO = new AvertissementDTO();
            //var actionResult = await avertissementController.CreateAvertissement(avertissementDTO);

            //Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));


            using (var dbContext = new ApplicationDbContext(options))
            {
                //dbContext.Database.EnsureDeleted();

                Mock<UtilisateursService> userMock = UserMock(dbContext);

                var commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
                commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                      .ReturnsAsync(new List<Commentaire>());

                var controller = new CommentaireController(commentaireServiceMock.Object, userMock.Object);

                // Act
                var result = await controller.GetCommentaires(1);

                // Assert
                Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullRandonneeException))]
        public async Task GetCommentaires_Controller_NullRandonnee_NotFound()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //dbContext.Database.EnsureDeleted();

                Mock<UtilisateursService> userMock = UserMock(dbContext);

                var commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
                commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                      .ReturnsAsync(new List<Commentaire>());

                var controller = new CommentaireController(commentaireServiceMock.Object, userMock.Object);

                // Act
                var result = await controller.GetCommentaires(1);

                // Assert
                Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_Test()
        {
            Assert.Fail();
        }


        //CommentaireService
        [TestMethod]
        public async Task GetCommentaires_Service_Test()
        {
            Assert.Fail();
        }

        [TestMethod]
        public async Task CreateCommentaireService_Test()
        {
            Assert.Fail();
        }
    }
}