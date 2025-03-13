using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<ProduceLine> ProduceLines { get; } = new List<ProduceLine>();


        public Recipe(int? recipeID, string? recipeName, int? cookTime, string? uRL)
        {
            RecipeID = recipeID;
            RecipeName = recipeName;
            CookTime = cookTime;
            URL = uRL;
        }

        public void AddProduceLine(IEnumerable<ProduceLine> produceLine)
        {
            //ProduceLines = produceLine.ToList();
        }
    }
}
