using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advantech.Library
{
    public class Log
    {
        public string logPath = AppDomain.CurrentDomain.BaseDirectory + @"\userdefinelog.log";
        public Log(string path)
        {
            RelativePath(path);
            Create();
        }
        public Log()
        {
            Create();
        }
        private void Create()
        {
            // This text is added only once to the file.
            if (!File.Exists(logPath))
            {
                // Create a file to write to.
                File.WriteAllText(logPath, "[LogStart]" + Environment.NewLine);
            }
            else
            {
                File.Delete(logPath);
                Create();
            }
        }
        public void WriteLog(string Log)
        {
            File.AppendAllText(logPath, Log);
        }
        private void RelativePath(string path)
        {
            if (path.IndexOf(@"..\") > -1)
            {
                logPath = Path.GetFullPath(path) + @"\userdefinelog.log";
            }
            else if (path.IndexOf(@".\") > -1)
            {
                logPath = AppDomain.CurrentDomain.BaseDirectory + path.Replace(".", "") + @"\userdefinelog.log";
            }
            else
            {
                logPath = path + @"\userdefinelog.log"; ;
            }
        }
    }
}
