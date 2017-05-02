using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Audits.Database.DatabaseObjects;
using Audits.Database.DataAccessLayer;
using Audits.Database;

namespace Audits.Infastructure
{
    public class CurrentUser
    {
        private static User _user;

        public static IUser User
        {
            get
            {
                if (_user == null)
                {
                    _user = new User().Where("usr_pclogon='" + Environment.UserName + "'").FirstOrDefault();
                }
                return _user;
            }
        }
    }
}
