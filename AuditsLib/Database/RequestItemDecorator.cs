using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using Audits.Infastructure;
using System.Runtime.CompilerServices;

namespace Audits.Database
{
    public abstract class RequestItemDecorator : ViewBase, IRequestItem
    {
        private IRequestItem _requestItem;

        public RequestItemDecorator(IRequestItem requestItem)
        {
            _requestItem = requestItem;
        }

        public string FailedSampleText
        {
            get { return _requestItem.FailedSampleText; }
        }
        public bool NeedsToSave
        {
            get { return _requestItem.NeedsToSave; }
            set { _requestItem.NeedsToSave = value; OnPropertyChanged(); }
        }
        public long RequestItemID
        {
            get
            {
                return _requestItem.RequestItemID;
            }
            set
            {
                _requestItem.RequestItemID = value;
                OnPropertyChanged();
            }
        }
        public long VBU
        {
            get { return _requestItem.VBU; }
            set { _requestItem.VBU = value; OnPropertyChanged(); }
        }
        public byte ItemTypeID
        {
            get
            {
                return _requestItem.ItemTypeID;
            }
            set
            {
                _requestItem.ItemTypeID = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get
            {
                return _requestItem.Value;
            }
            set
            {
                _requestItem.Value = value;
                OnPropertyChanged();
            }
        }

        public byte StatusCode
        {
            get
            {
                return _requestItem.StatusCode;
            }
            set
            {
                _requestItem.StatusCode = value;
                if (_requestItem.Status.StatusCode != _requestItem.StatusCode)
                    _requestItem.Status = DBContext.Instance.Status.GetSingle(s => s.sts_cd == StatusCode);
                OnPropertyChanged();
            }
        }

        public long? ParentID
        {
            get
            {
                return _requestItem.ParentID;
            }
            set
            {
                _requestItem.ParentID = value;
                OnPropertyChanged();
            }
        }

        public DateTime AddDate
        {
            get
            {
                return _requestItem.AddDate;
            }
            set
            {
                _requestItem.AddDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return _requestItem.UpdateDate;
            }
            set
            {
                _requestItem.UpdateDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime ExpDate
        {
            get
            {
                return _requestItem.ExpDate;
            }
            set
            {
                _requestItem.ExpDate = value;
                OnPropertyChanged();
            }
        }

        public long RequestID
        {
            get
            {
                return _requestItem.RequestID;
            }
            set
            {
                _requestItem.RequestID = value;
                OnPropertyChanged();
            }
        }

        public byte ContainerType
        {
            get
            {
                return _requestItem.ContainerType;
            }
            set
            {
                _requestItem.ContainerType = value;
                OnPropertyChanged();
            }
        }

        public virtual string Comments
        {
            get
            {
               return _requestItem.Comments;
            }
            set
            {
                _requestItem.Comments = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _requestItem.Description; }
        }

        public string DisplayValue
        {
            get { return _requestItem.DisplayValue; }
        }

        public IFailedSample FailedSample
        {
            get { return _requestItem.FailedSample; }
        }

        public IDCIssueItem DCIssueItem
        {
            get { return _requestItem.DCIssueItem; }
        }

        public ICollection<IAudit> Audits
        {
            get
            {
                return _requestItem.Audits;
            }
            set
            {
                _requestItem.Audits = value;
                OnPropertyChanged();
            }
        }

        public IContainer Container
        {
            get
            {
                return _requestItem.Container;
            }
            set
            {
                _requestItem.Container = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IDimension> Dimensions
        {
            get
            {
                return _requestItem.Dimensions;
            }
            set
            {
                _requestItem.Dimensions = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IPicture> Pictures
        {
            get
            {
                return _requestItem.Pictures;
            }
            set
            {
                _requestItem.Pictures = value;
                OnPropertyChanged();
            }
        }

        public IRequest Request
        {
            get
            {
                return _requestItem.Request;
            }
            set
            {
                _requestItem.Request = value;
                OnPropertyChanged();
            }
        }

        public IRequestItemType RequestItemType
        {
            get
            {
                return _requestItem.RequestItemType;
            }
            set
            {
                _requestItem.RequestItemType = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IRequestItem> Children
        {
            get
            {
                return _requestItem.Children;
            }
            set
            {
                _requestItem.Children = value;
                OnPropertyChanged();
            }
        }

        public IRequestItem Parent
        {
            get
            {
                return _requestItem.Parent;
            }
            set
            {
                _requestItem.Parent = value;
                OnPropertyChanged();
            }
        }

        public IStatus Status
        {
            get
            {
                return _requestItem.Status;
            }
            set
            {
                _requestItem.Status = value;
                OnPropertyChanged();
            }
        }

        public IRequestItem RequestItem
        {
            get
            {
                return _requestItem;
            }
            set
            {
                _requestItem = value;
                OnPropertyChanged();
            }
        }

        public virtual void Update()
        {
            _requestItem.Update();
        }

        public virtual void Add(bool addAll = false, ProgressReporter pg = null)
        {
            _requestItem.Add(addAll,pg);
        }
        public virtual void AddAsync(bool addAll = false, ProgressReporter pg = null)
        {
            _requestItem.AddAsync(addAll,pg);
        }
        public virtual void Delete()
        {
            _requestItem.Delete();
        }


        public string DCIssuesText
        {
            get { return _requestItem.DCIssuesText; }
        }


        public DBObjectState ObjectState
        {
            get
            {
                return _requestItem.ObjectState;
            }
            set
            {
                _requestItem.ObjectState = value;
                OnPropertyChanged();
            }
        }

        public void Add(bool addAll = false)
        {
            _requestItem.Add(addAll);
        }

        public bool Equals(DatabaseObjects.RequestItem other)
        {
            return _requestItem == other;
        }
    }
}
