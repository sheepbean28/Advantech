using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace INIFunction
{
    public class INIHelper
    {
        /// <summary>
        /// 為INI檔案中指定的節點取得字串
        /// </summary>
        /// <param name="lpAppName">欲在其中查詢關鍵字的節點名稱</param>
        /// <param name="lpKeyName">欲獲取的項名</param>
        /// <param name="lpDefault">指定的項沒有找到時返回的預設值</param>
        /// <param name="lpReturnedString">指定一個字串緩衝區，長度至少為nSize</param>
        /// <param name="nSize">指定裝載到lpReturnedString緩衝區的最大字元數量</param>
        /// <param name="lpFileName">INI檔案完整路徑</param>
        /// <returns>複製到lpReturnedString緩衝區的位元組數量，其中不包括那些NULL中止字元</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 修改INI檔案中內容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中寫入的節點名稱</param>
        /// <param name="lpKeyName">欲設定的項名</param>
        /// <param name="lpString">要寫入的新字串</param>
        /// <param name="lpFileName">INI檔案完整路徑</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// 讀取INI檔案值
        /// </summary>
        /// <param name="section">節點名</param>
        /// <param name="key">鍵</param>
        /// <param name="def">未取到值時返回的預設值</param>
        /// <param name="filePath">INI檔案完整路徑</param>
        /// <returns>讀取的值</returns>
        public static string Read(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        /// <summary>
        /// 寫INI檔案值
        /// </summary>
        /// <param name="section">欲在其中寫入的節點名稱</param>
        /// <param name="key">欲設定的項名</param>
        /// <param name="value">要寫入的新字串</param>
        /// <param name="filePath">INI檔案完整路徑</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        public static int Write(string section, string key, string value, string filePath)
        {
            CheckPath(filePath);
            return WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// 刪除節
        /// </summary>
        /// <param name="section">節點名</param>
        /// <param name="filePath">INI檔案完整路徑</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        public static int DeleteSection(string section, string filePath)
        {
            return Write(section, null, null, filePath);
        }

        /// <summary>
        /// 刪除鍵的值
        /// </summary>
        /// <param name="section">節點名</param>
        /// <param name="key">鍵名</param>
        /// <param name="filePath">INI檔案完整路徑</param>
        /// <returns>非零表示成功，零表示失敗</returns>
        public static int DeleteKey(string section, string key, string filePath)
        {
            return Write(section, key, null, filePath);
        }

        private static void CheckPath(string path)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");//在當前程式路徑建立
            //File.Create(filePath);//建立INI檔案
        }

    }

}
