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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authentication;

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

        private static CommentaireController CommentaireController(ApplicationDbContext dbContext, Mock<CommentaireService> commentaireServiceMock, string userId = "11111111-1111-1111-1111-111111111111")
        {
            //Mock utilisateurs service
            Mock<UtilisateursService>? userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
            userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                    .Returns(new Utilisateur { identityUserId = userId });

            //Connecter user
            ClaimsPrincipal? user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, userId),
            }));

            //Créer le controller
            CommentaireController? controller = new CommentaireController(commentaireServiceMock.Object, userMock.Object);
            //Ajoute user à la requête
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            return controller;
        }

        [TestMethod]
        public async Task GetCommentaires_Controller_Ok()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();

                Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
                commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                      .ReturnsAsync(new List<Commentaire>());

                // Act
                var result = await CommentaireController(dbContext, commentaireServiceMock).GetCommentaires(0);

                // Assert
                Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public async Task GetCommentaires_Controller_NullRandonnee_NotFound()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();

                Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
                commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                      .ReturnsAsync(new List<Commentaire>());

                // Act
                var result = await CommentaireController(dbContext, commentaireServiceMock).GetCommentaires(0);

                // Assert
                Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult), "Expected NotFoundObjectResult");

                var notFoundResult = (NotFoundObjectResult)result.Result!;
                var errorMessage = (string)notFoundResult.Value!;
                Assert.AreEqual(ExceptionStrings.RandonneeExistePas, result.Result, "Error message is not as expected");



                //var notFoundResult = Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
                //var errorMessage = (string)((NotFoundObjectResult)notFoundResult).Value;
                //Assert.AreEqual(ExceptionStrings.RandonneeExistePas, errorMessage);

                //// Assert
                //var notFoundResult = ;
                //var errorMessage = (string)(Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult)).Value;
                //Assert.AreEqual(ExceptionStrings.RandonneeExistePas, errorMessage);
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