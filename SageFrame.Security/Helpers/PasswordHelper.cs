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
using SageFrame.Security.Crypto;
using SageFrame.Security.Enums;
#endregion

namespace SageFrame.Security.Helpers
{
    public class PasswordHelper
    {
        public static bool ValidateUser(int PasswordFormat,string passwordText, string passwordHash, string passwordSalt)
        {
            Crypto.Crypto c = new SageFrame.Security.Crypto.Crypto();
            bool verificationStatus = false;
            switch (PasswordFormat)
            {
                case (int)PasswordFormats.CLEAR:
                case (int)PasswordFormats.ONE_WAY_HASHED:
                    verificationStatus = c.VerifyHashString(passwordText, passwordHash, passwordSalt);
                    break;
                case (int)PasswordFormats.ENCRYPTED_AES:                                 
                    verificationStatus = Crypto.Crypto.Decrypt(passwordHash) == passwordText ? true : false;
                    break;
                case (int)PasswordFormats.ENCRYPTED_RSA:
                    break;

            }
            return verificationStatus;

        }

        public static void EnforcePasswordSecurity(int PasswordFormat, string data, out string PassWord, out string PasswordSalt)
        {
            Crypto.Crypto cryptObj = new Crypto.Crypto();
            string _Password="", _Salt="";
            switch (PasswordFormat)
            {
                case (int)PasswordFormats.CLEAR:
                case (int)PasswordFormats.ONE_WAY_HASHED:
                    cryptObj.GetHashAndSaltString(data, out _Password, out _Salt);
                    break;
                case (int)PasswordFormats.ENCRYPTED_AES:                   
                    _Password = Crypto.Crypto.Encrypt(data);
                    _Salt = "";
                    break;
                case (int)PasswordFormats.ENCRYPTED_RSA:
                    break;                

            }
            PassWord = _Password;
            PasswordSalt = _Salt;
        }
    }
}
