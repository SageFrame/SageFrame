/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace SageFrame.Dashboard
{
    public class DashboardQuickInfo
    {
        public List<QuickLink> LSTQuickLinks { get; set; }
        public List<Sidebar> LSTSidebar { get; set; }
        public string BreadCrumb { get; set; }

        public DashboardQuickInfo() { }
    }
}
