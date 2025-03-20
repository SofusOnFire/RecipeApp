using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminProduceService
    {
		/// <summary>
		/// Creates produce in database
		/// </summary>
		/// <param name="produce"></param>
		/// <returns>string by checking if the produce already is stored in DB (if it exists = false)</returns>
		public bool CreateProduce(string produceName);
	}
}
