using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Management;
using INIFunction;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Linq;

namespace SATACheck
{
    public partial class SATACheck : Form
    {
        public class Global
        {
            public static string filePath;
            public static string Disk_Sata_Set;
            public static string End_result;
            public static string ResultPath;
            public static string Capacity;
            public static string Tool_Set;
            public static string IniTotal;
            public static string ResultString;
            public static int IniRecount;
            public static string[] myArray = new string[13];
        }

        private Dictionary<string, PhysicalDiskStruct> _pdiCache = new Dictionary<string, PhysicalDiskStruct>();
        public Dictionary<string, PhysicalDiskStruct> PDiskInfo
        {
            get
            {
                if (_pdiCache.Count == 0)
                    _pdiCache = GetDiskPI();
                return _pdiCache;
            }
        }
        public void ClearCache()
        {
            if (_pdiCache.Count > 0)
                _pdiCache.Clear();
        }
        private static Dictionary<string, PhysicalDiskStruct> GetDiskPI()
        {
            var DI = new Dictionary<string, PhysicalDiskStruct>();
            var scope = new ManagementScope(@"\\localhost\ROOT\Microsoft\Windows\Storage");
            var query = new ObjectQuery("SELECT * FROM MSFT_PhysicalDisk");
            var searcher = new ManagementObjectSearcher(scope, query);
            var dObj = searcher.Get();
            var wobj = new ManagementObjectSearcher("select * from MSFT_PhysicalDisk");
            foreach (ManagementObject diskobj in dObj)
            {
                var dis = new PhysicalDiskStruct();
                try
                {
                    dis.SupportedUsages = (ushort[])diskobj["SupportedUsages"];
                }
                catch (Exception ex)
                {
                    dis.SupportedUsages = null;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.CannotPoolReason = (ushort[])diskobj["CannotPoolReason"];
                }
                catch (Exception ex)
                {
                    dis.CannotPoolReason = null;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.OperationalStatus = (ushort[])diskobj["OperationalStatus"];
                }
                catch (Exception ex)
                {
                    dis.OperationalStatus = null;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.OperationalDetails = (string[])diskobj["OperationalDetails"];
                }
                catch (Exception ex)
                {
                    dis.OperationalDetails = null;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.UniqueIdFormat = (ushort)diskobj["UniqueIdFormat"];
                }
                catch (Exception ex)
                {
                    dis.UniqueIdFormat = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.DeviceId = diskobj["DeviceId"].ToString();
                }
                catch (Exception ex)
                {
                    dis.DeviceId = "NA";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.FriendlyName = (string)diskobj["FriendlyName"];
                }
                catch (Exception ex)
                {
                    dis.FriendlyName = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.HealthStatus = (ushort)diskobj["HealthStatus"];
                }
                catch (Exception ex)
                {
                    dis.HealthStatus = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.PhysicalLocation = (string)diskobj["PhysicalLocation"]; // Bus Number 1, Target Id 0, LUN 0
                }
                catch (Exception ex)
                {
                    dis.PhysicalLocation = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.VirtualDiskFootprint = (ushort)diskobj["VirtualDiskFootprint"];
                }
                catch (Exception ex)
                {
                    dis.VirtualDiskFootprint = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.Usage = (ushort)diskobj["Usage"];
                }
                catch (Exception ex)
                {
                    dis.Usage = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.Description = (string)diskobj["Description"];
                }
                catch (Exception ex)
                {
                    dis.Description = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.PartNumber = (string)diskobj["PartNumber"];
                }
                catch (Exception ex)
                {
                    dis.PartNumber = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.FirmwareVersion = (string)diskobj["FirmwareVersion"];
                }
                catch (Exception ex)
                {
                    dis.FirmwareVersion = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.SoftwareVersion = (string)diskobj["SoftwareVersion"];
                }
                catch (Exception ex)
                {
                    dis.SoftwareVersion = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.Size = (ulong)diskobj["SoftwareVersion"];
                }
                catch (Exception ex)
                {
                    dis.Size = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.AllocatedSize = (ulong)diskobj["AllocatedSize"];
                }
                catch (Exception ex)
                {
                    dis.AllocatedSize = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.BusType = (ushort)diskobj["BusType"];
                }
                catch (Exception ex)
                {
                    dis.BusType = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.IsWriteCacheEnabled = (bool)diskobj["IsWriteCacheEnabled"];
                }
                catch (Exception ex)
                {
                    dis.IsWriteCacheEnabled = false;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.IsPowerProtected = (bool)diskobj["IsPowerProtected"];
                }
                catch (Exception ex)
                {
                    dis.IsPowerProtected = false;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.PhysicalSectorSize = (ulong)diskobj["PhysicalSectorSize"]; // ROM？
                }
                catch (Exception ex)
                {
                    dis.PhysicalSectorSize = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.LogicalSectorSize = (ulong)diskobj["LogicalSectorSize"]; //碟容量GB
                }
                catch (Exception ex)
                {
                    dis.LogicalSectorSize = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.SpindleSpeed = (uint)diskobj["SpindleSpeed"];
                }
                catch (Exception ex)
                {
                    dis.SpindleSpeed = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.IsIndicationEnabled = (bool)diskobj["IsIndicationEnabled"];
                }
                catch (Exception ex)
                {
                    dis.IsIndicationEnabled = false;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.EnclosureNumber = (ushort)diskobj["EnclosureNumber"];
                }
                catch (Exception ex)
                {
                    dis.EnclosureNumber = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.SlotNumber = (ushort)diskobj["SlotNumber"];
                }
                catch (Exception ex)
                {
                    dis.SlotNumber = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.CanPool = (bool)diskobj["CanPool"];
                }
                catch (Exception ex)
                {
                    dis.CanPool = false;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.OtherCannotPoolReasonDescription = (string)diskobj["OtherCannotPoolReasonDescription"];
                }
                catch (Exception ex)
                {
                    dis.OtherCannotPoolReasonDescription = "?";
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.IsPartial = (bool)diskobj["IsPartial"];
                }
                catch (Exception ex)
                {
                    dis.IsPartial = false;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                try
                {
                    dis.MediaType = (ushort)diskobj["MediaType"];
                }
                catch (Exception ex)
                {
                    dis.MediaType = 0;
                    //ExceptionLog.ExLog(ex, "GetDiskPI", "PhysicalDiskStruct");
                }
                DI.Add(dis.DeviceId, dis);
            }
            return DI;
        }

        public SATACheck()
        {
            InitializeComponent();
        }

        private void SATACheck_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                Global.filePath = @"./Setup.ini";
                Global.IniTotal = INIHelper.Read("Compare_Set", "Disk_Sata_Set" + i, "", Global.filePath);
                Global.myArray[i] = Global.IniTotal;
            }
        }

        private void SNinputTextBox_keydown(object sender, KeyEventArgs e)
        {
            Global.IniRecount = 12;
            //今日日期
            DateTime Date = DateTime.Now;
            string TodyMillisecond = Date.ToString("yyyy-MM-dd HH:mm:ss");
            string Tody = Date.ToString("yyyy-MM-dd");

            if (e.KeyCode == Keys.Enter)
            {
                string strtxt = SNinputTextBox.Text.ToString().ToUpper();

                if (strtxt != "")
                {
                    SNinputTextBox.SelectAll();

                    //如果此路徑沒有資料夾
                    if (!Directory.Exists("./Test_Log"))
                    {
                        //新增資料夾
                        Directory.CreateDirectory("./Test_Log");
                    }

                    foreach (KeyValuePair<string, PhysicalDiskStruct> kvp in PDiskInfo)
                    {
                        //MessageBox.Show(kvp.Value.MediaType.ToString()); //確認SATA位置

                        /* Line #373 Setting kvp.Value.MediaType == ?
                            typedef enum _STORAGE_BUS_TYPE {
                              BusTypeUnknown = 0x00,
                              BusTypeScsi,
                              BusTypeAtapi,
                              BusTypeAta,
                              BusType1394,
                              BusTypeSsa,
                              BusTypeFibre,
                              BusTypeUsb,
                              BusTypeRAID,
                              BusTypeiScsi,
                              BusTypeSas,
                              BusTypeSata,
                              BusTypeSd,
                              BusTypeMmc,
                              BusTypeVirtual,
                              BusTypeFileBackedVirtual,
                              BusTypeSpaces,
                              BusTypeNvme,
                              BusTypeSCM,
                              BusTypeUfs,
                              BusTypeMax,
                              BusTypeMaxReserved = 0x7F
                            } STORAGE_BUS_TYPE, *PSTORAGE_BUS_TYPE;
                        */

                        if (kvp.Value.MediaType == 3 || kvp.Value.MediaType == 4) //只做GET SATA SSD
                        {
                            Console.WriteLine("Disk Number = {0}, FriendlyName = {1}, PhysicalLocation = {2}", strtxt + "_" + kvp.Key, kvp.Value.FriendlyName, kvp.Value.PhysicalLocation);
                            string stringAfterChar = kvp.Value.PhysicalLocation.Substring(kvp.Value.PhysicalLocation.IndexOf(": Port ") + 2);
                            Console.WriteLine(stringAfterChar);
                            Global.Capacity = (kvp.Value.AllocatedSize / 1024 / 1024 / 1024) + "GB"; //Bytes換算為GB
                            lblHDDChanels.AppendText(strtxt + "_" + "Read Disk info" + ": " + "Disk(" + kvp.Key + ")," + kvp.Value.FriendlyName + ",SATA(" + stringAfterChar + ")," + Global.Capacity + "\r\n");
                            File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Read Disk info " + ": " + "Disk(" + kvp.Key + ")," + kvp.Value.FriendlyName + ",SATA(" + stringAfterChar + ")," + Global.Capacity);
                            Global.ResultString = "Disk(" + kvp.Key + ")," + kvp.Value.FriendlyName + ",SATA(" + stringAfterChar + ")," + Global.Capacity;
                            Console.WriteLine(strtxt + "_" + Global.ResultString + "\r\n");

                            Global.filePath = @"./Setup.ini";
                            Global.Disk_Sata_Set = INIHelper.Read("Compare_Set", "Disk_Sata_Set" + kvp.Key, "", Global.filePath);
                            Global.ResultPath = @"./Result.ini";

                            if (Global.Disk_Sata_Set == "")
                            {
                                lblHDDChanels.AppendText(strtxt + "_" + "Read Ini No Data,Fail" + "\r\n");
                                File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Read Ini No Data");
                                lblHDDChanels.AppendText("\r\n");
                                Global.End_result = "FAIL";
                            }
                            else
                            {
                                lblHDDChanels.AppendText(strtxt + "_" + "Read ini info : " + Global.Disk_Sata_Set + "\r\n");
                                File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Read ini info" + ": " + Global.Disk_Sata_Set);

                                if (Global.ResultString == Global.Disk_Sata_Set)
                                {
                                    lblHDDChanels.AppendText(strtxt + "_" + "Compare Result : " + "Disk(" + kvp.Key + ")," + "SATA(" + stringAfterChar + ")," + "PASS" + "\r\n");
                                    File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Compare Result" + ": " + "Disk(" + kvp.Key + ")," + "SATA(" + stringAfterChar + ")," + "PASS");

                                    if (Global.End_result == "FAIL")
                                    {
                                        Global.End_result = "FAIL";
                                    }
                                    else
                                    {
                                        Global.End_result = "PASS";
                                    }
                                }
                                else
                                {
                                    lblHDDChanels.AppendText(strtxt + "_" + "Compare Result : " + "Disk(" + kvp.Key + ")," + "SATA(" + stringAfterChar + ")," + "FAIL" + "\r\n");
                                    File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Compare Result" + ": " + "Disk(" + kvp.Key + ")," + "SATA(" + stringAfterChar + ")," + "FAIL");
                                    Global.End_result = "FAIL";
                                }
                            }
                        }
                        else
                        {
                            lblHDDChanels.AppendText(strtxt + "_" + "Get Other Info : " + "Disk(" + kvp.Key + ")," + kvp.Value.FriendlyName + "," + Global.Capacity + "\r\n");
                            File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "Get Other Info" + ": " + "Disk(" + kvp.Key + ")," + kvp.Value.FriendlyName + "," + Global.Capacity + "\r\n");
                        }

                        for (int i = 0; i < 12; i++)
                        {
                            if (Global.myArray[i] == Global.ResultString && Global.myArray[i] != "")
                            {
                                //myArray = myArray.Where((source, index) => index != i).ToArray();
                                Global.myArray[i] = "";
                            }
                        }
                    }
                }
                else
                {
                    lblHDDChanels.AppendText("SN Input value cannot be null" + "\r\n");
                    File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "SN Input value cannot be null" + "\r\n");
                    Global.End_result = "FAIL";
                }

                for (int i = 0; i < 12; i++)
                {
                    if (Global.myArray[i] != "" && Global.myArray[i] != null)
                    {
                        lblHDDChanels.AppendText(strtxt + "_" + "INI Check sys error : " + "Disk_Sata_Set" + i + "=" + Global.myArray[i] + "\r\n");
                        File.AppendAllText("./Test_Log\\" + "SataCheckTest.log", "\r\n" + TodyMillisecond + "：" + strtxt + "_" + "INI Check sys error " + ": " + "Disk_Sata_Set" + i + "=" + Global.myArray[i] + "\r\n");
                        Global.End_result = "FAIL";
                    }
                }

                if (Global.End_result == "FAIL")
                {
                    this.Output_result.Text = "FAIL"; //修改顯示
                    this.Output_result.BackColor = Color.FromArgb(255, 0, 0); //(R, G, B) (0, 0, 0 = black) ; 背景顏色
                    this.Output_result.ForeColor = Color.FromArgb(0, 0, 0); //(R, G, B) (0, 0, 0 = black) ; 字體顏色
                    INIHelper.Write("Response", "Result", "FAIL", Global.ResultPath);
                }
                else
                {
                    this.Output_result.Text = "PASS"; //修改顯示字
                    this.Output_result.BackColor = Color.FromArgb(0, 255, 0); //(R, G, B) (0, 0, 0 = black) ; 背景顏色
                    this.Output_result.ForeColor = Color.FromArgb(0, 0, 0); //(R, G, B) (0, 0, 0 = black) ; 字體顏色
                    INIHelper.Write("Response", "Result", "PASS", Global.ResultPath);
                }

                Global.filePath = @"./Setup.ini";
                Global.Tool_Set = INIHelper.Read("Tool_Set", "AutoClosed", "", Global.filePath);
                if (Global.Tool_Set == "1")
                {
                    this.Close();
                }
                if (Global.Tool_Set == "0")
                {
                    Thread.Sleep(10);
                }
            }
        }
    }

    public class PhysicalDiskStruct
    {
        public ulong AllocatedSize;//??
        public ushort BusType; //?
        public ushort[] CannotPoolReason; //??
        public bool CanPool;//??
        public string Description; //??
        public string DeviceId; //??
        public ushort EnclosureNumber; //??
        public string FirmwareVersion; //Disk FW Ver
        public string FriendlyName; //裝置名稱
        public ushort HealthStatus; //??
        public bool IsIndicationEnabled; //??
        public bool IsPartial; //??
        public bool IsPowerProtected; //??
        public bool IsWriteCacheEnabled; //??
        public ulong LogicalSectorSize; //??
        public ushort MediaType;  //??
        public string[] OperationalDetails;  //??
        public ushort[] OperationalStatus;  //??
        public string OtherCannotPoolReasonDescription;  //??
        public string PartNumber; //??
        public string PhysicalLocation; //ex: Integrated : Bus 0 : Device 23 : Function 0 : Adapter 0 : Port 1 (Port = SATA Port, 但USB都會是0)
        public ulong PhysicalSectorSize; //??
        public ulong Size; //??
        public ushort SlotNumber; //??
        public string SoftwareVersion; //?
        public uint SpindleSpeed; // 主軸轉速？？
        public ushort[] SupportedUsages; // ??
        public ushort UniqueIdFormat; // ??
        public ushort Usage; // ??
        public ushort VirtualDiskFootprint; // ??
    }
}
