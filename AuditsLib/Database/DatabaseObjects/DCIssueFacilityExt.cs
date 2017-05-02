using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;


namespace Audits.Database.DatabaseObjects
{
    public partial class DCIssueFacility : DatabaseObject<DCIssueFacility>, IDCIssueFacility
    {

        public long DCIssueFacilityID
        {
            get
            {
                return dc_iss_fac_id;
            }
            set
            {
                dc_iss_fac_id = value;
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

        public short FacilityNumber
        {
            get
            {
                return dc_iss_fac_num;
            }
            set
            {
                dc_iss_fac_num = value;
            }
        }

        public DateTime ReportDate
        {
            get
            {
                return dc_iss_fac_rpt_dt;
            }
            set
            {
                dc_iss_fac_rpt_dt = value;
            }
        }

        IDCIssue IDCIssueFacility.DCIssue
        {
            get
            {
                return DCIssue;
            }
            set
            {
                DCIssue = (DCIssue)value;
            }
        }

        IDCIssueFacility IDCIssueFacility.DCIssueFacility
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
