using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Group
    {
    
        private ICollection<IEmailGroup> _emailGroup;

        public int grp_id { get; set; }
        public string grp_nme { get; set; }
        public string grp_desc { get; set; }

        ICollection<IEmailGroup> EmailAddresses
        {
            get
            {
                if (_emailGroup == null)
                {
                    _emailGroup = new EmailGroup().Where("grp_id={0}".Format(grp_id)).ToHashSet<IEmailGroup>();
                }
                return _emailGroup;
            }
        }
    }
}
