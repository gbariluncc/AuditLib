using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using System.Windows.Media;
using System.Windows;

namespace Audits.Database.DatabaseObjects
{
    public partial class Source : DatabaseObject<Source>, ISource
    {
        private bool _isSelected;

        public byte SourceID
        {
            get
            {
                return source_id;
            }
            set
            {
                source_id = value;
            }
        }
        public bool IsSelected 
        { 
            get { return _isSelected; } 
            set { _isSelected = value; } 
        }

        public string Description
        {
            get
            {
                return source_desc;
            }
            set
            {
                source_desc = value;
            }
        }
        public Geometry Icon
        {
            get
            {
                var dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("pack://application:,,,/AuditsLib;component/Common/Vectors.xaml", UriKind.Absolute);

                return (Geometry)dictionary[source_icon];
            }
        }
        public static bool operator ==(Source obj1, Source obj2)
        {
            if (object.ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (object.ReferenceEquals(obj1, null) ||
                object.ReferenceEquals(obj2, null))
            {
                return false;
            }
            return (obj1.source_id == obj2.source_id);
        }
        public static bool operator !=(Source obj1, Source obj2)
        {
            return !(obj1 == obj2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Source)
            {
                return (obj as Source) == this;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return source_id.GetHashCode();
        }
        ICollection<IProject> ISource.Projects
        {
            get
            {
                return InterfaceConverter.ConvertToCollection<IProject, Project>(Projects);
            }
            set
            {
                Projects = InterfaceConverter.ConvertToCollection<Project, IProject>(value);
            }
        }

        ISource ISource.Source
        {
            get
            {
                return this;
            }
            set
            {
                throw new NotImplementedException();
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
