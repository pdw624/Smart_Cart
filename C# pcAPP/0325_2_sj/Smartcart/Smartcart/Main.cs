using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            FillComboPdName();

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
            //picBoxCheck2.Visible = true;
            dataGridView1.Visible = true;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");
            pictureBox2.BackColor = Color.FromArgb(234, 234, 234);

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;

           // this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            //오늘 날짜 
            int nowYear = DateTime.Now.Year; //오늘 년
            int nowMonth = DateTime.Now.Month; //오늘 월
            string nowWeek = DTPlast1.Value.ToString("dddd"); //오늘 요일
            int nowHour = DateTime.Now.Hour; //오늘 시
            int nowMinute = DateTime.Now.Minute; //오늘 분
            int firstDay = DateTime.Now.Day - 7; //일주일 전 날짜
            int lastDay = DateTime.Now.Day; //오늘 날짜
            //총매출액 그래프 날짜
            DTPfirst1.Value = new DateTime(nowYear, nowMonth, firstDay);
            DTPlast1.Value = new DateTime(nowYear, nowMonth, lastDay);
            //상품별 매출액 그래프 날짜
            DTPfirst2.Value = new DateTime(nowYear, nowMonth, firstDay);
            DTPlast2.Value = new DateTime(nowYear, nowMonth, lastDay);

            int firstyear = DTPfirst1.Value.Year;
            int firstmonth = DTPfirst1.Value.Month;
            int firstday = DTPfirst1.Value.Day;
            int lastyear = DTPlast1.Value.Year;
            int lastmonth = DTPlast1.Value.Month;
            int lastday = DTPlast1.Value.Day;

            //총매출액 그래프
            string Querysale = "  select date_format(buydate, '%m-%d') as date, sum(price) from `order` where buydate between date('" + firstyear + "-" + firstmonth + "-" + firstday + "') AND date('" + lastyear + "-" + lastmonth + "-" + lastday + "') group by buydate";
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            MySqlConnection consaleDB = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB = new MySqlCommand(Querysale, consaleDB);
            MySqlDataReader myreadersale;
            consaleDB.Open();
            myreadersale = cmdsaleDB.ExecuteReader();
            chartSum.Series.Clear();
            Series series = chartSum.Series.Add("price");
            try
            {
                while (myreadersale.Read())
                {                    
                    string date = myreadersale.GetString("date");
                    chartSum.Series["price"].Points.AddXY(date, myreadersale.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            consaleDB.Close();

            //실시간 시간
            LblNowDate.Text = "" + nowYear + "년 " + nowMonth + "월 " + lastDay + "일 " + nowWeek + " " + nowHour + "시 " + nowMinute + "분";

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

            dataGridView1.Columns["cartNumber"].HeaderText = "카트 번호";
            dataGridView1.Columns["cartName"].HeaderText = "카트 이름";
            dataGridView1.Columns["usingName"].HeaderText = "사용자 정보";
            
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //db 행 색깔,폰트 색깔
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();







        }

        //로그인 생성 시 메시지박스 띄우기
        private void LoginSuccess(string userName)
        {
            //MessageBox.Show(userName + "님이 로그인하셨습니다.");
            LblAdmin.Text = "안녕하세요 " + userName + "님";
        }

        //btn, lbl 등 visible 비활성화 함수
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
            btnMemDel.Visible = false;
            LblPdName.Visible = false;
            LblPdPrice.Visible = false;
            LblPdQuantity.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            textPdName.Visible = false;
            textPdPrice.Visible = false;
            textPdQuantity.Visible = false;
            cbBoxPdName.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            chartProd.Visible = false;
            chartSum.Visible = false;
            LblProductManagement.Visible = false;
            LblMemManagement.Visible = false;
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
           // picBoxCheck2.Visible = false;
            picBoxCheck3.Visible = false;
            picBoxCheck4.Visible = false;
            picBoxCheck5.Visible = false;
            picBoxCheck6.Visible = false;
            picBoxCheck8.Visible = false;
            picBoxCheck9.Visible = false;
            picBoxCheck7.Visible = false;
            picBoxCheck10.Visible = false;
            picBoxCheck11.Visible = false;
            picBoxCheck12.Visible = false;
            picBoxCheck13.Visible = false;
        }
        //실시간 정보 (카트 현황)
        private void btnCart_Click(object sender, EventArgs e)
        {
            SetDefaultImage();
            VisibleFalseLabel();
            Checkit();
            picBoxCheck1.Visible = true;
          //  picBoxCheck2.Visible = true;
            LblCart.Visible = true;
            LblCartInfo.Visible = true;
            LblUsingUser.Visible = true;
            LblLiveInfo.Visible = true;
            dataGridView1.Visible = true;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");

            //DataGridView1에 Cart 실시간 현황 테이블 생성
            string sql = "SELECT * FROM `cart`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            dataGridView1.ClearSelection();




        }
        //회원 관리
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
            dataGridView2.Visible = true;
            LblMemManagement.Visible = true;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");

            //DataGridView2에 사용자 테이블 생성
            string sql = "SELECT * FROM `user`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns["userID"].HeaderText = "아이디";
            dataGridView2.Columns["userPassword"].HeaderText = "비밀번호";
            dataGridView2.Columns["userName"].HeaderText = "이름";
            dataGridView2.Columns["userMail"].HeaderText = "이메일";
            dataGridView2.Columns["userPhone"].HeaderText = "핸드폰 번호";

            dataGridView2.ClearSelection();

        }
        //상품 관리
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
            LblProductManagement.Visible = true;
            dataGridView2.Visible = true;
            
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            //DataGridView2에 상품 관리 테이블 생성
            string sql = "SELECT * FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns["name"].HeaderText = "아이디";
            dataGridView2.Columns["price"].HeaderText = "가격";
            dataGridView2.Columns["quantity"].HeaderText = "수량";
            dataGridView2.Columns["barcod"].HeaderText = "바코드 번호";

            dataGridView2.ClearSelection();


        }
        //입고 내역
        private void btnInbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck10.Visible = true;
            LblInbound.Visible = true;
            LblPdInbound.Visible = true;
            LblPdInbound1.Visible = true;
            dataGridView2.Visible = true;
            btnInbound.BackgroundImage = Image.FromFile("menuIB2.jpg");

              //DataGridView2에 입고 내역 테이블 생성
            string sql = "SELECT * FROM `inbound`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns["product"].HeaderText = "상품명";
            dataGridView2.Columns["date"].HeaderText = "날짜";
            dataGridView2.Columns["quantity"].HeaderText = "수량";

            dataGridView2.ClearSelection();

        }
        //출고 내역
        private void btnOutbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck11.Visible = true;
            LblOutbound.Visible = true;
            LblPdOutbound.Visible = true;
            LblPdOutbound1.Visible = true;
            dataGridView2.Visible = true;
            btnOutbound.BackgroundImage = Image.FromFile("menuOB2.jpg");

            //DataGridView2에 출고 내역 테이블 생성
            string sql = "SELECT * FROM `order`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns["product"].HeaderText = "상품명";
            dataGridView2.Columns["orderID"].HeaderText = "주문자 ID";
            dataGridView2.Columns["price"].HeaderText = "가격";
            dataGridView2.Columns["buydate"].HeaderText = "구매날짜";

            dataGridView2.ClearSelection();


        }
        //통 계(그래프 차트)
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
            chartSum.Visible = true;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");

            //차트 만들기 해야함

        }
        //회원 삭제
        private void LblMemDel_Click(object sender, EventArgs e)
        {
            FillComboMemName();

            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            LblMemDel1.Visible = true;
            picBoxCheck4.Visible = true;
            btnMemDel.Visible = true;
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
            LblMemManagement.Visible = true;

            cbBoxMemName.SelectedIndex = -1;
            textMemID.Text = "";
            textMemPassword.Text = "";
            textMemPhone.Text = "";
            textMemMail.Text = "";
        }

        //상품 주문
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
            dataGridView3.Visible = true;
            LblPdName.Visible = true;
            LblPdQuantity.Visible = true;
            cbBoxPdName.Visible = true;
            textPdQuantity.Visible = true;
            btnPdOrder.Visible = true;
            LblProductManagement.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name, quantity FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            cbBoxPdName.SelectedIndex = -1;
            textPdQuantity.Text = "";


            dataGridView3.ClearSelection();
        }

        //상품 가격 수정
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
            LblPdName.Visible = true;
            LblPdPrice.Visible = true;
            textPdPrice.Visible = true;
            cbBoxPdName.Visible = true;
            picBoxCheck9.Visible = true;
            dataGridView3.Visible = true;
            btnPdMdfy.Visible = true;
            LblProductManagement.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name, price FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            cbBoxPdName.SelectedIndex = -1;
            textPdPrice.Text = "";

            dataGridView3.ClearSelection();
        }

        //상품 등록
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
            LblPdName.Visible = true;
            textPdName.Visible = true;
            LblPdPrice.Visible = true;
            textPdPrice.Visible = true;
            picBoxCheck7.Visible = true;
            dataGridView2.Visible = false;
            btnPdRegi.Visible = true;
            LblProductManagement.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            textPdName.Text = "";
            textPdPrice.Text = "";
        }
        //상품 삭제
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
            LblPdName.Visible = true;
            cbBoxPdName.Visible = true;
            picBoxCheck8.Visible = true;
            dataGridView3.Visible = true;
            btnPdDel.Visible = true;
            LblProductManagement.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            cbBoxPdName.SelectedIndex = -1;
            textPdPrice.Text = "";
        }
        //상품별 판매 그래프
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
            chartProd.Visible = true;

            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");
        }
        //콤보박스 DB 연결 함수(회원 이름)
        public void FillComboMemName()
        {
            string Cstring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string QueryMem = "SELECT userName FROM user";
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
            MemconDB.Close();            
        }
        //콤보박스 DB 연결 함수(상품 이름)
        public void FillComboPdName()
        {
            string Cstring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string QueryPd = "SELECT name FROM product";
            MySqlConnection PdconDB = new MySqlConnection(Cstring);
            MySqlCommand PdcmdDB = new MySqlCommand(QueryPd, PdconDB);
            MySqlDataReader myReader;
            try
            {
                PdconDB.Open();
                myReader = PdcmdDB.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("name");
                    cbBoxPdName.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PdconDB.Close();
        }
        //회원 삭제
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
            MemconDB2.Close();
            cbBoxMemName.SelectedIndex = -1;
            textMemID.Text = "";
            textMemPassword.Text = "";
            textMemPhone.Text = "";
            textMemMail.Text = "";
            MessageBox.Show("삭제되었습니다.", "관리자");
            
        }
        //콤보박스 선택 시(회원 이름)
        private void cbBoxMemName_SelectedValueChanged(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            string QueryMem1 = "SELECT * FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";
            MySqlConnection MemconDB1 = new MySqlConnection(constring);
            MySqlCommand MemcmdDB1 = new MySqlCommand(QueryMem1, MemconDB1);
            MySqlDataReader myReader1;
            MemconDB1.Open();
            myReader1 = MemcmdDB1.ExecuteReader();
            try
            {
                while(myReader1.Read())
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MemconDB1.Close();
        }
        //상품 주문 버튼
        private void btnPdOrder_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            string QueryPdOrder1 = "SELECT * FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            string sQuantity = null;
            string PdQuantity = null;
            MySqlConnection PdconDB1 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB1 = new MySqlCommand(QueryPdOrder1, PdconDB1);
            MySqlDataReader myreader1;
            try
            {
                PdconDB1.Open();
                myreader1 = PdcmdDB1.ExecuteReader();
                while(myreader1.Read())
                {
                    sQuantity = myreader1.GetString("quantity");
                    PdQuantity = textPdQuantity.Text;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + 11);
            }

            string QueryPdOrder2 = "UPDATE product SET quantity = " + (Convert.ToInt32(sQuantity) + Convert.ToInt32(PdQuantity)) + " WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            MySqlConnection PdconDB2 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB2 = new MySqlCommand(QueryPdOrder2, PdconDB2);
            MySqlDataReader myreader2;
            try
            {
                PdconDB2.Open();
                myreader2 = PdcmdDB2.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(QueryPdOrder2, PdconDB2);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + 33);
            }

            // 주문 시 입고내역 데이터베이스에 추가
            string QueryPdOrder3 = "INSERT INTO inbound (product, quantity, date) VALUES ('" + cbBoxPdName.SelectedItem + "', '" + PdQuantity + "', '" + "2020-03-17')";
            MySqlConnection PdconDB3 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB3 = new MySqlCommand(QueryPdOrder3, PdconDB3);
            MySqlDataReader myreader3;
            try
            {
                PdconDB3.Open();
                myreader3 = PdcmdDB3.ExecuteReader();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(QueryPdOrder3, PdconDB3);
                MySqlCommandBuilder builder1 = new MySqlCommandBuilder(adapter1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbBoxPdName.SelectedIndex = -1;
            textPdQuantity.Text = "";
            MessageBox.Show("주문되었습니다.", "관리자");
        }
        //상품 가격 수정 버튼
        private void btnPdMdfy_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; username=root; password=apmsetup; database=smartcart;";
            string QueryPdMdfy1 = "SELECT * FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            string PdPrice = null;
            MySqlConnection PdconDB1 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB1 = new MySqlCommand(QueryPdMdfy1, PdconDB1);
            MySqlDataReader myreader1;
            try
            {
                PdconDB1.Open();
                myreader1 = PdcmdDB1.ExecuteReader();
                while(myreader1.Read())
                {
                    PdPrice = textPdPrice.Text;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string QueryPdMdfy2 = "UPDATE product SET price = " + Convert.ToInt32(PdPrice) + " WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            MySqlConnection PdconDB2 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB2 = new MySqlCommand(QueryPdMdfy2, PdconDB2);
            MySqlDataReader myreader2;
            try
            {
                PdconDB2.Open();
                myreader2 = PdcmdDB2.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(QueryPdMdfy2, PdconDB2);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbBoxPdName.SelectedIndex = -1;
            textPdPrice.Text = "";

            MessageBox.Show("수정되었습니다.", "관리자");
        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            int firstyear = DTPfirst1.Value.Year;
            int firstmonth = DTPfirst1.Value.Month;
            int firstday = DTPfirst1.Value.Day;
            int lastyear = DTPlast1.Value.Year;
            int lastmonth = DTPlast1.Value.Month;
            int lastday = DTPlast1.Value.Day;

            string QueryCheck = "SELECT date_format(buydate, '%m-%d') AS date, sum(price) FROM `order` WHERE buydate BETWEEN date('" + firstyear + "-" + firstmonth + "-" + firstday + "') AND date('" + lastyear + "-" + lastmonth + "-" + lastday + "') GROUP BY buydate";
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(QueryCheck, conDB);
            MySqlDataReader myreader;
            conDB.Open();
            myreader = cmdDB.ExecuteReader();
            chartSum.Series.Clear();
            Series series = chartSum.Series.Add("price");
            try
            {
                while (myreader.Read())
                {
                    string date = myreader.GetString("date");
                    chartSum.Series["price"].Points.AddXY(date, myreader.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + 11);
            }
            conDB.Close();
        }

        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }
     
    }
}
