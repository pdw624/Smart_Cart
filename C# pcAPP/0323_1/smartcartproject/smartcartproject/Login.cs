using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static smartcartproject.LoginChecker;

namespace smartcartproject
{
    public partial class Login : Form
    {
        public event EventHandler loginEventHandler;

        public Login()
        {
            InitializeComponent();
        }

        private bool ControlCheck()
        {
            if (String.IsNullOrEmpty(textUsername.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textUsername.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("비밀번호를 입력해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return false;
            }
            return true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(51, 153, 255);
            btnCancel.BackColor = Color.FromArgb(51, 153, 255);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginChecker.LoginHandler loginHandler = new LoginChecker.LoginHandler();
            if (ControlCheck())
            {
                if (loginHandler.LoginCheck(textUsername.Text, textPassword.Text))
                {
                    string userName = textUsername.Text;
                    loginEventHandler(userName);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("로그인 정보가 정확하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textUsername.Clear();
                    textPassword.Clear();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose(true);
            Application.Exit();
        }
    }
}
