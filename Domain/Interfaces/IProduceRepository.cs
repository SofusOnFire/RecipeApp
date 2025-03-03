﻿using System;
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

        public IEnumerable<Produce> GetAllProduce();
    }
}
