using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Pattern.Interface
{
    public interface IRepository<T>: IDisposable
    {

        IList<T> Get();       
        T Get(int id);
        bool Create(T data);
        bool Update(T data);
        bool Delete(int id);
    }
}
