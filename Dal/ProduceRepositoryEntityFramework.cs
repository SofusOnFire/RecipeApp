using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace DAL
{
	internal class ProduceRepositoryEntityFramework : IProduceRepository
	{
		private readonly DbcontextEntityFramework _dbcontext = new DbcontextEntityFramework();

		public List<Produce> GetAllProduce()
		{
			return _dbcontext.Produces.ToList();
		}

		public Produce GetProduceByID(int produceID)
		{
			return _dbcontext.Produces.Where(p => p.ProduceID == produceID).FirstOrDefault();
		}
	}
}
