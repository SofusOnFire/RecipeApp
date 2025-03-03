using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProduceLineService
    {
		/// <summary>
		/// Gets all recipe producelines from the database based on recipeID.
		/// </summary>
		/// <param name="recipeID"></param>
		/// <returns></returns>
		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID);

		/// <summary>
		/// Gets the linked produce that is linked to the produceline
		/// </summary>
		/// <param name="produceLine"></param>
		/// <returns></returns>
		public Produce GetProduceByID(ProduceLine produceLine);
    }
}
