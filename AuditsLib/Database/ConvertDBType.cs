using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Audits.Database
{
    public class ConvertDBType
    {
       Dictionary<Type, DbType> typeMap = new Dictionary<Type, DbType>();

       public Dictionary<Type, DbType> TypeMap { get { return typeMap; } }
       public ConvertDBType()
       {
           typeMap[typeof(byte)] = DbType.Byte;
           typeMap[typeof(sbyte)] = DbType.SByte;
           typeMap[typeof(short)] = DbType.Int16;
           typeMap[typeof(ushort)] = DbType.UInt16;
           typeMap[typeof(int)] = DbType.Int32;
           typeMap[typeof(uint)] = DbType.UInt32;
           typeMap[typeof(long)] = DbType.Int64;
           typeMap[typeof(ulong)] = DbType.UInt64;
           typeMap[typeof(float)] = DbType.Single;
           typeMap[typeof(double)] = DbType.Double;
           typeMap[typeof(decimal)] = DbType.Decimal;
           typeMap[typeof(bool)] = DbType.Boolean;
           typeMap[typeof(string)] = DbType.String;
           typeMap[typeof(char)] = DbType.StringFixedLength;
           typeMap[typeof(Guid)] = DbType.Guid;
           typeMap[typeof(DateTime)] = DbType.DateTime;
           typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
           typeMap[typeof(byte[])] = DbType.Binary;
           typeMap[typeof(byte?)] = DbType.Byte;
           typeMap[typeof(sbyte?)] = DbType.SByte;
           typeMap[typeof(short?)] = DbType.Int16;
           typeMap[typeof(ushort?)] = DbType.UInt16;
           typeMap[typeof(int?)] = DbType.Int32;
           typeMap[typeof(uint?)] = DbType.UInt32;
           typeMap[typeof(long?)] = DbType.Int64;
           typeMap[typeof(ulong?)] = DbType.UInt64;
           typeMap[typeof(float?)] = DbType.Single;
           typeMap[typeof(double?)] = DbType.Double;
           typeMap[typeof(decimal?)] = DbType.Decimal;
           typeMap[typeof(bool?)] = DbType.Boolean;
           typeMap[typeof(char?)] = DbType.StringFixedLength;
           typeMap[typeof(Guid?)] = DbType.Guid;
           typeMap[typeof(DateTime?)] = DbType.DateTime;
           typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
       }
    }
}
