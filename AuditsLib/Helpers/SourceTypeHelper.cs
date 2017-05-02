using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audits.Database;
using Audits.Database.DataAccessLayer;

namespace Audits.Helpers
{
    public static class SourceTypeHelper
    {
        public static string GetIcon(ISource source)
        {
            return GetIconString(source.SourceID);
        }
        public static string GetIcon(string SourceName)
        {
            byte sourceID = DBContext.Instance.Sources.GetSingle(s => s.Description == SourceName).SourceID;

            return GetIconString(sourceID);
        }

        public static string GetIcon(IRequestItem requestItem)
        {
            return SourceTypeHelper.GetIcon(requestItem.Request.Project.Source);
        }
        public static string GetMonochromeIcon(IRequestItem requestItem)
        {
            ISource source = requestItem.Request.Project.Source;

            return SourceTypeHelper.GetMonochromeIcon(source);
        }
        private static string GetIconString(byte sourceID)
        {
            switch (sourceID)
            {
                case 1:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/dolly.png";
                case 2:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/caution.png";
                case 3:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/speedometer.png";
                case 4:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/globe.png";
                case 5:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/countdown.png";
                case 6:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/magnifyingglass.png";
                case 7:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/stack.png";
                case 8:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/truck.png";
                case 9:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/rgb.png";
                case 10:
                    return "pack://application:,,,/AuditsLib;component/Assets/64px/spaceshuttle.png";
                default:
                    return string.Empty;
            }
        }
        public static string GetMonochromeIcon(ISource source)
        {
            return GetMonoIconString(source.SourceID);
        }
        private static string GetMonoIconString(byte sourceID)
        {
            switch (sourceID)
            {
                case 1:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/dolly.png";
                case 2:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/caution.png";
                case 3:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/speedometer.png";
                case 4:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/globe.png";
                case 5:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/countdown.png";
                case 6:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/magnifyingglass.png";
                case 7:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/stack.png";
                case 8:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/truck.png";
                case 9:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/rgb.png";
                case 10:
                    return "pack://application:,,,/AuditsLib;component/Assets/Monochrome/64px/spaceshuttle.png";
                default:
                    return string.Empty;
            }
        }
    }
}
