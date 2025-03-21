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
		[DataRow("Bladselleri", 8 , true)]
		[DataRow("Mango", 1 ,true)]
		public void CreateProduce_ShouldReturnSuccessMessage_WhenProduceIsCreated(string input, int unitID, bool expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input, unitID))
				.Returns(true); // Simulere at der returneres true

			// Act
			bool result = _adminProduceService.CreateProduce(input, unitID);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		[DataRow("Himalaya salt", 2 ,false)]
		[DataRow(null, null ,false)]
		public void CreateProduce_ShouldReturnErrorMessage_WhenProduceAlreadyExists(string input, int unitID, bool expected)
		{
			// Arrange
			_mockProduceRepository
				.Setup(repository => repository.CreateProduce(input, unitID))
				.Returns(false); // Simulere at der returneres false

			// Act
			bool result = _adminProduceService.CreateProduce(input, unitID);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
