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
        /// <summary>
        /// Returns a single produce with a specific ID
        /// </summary>
        /// <param name="produceID"></param>
        /// <returns></returns>
        public Produce GetProduceByID(int produceID);

        /// <summary>
        /// Returns all produce without a where clause
        /// </summary>
        /// <returns></returns>
        public List<Produce> GetAllProduce();
    }
}
