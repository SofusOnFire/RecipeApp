namespace Test;
using Domain.Models;

[TestClass]
public class ProduceTests
{
	private List<Produce> _testProduce;
	private List<int> _testAmountNeededForRecipe;

	[TestInitialize]
	public void Setup()
	{
		// Initialize lists before adding elements
		_testProduce = new List<Produce>
		{
			new Produce(1, "Tomat", 1),
			new Produce(2, null, 1),
			new Produce(-2, "Tomat", -1),
			new Produce(-8, "Tomat", 1),
			new Produce(9, "Gulerødder", -1)
		};

		_testAmountNeededForRecipe = new List<int> { 0, -1, 100, 1, 100 };
	}

	[TestMethod]
	public void SetStockStatus_ShouldChangeStatusColorOfProduce_WhenProduceAndNeededAmountIsPassedIntoMethod()
	{
		// Arrange - select a produce and a compared produce
		var produce = _testProduce[0]; // Tomat, UserAmount = 1
		var comparedProduce = new Produce(1, "Tomat", 2); // More stock than needed

		// Act & Assert - Various test cases

		// Case 1: recipeAmountOfIngredient is null → Should be "red"
		produce.SetStockStatus(comparedProduce, null);
		Assert.AreEqual("red", produce.InStockStatus, "Expected 'red' when recipe amount is null");

		// Case 2: comparedProduce.UserAmount == 0 → Should be "red"
		comparedProduce.UserAmount = 0;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[0]); // 0
		Assert.AreEqual("red", produce.InStockStatus, "Expected 'red' when comparedProduce.UserAmount is 0");

		// Case 3: recipeAmountOfIngredient <= comparedProduce.UserAmount → Should be "green"
		comparedProduce.UserAmount = 100;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[2]); // 100
		Assert.AreEqual("green", produce.InStockStatus, "Expected 'green' when recipe amount is less than or equal to stock");

		// Case 4: recipeAmountOfIngredient > comparedProduce.UserAmount → Should be "yellow"
		comparedProduce.UserAmount = 1;
		produce.SetStockStatus(comparedProduce, _testAmountNeededForRecipe[3]); // 1
		Assert.AreEqual("yellow", produce.InStockStatus, "Expected 'yellow' when recipe amount is greater than stock");
	}
}

//var thisProduce0 = new Produce(1, "Tomat", 2);
//thisProduce0.SetStockStatus(_testProduce[0], _testAmountNeededForRecipe[0]);
//Assert.AreEqual("green", thisProduce0.InStockStatus);

//var thisProduce1 = new Produce(1, "Tomat", 2);
//thisProduce1.SetStockStatus(_testProduce[1], _testAmountNeededForRecipe[1]);
//Assert.AreEqual("green", thisProduce1.InStockStatus);

//var thisProduce2 = new Produce(1, "Tomat", 2);
//thisProduce2.SetStockStatus(_testProduce[2], _testAmountNeededForRecipe[2]);
//Assert.AreEqual("yellow", thisProduce2.InStockStatus);

//var thisProduce3 = new Produce(1, "Tomat", 2);
//thisProduce3.UserAmount = 0;
//thisProduce3.SetStockStatus(_testProduce[3], _testAmountNeededForRecipe[3]);
//Assert.AreEqual("yellow", thisProduce3.InStockStatus);

//var thisProduce4 = new Produce(1, "Tomat", 2);
//thisProduce4.SetStockStatus(_testProduce[4], _testAmountNeededForRecipe[4]);
//Assert.AreEqual("green", thisProduce4.InStockStatus);
