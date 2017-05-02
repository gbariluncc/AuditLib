using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DMSObjects
{
    public interface IPOWithStatus : IPO
    {
        string LocationStatus { get; set; }
        POEntryType POEntryType { get; set; }
        void RefreshStatus();
    }

    [Serializable]
    public enum POEntryType
    {
        System,
        Manual
    }
}
