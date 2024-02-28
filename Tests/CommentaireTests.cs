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
using arsoudeServeur.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Tests.Controllers.Commentaires
{
    //Pas de dbContext dans les Controllers, juste du Mock
    [TestClass]
    public class Controllers
    {
        private static readonly string userId = "11111111-1111-1111-1111-111111111111";

        private static readonly Mock<UtilisateursService> userServiceMock = new Mock<UtilisateursService>() { CallBase = true };

        private static readonly Mock<CommentaireService> commentaireServiceMock = new Mock<CommentaireService>() { CallBase = true };


        [ClassInitialize]
        public static void ClassInitialize(TestContext dbContext) //Obligé de passer TestContext en paramètre
        {
            // Initialiser test dbContext
            //await dbContext.Database.EnsureDeletedAsync();

            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(databaseName: "CommentairesControllers")
            //    .Options;
            //dbContext = new ApplicationDbContext(options);

            //await dbContext.Database.EnsureCreatedAsync();


            userServiceMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                    .Returns(new Utilisateur { identityUserId = userId });

            commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()));
        }

        //[ClassCleanup]
        //public static void ClassCleanup(dbContext dbContext)
        //{
        //    // Clean up resources after all tests in the class have run
        //    await dbContext.();
        //}

        // CommentaireController générique
        private static CommentaireController CommentaireController(Mock<CommentaireService> commentaireServiceMock)
        {
            //Connecter user
            ClaimsPrincipal? user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, userId),
            }));

            // Créer le controller
            CommentaireController? controller = new CommentaireController(commentaireServiceMock.Object, userServiceMock.Object);
            // Ajoute user à la requête
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            return controller;
        }

        #region CreateCommentaire
        [TestMethod]
        public async Task CreateCommentaire_Controller_Ok()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ReturnsAsync(new Commentaire());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_UnauthorizedCreateCommentaireException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new UnauthorizedCreateCommentaireException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_NullRandonneeException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new NullRandonneeException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_NoTraceFoundException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new NoTraceFoundException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_AlreadyExistsCommentaireExeption()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new AlreadyExistsCommentaireExeption());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_RandonneeNotPublicException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.CreateCommentaire(It.IsAny<CommentaireDTO>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new RandonneeNotPublicException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

            // Act
            var result = await controller.CreateCommentaire(commentaireDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }
        #endregion CreateCommentaire

        #region DeleteCommentaire
        [TestMethod]
        public async Task DeleteCommentaire_Controller_Ok()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.DeleteCommentaire(It.IsAny<int>(), It.IsAny<Utilisateur>()))
                                  .ReturnsAsync(new Commentaire());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            // Act
            var result = await controller.DeleteCommentaire(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteCommentaire_Controller_NullCommentaireException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.DeleteCommentaire(It.IsAny<int>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new NullCommentaireException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            // Act
            var result = await controller.DeleteCommentaire(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task DeleteCommentaire_Controller_AlreadyDeletedException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.DeleteCommentaire(It.IsAny<int>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new AlreadyDeletedException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            // Act
            var result = await controller.DeleteCommentaire(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task DeleteCommentaire_Controller_UnauthorizedDeleteCommentaireException()
        {
            //Arrange
            commentaireServiceMock.Setup(service => service.DeleteCommentaire(It.IsAny<int>(), It.IsAny<Utilisateur>()))
                                  .ThrowsAsync(new UnauthorizedDeleteCommentaireException());

            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            // Act
            var result = await controller.DeleteCommentaire(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }
        #endregion DeleteCommentaire
    }

    //Pas de Mock dans les Services, juste du dbContext
    [TestClass]
    public class Services
    {
        private static readonly string userId = "11111111-1111-1111-1111-111111111111";

        private static readonly Utilisateur utilisateur = new Utilisateur
        {
            identityUserId = userId,
            codePostal = "J8L 9L9",
            courriel = "testcourriel@gmail.com",
            nom = "Test",
            prenom = "Test",
            role = "User"
        };
        private static readonly Commentaire commentaire = new Commentaire
        {
            id = 1,
            randonneeId = 1,
            utilisateur = utilisateur,
            utilisateurId = utilisateur.id,
            message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!"
        };
        private static readonly RandonneeUtilisateurTrace trace = new RandonneeUtilisateurTrace
        {
            utilisateur = utilisateur,
            randonnee = randonnee,
            timer = "10"
        };
        private static readonly Randonnee randonnee = new Randonnee
        {
            id = 1,
            nom = "TestNom",
            description = "TestDescription",
            emplacement = "TestEmplacement",
            etatRandonnee = Randonnee.Etat.Publique,
            commentaires = { commentaire },
            traces = { trace }
        };

        private static readonly DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CommentairesServices")
                .Options;

        #region CreateCommentaire
        [TestMethod]
        public async Task CreateCommentaires_Service_Ok()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.utilisateursTrace.AddAsync(trace);
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, note = 5, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Act
                var result = await commentaireService.CreateCommentaire(commentaireDTO, utilisateur);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(commentaire.message, result.message);

                await dbContext.DisposeAsync();
            }
        }

        [TestMethod]
        public async Task CreateCommentaires_Service_NullRandonneeException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<NullRandonneeException>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }

        [TestMethod]
        public async Task CreateCommentaires_Service_RandonneeNotPublicException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.utilisateursTrace.AddAsync(trace);
                randonnee.etatRandonnee = Randonnee.Etat.Privée;
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<RandonneeNotPublicException>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }

        [TestMethod]
        public async Task CreateCommentaires_Service_NoTraceFoundException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                randonnee.traces = new();
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<NoTraceFoundException>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }

        [TestMethod]
        public async Task CreateCommentaires_Service_AlreadyExistsCommentaireExeption()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange

                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<AlreadyExistsCommentaireExeption>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }
        #endregion CreateCommentaire

        #region DeleteCommentaire
        [TestMethod]
        public async Task DeleteCommentaires_Service_Ok() //PASS
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Act
                var result = await commentaireService.DeleteCommentaire(1, utilisateur);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("CommentDeletedByUserFirstNameLastName", result.message);
            }
        }

        [TestMethod]
        public async Task DeleteCommentaires_Service_NullCommentaireException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.Database.EnsureDeletedAsync();

                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.SaveChangesAsync();

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<NullCommentaireException>(async () => await commentaireService.DeleteCommentaire(0, utilisateur));
            }
        }

        [TestMethod]
        public async Task DeleteCommentaires_Service_AlreadyDeletedException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.Database.EnsureDeletedAsync();

                randonnee.etatRandonnee = Randonnee.Etat.Privée;
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<AlreadyDeletedException>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }

        [TestMethod]
        public async Task DeleteCommentaires_Service_UnauthorizedDeleteCommentaireException()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                //Arrange
                await dbContext.Database.EnsureDeletedAsync();

                randonnee.traces = new();
                await dbContext.randonnees.AddAsync(randonnee);
                await dbContext.commentaires.AddAsync(commentaire);
                await dbContext.SaveChangesAsync();

                CommentaireDTO commentaireDTO = new CommentaireDTO { randonneeId = 1, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" };

                CommentaireService commentaireService = new CommentaireService(dbContext);

                //Assert
                await Assert.ThrowsExceptionAsync<UnauthorizedDeleteCommentaireException>(async () => await commentaireService.CreateCommentaire(commentaireDTO, utilisateur));
            }
        }
        #endregion DeleteCommentaire
    }
}