using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRecipeService
    {
		/// <summary>
		/// Gets all recipe producelines from the database based on recipeID.
		/// </summary>
		/// <param name="recipeID"></param>
		/// <returns></returns>
		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID);

	}
}
