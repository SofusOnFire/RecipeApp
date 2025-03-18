using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Produce
    {
		public int ProduceID { get; private set; }
        public string? Name { get; private set; }
		public string? InStockStatus { get; private set; }
        public int UnitID { get; private set; }
        public Unit? Unit { get; private set; }
		public int UserAmount { get; private set; }

		public Produce(int produceID, string? name, int unitID) 
		{
			ProduceID = produceID;
			Name = name;
			UserAmount = 0;
			UnitID = unitID;
		}

		/// <summary>
		/// Sets the produce to true if the users contains it
		/// </summary>
		public void SetStockStatus(Produce comparedProduce)
		{
			InStockStatus = "green";
		}

		/// <summary>
		/// Sets the Amount of each Produce the user has. It checks if input is <0. Throw exeption if thats the case
		/// </summary>
		/// <param name="userAmount"></param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public void SetUserAmount(int userAmount)
		{
			if (userAmount < 0) throw new ArgumentOutOfRangeException();
			UserAmount = userAmount;
		}

		/// <summary>
		/// Simple set doesn't validate at this point. Used to set Unit to Produce in Dal
		/// </summary>
		/// <param name="unit"></param>
		public void SetUnit(Unit unit)
		{
			Unit = unit;
		}
    }
}
