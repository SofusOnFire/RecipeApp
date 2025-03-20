using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IUnitService
	{
		/// <summary>
		/// Get all units from database
		/// </summary>
		/// <returns>return IEnumerable of Units</returns>
		public IEnumerable<Unit> GetAllUnits();
	}
}
