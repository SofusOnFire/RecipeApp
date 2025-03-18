using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProduceRepository
    {
        public Produce GetProduceByID(int produceID);

        public List<Produce> GetAllProduce();

		/// <summary>
		/// Creates produce in database
		/// </summary>
		/// <param name="produce"></param>
		/// <returns>bool-value by checking if the produce already is stored in DB</returns>
		public bool CreateProduce(string produceName);
    }
}
