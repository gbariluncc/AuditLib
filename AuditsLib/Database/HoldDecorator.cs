using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;
using System.Runtime.CompilerServices;

namespace Audits.Database
{
    public abstract class HoldDecorator : IHold
    {
        private IHold _hold;

        public HoldDecorator(IHold hold)
        {
            _hold = hold;
        }


        public int HoldID
        {
            get
            {
                return _hold.HoldID;
            }
            set
            {
                _hold.HoldID = value;
            }
        }

        public DateTime HoldDate
        {
            get
            {
                return _hold.HoldDate;
            }
            set
            {
                _hold.HoldDate = value;
            }
        }

        public DateTime ReleaseDate
        {
            get
            {
                return _hold.ReleaseDate;
            }
            set
            {
                _hold.ReleaseDate = value;
            }
        }

        public int PONumber
        {
            get
            {
                return _hold.PONumber;
            }
            set
            {
                _hold.PONumber = value;
            }
        }

        public byte ReasonCode
        {
            get
            {
                return _hold.ReasonCode;
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
                return _hold.HoldComments;
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
                return _hold.HoldExpiration;
            }
            set
            {
                _hold.HoldExpiration = value;
            }
        }

        public IHoldReason HoldReason
        {
            get { return _hold.HoldReason; }
        }

        public void Update()
        {
            _hold.Update();
        }

        public void Add(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _hold.Add(addAll, pg);
        }

        public void Delete()
        {
            _hold.Delete();
        }

        public void AddAsync(bool addAll = false, Infastructure.ProgressReporter pg = null)
        {
            _hold.AddAsync(addAll, pg);
        }

        public bool NeedsToSave
        {
            get
            {
                return _hold.NeedsToSave;
            }
            set
            {
                _hold.NeedsToSave = value;
            }
        }
        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            _hold.OnPropertyChanged(propName);
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
