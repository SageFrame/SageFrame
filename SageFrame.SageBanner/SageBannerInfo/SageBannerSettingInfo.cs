#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace SageFrame.SageBannner.SettingInfo
{
    public class SageBannerSettingInfo
    {
        public string Auto_Direction { get; set; }
        public bool Auto_Hover { get; set; }
        public bool Auto_Slide { get; set; }
        public string BannerToUse { get; set; }
        public bool Caption { get; set; }
        public int DisplaySlideQty { get; set; }
        public string Easing { get; set; }
        public bool InfiniteLoop { get; set; }
        public List<SageBannerSettingInfo> ListSage { get; set; }
        public int MoveSlideQty { get; set; }
        public bool NavigationImagePager { get; set; }
        public bool NumericPager { get; set; }
        public int Pause_Time { get; set; }
        public bool RandomStart { get; set; }
        public int Speed { get; set; }
        public int Starting_Slide { get; set; }
        public string TransitionMode { get; set; }
        public bool EnableControl { get; set; }
        public SageBannerSettingInfo() { }
    }
}

