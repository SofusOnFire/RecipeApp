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
		// Public Field: The user's temporary personal list of produce.
		public List<Produce> UserProduceList { get; private set; } = new List<Produce>();
		
		/// <summary>
		/// Void: Allows the user to register their personal produce from the list of all produce (retrieved in the database).
		/// </summary>
		/// <param name="produce"></param>
		/// <param name="listOfProduce"></param>
		public void MoveBetweenList(Produce produce, List<Produce> listOfProduce)
		{
			if (listOfProduce != null && listOfProduce.Contains(produce)) // If produce exist in listOfProduce(database); continue:
			{
				listOfProduce.Remove(produce); // Temporarily removes the selected produce object from ALL produce->
				UserProduceList.Add(produce);  // in order to add it to the user's personal produce list.
				UserProduceList.Sort();		   // Sorts in alphabetical order after each add/remove.
			}
			else if (UserProduceList.Contains(produce)) // If user has produce on personal list; continue:
			{
				UserProduceList.Remove(produce); // Temporarily removes the selected produce object from the user's personal list->
				listOfProduce.Add(produce);		 // in order to add it back to the list of ALL produce.
				listOfProduce.Sort();			 // Sorts the list of ALL produce in alphabetical order after each add/remove.
			}
		}
	}
}
