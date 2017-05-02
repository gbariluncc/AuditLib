using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class PackagingLevel : DatabaseObject<PackagingLevel>, IPackagingLevel
    {
        public byte LevelID
        {
            get
            {
                return lvl_id;
            }
            set
            {
                lvl_id = value;
            }
        }

        public string LevelDescription
        {
            get
            {
                return lvl_desc;
            }
            set
            {
                lvl_desc = value;
            }
        }

        public string DMSPrefix
        {
            get
            {
                return lvl_dms_prefix;
            }
            set
            {
                lvl_dms_prefix = value;
            }
        }

        public bool DMSAvailable
        {
            get
            {
                return lvl_dms_avail;
            }
            set
            {
                lvl_dms_avail = value;
            }
        }

        public string AltDescription
        {
            get
            {
                return lvl_alt_desc;
            }
            set
            {
                lvl_alt_desc = value;
            }
        }

        public bool HasQty
        {
            get
            {
                return lvl_has_qty;
            }
            set
            {
                lvl_has_qty = value;
            }
        }

        ICollection<IDimension> IPackagingLevel.Dimensions
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IDimension, Dimension>(Dimensions);
            }
            set
            {
                Dimensions = InterfaceConverter.ConvertToCollection<Dimension, IDimension>(value);
            }
        }

        ICollection<IPicture> IPackagingLevel.Pictures
        {
            get
            {

                return InterfaceConverter.ConvertToCollection<IPicture, Picture>(Pictures);
            }
            set
            {
                Pictures = InterfaceConverter.ConvertToCollection<Picture, IPicture>(value);
            }
        }

        IPackagingLevel IPackagingLevel.PackagingLevel
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

        public static bool operator ==(PackagingLevel r1, PackagingLevel r2)
        {
            if (object.ReferenceEquals(r1, r2))
            {
                return true;
            }
            if (object.ReferenceEquals(r1, null) ||
                object.ReferenceEquals(r2, null))
            { return false; }

            return r1.lvl_id == r2.lvl_id;
        }
        public static bool operator !=(PackagingLevel obj1, PackagingLevel obj2)
        {
            return !(obj1 == obj2);
        }
        public override bool Equals(object obj)
        {
            if (obj is PackagingLevel)
            {
                return (obj as PackagingLevel) == this;
            }
            return false;
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
