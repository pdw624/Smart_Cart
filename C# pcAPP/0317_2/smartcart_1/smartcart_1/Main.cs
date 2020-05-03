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

    public partial class Main : Form
    {
        
        Con_database db;

        Login loginForm;

        public Main()
        {
            InitializeComponent();
            db = new Con_database();
            db.ConnectDB();
            
        }
        //처음 시작할때 띄우는 폼 로드
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            //첫 화면 배경색 지정
            btnLogout.BackColor = Color.FromArgb(64, 64, 64);
            label1.BackColor = Color.FromArgb(64, 64, 64);
            btnPdOrder.BackColor = Color.FromArgb(51, 153, 255);
            btnPdMdfy.BackColor = Color.FromArgb(51, 153, 255);
            btnPdDel.BackColor = Color.FromArgb(51, 153, 255);
            btnPdRegi.BackColor = Color.FromArgb(51, 153, 255);
            btnMemDel.BackColor = Color.FromArgb(51, 153, 255);
            btnSalesChart.BackColor = Color.FromArgb(51, 153, 255);
            btnPdChart.BackColor = Color.FromArgb(51, 153, 255);

            //로그인창 띄우기
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
            
            //데이터그리드뷰에 테이블 생성 (카트 실시간 현황)
            string sql = "SELECT * FROM cart";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            //상품판매액
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query = "select product, sum(price) from `order` group by product";
            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(Query, conDB);
            MySqlDataReader myreader;
            try
            {
                conDB.Open();
                myreader = cmdDB.ExecuteReader();

                while (myreader.Read())
                {
                    this.chartSales2.Series["price"].Points.AddXY(myreader.GetString("product"), myreader.GetInt32("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //버튼 배경색 지정
            btnCart.BackColor = Color.FromArgb(255, 192, 192);
            btnProduct.BackColor = Color.FromArgb(51, 153, 255);
            btnMember.BackColor = Color.FromArgb(51, 153, 255);
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255);            
        }

        //로그인 생성 시 메시지박스 띄우기
        private void LoginSuccess(string userName)
        {
            MessageBox.Show(userName + "님이 로그인하셨습니다.");
            LblLogname.Text = userName + "님";
        }
        //카트 실시간 현황 버튼
        private void btnCart_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            string sql = "SELECT * FROM cart";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            chartSales.Visible = false;
            chartSales2.Visible = false;

            btnCart.BackColor = Color.FromArgb(255, 192, 192);            
            btnProduct.BackColor = Color.FromArgb(51, 153, 255);
            btnMember.BackColor = Color.FromArgb(51, 153, 255);
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255);

            btnMemDel.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnPdChart.Visible = false;
            btnSalesChart.Visible = false;
        }
        //회원 관리 버튼
        private void btnMember_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            string sql = "SELECT * FROM user";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            chartSales.Visible = false;
            chartSales2.Visible = false;

            btnMember.BackColor = Color.FromArgb(255, 192, 192);
            btnProduct.BackColor = Color.FromArgb(51, 153, 255); 
            btnCart.BackColor = Color.FromArgb(51, 153, 255); 
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255); 

            btnMemDel.Visible = true;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnPdChart.Visible = false;
            btnSalesChart.Visible = false;
        }

        //상품 관리 버튼
        private void btnProduct_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            string sql = "SELECT * FROM product";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            chartSales.Visible = false;
            chartSales2.Visible = false;

            btnProduct.BackColor = Color.FromArgb(255, 192, 192);
            btnMember.BackColor = Color.FromArgb(51, 153, 255);
            btnCart.BackColor = Color.FromArgb(51, 153, 255); 
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255);

            btnPdOrder.Visible = true;
            btnPdMdfy.Visible = true;
            btnPdDel.Visible = true;
            btnPdRegi.Visible = true;
            btnMemDel.Visible = false;
            btnPdChart.Visible = false;
            btnSalesChart.Visible = false;
        }

        //매출 그래프 버튼 
        private void btnSales_Click(object sender, EventArgs e)
        {       
            dataGridView1.Visible = false;
            chartSales2.Visible = false;
            chartSales.Visible = true;

            btnSales.BackColor = Color.FromArgb(255, 192, 192);
            btnProduct.BackColor = Color.FromArgb(51, 153, 255);
            btnMember.BackColor = Color.FromArgb(51, 153, 255); 
            btnCart.BackColor = Color.FromArgb(51, 153, 255); 
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);

            btnMemDel.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnPdChart.Visible = true;
            btnSalesChart.Visible = true;
        }
        
        private void chartSales_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //총매출액 그래프 버튼
        private void btnSalesChart_Click(object sender, EventArgs e)
        {
            chartSales.Visible = true;
            chartSales2.Visible = false; ;
        }

        //상품별 판매 그래프 버튼
        private void btnPdChart_Click(object sender, EventArgs e)
        {
            

            chartSales.Visible = false;
            chartSales2.Visible = true;


        }

        //로그아웃 버튼
        private void btnLogout_Click(object sender, EventArgs e)
        {
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
               
        private void LblLogname_Click(object sender, EventArgs e)
        {
        }

        //상품주문 버튼
        private void btnPdOrder_Click(object sender, EventArgs e)
        {

            ProductOrder f = new ProductOrder();
            DialogResult = DialogResult.OK;
            f.Show();
        }

        //상품수정 버튼
        private void btnPdMdfy_Click(object sender, EventArgs e)
        {
            ProductModify f = new ProductModify();
            DialogResult = DialogResult.OK;
            f.Show();
        }

        //상품삭제 버튼
        private void btnPdDel_Click(object sender, EventArgs e)
        {
            textPdDelete f = new textPdDelete();
            DialogResult = DialogResult.OK;
            f.Show();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        //회원삭제 버튼
        private void btnMemDel_Click(object sender, EventArgs e)
        {
            MemberDelete f = new MemberDelete();
            DialogResult = DialogResult.OK;
            f.Show();
        }
        //출고내역 버튼
        private void btnOB_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            string sql = "select * from `order`";
            DataTable dt = db.GetDBTable(sql);

            dataGridView1.DataSource = dt;            
            
            btnOB.BackColor = Color.FromArgb(255, 192, 192);
            btnIB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255);
            btnProduct.BackColor = Color.FromArgb(51, 153, 255);
            btnMember.BackColor = Color.FromArgb(51, 153, 255);
            btnCart.BackColor = Color.FromArgb(51, 153, 255);                    

            btnMemDel.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnPdChart.Visible = false;
            btnSalesChart.Visible = false;

            chartSales.Visible = false;
            chartSales2.Visible = false;
        }
        //입고내역 버튼
        private void btnIB_Click(object sender, EventArgs e)
        {
            string sql = "select * from `inbound`";
            DataTable dt = db.GetDBTable(sql);

            dataGridView1.DataSource = dt;

            btnIB.BackColor = Color.FromArgb(255, 192, 192);
            btnOB.BackColor = Color.FromArgb(51, 153, 255);
            btnSales.BackColor = Color.FromArgb(51, 153, 255);
            btnProduct.BackColor = Color.FromArgb(51, 153, 255);
            btnMember.BackColor = Color.FromArgb(51, 153, 255);
            btnCart.BackColor = Color.FromArgb(51, 153, 255);

            btnMemDel.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnPdChart.Visible = false;
            btnSalesChart.Visible = false;

            chartSales.Visible = false;
            chartSales2.Visible = false;
            dataGridView1.Visible = true;
        }

        private void btnPdRegi_Click(object sender, EventArgs e)
        {
            ProductRegister f = new ProductRegister();
            DialogResult = DialogResult.OK;
            f.Show();
        }
    }
}
