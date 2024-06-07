using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Exceptions.Auth
{
    public static class AuthExceptions
    {
        public const string EMS01 = "Email/Password is wrong.";
        public const string EMS02 = "Email isn't existed in the system.";
        public const string EMS03 = "OTP is not correct.";
    }
}
