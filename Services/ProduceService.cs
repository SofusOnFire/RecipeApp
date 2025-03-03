using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Services
{
	public class ProduceService : IProduceService
	{
		public IProduceRepository _produceRepository;

        public ProduceService(IProduceRepository produceRepository)
        {
            _produceRepository = produceRepository;
        }
    }
}
