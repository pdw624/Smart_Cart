using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartcartproject
{
    class LoginChecker
    {
    }

    public class LoginHandler
    {
        public bool LoginCheck(string id, string password)
        {
            if (id.Equals("admin") && password.Equals("1234"))
            {
                return true;
            }
            else if (id.Equals("admin1") && password.Equals("1234"))
            {
                return true;
            }

            return false;
        }
    }
}
