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

namespace SageFrame.UserManagement
{
    public class ForgetPasswordInfo
    {
        public int MessageTemplateID{get;set;}
		public int MessageTemplateTypeID{get;set;}
		public string Subject{get;set;}
		public string Body{get;set;}
		public string MailFrom{get;set;}
		public bool IsActive{get;set;}
		public bool IsDeleted{get;set;}
		public bool IsModified{get;set;}
		public DateTime AddedOn{get;set;}
		public DateTime UpdatedOn{get;set;}
		public DateTime DeletedOn{get;set;}
		public int PortalID{get;set;}
		public string AddedBy{get;set;}
		public string UpdatedBy{get;set;}
		public string DeletedBy{get;set;}

        public Guid _UserActivationCode_ { get; set; }
        public string _Username_ { get; set; }
        public string _UserFirstName_ { get; set; }
        public string _UserLastName_ { get; set; }
        public string _UserEmail_ { get; set; }


        public Guid Code { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string CodeForPurpose { get; set; }
        public string CodeForUsername { get; set; }


          public bool IsAlreadyUsed { get; set; }

        public ForgetPasswordInfo(){}
      
		
    }
}
