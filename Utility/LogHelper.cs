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
        public static void Log(Exception ex, string preferredPath=null)
        {

            string logPath = HttpContext.Current.Server.MapPath("/");
            if (preferredPath == null)
                logPath += ConfigurationManager.AppSettings["LogFolder"] + "\\";
            else
                logPath = preferredPath;
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            logPath += "log.txt";
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
                System.IO.File.AppendAllText(logPath, sb.ToString());
            }
            finally { }
        }

    }
}
