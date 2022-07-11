using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<Momoery> lstMemory = new List<Momoery>();
        List<Momoery> lstCheck = new List<Momoery>();
        Advantech.Library.Log log = new Advantech.Library.Log();
        int Quantity = 0;
        Advantech.Library.INI INI = new Advantech.Library.INI(AppDomain.CurrentDomain.BaseDirectory + @"\MemoryTest.ini");

        private void frmMain_Load(object sender, EventArgs e)
        {
            Process p = Process.Start("HandShake.exe", "FAIL");
            ReadINIItem();
            if (INI.Read("MemoryTest", "AutoStart") == "1")
                GetMemory();
            if (INI.Read("MemoryTest", "AutoClose") == "1")
                Application.Exit();
        }

        //Data
        public void GetMemory()
        {
            ObjectQuery winQuery = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory ");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
            foreach (ManagementObject item in searcher.Get())
            {
                var props = new string[] { "Capacity", "PartNumber", "DeviceLocator" };
                foreach (PropertyData property in item.Properties)
                {
                    if (property.Value == null &&
                        props.Any(p => p.ToUpper() == property.Name.ToUpper()))
                    {
                        
                        SendMsg("GetMemory", $"{property.Name} is null");
                        //return;
                    }
                }
                UInt64.TryParse(item["Capacity"].ToString(), out UInt64 MemorySize);
                MemorySize = (MemorySize / 1024 / 1024); //取得的是Bytes單位，所以換算成MB
                string PartNumber = item["PartNumber"] == null ? "": item["PartNumber"].ToString().Replace(" ", "");
                string DeviceLocator = item["DeviceLocator"] == null ? "" : item["DeviceLocator"].ToString().Replace(" ", "");
              
                //DeviceLocator
                lstMemory.Add(new Momoery(MemorySize, PartNumber, DeviceLocator, 0));
            }
            lstMemory.ForEach(memorx => SendMsg("GetMemory", memorx.ConvertToString()));
            if (lstMemory.Count != lstCheck.Count)
            {
                SendMsg("Result->FAIL ", string.Format("SetQuantity:{0}  GetMemory:{1} -> memory quantity is not match with setting quantity", lstCheck.Count, lstMemory.Count));
                Result(false);
                return;
            }
            foreach (var check in lstCheck)
            {
                SendMsg("INI", check.ConvertToString());
                var oCHeck = lstMemory.Where(x => ((x.DeviceLocator == check.DeviceLocator || check.DeviceLocator == "NA"))
                        && ((x.MemorySize <= (check.Tolerance + check.MemorySize) || check.MemorySize == 0))
                        && ((x.MemorySize >= (check.MemorySize - check.Tolerance) || check.MemorySize == 0))
                        && ((x.PartNumber == check.PartNumber || check.PartNumber == "NA")));
                if (oCHeck.Any())
                {
                    check.check = true;
                    if (oCHeck.Count() > 1)
                    {
                        oCHeck.ToList().ForEach(memorx => SendMsg($"Result->PASS", memorx.ConvertToString()));
                        
                    }
                    else
                        SendMsg("Result->PASS", oCHeck.First().ConvertToString());
                }
                else
                {
                    check.check = false;
                    SendMsg("Result->FAIL", "Not match in settings");
                }
            }
            Result(!lstCheck.Where(x => (x.check == false)).Any());
        }
        public void ReadINIItem()
        {
            if (!Int32.TryParse(INI.Read("MemoryTest", "Quantity"), out Quantity))
                ErrorAndExit("Quantity is not a integer,check INI quantity settings");
            for (int i = 1; i <= Quantity; i++)
            {
                string slot = "slot" + i;
                ;
                UInt64 MemorySize = 0; //取得的是Bytes單位，所以換算成MB
                if (!UInt64.TryParse(CheckItem(slot, "MemorySize"), out MemorySize))
                    ErrorAndExit("MemorySize is not a integer,check INI Quantity settings");
                string PartNumber = CheckItem(slot, "PartNumber");
                string DeviceLocator = CheckItem(slot, "DeviceLocator");
                UInt64 Tolerance = 0;
                if (!UInt64.TryParse(INI.Read(slot, "Tolerance"), out Tolerance))
                    ErrorAndExit("Tolerance is not a integer,check INI tolerance settings");
                lstCheck.Add(new Momoery(MemorySize, PartNumber, DeviceLocator, Tolerance));
            }
        }
        public string CheckItem(string slot, string key)
        {
            if (INI.Read(slot, key) == string.Empty)
                ErrorAndExit(string.Format("{0} {1} read fail,check INI settings ", slot, key));
            return INI.Read(slot, key);
        }
        //UI Control
        public void SendMsg(string title, string Msg)
        {
            string msg = string.Format("[{0}] {2} -> {1} " + Environment.NewLine, DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss"), Msg, title);
            log.WriteLog(msg);
            rbMsg.Text += msg;
        }
        public void Result(bool result)
        {
            Process p = Process.Start("HandShake.exe", result ? "PASS" : "FAIL");
            p.WaitForExit();//關鍵，等待外部程式退出後才能往下執行
            if (result)
            {
                pcBanner.BackgroundImage = MemoryTest.Properties.Resources.banner_pass;
                return;
            }
            Image image = MemoryTest.Properties.Resources.banner_fail;
            pcBanner.BackgroundImage = image;

        }
        public void ErrorAndExit(string ErrorMsg)
        {
            MessageBox.Show(ErrorMsg, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            log.WriteLog(ErrorMsg);
            Application.Exit();
        }
        //UI Control
        public class Momoery
        {
            public UInt64 MemorySize;
            public string PartNumber;
            public string DeviceLocator;
            public bool check = false;
            public UInt64 Tolerance = 0;
            public Momoery(UInt64 MemorySize, string PartNumber, string DeviceLocator, UInt64 tolerance)
            {
                this.MemorySize = MemorySize;
                this.PartNumber = PartNumber;
                this.DeviceLocator = DeviceLocator;
                this.Tolerance = tolerance;
            }
            public string ConvertToString()
            {
                return string.Format("DeviceLocator: {0}   PartNumber: {1}   MemorySize: {2} ", DeviceLocator, PartNumber, MemorySize);
            }
        }
    }
}
