using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;
using Audits.Infastructure;

namespace Audits.Services
{
    public class TaskService : Service<ITask>
    {
        public TaskService()
        {
            InternalData = CurrentUser.User.Tasks.Where(t => t.StatusCode == 2).ToHashSet();
            SetGetDataAction(() => CurrentUser.User.Tasks.Where(t => t.StatusCode == 2).ToHashSet());
        }
    }
}
