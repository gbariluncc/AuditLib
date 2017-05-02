using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Facility : DatabaseObject<Facility>, IFacility   
    {
        public short FacilityNumber
        {
            get
            {
                return fac_num;
            }
            set
            {
                fac_num = value;
            }
        }

        public string StringID
        {
            get
            {
                return fac_str_id;
            }
            set
            {
                fac_str_id = value;
            }
        }

        public string Name
        {
            get
            {
                return fac_name;
            }
            set
            {
                fac_name = value;
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

        public string ConnectionString
        {
            get
            {
                return fac_cn_str;
            }
            set
            {
                fac_cn_str = value;
            }
        }

        public bool InUse
        {
            get
            {
                return fac_in_use;
            }
            set
            {
                fac_in_use = value;
            }
        }

        IFacilityType IFacility.FacilityType
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

        IFacility IFacility.Facility
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
