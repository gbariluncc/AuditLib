using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssueItem
    {
        private DCIssue _dcIssue;

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public long dc_itm_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long dc_iss_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public long itm_num { get; set; }

        [Database(IsDBField = false, IsPrimary = false, IsReadOnly = false)]
        public virtual DCIssue DCIssue 
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
                _dcIssue = value;
            }
        }
    }
}
