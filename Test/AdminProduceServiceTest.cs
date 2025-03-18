using Domain.Interfaces;
using Services;
using Moq;

namespace Test
{
	[TestClass]
	public sealed class AdminProduceServiceTest
	{
		private Mock<IProduceRepository> _mockProduceRepository;
		private IAdminProduceService _adminProduceService;

		[TestInitialize]
		public void Setup()
		{
			_mockProduceRepository = new Mock<IProduceRepository>(); // Laver en kopi af repository
			_adminProduceService = new AdminProduceService(_mockProduceRepository.Object); // Sætter klassen op, så den kan testes
		}

		[TestMethod]
		[DataRow("Bladselleri", "Ingrediens tilføjet til databasen")]
		public void CreateProduce_ShouldReturnSuccessMessage_WhenProduceIsCreated(string input, string expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input))
				.Returns(true); // Fortæller at metoden skal returner true

			// Act
			string result = _adminProduceService.CreateProduce(input);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		[DataRow("Bladselleri", "Den indtastede ingrediens findes allerede i databasen")]
		public void CreateProduce_ShouldReturnErrorMessage_WhenProduceAlreadyExists(string input, string expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input))
				.Returns(false); // Fortæller at metoden skal returner false

			// Act
			string result = _adminProduceService.CreateProduce(input);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
