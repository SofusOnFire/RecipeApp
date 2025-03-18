using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            StringBuilder BigProduce = new StringBuilder();
            foreach (char c in produce)
            {
                if (c == produce[0])
                {
                    BigProduce.Append(Char.ToUpper(c));
                }
                else
                {
                    BigProduce.Append(Char.ToLower(c));
                }
            }

            produce = BigProduce.ToString();

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
