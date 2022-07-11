using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advantech.Library
{
    public class INI
    {
        
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string name, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
		public string iniPath;

		public INI(string iniPath)
		{
			this.iniPath = iniPath;
		}
		public void Write(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, this.iniPath);
		}
		public string Read(string section, string key)
		{
			StringBuilder sb = new StringBuilder(255);
			int ini = GetPrivateProfileString(section, key, "", sb, 255, this.iniPath);
			return sb.ToString();
		}
	}
}
