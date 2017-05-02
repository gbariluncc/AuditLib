using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;
using System.Reflection;
using System.Windows;

namespace Audits.Services
{
    public abstract class Service<T> : ISubject where T: class, IEquatable<T>
    {
        private HashSet<IObserver> _observers;
        private HashSet<T> _internalCollection;
        private ICollection<T> _externalCollection;
        private Func<ICollection<T>> _getAction;
        private bool _isRunning = false;
        private HashSet<T> _newRecs;
        private HashSet<T> _updatedRecs;

        private bool _hasNew = false;

        public Service()
        {
            _observers = new HashSet<IObserver>();
            _newRecs = new HashSet<T>();
            _updatedRecs = new HashSet<T>();
            _internalCollection = new HashSet<T>();
        }
        public ICollection<T> ObservableData
        {
            get { return _externalCollection; }
            set 
            { 
                _externalCollection = value;
            }
        }
        public CompareType CompareType
        {
            get;
            set;
        }
        
        public ICollection<T> InternalData
        {
            get { return _internalCollection; }
            set { _internalCollection = (HashSet<T>)value; }
        }
        public ICollection<T> UpdatedRecords
        {
            get { return _updatedRecs; }
        }
        public void SetGetDataAction(Func<ICollection<T>> action)
        {
            _getAction = action;
        }
        public void registerObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public virtual void Compare()
        {
            ICollection<T> result = _getAction();

            lock (_internalCollection)
            {
                if (result.Count != _internalCollection.Count)
                {
                    HasNew = true;
                    UpdateCollection(result);
                    return;
                }
                else if (CompareType == CompareType.ByRecord)
                {
                    foreach (T e in result)
                    { 

                        T temp = _internalCollection.FirstOrDefault(itm => (itm as IEquatable<T>).Equals(e));

                        if (temp == null)
                        {
                            HasNew = true;
                            UpdateCollection(result);
                            return;
                        }
                        else if(!e.InstancePropertiesEqual(temp))
                        {
                            Updated = true;
                            _updatedRecs.Clear();
                            UpdateCollection(result);
                            return;
                        }
                    }
                }
            }
        }
        public ICollection<T> NewRecords
        {
            get { return _newRecs; }
        }
        private void UpdateCollection(ICollection<T> newCollection)
        {
            foreach (T temp in newCollection)
            {
                try
                {
                    T found = _internalCollection.FirstOrDefault(itm => (itm as IEquatable<T>).Equals(temp));

                    if (found == null)
                    {
                        _newRecs.Add(temp);
                    }
                    else if(!temp.InstancePropertiesEqual(found))
                    {
                        _updatedRecs.Add(temp);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }

            _internalCollection = newCollection.ToHashSet();
            updateObservers();
        }
        public void removeObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public virtual void StartService()
        {
            _isRunning = true;
            Task.Factory.StartNew(() => RunService());
        }
        private void RunService()
        {
            while (_isRunning == true)
            {
                Compare();
            }
        }
        public virtual void StopService()
        {
            _isRunning = false;
        }
        public void updateObservers()
        {
            _observers.EachAsync(o => o.update());
        }
        public bool HasNew
        {
            get { return _hasNew; }
            set
            {
                _hasNew = value;
                if (_hasNew == false) { _newRecs.Clear(); }
            }
        }
        public bool Updated
        {
            get;
            set;
        }
        public bool IsRunning { get { return _isRunning; } }
    }
    public enum CompareType
    {
        ByRecord,
        BySize
        
    }
}
