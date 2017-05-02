using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DMSObjects;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public class HoldRequest
    {
        private HashSet<IHoldPO> _pos;

        public HoldRequest()
        {
            _pos = new HashSet<IHoldPO>();
        }

        public HoldRequest(ICollection<IHoldPO> pos)
            : this()
        {
            _pos = (HashSet<IHoldPO>)pos;
        }
        public void HoldPOs()
        {
            _pos.Each(p =>
            {
                Hold hold = new Hold()
                {
                    ReasonCode = p.GetHoldReason().ReasonCode,
                    PONumber = Convert.ToInt32(p.Number),
                    HoldDate = DateTime.Now,
                    ReleaseDate = DateTime.Now.AddDays(2)
                };
                hold.AddAsync();
                
            });
        }
        public string GetTableData()
        {
            string tableDat = string.Empty;

            _pos.Each(p =>
            {
                tableDat += p.MakeHtmlTableRow();
            });

            return tableDat;
        }
    }
}
