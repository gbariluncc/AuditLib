using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using Audits.Database;

namespace Audits.Database.DMSObjects
{
    public class DCItem : RequestItemDecorator, IPrintableAuditItem
    {
        private DCLocation _forward;
        private HashSet<DCLocation> _reserves;
        private long _totOH = 0;

        public DCItem(IRequestItem requestItem)
            : base(requestItem)
        {
            _reserves = new HashSet<DCLocation>();
            GetDMSInfo(Value);
        }
        public long TotalOH { get { return _totOH; } }
        public DCLocation Forward { get { return _forward; } }
        public ICollection<DCLocation> Reserves { get { return _reserves; } }

        public void GetDMSInfo(long value)
        {
            ADODB.Recordset rs = DMSConnection.GetInstance().Recordset("SELECT * FROM [dbo.itemloc] WHERE [itm_num]=" + value.ToString());

            rs.Each(r =>
            {
                DCLocation temp = new DCLocation(r.Fields["location"].Value.ToString());
                temp.QtyOH = (int)r.Fields["qty_on_hand"].Value;
                temp.PickZone = (short)r.Fields["pic_zone"].Value;
                temp.StorageFunction = (byte)r.Fields["stg_fnc_code"].Value;

                
                if (temp.LocationType == "Forward")
                { 
                    _forward = temp;
                    _totOH += _forward.QtyOH;
                }
                else
                {
                    if (temp.PickZone < 900)
                    {
                        _reserves.Add(temp);
                        _totOH += temp.QtyOH;
                    }
                }
            });
            rs.Close();
            rs = null;
        }
    }
}
