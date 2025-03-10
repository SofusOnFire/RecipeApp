using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace DAL
{
	public class RepoT<T> : Repository<T> where T : class
	{
		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		IEnumerable<T> Repository<T>.GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
