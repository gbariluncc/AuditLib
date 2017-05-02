using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database.DatabaseObjects;

namespace Audits.Database
{
    public interface IPicture : IDatabaseObject<Picture>
    {
        long PictureID { get; set; }
        long RequestItemID { get; set; }
        string Path { get; set; }
        DateTime AddDate { get; set; }
        string Comments { get; set; }
        byte LevelID { get; set; }
        string FileName { get; }

        IPackagingLevel PackagingLevel { get; set; }
        IRequestItem RequestItem { get; set; }

        IPicture Picture { get; set; }
    }
}
