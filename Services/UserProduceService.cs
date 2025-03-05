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
		
		public void MoveBetweenList(Produce produce, List<Produce> listOfProduce)
		{
			if (listOfProduce != null && listOfProduce.Contains(produce))
			{
				listOfProduce.Remove(produce);
				UserProduceList.Add(produce);
				UserProduceList.Sort();
			}
			else if (UserProduceList.Contains(produce))
			{
				UserProduceList.Remove(produce);
				listOfProduce.Add(produce);
				listOfProduce.Sort();
			}
		}
	}
}
