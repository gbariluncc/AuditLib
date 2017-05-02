using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IFailedSample : IDatabaseObject<FailedSample>
    {
        int ItemNumber { get; set; }
        int PONumber { get; set; }
        DateTime SampleDate { get; set; }
        int VBU { get; set; }
        string FailSummary { get; set; }
        string GeneralComments { get; set; }
        byte FailTypeID { get; set; }
        bool IsNew { get; set; }
        DateTime ExpirationDate { get; set; }
        byte StatusCode { get; set; }
        DateTime AddDate { get; set; }
        DateTime UpdateDate { get; set; }

        IFailType FailType { get; set; }
        IStatus Status { get; set; }

        IFailedSample FailedSample { get; set; }
    }
}
