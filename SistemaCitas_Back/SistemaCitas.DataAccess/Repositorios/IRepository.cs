using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitas.DataAccess.Repositorios
{
    interface IRepository<T>
    {
        public IEnumerable<T> List();
        public RequestStatus Insert(T item);
        public RequestStatus Update(T item);
        public IEnumerable<T> Find(T? item);
        public RequestStatus Delete(T item);
    }
}
