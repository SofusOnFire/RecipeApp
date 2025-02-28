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
        public IEnumerable<Produce> GetAll();

        public Produce GetByProduceID(Produce produce);

        public IEnumerable<Produce> GetMatchesByName(string input);

    }
}
