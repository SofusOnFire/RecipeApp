using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserProduceService
    {
        public void AddProduce(Produce newProduce);

        public void DeleteProduce(Produce produce);
    }
}
