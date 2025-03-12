namespace Domain.Models
{
	public class ProduceLine
    {
        public int ProduceLineID { get; private set; }
        public int RecipeID { get; private set; }
        public int ProduceID { get; private set; }
        public Produce Produce { get; private set; }
		public Recipe Recipe { get; private set; }

		public ProduceLine(int produceLineID, int recipeID, int produceID)
		{
			ProduceLineID = produceLineID;
			RecipeID = recipeID;
			ProduceID = produceID;
		}

	}
}
