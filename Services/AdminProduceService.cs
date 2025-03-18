using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminProduceService : IAdminProduceService
    {
		IProduceRepository _produceRepository;

		public AdminProduceService(IProduceRepository produceRepository)
		{
			_produceRepository = produceRepository;
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
