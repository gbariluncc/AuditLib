using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Audits.Services
{
    public static class AppServices
    {
        private static TaskService _taskService = new TaskService() { CompareType = CompareType.ByRecord };
        private static POService _poService = new POService();

        public static TaskService TaskService
        {
            get { return _taskService; }
        }
        public static POService POService
        {
            get { return _poService; }
        }
    }
}
