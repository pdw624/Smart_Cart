using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace smartcart_1
{
    public partial class MemberDelete : Form
    {

        //콤보박스
        public void FillComboName()
        {
            string MemCstr = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query = "select userName from user";
            MySqlConnection MemconDB = new MySqlConnection(MemCstr);
            MySqlCommand MemcmdDB= new MySqlCommand(Query, MemconDB);
            MySqlDataReader myReader;
            try
            {
                MemconDB.Open();
                myReader = MemcmdDB.ExecuteReader();
                while (myReader.Read()) 
                {
                    string sName = myReader.GetString("userName");
                    cbBoxMemName.Items.Add(sName);                                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MemconDB.Close();
        }

        public MemberDelete()
        {
            InitializeComponent();
            FillComboName();
        }

        private void MemberModify_Load(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(51, 153, 255);
            btnDelete.BackColor = Color.FromArgb(51, 153, 255);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query2 = "DELETE FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";

            MySqlConnection conDataBase2 = new MySqlConnection(constring);
            MySqlCommand cmdDatabase2 = new MySqlCommand(Query2, conDataBase2);
            MySqlDataReader myReader2;
            try
            {
                conDataBase2.Open();
                myReader2 = cmdDatabase2.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query2, conDataBase2);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDataBase2.Close();
            MessageBox.Show("삭제되었습니다.", "관리자");
            Dispose(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소되었습니다.", "관리자");
            Dispose(true);
        }

        private void cbBoxMemName_SelectedValueChanged(object sender, EventArgs e)
        {
            string MemCstr = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query1 = "SELECT * FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";
            MySqlConnection MemconDB1 = new MySqlConnection(MemCstr);
            MySqlCommand MemcmdDB1 = new MySqlCommand(Query1, MemconDB1);
            MySqlDataReader myReader1;

            MemconDB1.Open();
            myReader1 = MemcmdDB1.ExecuteReader();

            while(myReader1.Read())
            {
                string sID = myReader1.GetString("userID");
                string sPassword = myReader1.GetString("userPassword");
                string sName = myReader1.GetString("userName");
                string sMail = myReader1.GetString("userMail");
                string sPhone = myReader1.GetString("userPhone");

                textMemInfo.Text = "아이디 : " + sID + "\r\n비밀번호 : " + sPassword + "\r\n이름 : " + sName + "\r\n이메일 : " + sMail + "\r\n폰넘버 : " + sPhone;
            }
            MemconDB1.Close();
        }
    }
}
