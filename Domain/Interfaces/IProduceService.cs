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

        /// <summary>
        /// Creates produce in database
        /// </summary>
        /// <param name="produce"></param>
        /// <returns>string by checking if the produce already is stored in DB</returns>
        public string CreateProduce(string produceName);
    }
}
