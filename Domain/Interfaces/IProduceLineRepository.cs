using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProduceLineRepository
    {
        /// <summary>
        /// Returns all ProduceLines with the correct Produce via Join for a specific recipeID
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public IEnumerable<ProduceLine> GetAllProduceLineByRecipeID(int? recipeID);
    }
}
