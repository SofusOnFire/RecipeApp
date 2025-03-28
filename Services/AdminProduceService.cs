﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminProduceService : IAdminProduceService
    {
		private readonly IProduceRepository _produceRepository;

		public AdminProduceService(IProduceRepository produceRepository)
		{
			_produceRepository = produceRepository;
		}

		public bool CreateProduce(string produceName, int unitID)
		{
            bool alreadyCreated = _produceRepository.CreateProduce(produceName, unitID);

			return alreadyCreated;
		}
	}
}
