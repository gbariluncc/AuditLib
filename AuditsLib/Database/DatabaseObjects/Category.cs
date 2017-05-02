using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits.Database.DatabaseObjects
{
    public partial class Category
    {
        private HashSet<Audit> _audits;
        private HashSet<Category> _subCategories;
        private HashSet<Dimension> _dimensions;
        private HashSet<Request> _requests;
        private Category _mainCategory;

        public Category()
        {
        }

        [Database(IsDBField = true, IsPrimary = true, IsReadOnly = false)]
        public byte cat_id { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public string cat_desc { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cat_grp { get; set; }

        [Database(IsDBField = true, IsPrimary = false, IsReadOnly = false)]
        public byte cat_smry_grp { get; set; }

        public virtual ICollection<Audit> Audits 
        {
            get
            {
                if (_audits == null)
                {
                    _audits = new Audit().Where("cat_id=" + cat_id).ToHashSet();
                }
                return _audits;
            }
            set
            {
                _audits = (HashSet<Audit>)value;
            }
        }
        public virtual ICollection<Category> SubCategories 
        {
            get
            {
                if (_subCategories == null)
                {
                    _subCategories = new Category().Where("cat_grp=" + cat_id).ToHashSet();
                }
                return _subCategories;
            }
            set
            {
                _subCategories = (HashSet<Category>)value;
            }
        }
        public virtual Category ParentCategory 
        {
            get
            {
                if (_mainCategory == null)
                {
                    _mainCategory = new Category().Where("cat_id=" + cat_smry_grp).SingleOrDefault();
                }
                return _mainCategory;
            }
            set { _mainCategory = value; }
        }
        public virtual ICollection<Dimension> Dimensions 
        {
            get
            {
                if (_dimensions == null)
                {
                    _dimensions = new Dimension().Where("cat_id=" + cat_id).ToHashSet();
                }
                return _dimensions;
            }
            set { _dimensions = (HashSet<Dimension>)value; }
        }
        public virtual ICollection<Request> Requests 
        {
            get
            {
                if (_requests == null)
                {
                    HashSet<RequestCategory> temp = new RequestCategory().Where("cat_id=" + cat_id).ToHashSet();
                    temp.Each(t => _requests.Add(t.Request));
                }
                return _requests;
            }
            set { _requests = (HashSet<Request>)value; } 
        }
    }
}
