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
        public string? ProduceName { get; private set; }

		private Produce() { }
		public int CompareTo(Produce produce)
		{
			if (produce == null) return 1;
			return ProduceName.CompareTo(produce.ProduceName);
		}
		public Produce(int produceID, string? name) 
		{
			ProduceID = produceID;
			ProduceName = name;
		}

    }
}
