using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProduceService
    {
        /// <summary>
        /// Gets the produce by produceID
        /// </summary>
        /// <param name="produceID"></param>
        /// <returns></returns>
        public Produce GetProduceByID(int produceID);

        public IEnumerable<Produce> GetProduceList();
    }
}
