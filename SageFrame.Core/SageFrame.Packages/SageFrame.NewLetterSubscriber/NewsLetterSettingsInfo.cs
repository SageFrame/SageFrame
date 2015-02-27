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


namespace SageFrame.NewLetterSubscriber
{
    public class NewsLetterSettingsInfo
    {
        #region Constructor
        public NewsLetterSettingsInfo()
        {
        }
        #endregion

        #region "Private Members"
        private string _submitButtonText = string.Empty;
        private string _subscriptionHelpText = string.Empty;
        private string _subscriptionModuleTitle= string.Empty;
        private string _subscriptionType = string.Empty;
        private string _textBoxWaterMarkText = string.Empty;
        #endregion

        #region "Public Properties"
        public string SubmitButtonText
        {
            get { return _submitButtonText; }
            set { _submitButtonText = value; }
        }

        public string SubscriptionHelpText
        {
            get { return _subscriptionHelpText; }
            set { _subscriptionHelpText = value; }
        }

        public string SubscriptionModuleTitle
        {
            get { return _subscriptionModuleTitle; }
            set { _subscriptionModuleTitle = value; }
        }

        public string SubscriptionType
        {
            get { return _subscriptionType; }
            set { _subscriptionType = value; }
        }

        public string TextBoxWaterMarkText
        {
            get { return _textBoxWaterMarkText; }
            set { _textBoxWaterMarkText = value; }
        }
        #endregion        
    }
}
