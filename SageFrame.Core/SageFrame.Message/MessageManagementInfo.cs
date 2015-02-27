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

namespace SageFrame.Message
{
    public class MessageManagementInfo
    {
        public int MessageTemplateTypeID { get; set; }
        public int MessageTemplateID { get; set; }
        public string Name { get; set; }
        public string CultureName { get; set; }
        public string Subject { get; set; }
        public string MailFrom { get; set; }
        public string Body { get; set; }


        public int MessageTemplateTypeTokenID { get; set; }
        public int MessageTokenID { get; set; }

        public string MessageTokenKey { get; set; }
        public string MessageTokenName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int PortalID { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        
		
        public MessageManagementInfo() { }
    }
}
