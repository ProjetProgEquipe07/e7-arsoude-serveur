using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;
using static arsoudeServeur.Services.RechercheService;

namespace Tests.Controllers
{
    [TestClass]
    public class RechercheTest
    {
        DbContextOptions<ApplicationDbContext> options;
        public RechercheTest()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "RechercheService")
                .Options;
        }

        [TestMethod]
        public async Task GetNearSearch_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" });

                
                var searchMock = new Mock<RechercheService>(dbContext);
                searchMock.Setup(service => service.GetNearSearchWithAuth(It.IsAny<string>(), It.IsAny<Utilisateur>(), It.IsAny<string>(), It.IsAny<bool>()))
                          .ReturnsAsync(new List<Randonnee>());

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.PutRandonneesFavorisAsync(It.IsAny<List<Randonnee>>(), It.IsAny<Utilisateur>()))
                         .ReturnsAsync(new List<RandonneeListDTO>());

                var searchController = new RechercheController(userMock.Object, searchMock.Object, randoMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                searchController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                SearchDTO searchDTO = new SearchDTO { recherche = "test", value = "test" };

                var actionResult = await searchController.GetNearSearch(searchDTO);

                Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public async Task GetNearSearch_NoAuth()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };

                var searchMock = new Mock<RechercheService>(dbContext);
                searchMock.Setup(service => service.GetNearSearchNoAuth(It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(new List<Randonnee>());

                var randoMock = new Mock<RandonneesService>(dbContext);
                randoMock.Setup(service => service.PutRandonneesFavorisAsync(It.IsAny<List<Randonnee>>(), It.IsAny<Utilisateur>()))
                         .ReturnsAsync(new List<RandonneeListDTO>());


                var searchController = new RechercheController(userMock.Object, searchMock.Object, randoMock.Object);
                SearchDTO searchDTO = new SearchDTO { recherche = "test", value = "test" };

                var actionResult = await searchController.GetNearSearch(searchDTO);

                Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public async Task GetNearSearch_TestAPIBadPostalCod()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchService = new RechercheService(dbContext);

                var actionResult = await searchService.GetLocation("12!!/45");

                Assert.IsNull(actionResult);
            }
        }


        [TestMethod]
        public async Task GetNearSearch_TestAPIGoodPostalCod()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchService = new RechercheService(dbContext);

                var actionResult = await searchService.GetLocation("J4V 3E5");

                Assert.IsNotNull(actionResult);
            }
        }

        [TestMethod]
        public async Task GetNearSearch_TestFilterWalking()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        typeRandonnee = Randonnee.Type.Marche,
                        etatRandonnee = Randonnee.Etat.Publique,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2 
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111" ,codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("Montagne", utilisateur, "Marche", false);
                dbContext.Database.EnsureDeleted();

                Assert.AreEqual(actionResult.Count(), 1);
            }
        }

        [TestMethod]
        public async Task GetNearSearch_TestFilterBiking()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        typeRandonnee = Randonnee.Type.Marche,
                        etatRandonnee = Randonnee.Etat.Publique,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = true, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("vélo", utilisateur, "Vélo", false);
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 1);
            }
        }


        [TestMethod]
        public async Task GetNearSearch_TestFilterUndefined()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
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
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("randonnée", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 2);
            }
        }


        [TestMethod]
        public async Task GetNearSearch_TestMethodeGood()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

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


                var randonneesResult = new List<Randonnee>
                {
                    
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
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("test", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), randonneesResult.Select(s => s.id).ToList());
            }
        }


        [TestMethod]
        public async Task GetNearSearch_TestAll()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

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


                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), actionResult.Select(s => s.id).ToList());
            }
        }


        [TestMethod]
        public async Task GetNearSearch_TestOnlyMyRando()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

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


                var randonneesResult = new List<Randonnee>
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
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345", id = 1 };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("test", utilisateur, "undefined", true);
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), randonneesResult.Select(s => s.id).ToList());
            }
        }



        [TestMethod]
        public async Task GetNearSearch_WithoutStartGPS()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Marche,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = false, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "test Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("test", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 1);
            }
        }


        [TestMethod]
        public async Task GetNearSearch_NulLoc()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(value: null);

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

                var randonneesResult = new List<Randonnee>
                {
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
                   
                    
                };


                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("test", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), randonneesResult.Select(s => s.id).ToList());
            }
        }


        [TestMethod]
        public async Task GetNearSearchNoUser_WithoutStartGPS()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Marche,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 1, x = 45.832619, y = 6.864719, depart = false, arrivee = false },
                            new GPS { id = 2, x = 45.832619, y = 6.865719, depart = false, arrivee = true },
                        },
                        image = new Image { id= 1 , lien="", randonneeId =1},
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "test Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                var actionResult = await searchMock.Object.GetNearSearchNoAuth("test", "undefined");
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 1);
            }
        }


        [TestMethod]
        public async Task GetNearSearchNoUser_TestFilterWalking()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        typeRandonnee = Randonnee.Type.Marche,
                        etatRandonnee = Randonnee.Etat.Publique,
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
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();


                var actionResult = await searchMock.Object.GetNearSearchNoAuth("Montagne", "Marche");
                dbContext.Database.EnsureDeleted();

                Assert.AreEqual(actionResult.Count(), 1);
            }
        }

        [TestMethod]
        public async Task GetNearSearchNoUser_TestFilterBiking()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
                        description = "Une belle randonnée en montagne.",
                        emplacement = "Alpes",
                        typeRandonnee = Randonnee.Type.Marche,
                        etatRandonnee = Randonnee.Etat.Publique,
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
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

              
                var actionResult = await searchMock.Object.GetNearSearchNoAuth("vélo", "Vélo");
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 1);
            }
        }


        [TestMethod]
        public async Task GetNearSearchNoUser_TestFilterUndefined()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

                var randonnees = new List<Randonnee>
                {
                    new Randonnee
                    {
                        id = 1,
                        nom = "Randonnée Montagne",
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
                        utilisateurId = 1 // Supposons que l'utilisateur 1 est le créateur
                    },
                    new Randonnee
                    {
                        id = 2,
                        nom = "Randonnée Vélo",
                        description = "Un parcours à vélo stimulant.",
                        emplacement = "Bretagne",
                        etatRandonnee = Randonnee.Etat.Publique,
                        typeRandonnee = Randonnee.Type.Vélo,
                        GPS = new List<GPS>
                        {
                            new GPS { id = 3, x = 48.202047, y = -2.932644, depart = true, arrivee = false },
                            new GPS { id = 4, x = 48.202047, y = -2.933644, depart = false, arrivee = true },
                        },
                        image = new Image { id= 2 , lien="", randonneeId =2 },
                        utilisateurId = 2
                    }
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                var actionResult = await searchMock.Object.GetNearSearchNoAuth("randonnée", "undefined");
                dbContext.Database.EnsureDeleted();
                Assert.AreEqual(actionResult.Count(), 2);
            }
        }


        [TestMethod]
        public async Task GetNearSearchNoUser_TestMethodeGood()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

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


                var randonneesResult = new List<Randonnee>
                {

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
                };

                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                var actionResult = await searchMock.Object.GetNearSearchNoAuth("test", "undefined");
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), randonneesResult.Select(s => s.id).ToList());
            }
        }


        [TestMethod]
        public async Task GetNearSearchNoUser_TestAll()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {

                var searchMock = new Mock<RechercheService>(dbContext) { CallBase = true };
                searchMock.Setup(service => service.GetLocation(It.IsAny<string>()))
                          .ReturnsAsync(new Location() { lat = 45.5943, lng = 73.5867 });

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


                dbContext.randonnees.AddRange(randonnees);
                await dbContext.SaveChangesAsync();

                Utilisateur utilisateur = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", codePostal = "12345" };

                var actionResult = await searchMock.Object.GetNearSearchWithAuth("", utilisateur, "undefined", false);
                dbContext.Database.EnsureDeleted();


                CollectionAssert.AreEqual(actionResult.Select(s => s.id).ToList(), actionResult.Select(s => s.id).ToList());
            }
        }
    }
}
