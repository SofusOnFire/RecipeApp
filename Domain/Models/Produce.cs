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

		public int CompareTo(Produce produce)
		{
			if (produce == null) return 1;
			return Name.CompareTo(produce.Name);
		}
		public Produce(int produceID, string? name) 
		{
			ProduceID = produceID;
			Name = name;
		}

    }
}
