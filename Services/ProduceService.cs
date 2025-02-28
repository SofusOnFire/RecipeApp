using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	internal class ProduceService : IProduceService
	{
		public IEnumerable<Produce> GetAllProduce()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Produce> GetMatchesByName(string input)
		{
			throw new NotImplementedException();
		}

		public Produce GetProduceByID(int produceID)
		{
			throw new NotImplementedException();
		}
	}
}
