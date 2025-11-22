using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt.Interfaces
{
    public interface IRepository<T>
    {
        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public T? Find(Predicate<T> predicate);
    }
}
