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

		public List<ProduceLine> ProduceLines { get; } = new List<ProduceLine>();

		public int CompareTo(Produce produce)
		{
			if (produce == null) return 1;
			return ProduceName.CompareTo(produce.ProduceName);
		}
		public Produce(int produceID, string? produceName) 
		{
			ProduceID = produceID;
			ProduceName = produceName;
		}
	}
}
