using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class FailType : DatabaseObject<FailType>, IFailType
    {
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

        public string FailDescription
        {
            get
            {
                return fail_typ_desc;
            }
            set
            {
                fail_typ_desc = value;
            }
        }

        ICollection<IFailedSample> IFailType.FailedSamples
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IFailedSample, FailedSample>(FailedSamples);
            }
            set
            {
                FailedSamples = InterfaceConverter.ConvertToCollection<FailedSample, IFailedSample>(value);
            }
        }

        IFailType IFailType.FailType
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
