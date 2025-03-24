using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
    public class AdminCreateRecipeService : IAdminCreateRecipeService
    {
        public List<Produce> AllProduceWhenAdminCreateRecipe { get; private set; } = new List<Produce>();
        public List<Produce> SelectedProduceWhenAdminCreateRecipe { get; private set; } = new List<Produce>();
        public List<int> GetCookTimes { get; private set; } = new List<int>();
        private readonly IProduceLineRepository _produceLineRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IProduceRepository _produceRepository; // Exists to use the GetAllProduce-method to retrieve all produce from DB.
        /// <summary>
        /// Retrieves all produce from DB and allows Admin to select the produce wanted for the new recipe.
        /// Also allows for the admin to remove produce if misselected.
        /// </summary>
        /// <param name="produce"></param>
        /// <param name="listOfProduce"></param>
        /// 

        public AdminCreateRecipeService(IProduceRepository produceRepository, IRecipeRepository recipeRepository, IProduceLineRepository produceLineRepository)
        {
            _produceRepository = produceRepository;
            AllProduceWhenAdminCreateRecipe = _produceRepository.GetAllProduce();
            _recipeRepository = recipeRepository;
            GetCookTimes.AddRange(new List<int>{15, 30, 45, 60, 75, 90, 115, 120, 150,
            180, 210, 240, 300, 360, 420, 480, 540, 600});
            _produceLineRepository = produceLineRepository;
            _produceLineRepository = produceLineRepository;

        }

        public List<Produce> GetAllProduces()
        {
            return _produceRepository.GetAllProduce();
        }

        /// <summary>
        /// Iterates through all produces in the AllProduceWhenAdminCreateRecipe list,
        /// until the loop finds a produce that matches the argument. The argument
        /// then gets added to the SelectedProduceWhenAdminCreateRecipe list.
        /// </summary>
        public void AddProduceToNewRecipe(Produce produce)
        {
            foreach (var prod in AllProduceWhenAdminCreateRecipe)
            {
                if (prod == produce)
                {
                    AllProduceWhenAdminCreateRecipe.Remove(produce);
                    break;
                }
            }
            SelectedProduceWhenAdminCreateRecipe.Add(produce);
            SelectedProduceWhenAdminCreateRecipe.Sort();
        }

        /// <summary>
        /// Iterates through all produces in the SelectedProduceWhenAdminCreateRecipe list,
        /// until the loop finds a produce that matches the argument. The produce
        /// then gets removed from the SelectedProduceWhenAdminCreateRecipe list and
        /// its RecipeAmount is set to 1.
        /// </summary>
        public void RemoveProduceFromNewRecipe(Produce produce)
        {
            foreach (var prod in SelectedProduceWhenAdminCreateRecipe)
            {
                if (prod == produce)
                {
                    prod.RecipeAmount = 1;
                    SelectedProduceWhenAdminCreateRecipe.Remove(produce);
                    break;
                }
            }
            AllProduceWhenAdminCreateRecipe.Add(produce);
            AllProduceWhenAdminCreateRecipe.Sort();
        }
        /// <summary>
        /// Validates the user input and checks if its a valid URL. Returns a
        /// string that will be used to show an alert message in the UI.
        /// </summary>
        public string ValidateURL(string url)
        {

            if (string.IsNullOrEmpty(url))
            {
                return "urlEmpty";
            }

            else if (!url.StartsWith("www.") && !url.StartsWith("https://") && !url.StartsWith("http://"))
            {
                return "urlInvalid";
            }

            else if (!string.IsNullOrEmpty(url))
            {
                IEnumerable<Recipe> allRecipes = _recipeRepository.GetAllRecipesFromDatabase();
                bool exists = false;

                foreach (var recipe in allRecipes)
                {
                    if (recipe.URL == url)
                    {
                        exists = true;
                    }
                }
                if (exists)
                {
                    return "urlExists";
                }
                else
                {
                    return "urlValid";
                }
            }
            else
            {
                return "urlValid";
            }
        }
        /// <summary>
        /// Validates the user input and checks if the recipe name is valid. Returns a string
        /// that will be used to show an alert message in the UI.
        /// </summary>
        public string ValidateRecipeName(string adminNameInput)
        {
            if (adminNameInput == null || String.IsNullOrWhiteSpace(adminNameInput))
            {
                return "noName";
            }
            else if (Char.IsWhiteSpace(adminNameInput[adminNameInput.Length - 1]))
            {
                return "invalid";
            }
            else if (adminNameInput.Length < 3)
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

        /// <summary>
        /// Checks if the recipe name, url and producelist aren't null. If they aren't,
        /// the AdminAddRecipeToDB method will be called in order to insert the recipe
        /// into the DB and return the recipe's ID, which will then be used in the
        /// AddProduceLines method along with the producelist. Then, each produce's
        /// RecipeAmount will be set back to 1 (standard value) and return true (will be
        /// used for an alert message).
        /// 
        /// If either the recipe name, url or producelist are null, nothing will happen
        /// and it will return false (will be used for an alert message).
        /// </summary>
        public bool AddRecipe(string recipeName, int cookTime, string uRL, List<Produce> produceList)
        {
            if (!string.IsNullOrEmpty(recipeName) && uRL != null && produceList != null)
            {
                int recipeID = _recipeRepository.AdminAddRecipeToDB(recipeName, cookTime, uRL);
                _produceLineRepository.AddProduceLines(produceList, recipeID);
                foreach (Produce produce in produceList)
                {
                    produce.RecipeAmount = 1;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearAddedProduces()
        {
            SelectedProduceWhenAdminCreateRecipe.Clear();
        }
    }
}
