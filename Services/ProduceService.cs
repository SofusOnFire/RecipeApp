using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class ProduceService : IProduceService
	{
		private readonly IProduceRepository _produceRepository;

		public ProduceService(IProduceRepository produceRepository)
		{
			_produceRepository = produceRepository;
		}

		public Produce GetProduceByID(int produceID)
		{
			return _produceRepository.GetProduceByID(produceID);
		}

		public string CreateProduce(string produce)
		{
			bool produceCreated = _produceRepository.CreateProduce(produce);

			string outcome = "Den indtastede ingrediens findes allerede i databasen";

			if (produceCreated)
			{
				outcome = "Ingrediens tilføjet til databasen";
			}

			return outcome;
		}
	}
}
