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

		public List<Produce> CompareAndGetProduceList(List<Produce> userProduces)
		{
			List<Produce> produceList = new List<Produce>();

			List<Produce> allProduces = _produceRepository.GetAllProduce();

			if (userProduces.Count != 0)
			{
				foreach (Produce produce in allProduces)
				{
					bool doesExist = false;
					for (int i = 0; i < userProduces.Count; i++)
					{
						if (userProduces[i].Name == produce.Name)
						{
							doesExist = true;
							break;
						}
					}

					if (!doesExist)
					{
						produceList.Add(produce);
					}
				}
			}
			else
			{
				produceList = allProduces;
			}
            
			return produceList;
		}
	}
}
