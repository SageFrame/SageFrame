/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace SageFrame.Dashboard
{
    public class CountUserInfo
    {

        public int AnonymousUser { get; set; }
        public int LoginUser { get; set; }
        public int PageCount { get; set; }
        public int UserCount { get; set; }
        public CountUserInfo() { }
    }
}
