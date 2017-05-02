using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssueItem : DatabaseObject<DCIssueItem>, IDCIssueItem
    {

        public long DCIssueItemID
        {
            get
            {
                return dc_itm_id;
            }
            set
            {
                dc_itm_id = value;
            }
        }

        public long DCIssueID
        {
            get
            {
                return dc_iss_id;
            }
            set
            {
                dc_iss_id = value;
            }
        }

        public long ItemNumber
        {
            get
            {
                return itm_num;
            }
            set
            {
                itm_num = value;
            }
        }

        IDCIssue IDCIssueItem.DCIssue
        {
            get
            {
                if (_dcIssue == null)
                {
                    _dcIssue = new DCIssue().Where("dc_iss_id=" + dc_iss_id).SingleOrDefault();
                }
                return _dcIssue;
            }
            set
            {
                DCIssue = (DCIssue)value;
            }
        }

        IDCIssueItem IDCIssueItem.DCIssueItem
        {
            get
            {
                return this;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DBObjectState ObjectState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
