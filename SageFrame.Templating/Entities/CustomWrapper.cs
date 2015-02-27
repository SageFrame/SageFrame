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

namespace SageFrame.Templating
{
    public class CustomWrapper
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Depth { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<string> LSTPositions { get; set; }
        public List<string> LSTExceptions { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }

        public CustomWrapper() { }
    }
}
