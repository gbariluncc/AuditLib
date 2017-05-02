using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssue : DatabaseObject<DCIssue>, IDCIssue
    {
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

        public byte FacilityTypeID
        {
            get
            {
                return fac_typ_id;
            }
            set
            {
                fac_typ_id = value;
            }
        }

        public DateTime AddDate
        {
            get
            {
                return dc_iss_add_dm;
            }
            set
            {
                dc_iss_add_dm = value;
            }
        }

        public int DCIssueVBU
        {
            get
            {
                return dc_iss_vbu;
            }
            set
            {
                dc_iss_vbu = value;
            }
        }

        public string DCIssueDescription
        {
            get
            {
                return dc_iss_desc;
            }
            set
            {
                dc_iss_desc = value;
            }
        }

        public string AuditorAction
        {
            get
            {
                return dc_iss_audit_act;
            }
            set
            {
                dc_iss_audit_act = value;
            }
        }

        public string FacilityInstructions
        {
            get
            {
                return dc_iss_fac_instr;
            }
            set
            {
                dc_iss_fac_instr = value;
            }
        }

        public string ActionPlan
        {
            get
            {
                return dc_iss_act_plan;
            }
            set
            {
                dc_iss_act_plan = value;
            }
        }

        public DateTime? GetWellDate
        {
            get
            {
                return dc_iss_gwd;
            }
            set
            {
                dc_iss_gwd = value.Value;
            }
        }

        public string GetWellFolder
        {
            get
            {
                return dc_iss_gw_fldr;
            }
            set
            {
                dc_iss_gw_fldr = value;
            }
        }

        public string DCIssueFolder
        {
            get
            {
                return dc_iss_fldr;
            }
            set
            {
                dc_iss_fldr = value;
            }
        }

        IFacilityType IDCIssue.FacilityType
        {
            get
            {
                return FacilityType;
            }
            set
            {
                FacilityType = (FacilityType)value;
            }
        }

        ICollection<IDCIssueFacility> IDCIssue.DCIssueFacilities
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IDCIssueFacility, DCIssueFacility>(DCIssueFacilities);
            }
            set
            {
                DCIssueFacilities = InterfaceConverter.ConvertToCollection<DCIssueFacility, IDCIssueFacility>(value);
            }
        }

        ICollection<IDCIssueItem> IDCIssue.DCIssueItems
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IDCIssueItem, DCIssueItem>(DCIssueItems);
            }
            set
            {
                DCIssueItems = InterfaceConverter.ConvertToCollection<DCIssueItem, IDCIssueItem>(value);
            }
        }

        IDCIssue IDCIssue.DCIssue
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
