using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class ProjectUser
    {
        [Database(IsDBField=true, IsPrimary=true, IsReadOnly=false, DataType=OleDbType.BigInt)]
        public long proj_id { get; set; }
        
        [Database(IsDBField=true, IsPrimary=true, IsReadOnly=false, DataType=OleDbType.Integer)]
        public int usr_id { get; set; }

        [Database(IsDBField=true, IsPrimary=false, IsReadOnly=false, DataType=OleDbType.TinyInt)]
        public byte role_id { get; set; }
    }
}
