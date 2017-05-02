using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audits.Database
{
    public static class DBTypeConverter
    {
        private static ConvertDBType _converter = new ConvertDBType();

        public static DbType Convert(Type type)
        {
            return _converter.TypeMap[type];
        }
    }
}
