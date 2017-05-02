using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DataAccessLayer;
using System.IO;

namespace Audits.Database.DatabaseObjects
{
    public partial class Picture : DatabaseObject<Picture>, IPicture
    {
        public long PictureID
        {
            get
            {
                return pic_id;
            }
            set
            {
                pic_id = value;
            }
        }

        public long RequestItemID
        {
            get
            {
                return req_itm_id;
            }
            set
            {
                req_itm_id = value;
            }
        }

        public string Path
        {
            get
            {
                return pic_path;
            }
            set
            {
                pic_path = value;
            }
        }

        public DateTime AddDate
        {
            get
            {
                return pic_add_dm;
            }
            set
            {
                pic_add_dm = value;
            }
        }

        public string Comments
        {
            get
            {
                return pic_comment;
            }
            set
            {
                pic_comment = value;
            }
        }

        public byte LevelID
        {
            get
            {
                return lvl_id;
            }
            set
            {
                lvl_id = value;
                if (lvl_id != PackagingLevel.LevelID)
                {
                    PackagingLevel = DBContext.Instance.PackagingLevels.GetSingle(p => p.lvl_id == LevelID);
                }
            }
        }
        public string FileName
        {
            get
            {
                if (!(string.IsNullOrEmpty(pic_path)))
                {
                    return System.IO.Path.GetFileName(pic_path);
                }
                else return string.Empty;
            }
        }
        IPackagingLevel IPicture.PackagingLevel
        {
            get
            {
                return new PackagingLevel().Where("lvl_id={0}".Format(lvl_id)).FirstOrDefault();
            }
            set
            {
                PackagingLevel = (PackagingLevel)value;
                if (PackagingLevel.LevelID != LevelID)
                {
                    LevelID = PackagingLevel.LevelID;
                }
            }
        }

        IRequestItem IPicture.RequestItem
        {
            get
            {
                return RequestItem;
            }
            set
            {
                RequestItem = (RequestItem)value;
            }
        }

        IPicture IPicture.Picture
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
