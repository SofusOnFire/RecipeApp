using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProduceRepository : DatabaseManager, IProduceRepository
    {
        public IEnumerable<Produce> GetProduceByID(int produceID)
        {
			List<Produce> list = new List<Produce>();

			return list;
		}
    }
}
