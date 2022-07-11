using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HandShake
{
    internal class Program
    {
        static bool boolMark = false;
        static string path = AppDomain.CurrentDomain.BaseDirectory + @"\userdefineresult.log";
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                boolMark = (args[0] == "PASS");
                if (args.Length > 1)
                   RelativePath(args[1]);
            }
            Create();
        }
        public static void Create() 
        {
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                Console.WriteLine(path);
                // Create a file to write to.
                File.WriteAllText(path, "[Response]" + Environment.NewLine + "Result=" + (boolMark ? "PASS" : "FAIL"));
            }
            else 
            {
                File.Delete(path);
                Create();
            }
        }
        public static void RelativePath(string args) 
        {
            if (args.IndexOf(@"..\") > -1)
            {
                path = Path.GetFullPath(args) + @"\userdefineresult.log";
            }
            else if (args.IndexOf(@".\") > -1)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + args.Replace(".","") + @"\userdefineresult.log";
            }
            else
            {
                path = args + @"\userdefineresult.log"; ;
            }
        }
    }
}
