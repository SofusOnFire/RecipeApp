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
		[DataRow("Bladselleri", true)]
		[DataRow("Mango", true)]
		public void CreateProduce_ShouldReturnSuccessMessage_WhenProduceIsCreated(string input, bool expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input))
				.Returns(true); // Simulere at der returneres true

			// Act
			bool result = _adminProduceService.CreateProduce(input);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		[DataRow("Himalaya salt", false)]
		[DataRow("Tangcaviar", false)]
		public void CreateProduce_ShouldReturnErrorMessage_WhenProduceAlreadyExists(string input, bool expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input))
				.Returns(false); // Simulere at der returneres false

			// Act
			bool result = _adminProduceService.CreateProduce(input);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
