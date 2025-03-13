namespace Domain.Models
{
	public class ProduceLine
	{
		public int ProduceLineID { get; private set; }
		public int RecipeID { get; private set; }
		public int ProduceID { get; private set; }

		public Produce? Produce { get; }  
		public Recipe? Recipe { get; }


		public ProduceLine(int produceLineID, int recipeID, int produceID)
		{
			ProduceLineID = produceLineID;
			RecipeID = recipeID;
			ProduceID = produceID;
		}
	}
}
