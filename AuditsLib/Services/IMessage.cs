using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits;

namespace Audits.Services
{
    public interface IMessage : IDisplay
    {
        long DisplayWidth { get; set; }
        long DisplayHeight { get; set; }
        MessageState MessageState { get; set; }

    }
    public enum MessageState
    {
        READY,
        REST
    }
}
