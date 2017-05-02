using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssue
    {
        private FacilityType _facilityType;
        private HashSet<DCIssueFacility> _dcIssueFacilities;
        private HashSet<DCIssueItem> _dcIssueItems;

        public DCIssue()
        {
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = true)]
        public long dc_iss_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte fac_typ_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public System.DateTime dc_iss_add_dm { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int dc_iss_vbu { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_audit_act { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_fac_instr { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_act_plan { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public DateTime dc_iss_gwd { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_gw_fldr { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string dc_iss_fldr { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public int validation_usr_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public DateTime validation_time { get; set; }

        public virtual FacilityType FacilityType 
        {
            get
            {
                if (_facilityType == null)
                {
                    _facilityType = new FacilityType().Where("fac_typ_id=" + fac_typ_id).SingleOrDefault();
                }
                return _facilityType;
            }
            set { _facilityType = value; }
        }
        public virtual ICollection<DCIssueFacility> DCIssueFacilities 
        {
            get
            {
                if (_dcIssueFacilities == null)
                {
                    _dcIssueFacilities = new DCIssueFacility().Where("dc_iss_id=" + dc_iss_id).ToHashSet();
                }
                return _dcIssueFacilities;
            }
            set { _dcIssueFacilities = (HashSet<DCIssueFacility>)value; }
        }
        public virtual ICollection<DCIssueItem> DCIssueItems 
        {
            get
            {
                if (_dcIssueItems == null)
                {
                    _dcIssueItems = new DCIssueItem().Where("dc_iss_id=" + dc_iss_id).ToHashSet();
                }
                return _dcIssueItems;
            }
            set { _dcIssueItems = (HashSet<DCIssueItem>)value; }
        }
    }
}
