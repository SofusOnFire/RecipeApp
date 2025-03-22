using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Produce : IComparable<Produce>
    {
		public int ProduceID { get; private set; }
        public string? Name { get; private set; }
		public string? InStockStatus { get; private set; }
        public int UnitID { get; private set; }
        public Unit? Unit { get; private set; }
		public int UserAmount { get;  set; }
		public int RecipeAmount { get; set; }

		public Produce(int produceID, string? name, int unitID) 
		{
			ProduceID = produceID;
			Name = name;
			UnitID = unitID;
			UserAmount = 1;
			RecipeAmount = 1;
		}

		/// <summary>
		/// Checks if the 2 Produces has the name.
		/// Then its set the status. If RecipeAmountOfIngredient is null or 0, set it as red (the color of text for UI). 
		/// If RecipeAmountOfIngredient is less than UserAmount set as green (Means User has the Amount of Produce needed for Recipe).
		/// If RecipeAmountOfIngredient is Greater than UserAmount set as yellow (Means User does not have enough of the Prodce needed for Recipe). 
		/// </summary>
		public void SetStockStatus(Produce comparedProduce, int? recipeAmountOfIngredient)
		{
			if (comparedProduce.Name == Name)
			{
				if (comparedProduce.UserAmount == 0 || recipeAmountOfIngredient == null)
				{
					InStockStatus = "red";
				}
				else if (recipeAmountOfIngredient > comparedProduce.UserAmount)
				{
					InStockStatus = "yellow";
				}
				else // recipeAmountOfIngredient <= comparedProduce.UserAmount
				{
					InStockStatus = "green";
				}

			}
		}

		/// <summary>
		/// Simple set doesn't validate at this point. Used to set Unit to Produce in Dal
		/// </summary>
		/// <param name="unit"></param>
		public void SetUnit(Unit unit)
		{
			Unit = unit;
		}

		public int CompareTo(Produce? other)
		{
			return Name.CompareTo(other.Name);
		}
	}
}
