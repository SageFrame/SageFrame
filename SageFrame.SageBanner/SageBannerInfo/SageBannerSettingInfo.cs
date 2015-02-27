/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.SageBannner.SettingInfo
{
    public class SageBannerSettingInfo
    {
        //public SageBannerSettingInfo();
       // public SageBannerSettingInfo(string _Auto_Direction, bool _Auto_Hover, bool _Auto_Slide, bool _Caption, int _DisplaySlideQty, string _Easing, bool _InfiniteLoop, int _MoveSlideQty, bool _navigationImagePager, int _Pause_Time, bool _RandomStart, int _Speed, int _Starting_Slide, string _TransitionMode, bool _numericPager, string _bannerToUse);

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
    }
}

