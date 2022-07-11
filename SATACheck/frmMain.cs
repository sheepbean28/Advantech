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

namespace SATACheck
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<PhysicalDisk> lstDisk = new List<PhysicalDisk>();
        List<PhysicalDisk> lstCheck = new List<PhysicalDisk>();
        Advantech.Library.Log log = new Advantech.Library.Log();
        int Quantity = 0;
        List<string> lstDevice = new List<string>();
        Advantech.Library.INI INI = new Advantech.Library.INI(AppDomain.CurrentDomain.BaseDirectory + @"\SATACheck.ini");

        private void frmMain_Load(object sender, EventArgs e)
        {
            Process p = Process.Start("HandShake.exe", "FAIL");
            ReadINIItem();
            if (INI.Read("SATACheck", "AutoStart") == "1")
                GetSATA();
            if (INI.Read("SATACheck", "AutoClose") == "1")
                Application.Exit();
        }

        //Data
        public void GetSATA()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_PnPSignedDriver");
            var searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject item in searcher.Get())
            {
                var props = new string[] {  "DriverName", "FriendlyName", "Location" };
                foreach (PropertyData property in item.Properties)
                {
                    if (property.Value == null &&
                        props.Any(p => p.ToUpper() == property.Name.ToUpper()))
                    {

                        //SendMsg("GetMemory", $"{property.Name} is null");
                        //return;
                    }
                }
                string FriendlyName = item["FriendlyName"] == null ? "" : item["FriendlyName"].ToString().Replace(" ", "");
                string Location = item["Location"] == null ? "" : item["Location"].ToString().Replace(" ", "");
                string DeviceName = item["DeviceName"] == null ? "" : item["DeviceName"].ToString().Replace(" ", "");
                string HardwareID = item["HardWareID"] == null ? "" : item["HardWareID"].ToString().Replace(" ", "");
                string CompatID = item["CompatID"] == null ? "" : item["CompatID"].ToString().Replace(" ", "");
                if (lstDevice.Any())
                {
                    if (lstDevice.Find(dev => dev.ToUpper() == DeviceName.ToUpper()) != null && CompatID.IndexOf("USB") ==  -1)
                    {
                        SendMsg("GetALL", $"DeviceName-> {DeviceName} DeviceID-> {HardwareID} FriendlyName-> {FriendlyName} Location->  {Location}");
                        lstDisk.Add(new PhysicalDisk(DeviceName, FriendlyName, Location, HardwareID));
                    }
                }
                else 
                {
                    SendMsg("GetALL", $"DeviceName-> {DeviceName} DeviceID-> {HardwareID} FriendlyName-> {FriendlyName} Location->  {Location}");
                    lstDisk.Add(new PhysicalDisk(DeviceName, FriendlyName, Location, HardwareID));
                }
              
            }
            //判斷總數
            if (lstDisk.Count != lstCheck.Count)
            {
                SendMsg("Result->FAIL ", string.Format("SetQuantity:{0}  GetDisk:{1} -> device quantity is not match with setting quantity", lstCheck.Count, lstDisk.Count));
                Result(false);
                return;
            }
            foreach (var check in lstCheck)
            {
                SendMsg("INI", check.ConvertToString());
                var oCHeck = lstDisk.Where(x => ((x.FriendlyName == check.DeviceKeyWords ) || (x.DeviceID.IndexOf(check.DeviceKeyWords) > -1))
                && ((x.Location == check.Location)));
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
             //}
            Result(!lstCheck.Where(x => (x.check == false)).Any());
        }
        public void ReadINIItem()
        {
            if (!Int32.TryParse(INI.Read("SATACheck", "Quantity"), out Quantity))
                ErrorAndExit("Quantity is not a integer,check INI quantity settings");

            string DeviceName = INI.Read("SATACheck", "DeviceName");
            if (DeviceName != string.Empty)
            {
                lstDevice = DeviceName.Split(',').ToList();
            }
            for (int i = 1; i <= Quantity; i++)
            {
                
                string slot = "slot" + i;
                string FriendlyName = CheckItem(slot, "DeviceKeyWords");
                string Location = CheckItem(slot, "Location");
                lstCheck.Add(new PhysicalDisk(FriendlyName,Location));
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
                pcBanner.BackgroundImage = global::SATACheck.Properties.Resources.banner_pass;
                return;
            }
            Image image = global::SATACheck.Properties.Resources.banner_fail;
            pcBanner.BackgroundImage = image;

        }
        public void ErrorAndExit(string ErrorMsg)
        {
            MessageBox.Show(ErrorMsg, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            log.WriteLog(ErrorMsg);
            Application.Exit();
        }
        //UI Control
        public class PhysicalDisk
        {
          public String DeviceName;
          public String FriendlyName;
          public String DeviceID;
          public String Location;
          public String DeviceKeyWords;
            
          public bool check = false;
            public PhysicalDisk(string DeviceName, string FriendlyName, string Location,string DeviceID)
            {
                this.DeviceName = DeviceName;
                this.FriendlyName = FriendlyName;
                this.Location = Location;
                this.DeviceID = DeviceID;
            }
            public PhysicalDisk(string DeviceKeyWords, string Location)
            {
                this.DeviceKeyWords = DeviceKeyWords;
                this.Location = Location;
            }
            public string ConvertToString()
            {
                 return string.Format($"DeviceName: {DeviceName}   FriendlyName: {FriendlyName}   string: {Location} ");
            }
        }
    }
}
