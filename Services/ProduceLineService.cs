using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class ProduceLineService : IProduceLineService
	{
		private readonly IProduceLineRepository _produceLineRepository;
		private readonly IProduceService _produceService;

		public ProduceLineService(IProduceLineRepository produceLineRepository)
		{
			_produceLineRepository = produceLineRepository;
		}

		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int recipeID)
		{
			return _produceLineRepository.GetAllProduceLineByRecipeID(recipeID);
		}

		public Produce GetProduceByID(ProduceLine produceLine)
		{
			throw new NotImplementedException();
		}
	}
}
