using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartcart
{
    public partial class Main : Form
    {
        Login loginForm;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //로그인 창 띄우기
            loginForm = new Login();
            loginForm.loginEventHandler += new EventHandler(LoginSuccess);
            switch (loginForm.ShowDialog())
            {
                case DialogResult.OK:
                    loginForm.Close();
                    break;
                case DialogResult.Cancel:
                    Dispose();
                    break;
            }
        }

        //로그인 생성 시 메시지박스 띄우기
        private void LoginSuccess(string userName)
        {
            //MessageBox.Show(userName + "님이 로그인하셨습니다.");
            //LblAdmin.Text = userName + "님 안녕하세요";
        }
    }
}
