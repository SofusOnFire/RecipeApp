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

		public ProduceLineService(IProduceLineRepository produceLineRepository, IProduceService produceService)
		{
			_produceLineRepository = produceLineRepository;
			_produceService = produceService;
		}

		public IEnumerable<ProduceLine> GetAllRecipeProduceLinesByRecipeID(int? recipeID)
		{
			IEnumerable<ProduceLine> produceLines = _produceLineRepository.GetAllProduceLineByRecipeID(recipeID);

			foreach (ProduceLine line in produceLines)
			{
				Produce produce = _produceService.GetProduceByID(line.ProduceID);
				line.SetProduce(produce);
			}

			return produceLines;
		}
	}
}
