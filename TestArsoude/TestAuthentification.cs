using arsoudeServeur.Controllers;
using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using arsoudeServeur.Services.Interfaces;
using arsoudServeur.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestArsoude
{

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager()
            : base(
                  new Mock<IUserStore<IdentityUser>>().Object,
                  new Mock<Microsoft.Extensions.Options.IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<IdentityUser>>().Object,
                  new IUserValidator<IdentityUser>[0],
                  new IPasswordValidator<IdentityUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }
    }
    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public FakeSignInManager()
            : base(
                  new Mock<FakeUserManager>().Object,
                  new HttpContextAccessor(),
                  new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                  new Mock<Microsoft.Extensions.Options.IOptions<IdentityOptions>>().Object,
                  new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                  new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object,
                  new Mock<Microsoft.AspNetCore.Identity.IUserConfirmation<IdentityUser>>().Object
                  )
        { }
    }


    [TestClass]
    public class AuthentificationTest
    {
        DbContextOptions<ApplicationDbContext> options;
        public AuthentificationTest()
        {
            //  On initialise les options de la BD, on utilise une InMemoryDatabase
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    // il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                    .UseInMemoryDatabase(databaseName: "AuthentitficationService")
                    .Options;
        }

        [TestMethod]
        public async Task Register_WithValidData_ReturnsOk()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var userManagerMock = new Mock<FakeUserManager>();
                var mockSignIn = new Mock<FakeSignInManager>();
                var mockUtilisateurService = new Mock<UtilisateursService>(dbContext);
                var mockConfiguration = new Mock<IConfiguration>();
                var controller = new AuthentificationController(userManagerMock.Object, mockUtilisateurService.Object);
                var registerDto = new RegisterDTO
                {
                    nom = "John",
                    prénom = "Doe",
                    courriel = "johndoe@example.com",
                    motDePasse = "Password123!",
                    confirmationMotDePasse = "Password123!",
                    codePostal = "A1B 2C3",
                    anneeDeNaissance = 1990,
                    moisDeNaissance = 5,
                    adresse = "123 Main St"
                };

                mockUtilisateurService.Setup(s => s.PostUtilisateurFromIdentityUserId(It.IsAny<string>())).Verifiable();
                

                // Act
                var result = await controller.Register(registerDto);

                // Assert
                Assert.IsInstanceOfType(result, typeof(OkResult));
            }
        }

        /*[TestMethod]
        public async Task Register_WithInvalidEmail_ReturnsBadRequest()
        {
            // Arrange
            var registerDto = new RegisterDTO 
            {
                nom = "John",
                prénom = "Doe",
                courriel = "johndoe@example.com",
                motDePasse = "Password123!",
                confirmationMotDePasse = "Password123!",
                codePostal = "A1B 2C3",
                anneeDeNaissance = 1990,
                moisDeNaissance = 5,
                adresse = "123 Main St"
            };

            // Act
            var result = await _controller.Register(registerDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }*/
    }
}