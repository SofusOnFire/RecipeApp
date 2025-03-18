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
		public string InStockStatus { get; private set; }
		public Unit Unit { get; private set; }
		public int UserAmount { get; private set; }

		public Produce(int produceID, string? name, Unit unit) 
		{
			ProduceID = produceID;
			Name = name;
			Unit = unit;
			InStockStatus = "red";
			UserAmount = 0;
		}

		/// <summary>
		/// Sets the produce to true if the users contains it
		/// </summary>
		public void SetStockToTrue()
		{
			InStockStatus = "green";
		}

		public void SetUserAmount(int userAmount)
		{
			if (userAmount < 0) throw new ArgumentOutOfRangeException();
			UserAmount = userAmount;
		}
    }
}
