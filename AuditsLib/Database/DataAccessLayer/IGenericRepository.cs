using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DataAccessLayer
{
    public interface IGenericRepository<T> where T : new()
    {
        ICollection<T> GetAll();
        T GetSingle(Func<T, bool> where);

        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}
