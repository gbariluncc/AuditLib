using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Infastructure;
using System.Runtime.CompilerServices;

namespace Audits.Database
{
    public abstract class SourceDecorator : ISource
    {
        private ISource _source;

        public SourceDecorator(ISource source)
        {
            _source = source;
        }
        public byte SourceID
        {
            get
            {
                return _source.SourceID;
            }
            set
            {
                
            }
        }
        public bool IsSelected { get; set; }
        public bool NeedsToSave
        {
            get { return _source.NeedsToSave; }
            set { _source.NeedsToSave = value; }
        }
        public void AddAsync(bool addAll = false, ProgressReporter pg = null)
        {
            _source.AddAsync(addAll,pg);
        }
        public string Description
        {
            get
            {
                return _source.Description;
            }
            set
            {
                
            }
        }

        public ICollection<IProject> Projects
        {
            get
            {
                return _source.Projects;
            }
            set
            {
                
            }
        }

        public ISource Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }


        public void Delete()
        {
            throw new NotImplementedException();
        }



        public DBObjectState ObjectState
        {
            get
            {
               return _source.ObjectState;
            }
            set
            {
                _source.ObjectState = value;
            }
        }

        public void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            _source.OnPropertyChanged(propName);
        }
        public void Add(bool addAll = false, ProgressReporter pg = null)
        {
            _source.Add(addAll,pg);
        }


        public System.Windows.Media.Geometry Icon
        {
            get { return _source.Icon; }
        }
    }
}
