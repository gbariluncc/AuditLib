using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database
{
    public abstract class RequestDecorator : ViewBase, IRequest
    {
        private IRequest _request;

        public RequestDecorator(IRequest request)
        {
            _request = request;
        }
        public long RequestID
        {
            get
            {
                return _request.RequestID;
            }
            set
            {
                _request.RequestID = value;
                OnPropertyChanged("RequestID");
            }
        }

        public long ProjectID
        {
            get
            {
                return _request.ProjectID;
            }
            set
            {
                _request.ProjectID = value;
                OnPropertyChanged("ProjectID");
            }
        }

        public DateTime AddDate
        {
            get
            {
                return _request.AddDate;
            }
            set
            {
                _request.AddDate = value;
                OnPropertyChanged("AddDate");
            }
        }

        public string Instructions
        {
            get
            {
                return _request.Instructions;
            }
            set
            {
                _request.Instructions = value;
                OnPropertyChanged("Instructions");
            }
        }

        public bool IsSafety
        {
            get
            {
                return _request.IsSafety;
            }
            set
            {
                _request.IsSafety = value;
                OnPropertyChanged("IsSafety");
            }
        }

        public DateTime ExpectedCompleteDate
        {
            get
            {
                return _request.ExpectedCompleteDate;
            }
            set
            {
                _request.ExpectedCompleteDate = value;
                OnPropertyChanged("ExpectedCompleteDate");
            }
        }

        public byte StatusCode
        {
            get
            {
                return _request.StatusCode;
            }
            set
            {
                _request.StatusCode = value;
                OnPropertyChanged("StatusCode");
            }
        }

        public string DocumentFolder
        {
            get
            {
                return _request.DocumentFolder;
            }
            set
            {
                _request.DocumentFolder = value;
                OnPropertyChanged("DocumentFolder");
            }
        }

        public string Title
        {
            get
            {
                return _request.Title;
            }
            set
            {
                _request.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public bool IsPermanent
        {
            get
            {
                return _request.IsPermanent;
            }
            set
            {
                _request.IsPermanent = value;
                OnPropertyChanged("IsPermanent");
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return _request.UpdateDate;
            }
            set
            {
                _request.UpdateDate = value;
                OnPropertyChanged("UpdateDate");
            }
        }

        public string Requestor
        {
            get
            {
                return _request.Requestor;
            }
            set
            {
                _request.Requestor = value;
                OnPropertyChanged("Requestor");
            }
        }

        public int ShipFromVBU
        {
            get
            {
                return _request.ShipFromVBU;
            }
            set
            {
                _request.ShipFromVBU = value;
                OnPropertyChanged("ShipFromVBU");
            }
        }

        public System.Windows.Media.Geometry Icon
        {
            get { return _request.Icon; }
        }

        public bool IsSelected
        {
            get
            {
                return _request.IsSelected;
            }
            set
            {
                _request.IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public IProject Project
        {
            get
            {
                return _request.Project;
            }
            set
            {
                _request.Project = value;
                OnPropertyChanged("Project");
            }
        }

        public IStatus Status
        {
            get
            {
                return _request.Status;
            }
            set
            {
                _request.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public ICollection<IRequestItem> RequestItems
        {
            get
            {
                return _request.RequestItems;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<ITask> Tasks
        {
            get
            {
                return _request.Tasks;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<ICategory> Categories
        {
            get
            {
                return _request.Categories;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IRequest Request
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }
        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            _request.OnPropertyChanged(propName);
        }
        public void Update()
        {
            _request.Update();
        }

        public void Add(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _request.Add(addAll, pg);
        }

        public void Delete()
        {
            _request.Delete();
        }

        public void AddAsync(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _request.AddAsync();
        }

        public bool NeedsToSave
        {
            get
            {
                return _request.NeedsToSave;
            }
            set
            {
                _request.NeedsToSave = value;
                OnPropertyChanged("NeedsToSave");
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
