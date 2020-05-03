using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartcart_1
{
    public partial class LoginChecker : Form
    {
        public LoginChecker()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
}
