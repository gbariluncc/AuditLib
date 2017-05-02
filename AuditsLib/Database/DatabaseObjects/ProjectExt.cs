using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public partial class Project : DatabaseObject<Project>, IProject
    {
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

        public DateTime AddDate
        {
            get
            {
                return proj_add_dt;
            }
            set
            {
                proj_add_dt = value;
            }
        }

        public string Title
        {
            get
            {
                return proj_title;
            }
            set
            {
                proj_title = value;
            }
        }

        public string Description
        {
            get
            {
                return proj_desc;
            }
            set
            {
                proj_desc = value;
            }
        }

        public bool IsPublic
        {
            get
            {
                return proj_is_public;
            }
            set
            {
                proj_is_public = value;
            }
        }

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

        public byte StatusCode
        {
            get
            {
                return sts_cd;
            }
            set
            {
                sts_cd = value;
            }
        }

        ISource IProject.Source
        {
            get
            {
                if (Source == null)
                {
                    Source = new Source().Where("source_id=" + source_id).SingleOrDefault();
                }
                return Source;
            }
            set
            {
                Source = (Source)value;
            }
        }

        IStatus IProject.Status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = (Status)value;
            }
        }

        ICollection<IRequest> IProject.Requests
        {
            get
            {
                if (Requests == null)
                {
                    Requests = new Request().Where("proj_id={0}".Format(proj_id));
                }
                return Requests.ToHashSet<IRequest>();
            }
            set
            {
                
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
