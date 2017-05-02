using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Infastructure
{
    public abstract class RecordNavigator<T> : ViewBase where T : class
    {
        protected IList<T> _objects;
        protected T _current;
        protected int _pointer;
        protected abstract T CreateNew();
        protected virtual void RefreshData()
        {
            OnPropertyChanged("RecordCount");
            OnPropertyChanged("CurrentRecord");
            OnPropertyChanged("Display");
            OnPropertyChanged("DataSheet");
            OnPropertyChanged("Position");
        }
        protected bool CanDelete()
        {
            return (_pointer != _objects.Count);
        }
        public IList<T> Data
        {
            get
            {
                if (_objects == null)
                {
                    _objects = new List<T>();
                }
                return _objects;
            }
            set
            {
                _objects = value; OnPropertyChanged();
            }
        }
        public int Position
        {
            get { return _pointer; }
            set
            {
                if (value > 0 && value <= _objects.Count)
                {
                    _pointer = value;
                }
                else
                {
                    _pointer = value > _objects.Count ? _objects.Count : 1;
                }

                int pos = _pointer - 1;

                _current = _objects[pos];
                OnPropertyChanged("CurrentRecord");
                OnPropertyChanged("DataSheet");
                OnPropertyChanged("Position");
            }
        }
        public T CurrentRecord
        {
            get { return _current; }
            protected set
            {
                SetProperty(ref _current, value);
                _objects.Add(_current);
                _pointer = _objects.Count;
                OnPropertyChanged("Position");
            }
        }
        public int RecordCount
        {
            get { return Data.Count; }
        }
        protected virtual bool MoveForward()
        {
            if (_pointer < _objects.Count)
            {
                _pointer++;
                _current = _objects[_pointer - 1];

                RefreshData();
                return true;
            }
            return false;
        }
        protected virtual bool MoveBack()
        {
            if (_pointer != 1)
            {
                _pointer--;
                _current = _objects[_pointer - 1];

                RefreshData();
                return true;
            }
            return false;
        }
        protected virtual void MoveLast()
        {
            _pointer = _objects.Count;

            _current = _objects[_pointer - 1];

            RefreshData();
        }
        protected virtual void MoveFirst()
        {
            _pointer = 1;

            _current = _objects[_pointer - 1];
            RefreshData();
        }
    }
}
