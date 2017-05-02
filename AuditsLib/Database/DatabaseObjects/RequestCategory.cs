using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;

namespace Audits.Database.DatabaseObjects
{
    public class RequestCategory : DatabaseObject<RequestCategory>, IDatabaseObject<RequestCategory>
    {
        private Category _category;
        private Request _request;

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public long req_id { get; set; }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte cat_id { get; set; }

        public Request Request
        {
            get
            {
                if (_request == null)
                {
                    _request = new Request().Where("req_id=" + req_id).SingleOrDefault();
                }
                return _request;
            }
            set { _request = value; }
        }
        public Category Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new Category().Where("cat_id=" + cat_id).SingleOrDefault();
                }
                return _category;
            }
            set { _category = value; }
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
