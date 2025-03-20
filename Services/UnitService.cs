using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class UnitService : IUnitService
	{
		private readonly IUnitRepositry _unitRepositry;

		public UnitService(IUnitRepositry unitRepositry)
		{
			_unitRepositry = unitRepositry;
		}

		public IEnumerable<Unit> GetAllUnits()
		{
			return _unitRepositry.GetAllUnits();
		}
	}
}
