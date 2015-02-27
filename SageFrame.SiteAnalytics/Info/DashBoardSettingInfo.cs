using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DashBoardControl.Info
{
    public class DashBoardSettingInfo
    {

        public int DashBoardSettingID { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public int PortalID { get; set; }
        public int UserModuleID { get; set; }
        public int IsActive { get; set; }
        public string AddedBy { get; set; }
        public int Count { get; set; }
        public int RowNum { get; set; }

       

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SelectionType { get; set; }
        
        public string Country { get; set; }
        public string VisitTime { get; set; }
        public string Browser { get; set; }
        public string VisitPage { get; set; }

        public string VisitedDate { get; set; }
        public string VisitCount { get; set; }

        public string RefPage { get; set; }

        public string VistPageWithoutExtension
        {
            get
            {
                return Path.GetFileNameWithoutExtension(VisitPage);
            }
        }
        public string SessionUserHostAddress { get; set; }
       

        public DashBoardSettingInfo() { }
        public DashBoardSettingInfo(string _SettingKey, string _SettingValue)
        {
            this.SettingKey = _SettingKey;
            this.SettingValue = _SettingValue;
        }

        public DashBoardSettingInfo(string StartDate, string EndDate, string SelectionType)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.SelectionType = SelectionType;
        }
    
    }
}
