using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class RefactoredProduceLineRepository : DatabaseManager, IProduceLineRepository
    {
        private readonly IProduceRepository _produceRepository;

        public RefactoredProduceLineRepository(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
        }

        public IEnumerable<ProduceLine> GetAllProduceLineByRecipeID(int? recipeID)
        {
            throw new NotImplementedException();
        }
    }
}
