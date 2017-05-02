using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IFailType : IDatabaseObject<FailType>
    {
        byte FailTypeID { get; set; }
        string FailDescription { get; set; }

        ICollection<IFailedSample> FailedSamples { get; set; }

        IFailType FailType { get; set; }
    }
}
