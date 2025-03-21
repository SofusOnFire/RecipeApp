using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Recipe
    {
        public int? RecipeID { get; private set; }
        public string? RecipeName { get; private set; }
        public int? CookTime { get; private set; }
        public string? URL { get; private set; }
        public List<ProduceLine>? ProduceLines { get; private set; }

        public Recipe(int? recipeID, string? name, int? cookTime, string? uRL)
        {
            RecipeID = recipeID;
            RecipeName = name;
            CookTime = cookTime;
            URL = uRL;
            ProduceLines = new List<ProduceLine>();
        }

        public Recipe(string? recipeName, int? cookTime, string? uRL)
        {
            RecipeName = recipeName;
            CookTime = cookTime;
            URL = uRL;
        }

        public void SetProduceLineList(IEnumerable<ProduceLine> produceLines)
        {
            var list = produceLines.ToList<ProduceLine>();
            ProduceLines = list;
        }

        /// <summary>
        /// ReOrder ProduceLines in Recipe, so its inorder of green, yellow, red. 
        /// Green is when user has enough of Produce needed for Recipe
        /// Yellow is when user doesn't have enough of Produce needed for Recipe
        /// Red is when user doesn't have the Produce at all
        /// </summary>
        public void ReOrderProduceLines()
        {
			// List to store produce the user doesn't have in stock
			List<ProduceLine> greenStockProduces = new List<ProduceLine>();
			List<ProduceLine> yellowStockProduces = new List<ProduceLine>();
			List<ProduceLine> redStockProduces = new List<ProduceLine>();

            if (ProduceLines == null) // If the recipe doesn't have any produce, get the next recipe
                return;

			// Iterates through all of the lines of the current recipe
			for (int i = 0; i < ProduceLines.Count; i++)
			{

				if (ProduceLines[i]._Produce.InStockStatus == "green") greenStockProduces.Add(ProduceLines[i]);
				else if (ProduceLines[i]._Produce.InStockStatus == "yellow") yellowStockProduces.Add(ProduceLines[i]);
                else redStockProduces.Add(ProduceLines[i]); 
			}

            // Concat all 3 lists, so that green is first then yellow then red
            greenStockProduces.AddRange(yellowStockProduces);
            greenStockProduces.AddRange(redStockProduces);

            ProduceLines = greenStockProduces;
		}
    }
}
