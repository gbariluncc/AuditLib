using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class FailedSample : DatabaseObject<FailedSample>, IFailedSample
    {
        public int ItemNumber
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

        public int PONumber
        {
            get
            {
                return po_num;
            }
            set
            {
                po_num = value;
            }
        }

        public DateTime SampleDate
        {
            get
            {
                return sample_dt;
            }
            set
            {
                sample_dt = value;
            }
        }

        public int VBU
        {
            get
            {
                return vbu;
            }
            set
            {
                vbu = value;
            }
        }

        public string FailSummary
        {
            get
            {
                return fail_sum;
            }
            set
            {
                fail_sum = value;
            }
        }

        public string GeneralComments
        {
            get
            {
                return gen_comm;
            }
            set
            {
                gen_comm = value;
            }
        }

        public byte FailTypeID
        {
            get
            {
                return fail_typ_id;
            }
            set
            {
                fail_typ_id = value;
            }
        }

        public bool IsNew
        {
            get
            {
                return is_new;
            }
            set
            {
                is_new = value;
            }
        }

        public DateTime ExpirationDate
        {
            get
            {
                return expire_date;
            }
            set
            {
                expire_date = value;
            }
        }

        public byte StatusCode
        {
            get
            {
                return sts_cd;
            }
            set
            {
                sts_cd = value;
                if (Status == null || sts_cd != Status.StatusCode)
                {
                    Status = DBContext.Instance.Status.GetSingle(s => s.sts_cd == StatusCode);
                }
            }
        }
        public DateTime UpdateDate
        {
            get { return fs_upd_dm; }
            set { fs_upd_dm = value; }
        }
        public DateTime AddDate
        {
            get
            {
                return add_dt;
            }
            set
            {
                add_dt = value;
            }
        }

        IFailType IFailedSample.FailType
        {
            get
            {
                return FailType;
            }
            set
            {
                FailType = (FailType)value;
            }
        }

        IStatus IFailedSample.Status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = (Status)value;
                if (StatusCode != Status.StatusCode)
                {
                    StatusCode = Status.StatusCode;
                }
            }
        }

        IFailedSample IFailedSample.FailedSample
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
