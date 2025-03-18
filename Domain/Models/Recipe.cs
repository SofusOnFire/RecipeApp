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
        
        public string ValidateRecipeName(string adminNameInput)
        {

            if (adminNameInput.Length < 3)
            {
                return "invalid";
            }
            else if (adminNameInput.Length > 20)
            {
                return "invalid";
            }
            else
            {
                return "valid";
            }
        }
        
        public string ValidateCookTime(int adminCookTimeInput)
        {
            int[] validNumbers = { 15, 30, 45, 60, 75, 90, 115, 120, 150, 
                                   180, 210, 240, 300, 360, 420, 480, 540, 600 };
            
            if (adminCookTimeInput < 15)
            {
                return "invalid";
            }
            if (adminCookTimeInput > 600)
            {
                return "invalid";
            }
            if (!validNumbers.Contains(adminCookTimeInput))
            {
                return "invalid";
            }
            else
            {
                return "valid";
            }
        }
    }
}
