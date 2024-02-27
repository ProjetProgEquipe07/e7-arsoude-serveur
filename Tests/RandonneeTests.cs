using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using arsoudeServeur.Controllers;
using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static arsoudeServeur.Services.RandonneesService;


namespace Tests.Controllers
{
    [TestClass]
    public class RandonneeControllerTests
    {
        DbContextOptions<ApplicationDbContext> options;
        public RandonneeControllerTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RandonneesService")
                .Options;
        }

        [TestMethod]
        public async Task ControllerGetRandonnees_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonnees = new List<RandonneeListDTO>
                {
                    new RandonneeListDTO
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                    },
                    new RandonneeListDTO
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Pas dans les Alpes"
                    }
                };

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.GetRandonneesAFaireAsync(It.IsAny<int>(), It.IsAny<Utilisateur>())).ReturnsAsync(randonnees);

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                int listSize = 1;

                var actionResult = await randoController.GetRandonnees(listSize);
                dbContext.Database.EnsureDeleted();
                Assert.IsInstanceOfType(actionResult.Value, typeof(List<RandonneeListDTO>));
            }
        }
        [TestMethod]
        public async Task ControllerGetRandonnees_RandonneeNotFound()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonnees = new List<RandonneeListDTO>
                {
                };

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.GetRandonneesAFaireAsync(It.IsAny<int>(), It.IsAny<Utilisateur>())).ThrowsAsync(new RandonneeNotFoundException());

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                var actionResult = await randoController.GetRandonnees(1);
                Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));
            }
        }
        [TestMethod]
        public async Task ControllerGetRandonneesNoAuth_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };


                var randonnees = new List<RandonneeListDTO>
                {
                    new RandonneeListDTO
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                    },
                    new RandonneeListDTO
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Pas dans les Alpes"
                    }
                };

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.GetRandonneesAFaireNoAuthAsync(It.IsAny<int>())).ReturnsAsync(randonnees);

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                int listSize = 1;

                var actionResult = await randoController.GetRandonnees(listSize);
                dbContext.Database.EnsureDeleted();
                Assert.IsInstanceOfType(actionResult.Value, typeof(List<RandonneeListDTO>));
            }
        }
        [TestMethod]
        public async Task ControllerGetRandonnee_Good()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonnee = new RandonneeDetailDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                };

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>(), It.IsAny<Utilisateur>())).ReturnsAsync(randonnee);

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                var actionResult = await randoController.GetRandonnee(randonnee.id);
                dbContext.Database.EnsureDeleted();
                Assert.IsInstanceOfType(actionResult.Value, typeof(RandonneeDetailDTO));

            }
        }
        [TestMethod]
        public async Task ControllerGetRandonnee_Bad()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonnee = new RandonneeDetailDTO
                {
                };

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.GetRandonneeByIdAsync(It.IsAny<int>(), It.IsAny<Utilisateur>()))
                         .ThrowsAsync(new RandonneeNotFoundException());

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                await Assert.ThrowsExceptionAsync<RandonneeNotFoundException>(async () => await randoController.GetRandonnee(randonnee.id));

            }
        }
        [TestMethod]
        public async Task ServiceGetRandonneeByIdAsync_Good()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });

                Utilisateur utilisateur = new Utilisateur { id = 1, identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };
                var randonnee = new Randonnee
                {
                    avertissements = new List<Avertissement>(),
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };

                var randonneeResult = new RandonneeDetailDTO
                {
                    avertissements = new List<Avertissement>(),
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false, randonnee = randonnee, randonneeId = randonnee.id  },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true, randonnee = randonnee, randonneeId = randonnee.id },
                        },

                };

                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                dbContext.randonnees.AddRange(randonnee);
                dbContext.SaveChangesAsync();


                var actionResult = await randoMock.Object.GetRandonneeByIdAsync(1, utilisateur);
                dbContext.Database.EnsureDeleted();

                Assert.AreEqual(randonneeResult.id, actionResult.id);

            }
        }
        [TestMethod]
        public async Task ServiceGetRandonneeByIdAsync_NotFound()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });

                Utilisateur utilisateur = new Utilisateur { id = 1, identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));

                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                await Assert.ThrowsExceptionAsync<RandonneeNotFoundException>(async () => await randoMock.Object.GetRandonneeByIdAsync(1, utilisateur));

            }
        }

        [TestMethod]
        public async Task ControllerCreateRando_Good()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonneeDTO = new RandonneeDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };
                var randonnee = new Randonnee
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };


                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.CreateRandonneeAsync(It.IsAny<RandonneeDTO>(), It.IsAny<Utilisateur>()))
                         .ReturnsAsync(randonnee);

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                var actionResult = await randoController.CreateRandonnee(randonneeDTO);
                var result2 = dbContext.randonnees.SingleOrDefault(x => x.id == 1);

                Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            }
        }
        [TestMethod]
        public async Task ControllerCreateRando_Bad_UtilisateurNotFound()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonneeDTO = new RandonneeDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };


                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.CreateRandonneeAsync(It.IsAny<RandonneeDTO>(), It.IsAny<Utilisateur>()))
                         .ThrowsAsync(new UtilisateurNotFoundException());

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                var actionResult = await randoController.CreateRandonnee(randonneeDTO);
                Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));
            }
        }
        [TestMethod]
        public async Task ControllerCreateRando_Bad_RandonneeNotFound()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonneeDTO = new RandonneeDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };


                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.CreateRandonneeAsync(It.IsAny<RandonneeDTO>(), It.IsAny<Utilisateur>()))
                         .ThrowsAsync(new UtilisateurNotFoundException());

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                var actionResult = await randoController.CreateRandonnee(randonneeDTO);
                Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));
            }
        }
        [TestMethod]
        public async Task ControllerCreateRando_Bad()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", });


                var randonneeDTO = new RandonneeDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };


                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.CreateRandonneeAsync(It.IsAny<RandonneeDTO>(), It.IsAny<Utilisateur>()))
                         .ThrowsAsync(new UtilisateurNotFoundException());

                var randoController = new RandonneeController(userMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                randoController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };
                var actionResult = await randoController.CreateRandonnee(randonneeDTO);
                Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));
            }
        }
        [TestMethod]
        public async Task ServiceCreateRando_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                var userTest = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1, codePostal = "12345", courriel= "ltg@gmail,com", nom="robert", prenom= "tangerine", role = "User" };
                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);


                var randonneeDTO = new RandonneeDTO
                {
                    id = 1,
                    nom = "Randonnée Montagne",
                    description = "Une belle randonnée en montagne.",
                    emplacement = "Alpes",
                    typeRandonnee = 0,
                    gps = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        }
                };

                var actionResult = await randoMock.Object.CreateRandonneeAsync(randonneeDTO, userTest);

                Randonnee result = await dbContext.randonnees.SingleOrDefaultAsync(x => x.id == 1);
                Assert.IsNotNull(result);
                Assert.AreEqual(result.id, 1);
                Assert.AreEqual(result.nom, "Randonnée Montagne");
                Assert.AreEqual(result.description, "Une belle randonnée en montagne.");
                Assert.AreEqual(result.typeRandonnee,Randonnee.Type.Marche);
                Assert.AreEqual(result.emplacement, "Alpes");
                Assert.AreEqual(result.GPS.Count, 2);
            }
        }
        [TestMethod]
        public async Task ServiceCreateRando_Bad_NullReference()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {


                var randonneeDTO = new RandonneeDTO { 
                    id = 0,
                    nom = "allo",
                    description = "salut mon beau",
                    emplacement = "mont-tremblant",
                    typeRandonnee = 1
                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };
                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1, codePostal = "12345", courriel = "ltg@gmail,com", nom = "robert", prenom = "tangerine", role = "User" };
                await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await randoMock.Object.CreateRandonneeAsync(randonneeDTO, utilisateur));
            }
        }
        [TestMethod]
        public async Task ServiceCreateRando_Bad_NomOutOfBounds()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {


                var randonneeDTO = new RandonneeDTO
                {
                    id = 0,
                    nom = "a",
                    description = "salut mon beau",
                    emplacement = "mont-tremblant",
                    typeRandonnee = 1,

                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };
                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1, codePostal = "12345", courriel = "ltg@gmail,com", nom = "robert", prenom = "tangerine", role = "User" };
                await Assert.ThrowsExceptionAsync<NomOutOfBoundsException>(async () => await randoMock.Object.CreateRandonneeAsync(randonneeDTO, utilisateur));
            }
        }
        [TestMethod]
        public async Task ServiceCreateRando_Bad_DescriptionOutOfBounds()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {


                var randonneeDTO = new RandonneeDTO
                {
                    id = 0,
                    nom = "allo",
                    description = "sal",
                    emplacement = "mont-tremblant",
                    typeRandonnee = 1,

                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };
                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1, codePostal = "12345", courriel = "ltg@gmail,com", nom = "robert", prenom = "tangerine", role = "User" };
                await Assert.ThrowsExceptionAsync<DescriptionOutOfBoundsException>(async () => await randoMock.Object.CreateRandonneeAsync(randonneeDTO, utilisateur));
            }
        }
        [TestMethod]
        public async Task ServiceCreateRando_Bad_GPSRequired()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {


                var randonneeDTO = new RandonneeDTO
                {
                    id = 0,
                    nom = "allo",
                    description = "salut mon beau",
                    emplacement = "mont-tremblant",
                    typeRandonnee = 1
                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };
            
                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1, codePostal = "12345", courriel = "ltg@gmail,com", nom = "robert", prenom = "tangerine", role = "User" };
                await Assert.ThrowsExceptionAsync<GPSRequiredException>(async () => await randoMock.Object.CreateRandonneeAsync(randonneeDTO, utilisateur));
            }
        }

        [TestMethod]
        public async Task ServiceGetAllRandoAsync_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "test Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Marche,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 3,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 5, x = 50.202047, y = -4.932644, depart = true, arrivee = false },
                            new GPS { id = 6, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 3 , lien="", randonneeId =3 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 4,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 7, x = 60.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 8, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 4 , lien="", randonneeId =4 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 5,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 9, x = 10.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 10, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 5 , lien="", randonneeId =5 },
                        utilisateurId = 2
                    }
                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                dbContext.randonnees.AddRange(randonnees);
                dbContext.SaveChangesAsync();
                var actionResult = await randoMock.Object.GetAllRandonneesAsync();


                Assert.AreEqual(actionResult.Count, 5);
            }
        }

        [TestMethod]
        public async Task ServiceGetRandonneeAFaireNoAuthAsync_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "test Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Marche,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 3,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 5, x = 50.202047, y = -4.932644, depart = true, arrivee = false },
                            new GPS { id = 6, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 3 , lien="", randonneeId =3 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 4,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 7, x = 60.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 8, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 4 , lien="", randonneeId =4 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 5,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 9, x = 10.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 10, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 5 , lien="", randonneeId =5 },
                        utilisateurId = 2
                    }
                };


                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                dbContext.randonnees.AddRange(randonnees);
                dbContext.SaveChangesAsync();
                int listLength = 5;
                var actionResult = await randoMock.Object.GetRandonneesAFaireNoAuthAsync(listLength);


                Assert.AreEqual(5, actionResult.Count);
            }
        }
        [TestMethod]
        public async Task ServiceGetRandonneeAFaireNoAuthAsync_RandonneeNotFound()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };
                await Assert.ThrowsExceptionAsync<RandonneeNotFoundException>(async () => await randoMock.Object.GetRandonneesAFaireNoAuthAsync(5));
            }
        }
        [TestMethod]
        public async Task ServiceGetRandonneeAFaireAsync_2_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "test Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        etatRandonnee = Randonnee.Etat.Privée,
                        typeRandonnee = Randonnee.Type.Marche,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Privée,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 3,
                        nom = "test Vélo",
                        description = "Un test à vélo stimulant.",
                        emplacement = "test",
                        etatRandonnee = Randonnee.Etat.Privée,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 5, x = 50.202047, y = -4.932644, depart = true, arrivee = false },
                            new GPS { id = 6, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 3 , lien="", randonneeId =3 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 4,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 7, x = 60.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 8, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 4 , lien="", randonneeId =4 },
                        utilisateurId = 2
                    },
                    new Randonnee
                    {
                        id = 5,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 9, x = 10.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 10, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 5 , lien="", randonneeId =5 },
                        utilisateurId = 2
                    }
                };

                Utilisateur utilisateur = new Utilisateur { id = 1, identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };
                var randoMock = new Mock<RandonneesService>(dbContext) { CallBase = true };

                dbContext.randonnees.AddRange(randonnees);
                dbContext.SaveChangesAsync();
                int listLength = 5;
                var actionResult = await randoMock.Object.GetRandonneesAFaireAsync(listLength, utilisateur);

                //Devrait en recevoir que 3, car l'utilisateur a 1 rando privée et il n'y a que 2 rando publique
                Assert.AreEqual(actionResult.Count, 3);
            }
        }

    }
}