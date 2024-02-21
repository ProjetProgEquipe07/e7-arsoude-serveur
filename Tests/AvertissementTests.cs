using arsoudeServeur.Controllers;
using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Packaging.Signing;
using System.Security.Claims;
using static arsoudeServeur.Services.AvertissementService;

namespace Tests.Controllers
{
    [TestClass]
    public class AvertissementTests
    {
        DbContextOptions<ApplicationDbContext> options;
        public AvertissementTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AvertissementService")
                .Options;
        }

        [TestMethod]
        public async Task CreateAvertissementController_Ok() 
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };
                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };

                avertissementMock.Setup(s => s.CreateAvertissementAsync(It.IsAny<AvertissementDTO>())).ReturnsAsync(new Avertissement());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));

                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };                

                AvertissementDTO avertissementDTO = new AvertissementDTO();
                var actionResult = await avertissementController.CreateAvertissement(avertissementDTO);

                Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            }
        }
        [TestMethod]
        public async Task CreateAvertissementController_Exception()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };
                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };

                avertissementMock.Setup(s => s.CreateAvertissementAsync(It.IsAny<AvertissementDTO>())).ThrowsAsync(new RandonneeNotFoundException());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));

                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                AvertissementDTO avertissementDTO = new AvertissementDTO();
                var actionResult = await avertissementController.CreateAvertissement(avertissementDTO);

                Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundObjectResult));
            }
        }

        [TestMethod]
        public async Task CreateAvertissementService_Valid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 90,
                    y = 90,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps

                };

                var actionResult = await avertissementMock.Object.CreateAvertissementAsync(avertissement);
                DateTime date = DateTime.Now + TimeSpan.FromDays(7);
                Avertissement avertissementresult = await dbContext.avertissements.FirstOrDefaultAsync(x => x.id == 1);

                Assert.IsNotNull(avertissementresult);
                Assert.AreEqual(avertissementresult.id, 1);
                Assert.AreEqual(avertissementresult.description, "description");
                Assert.AreEqual(avertissementresult.typeAvertissement, Avertissement.TypeAvertissement.CheminInnondé);
                Assert.AreEqual(avertissementresult.randonneeId, 1);
                Assert.AreEqual(avertissementresult.DateSuppresion.Day, date.Day);
                Assert.AreEqual(avertissementresult.DateSuppresion.Month, date.Month);
                Assert.AreEqual(avertissementresult.DateSuppresion.Year, date.Year);
                Assert.AreEqual(avertissementresult.x, 90);
                Assert.AreEqual(avertissementresult.y, 90);

            }
        }

        [TestMethod]
        [ExpectedException(typeof(RandonneeNotFoundException))]
        public async Task CreateAvertissementService_RandoInvalid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock =  new Mock<AvertissementService>(dbContext) { CallBase = true };


                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 219676678
                   

                };
                var actionResult = await avertissementMock.Object.CreateAvertissementAsync(avertissement);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(TypeAvertissementNotFoundException))]
        public async Task CreateAvertissementService_TypeRandoInvalid_Max()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 5,
                    randonneeId = 1
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);
                

            }
        }

        [TestMethod]
        [ExpectedException(typeof(TypeAvertissementNotFoundException))]
        public async Task CreateAvertissementService_TypeRandoInvalid_Min()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = -1,
                    randonneeId = 1
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(GPSOutOfBoundsException))]
        public async Task CreateAvertissementService_GpsInvalid_MaxX()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 91,
                    y = 0,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(GPSOutOfBoundsException))]
        public async Task CreateAvertissementService_GpsInvalid_MinX()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = -91,
                    y = 0,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(GPSOutOfBoundsException))]
        public async Task CreateAvertissementService_GpsInvalid_MaxY()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 0,
                    y = 181,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(GPSOutOfBoundsException))]
        public async Task CreateAvertissementService_GpsInvalid_MinY()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 0,
                    y = -181,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(DescriptionOutOfBoundsException))]
        public async Task CreateAvertissementService_DescriptionInvalid_Max()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();
                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 90,
                    y = 180,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "12345678901234567890123456789012345678901234567890plusque50",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }

        [TestMethod]
        [ExpectedException(typeof(DescriptionOutOfBoundsException))]
        public async Task CreateAvertissementService_DescriptionInvalid_Min()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();
                GPS gps = new GPS
                {
                    id = 0,
                    arrivee = false,
                    depart = false,
                    x = 90,
                    y = 180,
                    randonneeId = 1
                };

                AvertissementDTO avertissement = new AvertissementDTO
                {
                    id = 1,
                    description = "",
                    typeAvertissement = 2,
                    randonneeId = 1,
                    gps = gps,
                };

                var result = await avertissementMock.Object.CreateAvertissementAsync(avertissement);


            }
        }


        [TestMethod]
        public async Task DeleteAvertissmentController_Ok()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext);
                var userMock = new Mock<UtilisateursService>(dbContext);

                avertissementMock.Setup(s => s.DeleteAvertissementAsync(It.IsAny<int>())).ReturnsAsync(new bool());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                Avertissement avertissement = new Avertissement();
                var actionResult = await avertissementController.DeleteAvertissement(10);

                Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            }
        }
        [TestMethod]
        public async Task DeleteAvertissmentController_Exception()
        {
            

            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext);
                var userMock = new Mock<UtilisateursService>(dbContext);

                avertissementMock.Setup(s => s.DeleteAvertissementAsync(It.IsAny<int>())).ThrowsAsync(new AvertissementNotFoundException());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                Avertissement avertissement = new Avertissement();
                var actionResult = await avertissementController.DeleteAvertissement(10);

                Assert.IsInstanceOfType(actionResult, typeof(NotFoundObjectResult));
            }

        }
        [TestMethod]
        public async Task DeleteAvertissementService_Valid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                Avertissement avertissement = new Avertissement
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = Avertissement.TypeAvertissement.GlissementTerrain,
                    randonneeId = 1,
                    DateSuppresion = DateTime.Now,
                    randonnee = rando,
                    x = 10,
                    y = 10,
                };
                dbContext.avertissements.Add(avertissement);
                await dbContext.SaveChangesAsync();



                var result = await avertissementMock.Object.DeleteAvertissementAsync(1);

                Avertissement avert = await dbContext.avertissements.FirstOrDefaultAsync(x => x.id == 1);
                Assert.IsNull(avert);
            }
           
        }
        [TestMethod]
        [ExpectedException(typeof(AvertissementNotFoundException))]
        public async Task DeleteAvertissementService_AvertissementInvalid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };
                var result = await avertissementMock.Object.DeleteAvertissementAsync(1000);

            }
            
        }

        [TestMethod]
        public async Task AddTimeAvertissementController_Ok()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext);
                var userMock = new Mock<UtilisateursService>(dbContext);

                avertissementMock.Setup(s => s.AddTimeAvertissementAsync(It.IsAny<int>())).ReturnsAsync(new bool());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                Avertissement avertissement = new Avertissement();
                var actionResult = await avertissementController.AddTime(10);

                Assert.IsInstanceOfType(actionResult, typeof(OkResult));
            }
        }
        [TestMethod]
        public async Task AddTimeAvertissementController_Exception()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var avertissementMock = new Mock<AvertissementService>(dbContext);
                var userMock = new Mock<UtilisateursService>(dbContext);

                avertissementMock.Setup(s => s.AddTimeAvertissementAsync(It.IsAny<int>())).ThrowsAsync(new AvertissementNotFoundException());

                var avertissementController = new AvertissementController(userMock.Object, avertissementMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                avertissementController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                Avertissement avertissement = new Avertissement();
                var actionResult = await avertissementController.AddTime(10);

                Assert.IsInstanceOfType(actionResult, typeof(NotFoundObjectResult));
            }

        }

        [TestMethod]
        public async Task AddTimeAvertissementService_Valid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };

                Randonnee rando = new Randonnee
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
                    image = new Image { id = 1, lien = "", randonneeId = 1 },
                    utilisateurId = 1
                };

                dbContext.randonnees.Add(rando);
                await dbContext.SaveChangesAsync();

                Avertissement avertissement = new Avertissement
                {
                    id = 1,
                    description = "description",
                    typeAvertissement = Avertissement.TypeAvertissement.GlissementTerrain,
                    randonneeId = 1,
                    DateSuppresion = DateTime.Now,
                    randonnee = rando,
                    x = 10,
                    y = 10,
                };
                dbContext.avertissements.Add(avertissement);
                await dbContext.SaveChangesAsync();



                var result = await avertissementMock.Object.AddTimeAvertissementAsync(1);
                Avertissement avert = await dbContext.avertissements.FirstOrDefaultAsync(x => x.id == 1);

                DateTime date = DateTime.Now + TimeSpan.FromDays(7);
                Assert.IsNotNull(avert);
                Assert.AreEqual(avertissement.id, avert.id);
                Assert.AreEqual(avertissement.description, avert.description);
                Assert.AreEqual(avertissement.x, avert.x);
                Assert.AreEqual(avertissement.y, avert.y);
                Assert.AreEqual(avertissement.randonneeId, avert.randonneeId);
                Assert.AreEqual(avertissement.randonnee, avert.randonnee);
                Assert.AreNotEqual(avertissement.DateSuppresion, avert.description);
                Assert.AreEqual(date.Year, avert.DateSuppresion.Year);
                Assert.AreEqual(date.Month, avert.DateSuppresion.Month);
                Assert.AreEqual(date.Day, avert.DateSuppresion.Day);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(AvertissementNotFoundException))]
        public async Task AddTimeAvertissementService_AvertissementInvalid()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                dbContext.Database.EnsureDeleted();
                var avertissementMock = new Mock<AvertissementService>(dbContext) { CallBase = true };
                var result = await avertissementMock.Object.AddTimeAvertissementAsync(1000);

            }
        }
    }
}
