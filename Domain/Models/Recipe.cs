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

        public void SetProduceLineList(IEnumerable<ProduceLine> produceLines)
        {
            var list = produceLines.ToList<ProduceLine>();
            ProduceLines = list;
        }
        public bool ValidateRecipeName(string adminInput)
        {
            adminInput.ToCharArray();
            if (adminInput.Length < 3)
            {
                return ""
            }
        }
        public void ValidateCookTime()
        {

        }
    }
}
