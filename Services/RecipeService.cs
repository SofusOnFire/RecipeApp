using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IUserProduceService _userProduceService; // DI for FindRecipe method.
		private readonly IProduceLineService _produceLineService; // DI for GetAllRecipeProduceLinesByRecipeID

		public RecipeService(IUserProduceService userProduceService, IProduceLineService produceLineService)
		{
			_userProduceService = userProduceService;
			_produceLineService = produceLineService;
		}

		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID)
		{
			return _produceLineService.GetAllRecipeProduceLinesByRecipeID(recipeID);
		}
	}
}
