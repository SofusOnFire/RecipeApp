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
		public List<Produce> TheUsersPersonalProduce { get; private set; } = new List<Produce>();
		
		/// <summary>
		/// Allows the user to register their personal produce from the list of all produce (retrieved from the database).
		/// When the user clicks on a product, it is added to their personal list.
		/// Clicking any of the added produce, moves them back to the all-produce list.
		/// </summary>
		/// <param name="produce"></param>
		/// <param name="listOfProduce"></param>
		public void MoveProduceBetweenLists(Produce produce, List<Produce> listOfProduce)
		{
			if (listOfProduce.Contains(produce))
			{
				listOfProduce.Remove(produce);		   // Temporarily removes the selected produce object from ALL produce->
				TheUsersPersonalProduce.Add(produce);  // in order to add it to the user's personal produce list.
				TheUsersPersonalProduce.Sort();		   // Sorts in alphabetical order after each add/remove.
			}
			else if (TheUsersPersonalProduce.Contains(produce)) // If user has produce on personal list; continue:
			{
				TheUsersPersonalProduce.Remove(produce); // Temporarily removes the selected produce object from the user's personal list->
				listOfProduce.Add(produce);				 // in order to add it back to the list of ALL produce.
				listOfProduce.Sort();					 // Sorts the list of ALL produce in alphabetical order after each add/remove.
			}
		}
	}
}
