using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public class InterfaceConverter
    {
        public static ICollection<T> ConvertToCollection<T, F>(ICollection<F> FromCollection) where T : class
        {
            ICollection<T> temp = new HashSet<T>();

            foreach (object itm in FromCollection)
            {
                if (itm is T)
                {
                    temp.Add((T)itm);
                }
            }

            return temp;
        }
    }
}
