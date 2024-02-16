using arsoudeServeur.Models;
using arsoudeServeur.Models.DTOs;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Security.Claims;
using static arsoudeServeur.Services.UtilisateursService;

namespace Tests.Controllers
{
    [TestClass]
    public class ProfilTest
    {
        DbContextOptions<ApplicationDbContext> options;
        public ProfilTest()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ProfilService")
                .Options;
        }

        //Tests Controller
            //EditProfil

        [TestMethod]
        public async Task EditProfil_Controller_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1 };

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);

                userMock.Setup(service => service.EditProfil(It.IsAny<Utilisateur>(), It.IsAny<EditProfilDTO>()))
                          .ReturnsAsync(userTest);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditProfilDTO editDTO = new EditProfilDTO { nom = "Georgy", prenom = "Lasalle", adresse = "200 twisted lane", codePostal = "Y6T 3R6", anneeDeNaissance = 1999, moisDeNaissance = 1 };

                var actionResult = await profilController.Edit(editDTO);

                var result = actionResult.Result as OkObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditProfil_Controller_UtilisateurNull()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns((Utilisateur)null);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditProfilDTO editDTO = new EditProfilDTO { nom = "G", prenom = "Lasalle", adresse = "200 twisted lane", codePostal = "Y6T 3R6", anneeDeNaissance = 1999, moisDeNaissance = 1 };

                var actionResult = await profilController.Edit(editDTO);

                var result = actionResult.Result as NotFoundObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditProfil_Controller_UtilisateurId0()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur { identityUserId = null, id = 0 };

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditProfilDTO editDTO = new EditProfilDTO { nom = "G", prenom = "Lasalle", adresse = "200 twisted lane", codePostal = "Y6T 3R6", anneeDeNaissance = 1999, moisDeNaissance = 1 };

                var actionResult = await profilController.Edit(editDTO);

                var result = actionResult.Result as NotFoundObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        //EditPassword
        [TestMethod]
        public async Task EditPassword_Controller_Good()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1 };

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);

                userMock.Setup(service => service.EditPassword(It.IsAny<Utilisateur>(), It.IsAny<string>(), It.IsAny<string>()))
                          .ReturnsAsync(true);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditPasswordDTO editDTO = new EditPasswordDTO { currentPassword = "Passw0rd!", newPassword = "Pass0!"};

                IActionResult actionResult = await profilController.EditPassword(editDTO);

                var result = actionResult as OkResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditPassword_Controller_ErreurService()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur { identityUserId = "11111111-1111-1111-1111-111111111111", id = 1 };

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);

                userMock.Setup(service => service.EditPassword(It.IsAny<Utilisateur>(), It.IsAny<string>(), It.IsAny<string>()))
                          .ThrowsAsync(new BadPasswordException("PasswordMismatch"));

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditPasswordDTO editDTO = new EditPasswordDTO { currentPassword = "Passw0rd!", newPassword = "Pass0!" };

                IActionResult actionResult = await profilController.EditPassword(editDTO);

                var result = actionResult as BadRequestObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditPassword_Controller_UtilisateurNull()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns((Utilisateur)null);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditPasswordDTO editDTO = new EditPasswordDTO { currentPassword = "Passw0rd!", newPassword = "Pass0!" };

                IActionResult actionResult = await profilController.EditPassword(editDTO);

                var result = actionResult as NotFoundObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditPassword_Controller_UtilisateurId0()
        {

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur { identityUserId = null, id = 0 };

                var userMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };
                userMock.Setup(service => service.GetUtilisateurFromUserId(It.IsAny<string>()))
                        .Returns(userTest);

                var profilController = new ProfilController(userMock.Object);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]

                {
                new Claim(ClaimTypes.NameIdentifier, "11111111-1111-1111-1111-111111111111"),
                }));
                profilController.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                };

                // Appel de la méthode dans le contrôleur et vérification du résultat
                EditPasswordDTO editDTO = new EditPasswordDTO { currentPassword = "Passw0rd!", newPassword = "Pass0!" };

                IActionResult actionResult = await profilController.EditPassword(editDTO);

                var result = actionResult as NotFoundObjectResult;


                Assert.IsNotNull(result);
                dbContext.Database.EnsureDeleted();
            }
        }

        //Tests Service
            //Edit Profil
        [TestMethod]
        public async Task EditProfil_Service_Good()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur
                {
                    nom = "George",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = "test@gmail.com",
                    adresse = "",
                    identityUserId = "11111111-1111-1111-1111-111111111122",
                };
                dbContext.utilisateurs.Add(userTest);
                dbContext.SaveChanges();

                var utilisateursServiceMock = new Mock<UtilisateursService>(dbContext) { CallBase=true };
                    
                //appel de la méthode
                EditProfilDTO editDTO = new EditProfilDTO { nom = "Georgy", prenom = "Lasalle", adresse = "200 twisted lane", codePostal = "Y6T 3R6", anneeDeNaissance = 1999, moisDeNaissance = 1};

                await utilisateursServiceMock.Object.EditProfil(userTest, editDTO);
                dbContext.SaveChanges();

                Assert.AreEqual("Georgy", userTest.nom);
                Assert.AreEqual("Lasalle", userTest.prenom);
                Assert.AreEqual("200 twisted lane", userTest.adresse);
                Assert.AreEqual("Y6T 3R6", userTest.codePostal);
                Assert.AreEqual(1999, userTest.anneeDeNaissance);
                Assert.AreEqual(1, userTest.moisDeNaissance);

                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public async Task EditProfil_Service_GoodDonneesNull()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var userTest = new Utilisateur
                {
                    nom = "George",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = "test@gmail.com",
                    adresse = "300 de la mouette",
                    identityUserId = "11111111-1111-1111-1111-111111111122",
                    anneeDeNaissance = 1999,
                    moisDeNaissance = 5
                };
                dbContext.utilisateurs.Add(userTest);
                dbContext.SaveChanges();

                var utilisateursServiceMock = new Mock<UtilisateursService>(dbContext) { CallBase = true };

                //appel de la méthode
                EditProfilDTO editDTO = new EditProfilDTO { nom = "Georgy", prenom = "Lasalle", adresse = null, codePostal = "Y6T 3R6", anneeDeNaissance = null, moisDeNaissance = null };

                await utilisateursServiceMock.Object.EditProfil(userTest, editDTO);
                dbContext.SaveChanges();

                Assert.AreEqual("Georgy", userTest.nom);
                Assert.AreEqual("Lasalle", userTest.prenom);
                Assert.AreEqual("", userTest.adresse);
                Assert.AreEqual("Y6T 3R6", userTest.codePostal);
                Assert.AreEqual(0, userTest.anneeDeNaissance);
                Assert.AreEqual(0, userTest.moisDeNaissance);

                dbContext.Database.EnsureDeleted();
            }
        }

            //EditPassword
        [TestMethod]
        public async Task EditPassword_Service_Good()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var hasher = new PasswordHasher<IdentityUser>();
                var utilisateur2 = new IdentityUser
                {
                    Id = "11111111-1111-1111-1111-11111111114",
                    UserName = "user2@hotmail.com",
                    Email = "user2@hotmail.com",

                    NormalizedUserName = "USER2@HOTMAIL.COM",
                    NormalizedEmail = "USER2@HOTMAIL.COM",
                    EmailConfirmed = true
                };
                utilisateur2.PasswordHash = hasher.HashPassword(utilisateur2, "Passw0rd!");
                dbContext.Users.Add(utilisateur2);
                dbContext.SaveChanges();

                var userTest = new Utilisateur
                {
                    id = 40,
                    nom = "George",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur2.UserName,
                    adresse = "",
                    identityUserId = utilisateur2.Id,
                };
                dbContext.utilisateurs.Add(userTest);
                dbContext.SaveChanges();

                var userManagerMock = new Mock<UserManager<IdentityUser>>(
                    new Mock<IUserStore<IdentityUser>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<IdentityUser>>().Object,
                    new IUserValidator<IdentityUser>[0],
                    new IPasswordValidator<IdentityUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<IdentityUser>>>().Object
                );

                userManagerMock
                    .Setup(userManager => userManager.ChangePasswordAsync(It.IsAny<IdentityUser>(), It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(IdentityResult.Success);

                var utilisateursServiceMock = new Mock<UtilisateursService>(dbContext, userManagerMock.Object) { CallBase = true };

                //appel de la méthode
                var result = await utilisateursServiceMock.Object.EditPassword(userTest, "Passw0rd!", "Pass0!");
                dbContext.SaveChanges();

                Assert.AreEqual(true, result);

                dbContext.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BadPasswordException))]
        public async Task EditPassword_Service_MauvaisPassword()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var hasher = new PasswordHasher<IdentityUser>();
                var utilisateur2 = new IdentityUser
                {
                    Id = "11111111-1111-1111-1111-11111111114",
                    UserName = "user2@hotmail.com",
                    Email = "user2@hotmail.com",

                    NormalizedUserName = "USER2@HOTMAIL.COM",
                    NormalizedEmail = "USER2@HOTMAIL.COM",
                    EmailConfirmed = true
                };
                utilisateur2.PasswordHash = hasher.HashPassword(utilisateur2, "Passw0rd!");
                dbContext.Users.Add(utilisateur2);
                dbContext.SaveChanges();

                var userTest = new Utilisateur
                {
                    id = 40,
                    nom = "George",
                    prenom = "robert",
                    codePostal = "E3A 4R4",
                    role = "User",
                    courriel = utilisateur2.UserName,
                    adresse = "",
                    identityUserId = utilisateur2.Id,
                };
                dbContext.utilisateurs.Add(userTest);
                dbContext.SaveChanges();

                var userManagerMock = new Mock<UserManager<IdentityUser>>(
                    new Mock<IUserStore<IdentityUser>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<IdentityUser>>().Object,
                    new IUserValidator<IdentityUser>[0],
                    new IPasswordValidator<IdentityUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<IdentityUser>>>().Object
                );

                var identityErrors = new IdentityError[]
                {
                    new IdentityError
                    {
                        Code = "PasswordMismatch",
                        Description = "PasswordMismatch"
                    }
            };

                userManagerMock
                    .Setup(userManager => userManager.ChangePasswordAsync(It.IsAny<IdentityUser>(), It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(IdentityResult.Failed(identityErrors));

                var utilisateursServiceMock = new Mock<UtilisateursService>(dbContext, userManagerMock.Object) { CallBase = true };

                //appel de la méthode
                await utilisateursServiceMock.Object.EditPassword(userTest, "Pass0rd!", "Pass0!");
                dbContext.SaveChanges();

                dbContext.Database.EnsureDeleted();
            }
        }
    }
}
