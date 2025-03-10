using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface Repository<T> where T : class
	{
		public void Add(T entity);
		public void Remove(T entity);
		public IEnumerable<T> GetAll();

	}
}
