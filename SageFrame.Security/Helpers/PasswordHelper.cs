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
using SageFrame.Security.Crypto;
using SageFrame.Security.Enums;

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
