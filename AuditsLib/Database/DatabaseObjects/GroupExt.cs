using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Group : DatabaseObject<Group>, IGroup
    {
        public int GroupID
        {
            get
            {
                return grp_id;
            }
            set
            {
                grp_id = value;
            }
        }

        public string GroupName
        {
            get
            {
                return grp_nme;
            }
            set
            {
                grp_nme = value;
            }
        }

        public string Description
        {
            get
            {
                return grp_desc;
            }
            set
            {
                grp_desc = value;
            }
        }



        ICollection<IEmailGroup> IGroup.EmailAddresses
        {
            get { return EmailAddresses; }
        }
    }
}
