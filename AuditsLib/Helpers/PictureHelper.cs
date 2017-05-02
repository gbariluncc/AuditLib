using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using Audits.Database;
using System.Collections.Generic;
using System.Threading;

namespace Audits.Helpers
{
    public static class PictureHelper
    {
        public static bool Compress(string FromPath, string ToPath)
        {
            bool done = false;
            //Bitmap bmp = new Bitmap(FromPath);
            using (Bitmap bmp = new Bitmap(FromPath))
            {
                ImageCodecInfo picEncoder = GetEncoder(FromPath);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters encoderParams = new EncoderParameters(1);
                EncoderParameter encoderParam = new EncoderParameter(myEncoder, 50L);

                try
                {
                    encoderParams.Param[0] = encoderParam;
                    bmp.Save(ToPath, picEncoder, encoderParams);

                    while (!File.Exists(ToPath)) { Thread.Sleep(10); }
                }
                catch (Exception err) { MessageBox.Show("Error compressing picture: " + err.Message); return done; }
                finally
                {
                    picEncoder = null;
                    myEncoder = null;
                    encoderParam = null;
                    encoderParams = null;
                    done = true;
                }

                return done;
            }
        }
        public static void CompressList(List<IPicture> pictures, string toPath)
        {
            pictures.Each(p =>
                {

                });
        }
        private static ImageCodecInfo GetEncoder(string path)
        {
            string ext = path.Substring(path.Length - 3, 3);
            ImageFormat format;

            switch (ext.ToLower())
            {
                case "jpg":
                    format = ImageFormat.Jpeg;
                    break;
                case "png":
                    format = ImageFormat.Png;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
