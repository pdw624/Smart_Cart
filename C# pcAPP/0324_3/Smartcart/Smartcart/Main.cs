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

namespace Smartcart
{
    public partial class Main : Form
    {
        Login loginForm;
        Con_datatable db;

        public Main()
        {
            InitializeComponent();           
            db = new Con_datatable();
            db.ConnectDB();
            FillComboName();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Checkit();
            VisibleFalseLabel();
            LblCart.Visible = true;
            LblCartInfo.Visible = true;
            LblLiveInfo.Visible = true;
            LblUsingUser.Visible = true;
            picBoxCheck1.Visible = true;
            picBoxCheck2.Visible = true;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");
            pictureBox2.BackColor = Color.FromArgb(234, 234, 234);

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

            //DataGridView1에 Cart 실시간 현황 테이블 생성
            string sql = "SELECT * FROM `cart`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;
        }

        //로그인 생성 시 메시지박스 띄우기
        private void LoginSuccess(string userName)
        {
            //MessageBox.Show(userName + "님이 로그인하셨습니다.");
            //LblAdmin.Text = userName + "님 안녕하세요";
        }

        //Label visible 비활성화 함수
        private void VisibleFalseLabel()
        {
            LblCart.Visible = false;
            LblCartInfo.Visible = false;
            LblUsingUser.Visible = false;
            LblLiveInfo.Visible = false;
            LblMember.Visible = false;
            LblMemDel.Visible = false;
            LblProduct.Visible = false;
            LblPdOrder.Visible = false;
            LblPdRegi.Visible = false;
            LblPdDel.Visible = false;
            LblPriceMdfy.Visible = false;
            LblOutbound.Visible = false;
            LblPdOutbound.Visible = false;
            LblInbound.Visible = false;
            LblPdInbound.Visible = false;
            LblChart.Visible = false;
            LblProdChart.Visible = false;
            LblSaleChart.Visible = false;
            Lblmember1.Visible = false;
            LblMemDel1.Visible = false;
            LblProduct1.Visible = false;
            LblPdOrder1.Visible = false;
            LblPdRegi1.Visible = false;
            LblPdDel1.Visible = false;
            LblPriceMdfy1.Visible = false;
            LblPdOutbound1.Visible = false;
            LblPdInbound1.Visible = false;
            LblProdChart1.Visible = false;
            LblSaleChart1.Visible = false;
            LblMemName.Visible = false;
            LblMemPassword.Visible = false;
            LblMemID.Visible = false;
            LblMemPhone.Visible = false;
            LblMemMail.Visible = false;
            cbBoxMemName.Visible = false;
            textMemID.Visible = false;
            textMemMail.Visible = false;
            textMemPhone.Visible = false;
            textMemPassword.Visible = false;
            pictureBox4.Visible = false;
            LblMemManage.Visible = false;

        }

        //메인 메뉴 버튼 기본이미지로 색깔 초기화
        private void SetDefaultImage()
        {
            btnCart.BackgroundImage = Image.FromFile("menuCart1.jpg");
            btnMember.BackgroundImage = Image.FromFile("menuMem1.jpg");
            btnProduct.BackgroundImage = Image.FromFile("menuProduct1.jpg");
            btnInbound.BackgroundImage = Image.FromFile("menuIB1.jpg");
            btnOutbound.BackgroundImage = Image.FromFile("menuOB1.jpg");
            btnChart.BackgroundImage = Image.FromFile("menuChart1.jpg");
        }

        //체크 pictureBox 전부 비활성화 함수
        private void Checkit()
        {
            picBoxCheck1.Visible = false;
            picBoxCheck2.Visible = false;
            picBoxCheck3.Visible = false;
            picBoxCheck4.Visible = false;
            picBoxCheck5.Visible = false;
            picBoxCheck6.Visible = false;
            picBoxCheck7.Visible = false;
            picBoxCheck8.Visible = false;
            picBoxCheck9.Visible = false;
            picBoxCheck10.Visible = false;
            picBoxCheck11.Visible = false;
            picBoxCheck12.Visible = false;
            picBoxCheck13.Visible = false;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            SetDefaultImage();
            VisibleFalseLabel();
            Checkit();
            picBoxCheck1.Visible = true;
            picBoxCheck2.Visible = true;
            LblCart.Visible = true;
            LblCartInfo.Visible = true;
            LblUsingUser.Visible = true;
            LblLiveInfo.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");            

            //DataGridView1에 Cart 실시간 현황 테이블 생성
            string sql = "SELECT * FROM `cart`";
            DataTable dt = db.GetDBTable(sql);

            //헤더 텍스트 가운데 정렬
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //데이터 출력 셀 가운데 정렬
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //행, 열 색깔 바꾸기
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            
        
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
           // dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;








        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck3.Visible = true;
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            Lblmember1.Visible = true;
            LblMemDel1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");
            LblMemManage.Visible = true;
            //DataGridView2에 사용자 테이블 생성
            string sql = "SELECT * FROM `user`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck5.Visible = true;
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdRegi.Visible = true;
            LblPdDel.Visible = true;
            LblPriceMdfy.Visible = true;
            LblProduct1.Visible = true;
            LblPdOrder1.Visible = true;
            LblPdRegi1.Visible = true;
            LblPdDel1.Visible = true;
            LblPriceMdfy1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            //DataGridView2에 상품 관리 테이블 생성
            string sql = "SELECT * FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void btnInbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck10.Visible = true;
            LblInbound.Visible = true;
            LblPdInbound.Visible = true;
            LblPdInbound1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnInbound.BackgroundImage = Image.FromFile("menuIB2.jpg");

              //DataGridView2에 입고 내역 테이블 생성
            string sql = "SELECT * FROM `inbound`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void btnOutbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck11.Visible = true;
            LblOutbound.Visible = true;
            LblPdOutbound.Visible = true;
            LblPdOutbound1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnOutbound.BackgroundImage = Image.FromFile("menuOB2.jpg");

            //DataGridView2에 출고 내역 테이블 생성
            string sql = "SELECT * FROM `order`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck12.Visible = true;
            LblChart.Visible = true;
            LblProdChart.Visible = true;
            LblSaleChart.Visible = true;
            LblSaleChart1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");

        }

        private void LblMemDel_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            LblMemDel1.Visible = true;
            picBoxCheck4.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");

            LblMemName.Visible = true;
            LblMemPassword.Visible = true;
            LblMemID.Visible = true;
            LblMemPhone.Visible = true;
            LblMemMail.Visible = true;
            cbBoxMemName.Visible = true;
            textMemID.Visible = true;
            textMemMail.Visible = true;
            textMemPhone.Visible = true;
            textMemPassword.Visible = true;
            pictureBox4.Visible = true;
            LblMemManage.Visible = true;
        }

        private void LblPdOrder_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdOrder1.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck6.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        private void LblPriceMdfy_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            LblPriceMdfy1.Visible = true;
            picBoxCheck7.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        private void LblPdRegi_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPdRegi1.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck8.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        private void LblPdDel_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdDel1.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck9.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        private void LblProdChart_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblChart.Visible = true;
            LblSaleChart.Visible = true;
            LblProdChart.Visible = true;
            LblProdChart1.Visible = true;
            picBoxCheck13.Visible = true;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");
        }

        //콤보박스 DB 연결 함수
        public void FillComboName()
        {
            string Cstring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string QueryMem = "SELECT userName from user";
            MySqlConnection MemconDB = new MySqlConnection(Cstring);
            MySqlCommand MemcmdDB = new MySqlCommand(QueryMem, MemconDB);
            MySqlDataReader myReader;
            try
            {
                MemconDB.Open();
                myReader = MemcmdDB.ExecuteReader();
                while(myReader.Read())
                {
                    string sName = myReader.GetString("userName");
                    cbBoxMemName.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string QueryMem1 = "SELECT * FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";
            MySqlConnection MemconDB1 = new MySqlConnection(Cstring);
            MySqlCommand MemcmdDB1 = new MySqlCommand(QueryMem1, MemconDB1);
            MySqlDataReader myReader1;           
            try
            {
                MemconDB1.Open();
                myReader1 = MemcmdDB1.ExecuteReader();

                string sID = myReader1.GetString("userID");
                string sPassword = myReader1.GetString("userPassword");
                string sName = myReader1.GetString("userName");
                string sMail = myReader1.GetString("userMail");
                string sPhone = myReader1.GetString("userPhone");

                textMemID.Text = sID;
                textMemPassword.Text = sPassword;
                textMemMail.Text = sMail;
                textMemPhone.Text = sPhone;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + 11);
            }
        }

        private void btnMemDel_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            string QueryMemDel = "DELETE FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";

            MySqlConnection MemconDB2 = new MySqlConnection(constring);
            MySqlCommand MemcmdDB2 = new MySqlCommand(QueryMemDel, MemconDB2);
            MySqlDataReader myReader2;
            try
            {
                MemconDB2.Open();
                myReader2 = MemcmdDB2.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(QueryMemDel, MemconDB2);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LblUsingUser_Click(object sender, EventArgs e)
        {

        }

        private void picBoxCheck1_Click(object sender, EventArgs e)
        {

        }

        private void LblCart_Click(object sender, EventArgs e)
        {

        }

        private void picBoxCheck4_Click(object sender, EventArgs e)
        {

        }

        private void picBoxCheck2_Click(object sender, EventArgs e)
        {

        }

        private void LblNowDate_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
