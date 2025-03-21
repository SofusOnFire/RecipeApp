using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Unit
    {
        public int UnitID { get; private set; }
        public string UnitName { get; private set; }

		public Unit(int unitID, string unitName)
		{
			UnitID = unitID;
			UnitName = unitName;
		}
	}
}
