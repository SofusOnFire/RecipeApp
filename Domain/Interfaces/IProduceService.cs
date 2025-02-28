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
        public IEnumerable<Produce> GetAllProduce();

        public Produce GetProduceByID(int produceID);

        public IEnumerable<Produce> GetMatchesByName(string input);

    }
}
