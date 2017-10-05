using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utility
{
    public static class LogHelper
    {
        public static void Log(Exception ex, HataTuru h)
        {
            string logPath = "c:/Users/Wissen/Desktop/logs";


            /*
            string logPath = ConfigurationManager.AppSettings["LogPath"];
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

    */
            //string klasor = HttpContext.Current.Server.MapPath(logPath);

            string dosyaAdi = "";
            switch (h)
            {
                case HataTuru.Seed:
                    dosyaAdi = ConfigurationManager.AppSettings["SeedLogFile"];
                    break;
                case HataTuru.Video:
                    break;
                case HataTuru.Makale:
                    break;
                case HataTuru.Ekitap:
                    dosyaAdi = ConfigurationManager.AppSettings["EKitapLogFile"];
                    break;
                default:
                    break;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(ex.Message);
                sb.Append(Environment.NewLine);
                sb.Append("************* INNER EX ***************");
                sb.Append(Environment.NewLine);
                if (ex.InnerException != null)
                    sb.Append(ex.InnerException.Message);
                sb.Append(Environment.NewLine);
                sb.Append("************* STACK TRACE ***************");
                sb.Append(ex.StackTrace);
                sb.Append(Environment.NewLine);
                sb.Append("----------------------------------------");
                sb.Append(Environment.NewLine);
                System.IO.File.AppendAllText(logPath + "/" + dosyaAdi, sb.ToString());
            }
            finally { }
        }

    }

    public enum HataTuru
    {
        Seed,
        Video,
        Makale,
        Ekitap
    }
}
