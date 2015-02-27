using System;
using System.Collections.Generic;
using System.Text;

namespace DashBoardControl
{
    public class DashBoardInfo
    {
        public string Browser { get; set; }
        public string VisitTime { get; set; }
        public string VisitPage { get; set; }
        public string  SessionUserHostAddress { get; set; }
        public string Country { get; set; }

        public DashBoardInfo() { }
    }
}
