using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Infastructure;

namespace Audits.Database
{
    public interface IDatabaseObject<T> where T: class
    {
        void Update();
        void Add(bool addAll = false, ProgressReporter pg = null);
        void Delete();
        void AddAsync(bool addAll = false, ProgressReporter pg = null);
        bool NeedsToSave { get; set; }
        void OnPropertyChanged(string propName);

        DBObjectState ObjectState { get; set; }
    }
    public enum DBObjectState
    {
        StateObjectModified,
        StateObjectAdded,
        StateObjectRemove,
        StateObjectUnchanged
    }
}
