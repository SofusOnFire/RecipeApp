using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	class RecipeService : IRecipeService
	{
		private readonly IUserProduce _userProduce; // DI for FindRecipe method.
	}
}
