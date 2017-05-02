using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Services;

namespace Audits.Database.DatabaseObjects
{
    public partial class ProjectUser : DatabaseObject<ProjectUser>, IProjectUser, ISubject
    {
        private IProject _project;
        private bool _isSelected;
        private List<IObserver> _observers;

        public ProjectUser()
        {
            _observers = new List<IObserver>();
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                _observers.ForEach(o => o.update());
            }
        }
        public int UserID
        {
            get
            {
                return usr_id;
            }
            set
            {
                usr_id = value;
            }
        }

        public long ProjectID
        {
            get
            {
                return proj_id;
            }
            set
            {
                proj_id = value;
            }
        }

        public byte RoleID
        {
            get
            {
                return role_id;
            }
            set
            {
                role_id = value;
            }
        }
        public ISource Source
        {
            //get { return null; }
            get { return Project.Source; }
        }
        public IUser User
        {
            get { return new User().Where("usr_id={0}".Format(usr_id)).FirstOrDefault(); }
        }

        public IProject Project
        {
            get 
            {
                if (_project == null) { }
                _project = new Project().Where("proj_id={0}".Format(proj_id)).FirstOrDefault();

                return _project;
            }
        }

        public IRole Role
        {
            get { return null; }
            //get { return Role.Where("role_id={0}".Format(role_id)).FirstOrDefault(); }
        }

        public void registerObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void updateObservers()
        {
            _observers.ForEach(o => o.update());
        }
    }
}
