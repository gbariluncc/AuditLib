using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class FacilityType : DatabaseObject<FacilityType>, IFacilityType
    {
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

        public string Description
        {
            get
            {
                return fac_typ_desc;
            }
            set
            {
                fac_typ_desc = value;
            }
        }

        ICollection<IDCIssue> IFacilityType.DCIssues
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IDCIssue, DCIssue>(DCIssues);
            }
            set
            {
                DCIssues = InterfaceConverter.ConvertToCollection<DCIssue, IDCIssue>(value);
            }
        }

        ICollection<IFacility> IFacilityType.Facilities
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IFacility, Facility>(Facilities);
            }
            set
            {
                Facilities = InterfaceConverter.ConvertToCollection<Facility, IFacility>(value);
            }
        }

        IFacilityType IFacilityType.FacilityType
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
