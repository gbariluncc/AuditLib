using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IContainer : IDatabaseObject<Container>
    {
        byte ContainerType { get; set; }
        string ContainerDescription { get; set; }

        ICollection<IRequestItem> RequestItems { get; set; }

        IContainer Container { get; set; }
    }
}
