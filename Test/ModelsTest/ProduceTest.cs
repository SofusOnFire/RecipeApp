namespace Test;
using Domain.Models;

[TestClass]
public class ProduceTests
{
	private Produce _testProduce;
	private List<int> _testAmountNeededForRecipe;

	[TestInitialize]
	public void Setup()
	{
		// Initialize lists before adding elements
		_testProduce = new Produce(1, "Tomat", 1);

		_testAmountNeededForRecipe = new List<int> { 0, -1, 100, 1, 100 };
	}

	[TestMethod]
	public void SetStockStatus_ShouldChangeStatusColorOfProduce_WhenProduceAndNeededAmountIsPassedIntoMethod()
	{
		// Arrange
		var produce = _testProduce; // Tomat, UserAmount = 1
		var comparedProduce = new Produce(1, "Tomat", 2);

		// Act & Assert

		// Case 1: recipeAmountOfIngredient is null -> Should be "red"
		produce.SetStockStatus(comparedProduce, null);
		Assert.AreEqual("red", produce.InStockStatus, "Expected 'red' when recipe amount is null");

		// Case 2: comparedProduce.UserAmount == 0 -> Should be "red"
		comparedProduce.UserAmount = 0;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[0]); // 0
		Assert.AreEqual("red", produce.InStockStatus, "Expected 'red' when comparedProduce.UserAmount is 0");

		// Case 3: recipeAmountOfIngredient <= comparedProduce.UserAmount -> Should be "green"
		comparedProduce.UserAmount = 100;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[2]); // 100
		Assert.AreEqual("green", produce.InStockStatus, "Expected 'green' when recipe amount is less than or equal to stock");

		// Case 4: recipeAmountOfIngredient > comparedProduce.UserAmount -> Should be "yellow"
		comparedProduce.UserAmount = 1;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[2]); // 100 (greater than 1)
		Assert.AreEqual("yellow", produce.InStockStatus, "Expected 'yellow' when recipe amount is greater than stock");
	}
}
