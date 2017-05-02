using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Rating : DatabaseObject<Rating>, IRating
    {
        public byte RatingID
        {
            get
            {
                return rating_id;
            }
            set
            {
                rating_id = value;
            }
        }

        public string Description
        {
            get
            {
                return rating_desc;
            }
            set
            {
                rating_desc = value;
            }
        }

        public string ShortDescription
        {
            get
            {
                return rating_sht_desc;
            }
            set
            {
                rating_sht_desc = value;
            }
        }

        ICollection<IAudit> IRating.Audits
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IAudit, Audit>(Audits);
            }
            set
            {
                Audits = InterfaceConverter.ConvertToCollection<Audit, IAudit>(value);
            }
        }

        IRating IRating.Rating
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

        public static bool operator ==(Rating r1, Rating r2)
        {
            if (object.ReferenceEquals(r1, r2))
            {
                return true;
            }
            if(object.ReferenceEquals(r1 , null) ||
                object.ReferenceEquals(r2,null))
            { return false; }

            return r1.rating_id == r2.rating_id;
        }
        public static bool operator !=(Rating rating1, Rating rating2)
        {
            return !(rating1 == rating2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Rating)
            {
                return (obj as Rating) == this;
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
