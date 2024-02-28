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

namespace Tests.Controllers.Commentaires
{
    //Pas de dbContext dans les Controllers, juste du Mock
    [TestClass]
    public class Controllers
    {
        private static readonly string userId = "11111111-1111-1111-1111-111111111111";

        private static readonly Mock<UtilisateursService> userServiceMock = new Mock<UtilisateursService>() { CallBase = true };

        [ClassInitialize]
        public static void ClassInitialize(TestContext dbContext)
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
        }

        //[ClassCleanup]
        //public static void ClassCleanup(TestContext dbContext)
        //{
        //    // Clean up resources after all tests in the class have run
        //    //await dbContext.DisposeAsync();
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

        //Pass
        [TestMethod]
        public async Task GetCommentaires_Controller_Ok()
        {
            //Arrange
            Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>() { CallBase = true };
            commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                  .ReturnsAsync(new List<Commentaire> { new Commentaire(), new Commentaire() });
            
            CommentaireController? controller = CommentaireController(commentaireServiceMock);

            // Act
            var result = await controller.GetCommentaires(0);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            //}
        }

        //Pass
        [TestMethod]
        public async Task GetCommentaires_Controller_NullRandonnee_NotFound()
        {
            //Arrange
            Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>() { CallBase = true };
            commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
                                  .ThrowsAsync(new NullRandonneeException());

            // Act
            var result = await CommentaireController(commentaireServiceMock).GetCommentaires(0);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult), "Expected NotFoundObjectResult");
        }

        [TestMethod]
        public async Task CreateCommentaire_Controller_Test()
        {
            Assert.Fail();
        }

        [TestMethod]
        public async Task DeleteCommentaire_Controller_Test()
        {
            Assert.Fail();
        }
    }

    //Pas de Mock dans les Services, juste du dbContext
    [TestClass]
    public class Services
    {
        //[TestMethod]
        //public async Task GetCommentaires_Service_Ok()
        //{
        //    using (var dbContext = new ApplicationDbContext(options))
        //    {
        //        //Arrange
        //        //Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
        //        //commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
        //        //                      .ReturnsAsync(new List<Commentaire>());

        //        CommentaireService service = new CommentaireService(dbContext);

        //        //Mock<UtilisateursService>? userMock = UserServiceMock(dbContext);


        //        List<Commentaire> commentaires = new List<Commentaire>
        //        {
        //            new Commentaire { id = 1, randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service for hikers of all levels. As an avid hiker, I was immediately drawn to the concept of being able to track my hikes and have all the information in one place. After using it for a few weeks, I can confidently say that Arsoude has exceeded my expectations.\r\n\r\nOne of the best features of Arsoude is its user-friendly interface. It is easy to navigate and has a clean design, making it simple to use for hikers of all ages and experience levels. The app allows users to track their hikes by recording the distance, elevation, and route taken. This information is then displayed in a clear and organized manner, making it easy to analyze and compare different hikes.\r\n\r\nAnother great aspect of Arsoude is the community aspect. Users can connect with other hikers, share their experiences, and even discover new hiking trails. This not only adds a social aspect to the app but also allows for a sense of camaraderie among hikers.\r\n\r\nOne feature that sets Arsoude apart from other hiking apps is its ability to track weather conditions. This is extremely helpful for planning hikes and ensuring safety on the trail. The app also provides suggestions for gear and equipment based on the weather, making it a valuable resource for hikers.\r\n\r\nOverall, I highly recommend Arsoude to anyone who loves hiking. It is a comprehensive and user-friendly service that has enhanced my hiking experience. Whether you are a beginner or an experienced hiker, Arsoude has something to offer for everyone. So, download the app and start tracking your hikes today!" },
        //            new Commentaire { id = 2, randonneeId = 0, message = "I recently discovered Arsoude, a fantastic service that has completely changed the way I track my hikes. As an avid hiker, I have always been interested in keeping track of my progress and exploring new trails. However, I struggled to find a reliable and user-friendly way to do so until I came across Arsoude.\r\n\r\nOne of the things I love most about Arsoude is its simplicity. The interface is clean and easy to navigate, making it perfect for hikers of all levels. Whether you're a beginner or an experienced hiker, Arsoude has everything you need to track your hikes and improve your skills.\r\n\r\nThe tracking feature is by far my favorite aspect of Arsoude. It uses GPS technology to accurately track my route, distance, and elevation gain. This has been incredibly helpful in planning my hikes and setting goals for myself. I can also save my favorite routes and share them with other hikers, making it a great community for exploring new trails.\r\n\r\nAnother great feature of Arsoude is the ability to log my hikes and keep a record of my progress. I can add notes, photos, and even rate the difficulty of the trail. This has been a game-changer for me as I can now easily refer back to my previous hikes and see how far I've come. It's also a great way to keep track of any challenges or obstacles I may have faced on a particular trail.\r\n\r\nOne of the things I appreciate most about Arsoude is its inclusivity. It caters to hikers of all levels, from beginners to experts. The app offers helpful tips and advice for beginners, while also providing advanced features for experienced hikers. This makes it a great tool for anyone looking to improve their hiking skills and explore new trails.\r\n\r\nIn addition to its tracking and logging features, Arsoude also offers a variety of resources for hikers. From safety tips to gear recommendations, the app has everything you need to make the most out of your hiking experience. It even has a feature that allows you to connect with other hikers in your area, making it a great way to meet new people who share your passion for hiking.\r\n\r\nOverall, I highly recommend Arsoude to any hiker looking to track their progress and explore new trails. It's a user-friendly, comprehensive, and inclusive service that has greatly enhanced my hiking experience. I can't imagine going on a hike without it now. Give it a try and see for yourself how Arsoude can take your hiking to the next level." },
        //            new Commentaire { id = 3, randonneeId = 0, message = "I recently had the opportunity to try out Arsoude, a hiking tracking service, and I must say, I am thoroughly impressed. As an avid hiker, I am always looking for ways to enhance my hiking experience and Arsoude has definitely done that.\r\n\r\nOne of the best things about Arsoude is its user-friendly interface. It is easy to navigate and I was able to start tracking my hikes in no time. The app also offers a variety of features such as GPS tracking, elevation data, and even a social aspect where you can connect with other hikers and share your experiences.\r\n\r\nWhat I found most useful about Arsoude is its ability to track my progress and provide detailed information about my hikes. I was able to see the distance I covered, the time it took, and even the calories I burned. This not only helped me stay motivated but also allowed me to plan my future hikes more efficiently.\r\n\r\nAnother great aspect of Arsoude is its versatility. It caters to hikers of all levels, whether you are a beginner or an experienced hiker, there is something for everyone. The app offers a variety of trails to choose from, ranging from easy to difficult, so you can pick one that suits your level and preferences.\r\n\r\nAs someone who loves to explore new trails, I also appreciate the fact that Arsoude has a feature that allows you to discover new hikes in your area. This has opened up a whole new world of hiking possibilities for me and I am excited to try out new trails with the help of this app.\r\n\r\nLastly, I must mention the customer service of Arsoude. I had a few questions and concerns about the app and the team was quick to respond and resolve any issues I had. It is evident that they truly care about their users and their hiking experience.\r\n\r\nIn conclusion, I highly recommend Arsoude to all hikers out there. It is a fantastic service that not only helps you track your hikes but also enhances your overall experience. With its user-friendly interface, versatile features, and excellent customer service, Arsoude is a must-have for any hiker, regardless of their level. So, grab your hiking boots and give Arsoude a try, I promise you won't be disappointed. Happy hiking!" }
        //        };

        //        //Console.WriteLine(commentaires);

        //        await dbContext.commentaires.AddRangeAsync(commentaires);
        //        await dbContext.SaveChangesAsync();

        //        //Act
        //        var result = await service.GetCommentaires(0);

        //        //Assert
        //        Assert.IsNotNull(result);
        //        Assert.AreEqual(commentaires.Count, result.Count);

        //        foreach (var commentaire in commentaires)
        //        {
        //            Assert.AreEqual(commentaire.message, result.Find(c => c.id == commentaire.id)!.message);
        //        }

        //        //CollectionAssert.AreEqual(commentaires, result);



        //        await dbContext.Database.EnsureDeletedAsync();
        //    }
        //}


        //[TestMethod]
        //public async Task GetCommentaires_Service_NullRandonnee()
        //{
        //    using (var dbContext = new ApplicationDbContext(options))
        //    {
        //        //Arrange
        //        dbContext.Database.EnsureDeleted();

        //        Mock<CommentaireService>? commentaireServiceMock = new Mock<CommentaireService>(dbContext) { CallBase = true };
        //        commentaireServiceMock.Setup(service => service.GetCommentaires(It.IsAny<int>()))
        //                              .ThrowsAsync(new NullRandonneeException());

        //        // Act
        //        var result = await CommentaireController(dbContext, commentaireServiceMock).GetCommentaires(0);

        //        // Assert
        //        Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult), "Expected NotFoundObjectResult");
        //    }
        //}

        ////CommentaireService
        //[TestMethod]
        //public async Task GetCommentaires_Service_Test()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod]
        //public async Task CreateCommentaireService_Test()
        //{
        //    Assert.Fail();
        //}
    }
}