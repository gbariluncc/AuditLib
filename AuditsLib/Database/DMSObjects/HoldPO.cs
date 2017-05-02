using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using System.Windows.Input;
using Audits.Infastructure.Commands;

namespace Audits.Database.DMSObjects
{
    public class HoldPO : POWithStatus, IHoldPO, IDatabaseObject<HoldPO>
    {
        private IHold _hold;
        private bool _isSelected;

        public HoldPO(IRequestItem reqeustItem)
            :base(new PO(reqeustItem))
        {
            Initialize();
        }
        public HoldPO(IPO po)
            : base(po)
        {
            Initialize();
        }
        public HoldPO(long number)
            : base(new PO(number))
        {
            Initialize();
        }
        public void Initialize()
        {
            _hold = new Hold().Where("hold_po={0}".Format(this.Number)).FirstOrDefault();

            _isSelected = false;
        }
        public IHold Hold
        {
            get
            {
                return _hold;
            }
            set
            {
                SetProperty(ref _hold, value);
            }
        }
        public int HoldID
        {
            get
            {
                return _hold == null? -1 : _hold.HoldID;
            }
            set
            {
                _hold.HoldID = value;
                OnPropertyChanged();
            }
        }

        public DateTime HoldDate
        {
            get
            {
                return _hold == null? DateTime.Now : _hold.HoldDate;
            }
            set
            {
                _hold.HoldDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return _hold == null? DateTime.Now : _hold.ReleaseDate;
            }
            set
            {
                _hold.ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        public int PONumber
        {
            get
            {
                return Convert.ToInt32(base.Number);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public byte ReasonCode
        {
            get
            {
                return _hold == null? (byte)0 : _hold.ReasonCode;
            }
            set
            {
                _hold.ReasonCode = value;
            }
        }

        public string HoldComments
        {
            get
            {
                return _hold == null? string.Empty : _hold.HoldComments;
            }
            set
            {
                _hold.HoldComments = value;
            }
        }

        public DateTime HoldExpiration
        {
            get
            {
                return _hold == null? DateTime.Now.AddDays(2) : _hold.HoldExpiration;
            }
            set
            {
                _hold.HoldExpiration = value;
            }
        }

        public IHoldReason HoldReason
        {
            get { return _hold == null? null : _hold.HoldReason; }
        }
        public override void Add(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _hold.Add(addAll, pg);
        }
        public override void Delete()
        {
            _hold.Delete();
        }
        public override void Update()
        {
            _hold.Update();
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }


        public string RequestTitle
        {
            get 
            {
                if (RequestItem != null)
                {
                    return RequestItem.Request.Title;
                }
                else return string.Empty;
            }
        }
        public string AuditType
        {
            get
            {
                if (RequestItem != null)
                {
                    if (RequestItem.ContainerType == 4)
                    {
                        return "Audit";
                    }
                    else
                    {
                        return RequestItem.Container.ContainerDescription;
                    }
                }
                return string.Empty;
            }
        }


        public ICommand OpenAudit
        {
            get;
            set;
        }
    }
}
