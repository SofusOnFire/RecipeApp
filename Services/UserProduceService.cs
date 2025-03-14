using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class UserProduceService : IUserProduceService
	{
		public List<Produce> UserProduceList { get; private set; } = new List<Produce>();
		public List<Produce> AllNotTakenProduces { get; private set; }
		private readonly IProduceService _produceService;

		public UserProduceService(IProduceService produceService)
		{
			_produceService = produceService;
			AllNotTakenProduces = _produceService.GetAllProduce();
		}

		public void MoveBetweenList(Produce produce)
		{
			if (AllNotTakenProduces != null && AllNotTakenProduces.Contains(produce))
			{
				AllNotTakenProduces.Remove(produce);
				UserProduceList.Add(produce);
				UserProduceList.Sort();
			}
			else if (UserProduceList.Contains(produce))
			{
				UserProduceList.Remove(produce);
				AllNotTakenProduces.Add(produce);
				AllNotTakenProduces.Sort();
			}
		}
	}
}
