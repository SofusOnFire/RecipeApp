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


		/* This method creates a new produce list that only contains the
		 * produces that aren't in the users personal list of produces. 
		 * 
		 * If the users produce list isn't empty, it'll iterate through all produces
		 * in the database. If a produce doesn't already exist on the users
		 * produce list, it'll be added to the produce list.
		 * After going through all the produces on the users list, it'll
		 * return a list of produces that aren't already on the user produce list.
		 * If the users produce list is empty, a list of all produces will be returned. */
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
