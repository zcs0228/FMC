using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMC.EFRepository
{
    public interface IRepository<T>
    {
        void Create(T entity);

        T Read(Guid id);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> FindAll();
    }
}
