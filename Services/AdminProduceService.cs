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

		public string CreateProduce(string produceName)
		{
            StringBuilder formattedName = new StringBuilder();
            foreach (char c in produceName)
            {
                if (c == produceName[0])
                {
					formattedName.Append(char.ToUpper(c));
                }
                else
                {
					formattedName.Append(char.ToLower(c));
                }
            }

            produceName = formattedName.ToString();

            bool isCreated = _produceRepository.CreateProduce(produceName);

			string outcome = $"{produceName} findes allerede i databasen";

			if (isCreated == true)
			{
				outcome = $"{produceName} tilføjet til databasen";
			}

			return outcome;
		}
	}
}
