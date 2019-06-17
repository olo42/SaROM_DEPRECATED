using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaROM.BL
{
    public class LoginManager
    {
        public bool IsValidLogin(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("secure"))
            {
                return true;
            }

            return false;
        }
    }
}
