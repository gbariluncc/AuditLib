using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

using ADODB;

namespace Audits.Database.DMSObjects
{
    public class DMSItem : RequestItemDecorator, IDMSItem
    {
        private int _oh;

        public DMSItem(IRequestItem requestItem)
            : base(requestItem)
        {
            GetOH(base.Value);
        }

        private void GetOH(long value)
        {
            string sql = "SELECT fwd_on_hand, res_on_hand FROM dbo.item WHERE itm_num =" + value;
            ADODB.Recordset rs = DMSConnection.GetInstance().Recordset(sql);

            if (!(rs.BOF && rs.EOF))
            {
                _oh = (int)rs.Fields[0].Value + (int)rs.Fields[1].Value;
            }
            rs.Close();
            rs = null;
        }

        public virtual int OnHand
        {
            get { return _oh; }
        }

        public long Number
        {
            get { return base.Value; }
        }
    }
}
