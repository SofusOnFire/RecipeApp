﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    interface IProduceRepository
    {
        public IEnumerable<Produce> GetProduceByID(int produceID);
    }
}
