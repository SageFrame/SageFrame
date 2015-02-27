using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SageFrame.NewsLetter
{
   public  class NL_Info
    {
       public int SubscriberID
       {
           get;
           set;
       }
       public string SubscriberEmail
       {
           get;
           set;
       }
       public bool IsSubscribed
       {
           get;
           set;
       }
       public string ClientIP
       {
           get;
           set;
       }
       public DateTime AddedOn
       {
           get;
           set;
       }
       public string AddedBy
       {
           get;
           set;
       }
       public int UserModuleID
       {
           get;
           set;
       }
       public int PortalID
       {
           get;
           set;
       }
       public int EmailCount
       {
           get;
           set;

       }

    }
}
