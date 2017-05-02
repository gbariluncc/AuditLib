using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Infastructure;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;

namespace Audits.Database
{
    public class PictureDecorator : ViewBase, IPicture
    {
        private IPicture _picture;
        private BitmapImage _image;
        private BitmapImage _thumbnail;

        public PictureDecorator(IPicture picture)
        {
            _picture = picture;
            CreateBitmap();
            //_image = CreateBitmatImage(150, 150);
            //_thumbnail = CreateBitmatImage(50, 50);
        }

        public void CreateBitmap()
        {
            _image = CreateBitmatImage(150, 150);
            _thumbnail = CreateBitmatImage(50, 50);
        }
        public long PictureID
        {
            get
            {
                return _picture.PictureID;
            }
            set
            {
                _picture.PictureID = value;
            }
        }
        public bool NeedsToSave
        {
            get { return _picture.NeedsToSave; }
            set { _picture.NeedsToSave = value; }
        }
        public long RequestItemID
        {
            get
            {
                return _picture.RequestItemID;
            }
            set
            {
                _picture.RequestItemID = value;
            }
        }
        public string FileName
        {
            get
            {
                return _picture.FileName;
            }
        }
        public string Path
        {
            get
            {
                return _picture.Path;
            }
            set
            {
                _picture.Path = value;
                /*_thumbnail = CreateBitmatImage(50, 50);
                _image = CreateBitmatImage(150, 150);
                OnPropertyChanged("Thumbnail");
                OnPropertyChanged("Image");
                OnPropertyChanged();*/
            }
        }
        public BitmapImage Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public BitmapImage Thumbnail
        {
            get { return _thumbnail; }
            set { SetProperty(ref _thumbnail, value); }
        }
        public DateTime AddDate
        {
            get
            {
                return _picture.AddDate;
            }
            set
            {
                _picture.AddDate = value;
            }
        }

        public string Comments
        {
            get
            {
                return _picture.Comments;
            }
            set
            {
                _picture.Comments = value;
            }
        }

        public byte LevelID
        {
            get
            {
                return _picture.LevelID;
            }
            set
            {
                _picture.LevelID = value;
            }
        }
        private BitmapImage CreateBitmatImage(int pixelSizeHeight, int pixelSizeWidth)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(Path);
            bi.DecodePixelHeight = pixelSizeHeight;
            bi.DecodePixelWidth = pixelSizeWidth;
            bi.EndInit();
            bi.Freeze();

            return bi;
        }
        public IPackagingLevel PackagingLevel
        {
            get
            {
                return _picture.PackagingLevel;
            }
            set
            {
                _picture.PackagingLevel = value;
            }
        }

        public IRequestItem RequestItem
        {
            get
            {
                return _picture.RequestItem;
            }
            set
            {
                _picture.RequestItem = value;
            }
        }

        public IPicture Picture
        {
            get
            {
                return _picture.Picture;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Update()
        {
            _picture.Update();
        }


        public void Delete()
        {
            _picture.Delete();
        }

        public void AddAsync(bool addAll = false,ProgressReporter pg = null )
        {
            _picture.AddAsync(addAll,pg);
        }

        public DBObjectState ObjectState
        {
            get
            {
                return _picture.ObjectState;
            }
            set
            {
                _picture.ObjectState = value;
            }
        }

        public void Add(bool addAll = false, ProgressReporter pg = null)
        {
            _picture.Add(addAll,pg);
        }
    }
}
