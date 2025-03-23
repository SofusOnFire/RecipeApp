using Domain.Interfaces;
using Services;
using Moq;
using Domain.Models;
using System.Net;
using System.Xml.Linq;

namespace Test
{
    [TestClass]
    public class AdminCreateRecipeServiceTest
    {
        private Mock<IRecipeRepository> recipeRepositoryMock;
        private Mock<IAdminCreateRecipeService> adminCreateRecipeServiceMock;
        private Mock<IProduceRepository> produceRepositoryMock;
        private Mock<IProduceLineRepository> produceLineRepositoryMock;
        private IAdminCreateRecipeService adminCreateRecipeService;
        private IRecipeRepository recipeRepository;

        [TestInitialize]
        public void Setup()
        {
            recipeRepositoryMock = new Mock<IRecipeRepository>();
            produceLineRepositoryMock = new Mock<IProduceLineRepository>();
            produceRepositoryMock = new Mock<IProduceRepository>();
            adminCreateRecipeServiceMock = new Mock<IAdminCreateRecipeService>();
            adminCreateRecipeService = new AdminCreateRecipeService(produceRepositoryMock.Object, recipeRepositoryMock.Object, produceLineRepositoryMock.Object);
        }

        [TestMethod]
        [DataRow("Guacamole", 15, "www.avocado.dk", true)]
        public void CreateRecipe_ShouldReturnSuccessMessage_IfRecipeCanBeSavedToDB(string name, int cookTime, string url, bool expected)
        {
            List<Produce> testProduces = new List<Produce>();
            Produce testProduce = new Produce(50, "Avocado", 3);
            testProduces.Add(testProduce);

            //Arrange
            adminCreateRecipeServiceMock
                    .Setup(repository => repository.AddRecipe(name, cookTime, url, testProduces));

            // Act
            bool result = adminCreateRecipeService.AddRecipe(name, cookTime, url, testProduces);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(null, 15, null, false)]

        public void CreateRecipe_ShouldReturnFalse_IfErrorInRecipe(string name, int cookTime, string url, bool expected)
        {
            List<Produce> testProduces = new List<Produce>();

            //Arrange
            adminCreateRecipeServiceMock
                    .Setup(repository => repository.AddRecipe(name, cookTime, url, testProduces));

            // Act
            bool result = adminCreateRecipeService.AddRecipe(name, cookTime, url, testProduces);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("", "urlEmpty")]
        public void ValidateURL_ShouldReturnTrue_IfURLStringIsEmpty(string url, string expected)
        {

            //Arrange
            var existingRecipes = new List<Recipe>();

            recipeRepositoryMock.Setup(repository => repository.GetAllRecipesFromDatabase())
                .Returns(existingRecipes);

            // Act
            string result = adminCreateRecipeService.ValidateURL(url);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("https://www.valdemarsro.dk/lasagne/", "urlValid")]
        public void ValidateURL_ShouldReturnTrue_IfURLIsValid(string url, string expected)
        {

            //Arrange
            var existingRecipes = new List<Recipe>();

            recipeRepositoryMock.Setup(repository => repository.GetAllRecipesFromDatabase())
                .Returns(existingRecipes);

            // Act
           string result = adminCreateRecipeService.ValidateURL(url);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("https://www.valdemarsro.dk/lasagne/", "urlExists")]
        public void CreateRecipe_ShoudReturnTrue_IfRecipeAlreadyExistsInDB(string url, string expected)
        {

            //Arrange
            var existingRecipes = new List<Recipe>();
            
            var recipe1 = new Recipe("Lasagne", 180, "https://www.valdemarsro.dk/lasagne/");
            
            existingRecipes.Add(recipe1);

            recipeRepositoryMock.Setup(repository => repository.GetAllRecipesFromDatabase())
                .Returns(existingRecipes);

            // Act
            string result = adminCreateRecipeService.ValidateURL(url);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("", "noName")]     // Intet input.
        [DataRow("   ", "noName")]  // Mellemrums input.
        public void ValidateRecipeName_ShouldReturnTrue_IfInputActivatesNoNameError(string adminNameInput, string expected)
        {
            // Arrange

            // Act
            string result = adminCreateRecipeService.ValidateRecipeName(adminNameInput);

            // Assert
            Assert.AreEqual(expected, result);

        }
        
        [TestMethod]
        [DataRow("ab", "invalid")]                          // For kort input.
        [DataRow("abcdefghijklmnopqrstuvwxyz", "invalid")]  // For langt input.
        public void ValidateRecipeName_ShouldReturnTrue_IfInputActivatesInvalidError(string adminNameInput, string expected)
        {
            // Arrange

            // Act
            string result = adminCreateRecipeService.ValidateRecipeName(adminNameInput);

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [DataRow("GodtSolidtNavn", "valid")]
        public void ValidateRecipeName_ShouldReturnTrue_IfInputIsValid(string adminNameInput, string expected)
        {
            // Arrange

            // Act
            string result = adminCreateRecipeService.ValidateRecipeName(adminNameInput);

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void AddProduceToNewRecipe_ShouldReturnTrue_WhenProduceIsAdded()
        {
            // Arrange
            var allProduce = new List<Produce>();

            var test1 = new Produce(1, "Bladselleri", 2);

            adminCreateRecipeService.AllProduceWhenAdminCreateRecipe.Add(test1);
            
            //allProduce.Add(test1);

            // Act
            adminCreateRecipeService.AddProduceToNewRecipe(test1);

            // Assert
            Assert.IsTrue(adminCreateRecipeService.AllProduceWhenAdminCreateRecipe.Contains(test1));
            //Assert.IsFalse(selectedProduce.Contains(produce));
        }
    }
}