using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Produce : IComparable<Produce>
    {
		public int ProduceID { get; private set; }
        public string? Name { get; private set; }
		public bool InStock { get; private set; }
		public Unit Unit { get; private set; }

		public int CompareTo(Produce produce)
		{
			if (produce == null) return 1;
			return Name.CompareTo(produce.Name);
		}
		public Produce(int produceID, string? name, Unit unit) 
		{
			ProduceID = produceID;
			Name = name;
			Unit = unit;
			InStock = false;
		}

		/// <summary>
		/// Sets the produce to true if the users contains it
		/// </summary>
		public void SetStockToTrue()
		{
			InStock = true;
		}
    }
}
