using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IUnitRepository
	{
		/// <summary>
		/// Retrieves a unit based on the provided unit ID.
		/// </summary>
		/// <param name="unitID">The unique identifier of the unit.</param>
		/// <returns>The <see cref="Unit"/> object if found; otherwise, null.</returns>
		public Unit GetUnitByUnitID(int unitID);

		/// <summary>
		/// Retrieves all available units.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Unit"/> objects.</returns>
		public IEnumerable<Unit> GetAllUnits();
	}
}
