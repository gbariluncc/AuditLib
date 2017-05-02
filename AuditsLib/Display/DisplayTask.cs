using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using Audits.Database;
using System.Windows.Input;
using Audits.Infastructure.Commands;
using Audits.Helpers;

namespace Audits.Display
{
    public class DisplayTask : TaskDecorator, IDisplayTask
    {

        public DisplayTask(ITask task)
            : base(task)
        {
            if (this.IsLoaded == false)
            {
                //base.User = DBContext.Instance.Users.GetSingle(u => u.usr_id == UserID);
                /*base.Request = DBContext.Instance.Requests.GetSingle(r => r.req_id == RequestID,
                                                                     r => r.RequestItems,
                                                                     r => r.Project.Source);*/
                //base.Priority = DBContext.Instance.Priorities.GetSingle(p => p.prior_lvl == PriorityLevel);
                //base.Status = DBContext.Instance.Status.GetSingle(s => s.sts_cd == StatusCode);

            }
            Icon = SourceTypeHelper.GetIcon(Source);
        }
        public bool IsLoading
        {
            get { return false; }
            set { }
        }
        public ICollection<ICategory> Categories
        {
            get { return base.Request.Categories; }
        }
        public ISource Source
        {
            get
            {
                return base.Request.Project.Source;
            }
            set
            {
                base.Request.Project.Source = value; OnPropertyChanged();
            }
        }
        public override void Update()
        {
            UpdateDate = DateTime.Now;
            //StatusCode = 15;

            base.Update();
        }
        public ICommand DetailClick
        {
            get;
            set;
        }

        public long ID
        {
            get { return TaskID; }
        }

        public string Icon
        {
            get;
            set;
        }
    }
}
