using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;


namespace Smartcart
{
    public partial class Main : Form
    {
        Thread _thread = null;
        Login loginForm;
        Con_datatable db;        

        public Main()
        {
            InitializeComponent();           
            db = new Con_datatable();
            db.ConnectDB();
            
            //PrivateFontCollection privatieFonts = new PrivateFontCollection();
            //privatieFonts.AddFontFile("NanumSquareRoundR.ttf");

            ////24f는 출력될 폰트 사이즈
            //Font font = new Font(privatieFonts.Families[0], 11f);

            //btnCheck1.Font = font;
            //btnCheck2.Font = font;
            //LblNowDate.Font = font;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.White;

            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();

            this.MaximizeBox = false;
        }
        //스레드 시작 함수
        public void fThreadStart()
        {
            _thread = new Thread(Run);

            _thread.Start();
        }
        //스레드 함수
        private void Run()
        {
            try
            {
                while (true)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            int nowYear = DateTime.Now.Year; //오늘 년
                            int nowMonth = DateTime.Now.Month; //오늘 월
                            string nowWeek = DTPlast1.Value.ToString("dddd"); //오늘 요일
                            int nowHour = DateTime.Now.Hour; //오늘 시
                            int nowMinute = DateTime.Now.Minute; //오늘 분
                            int lastDay = DateTime.Now.Day; //오늘 날짜
                            //실시간 시간
                            LblNowDate.Text = "" + nowYear + "년 " + nowMonth + "월 " + lastDay + "일 " + nowWeek + " " + nowHour + "시 " + nowMinute + "분";

                            string sql = "SELECT * FROM cart";
                            DataTable dt = db.GetDBTable(sql);
                            dataGridView1.DataSource = dt;

                            this.Refresh();
                        }));
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //스레드 강제 종료 함수
        public void ThreadAbort()
        {
            if (_thread.IsAlive)
            {
                _thread.Abort();
            }
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
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //쓰레드 시작
            fThreadStart();

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

            int firstyear1 = DTPfirst1.Value.Year;
            int firstmonth1 = DTPfirst1.Value.Month;
            int firstday1 = DTPfirst1.Value.Day;
            int lastyear1 = DTPlast1.Value.Year;
            int lastmonth1 = DTPlast1.Value.Month;
            int lastday1 = DTPlast1.Value.Day;
            int firstyear2 = DTPfirst2.Value.Year;
            int firstmonth2 = DTPfirst2.Value.Month;
            int firstday2 = DTPfirst2.Value.Day;
            int lastyear2 = DTPlast2.Value.Year;
            int lastmonth2 = DTPlast2.Value.Month;
            int lastday2 = DTPlast2.Value.Day;

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
            LblMemManagement.Visible = false;
            LblProductManagement.Visible = false;
            LblPdName.Visible = false;
            LblPdPrice.Visible = false;
            LblPdQuantity.Visible = false;
            LblDateBetween.Visible = false;
            LblMemOB.Visible = false;
            LblMemOB1.Visible = false;
            LblMemID1.Visible = false;
            LblBuydateOB.Visible = false;
            LblBuydateOB1.Visible = false;
            LblBuydate1.Visible = false;
            LblDateIB.Visible = false;
            LblDateIB1.Visible = false;
            LblPdMenu.Visible = false;
            LblDate1.Visible = false;
            LblPdIB.Visible = false;
            LblPdIB1.Visible = false;
            LblMonthChart.Visible = false;
            LblMonthChart1.Visible = false;
            btnMemDel.Visible = false;
            btnPdOrder.Visible = false;
            btnPdMdfy.Visible = false;
            btnPdDel.Visible = false;
            btnPdRegi.Visible = false;
            btnCheck1.Visible = false;
            btnCheck2.Visible = false;            
            textMemID.Visible = false;
            textMemMail.Visible = false;
            textMemPhone.Visible = false;
            textMemPassword.Visible = false;
            textPdName.Visible = false;
            textPdPrice.Visible = false;
            textPdQuantity.Visible = false;
            cbBoxMemName.Visible = false;
            cbBoxPdName.Visible = false;
            cbBoxMemID.Visible = false;
            cbBoxProduct.Visible = false;
            cbBoxBuydate.Visible = false;
            cbBoxDateIB.Visible = false;
            cbBoxProduct.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            chartProd.Visible = false;
            chartSum.Visible = false;
            DTPfirst1.Visible = false;
            DTPfirst2.Visible = false;
            DTPlast1.Visible = false;
            DTPlast2.Visible = false;
            //pictureBox4.Visible = false;
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
           //picBoxCheck2.Visible = false;
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
            picBoxCheck14.Visible = false;
            picBoxCheck15.Visible = false;
            picBoxCheck16.Visible = false;
            picBoxCheck17.Visible = false;
            picBoxCheck18.Visible = false;
        }
        //실시간 정보 (카트 현황)
        private void btnCart_Click(object sender, EventArgs e)
        {
            SetDefaultImage();
            VisibleFalseLabel();
            Checkit();
            picBoxCheck1.Visible = true;
            //picBoxCheck2.Visible = true;
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
            dataGridView2.Columns["barcode"].HeaderText = "바코드 번호";
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
            LblPdIB.Visible = true;
            LblDateIB.Visible = true;
            dataGridView2.Visible = true;
            //pictureBox4.Visible = true;
            btnInbound.BackgroundImage = Image.FromFile("menuIB2.jpg");

            //DataGridView2에 입고 내역 테이블 생성
            string sql = "SELECT * FROM `inbound`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns["product"].HeaderText = "상품명";
            dataGridView2.Columns["date"].HeaderText = "날짜";
            dataGridView2.Columns["quantity"].HeaderText = "수량";
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
            LblMemOB.Visible = true;
            LblBuydateOB.Visible = true;
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
            LblMonthChart.Visible = true;
            DTPfirst1.Visible = true;
            DTPlast1.Visible = true;
            LblDateBetween.Visible = true;
            chartSum.Visible = true;
            btnCheck1.Visible = true;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");

            int nowYear = DateTime.Now.Year; //오늘 년
            int nowMonth = DateTime.Now.Month; //오늘 월
            int firstDay = DateTime.Now.Day - 7; //일주일 전 날짜
            int lastDay = DateTime.Now.Day; //오늘 날짜
            //총매출액 그래프 날짜
            DTPfirst1.Value = new DateTime(nowYear, nowMonth, firstDay);
            DTPlast1.Value = new DateTime(nowYear, nowMonth, lastDay);

            int firstyear1 = DTPfirst1.Value.Year;
            int firstmonth1 = DTPfirst1.Value.Month;
            int firstday1 = DTPfirst1.Value.Day;
            int lastyear1 = DTPlast1.Value.Year;
            int lastmonth1 = DTPlast1.Value.Month;
            int lastday1 = DTPlast1.Value.Day;

            //총매출액 그래프
            string Querysale = "SELECT date_format(buydate, '%m-%d') AS date, sum(price) FROM `order` WHERE buydate BETWEEN date('" + firstyear1 + "-" + firstmonth1 + "-" + firstday1 + "') AND date('" + lastyear1 + "-" + lastmonth1 + "-" + lastday1 + "') GROUP BY buydate";
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            MySqlConnection consaleDB = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB = new MySqlCommand(Querysale, consaleDB);
            MySqlDataReader myreadersale;
            consaleDB.Open();
            myreadersale = cmdsaleDB.ExecuteReader();
            chartSum.Series.Clear();
            Series Series1 = chartSum.Series.Add("매출액");
            Series1.Color = Color.MediumPurple; // 막대 색
            Series1.MarkerSize = 5; // 막대 사이즈
            //chartSum.BackColor = Color.CornflowerBlue;
            Series1.IsValueShownAsLabel = true; // y값 표시
            Series1.LabelForeColor = Color.Black;

            try
            {
                while (myreadersale.Read())
                {
                    string date = myreadersale.GetString("date");
                    chartSum.Series["매출액"].Points.AddXY(date, myreadersale.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            consaleDB.Close();
        }
        //회원 삭제 메뉴
        private void LblMemDel_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            LblMemDel1.Visible = true;
            picBoxCheck4.Visible = true;
            btnMemDel.Visible = true;
            LblMemName.Visible = true;
            LblMemPassword.Visible = true;
            LblMemID.Visible = true;
            LblMemPhone.Visible = true;
            LblMemMail.Visible = true;
			LblMemManagement.Visible = true;
            cbBoxMemName.Visible = true;
            textMemID.Visible = true;
            textMemMail.Visible = true;
            textMemPhone.Visible = true;
            textMemPassword.Visible = true;
            LblMemManagement.Visible = true;
            dataGridView3.Visible = true;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");

            string sql = "SELECT userName FROM `user`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            dataGridView2.Columns["userName"].HeaderText = "회원이름";
            
            cbBoxMemName.SelectedIndex = -1;
            textMemID.Text = "";
            textMemPassword.Text = "";
            textMemPhone.Text = "";
            textMemMail.Text = "";

            cbBoxMemName.Items.Clear();
            FillComboMemName();
        }
        //상품 주문 메뉴
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
			LblProductManagement.Visible = true;
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

            dataGridView3.Columns["name"].HeaderText = "상품명";
            dataGridView3.Columns["quantity"].HeaderText = "상품수량";
            
            cbBoxPdName.SelectedIndex = -1;
            textPdQuantity.Text = "";

            cbBoxPdName.Items.Clear();
            FillComboPdName();
        }
        //상품 가격 수정 메뉴
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
			LblProductManagement.Visible = true;
            textPdPrice.Visible = true;
            cbBoxPdName.Visible = true;
            picBoxCheck9.Visible = true;
            dataGridView3.Visible = true;
            btnPdMdfy.Visible = true;
            
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name, price FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            dataGridView3.Columns["name"].HeaderText = "상품명";
            dataGridView3.Columns["price"].HeaderText = "상품가격";            

            cbBoxPdName.SelectedIndex = -1;
            textPdPrice.Text = "";

            cbBoxPdName.Items.Clear();
            FillComboPdName();
        }
        //상품 등록 메뉴
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
			LblProductManagement.Visible = true;
            LblPdName.Visible = true;
            textPdName.Visible = true;
            LblPdPrice.Visible = true;
            textPdPrice.Visible = true;
            picBoxCheck7.Visible = true;
            dataGridView3.Visible = true;
            btnPdRegi.Visible = true;            
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            dataGridView3.Columns["name"].HeaderText = "상품명";

            textPdName.Text = "";
            textPdPrice.Text = "";
        }
        //상품 삭제 메뉴
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
			LblProductManagement.Visible = true;
            cbBoxPdName.Visible = true;
            picBoxCheck8.Visible = true;
            dataGridView3.Visible = true;
            btnPdDel.Visible = true;            
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

            string sql = "SELECT name FROM `product`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            dataGridView3.Columns["name"].HeaderText = "상품명";            
            
            cbBoxPdName.SelectedIndex = -1;
            textPdPrice.Text = "";

            cbBoxPdName.Items.Clear();
            FillComboPdName();
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
            LblDateBetween.Visible = true;
            LblMonthChart.Visible = true;
            picBoxCheck13.Visible = true;
            chartProd.Visible = true;
            DTPfirst2.Visible = true;
            DTPlast2.Visible = true;
            btnCheck2.Visible = true;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");

            int nowYear = DateTime.Now.Year; //오늘 년
            int nowMonth = DateTime.Now.Month; //오늘 월
            int firstDay = DateTime.Now.Day - 7; //일주일 전 날짜
            int lastDay = DateTime.Now.Day; //오늘 날짜
            //상품별 매출액 그래프 날짜
            DTPfirst2.Value = new DateTime(nowYear, nowMonth, firstDay);
            DTPlast2.Value = new DateTime(nowYear, nowMonth, lastDay);
            int firstyear2 = DTPfirst2.Value.Year;
            int firstmonth2 = DTPfirst2.Value.Month;
            int firstday2 = DTPfirst2.Value.Day;
            int lastyear2 = DTPlast2.Value.Year;
            int lastmonth2 = DTPlast2.Value.Month;
            int lastday2 = DTPlast2.Value.Day;

            //상품별 매출액 그래프
            ArrayList ProdList = new ArrayList();//order 상품 목록
            ArrayList sCount = new ArrayList();//order 날짜에 따른 상품 판매 개수
            ArrayList sDay = new ArrayList();//order 날짜
            ArrayList sProduct = new ArrayList();
            chartProd.Series.Clear();
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            string QueryPdMenu1 = "SELECT product FROM `order` GROUP BY product"; //order 테이블의 상품 목록들
            MySqlConnection conPdmenuDB1 = new MySqlConnection(constring);
            MySqlCommand cmdPdmenuDB1 = new MySqlCommand(QueryPdMenu1, conPdmenuDB1);
            MySqlDataReader myreaderPdmenu1;
            try
            {
                conPdmenuDB1.Open();
                myreaderPdmenu1 = cmdPdmenuDB1.ExecuteReader();
                while (myreaderPdmenu1.Read())
                {
                    string sName = myreaderPdmenu1.GetString("product");
                    ProdList.Add(sName);
                    chartProd.Series.Add(sName);
                }
                conPdmenuDB1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ArrayList QueryDay2 = new ArrayList();
            string QueryDay = $"SELECT date_format(buydate, '%Y-%m-%d') AS date FROM `order` WHERE buydate BETWEEN date('{nowYear}-{nowMonth}-{firstDay}') AND date('{nowYear}-{nowMonth}-{lastDay}') GROUP BY buydate";
            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(QueryDay, conDB);
            MySqlDataReader myreader1;
            try
            {
                conDB.Open();
                myreader1 = cmdDB.ExecuteReader();
                while (myreader1.Read())
                {
                    string sDay1 = myreader1.GetString("date");
                    QueryDay2.Add(sDay1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ArrayList QueryDay1 = new ArrayList();//판매 내역 날짜 목록
            ArrayList sDatePd = new ArrayList();//판매 날짜에 따른 상품 목록
            ArrayList sDate = new ArrayList();//판매날짜
            ArrayList sCountd = new ArrayList();//판매개수
            string ssDate="";
            for (int i = 0; i < QueryDay2.Count; i++)
            {
                //선택한 처음날짜와 마지막 날짜 사이의 판매 내역 날짜에 따라 팔린 상품들 목록 조회
                QueryDay1.Add($"SELECT date_format(buydate, '%Y-%m-%d') AS Sdate, date_format(buydate, '%m-%d') AS date, product, count(product) AS cnt FROM `order` WHERE buydate = '{QueryDay2[i]}' GROUP BY product");
            }
            for (int i = 0; i < QueryDay2.Count; i++)
            {
                MySqlConnection conPdCntDB = new MySqlConnection(constring);
                MySqlCommand cmdPdCntDB = new MySqlCommand((string)QueryDay1[i], conPdCntDB);
                MySqlDataReader myreader;
                try
                {                    
                    conPdCntDB.Open();
                    myreader = cmdPdCntDB.ExecuteReader();

                    int count = ProdList.Count;
                    ArrayList Temp = new ArrayList();
                    for(int j=0; j < ProdList.Count; j++)
                    {
                        Temp.Add(ProdList[j]);
                    }
                    ArrayList Date_array = new ArrayList();
                    ArrayList DatePD_array = new ArrayList();
                    ArrayList DateCount_array = new ArrayList();
                    while (myreader.Read())
                    {
                        //ssDate = myreader.GetString("date");
                        //ssDatePd = myreader.GetString("product");
                        Date_array.Add(myreader.GetString("date"));
                        DatePD_array.Add(myreader.GetString("product"));
                        for (int j = 0; j < Temp.Count; j++)
                        {
                            if (myreader.GetString("product") == (string)Temp[j])
                            {
                                Console.WriteLine($"...Temp.RemoveAt(j)....{Temp[j]}");
                                Temp.RemoveAt(j);                                
                            }
                        }
                        //ssCountd = myreader.GetString("cnt");
                        DateCount_array.Add(myreader.GetString("cnt"));
                        //chartProd.Series[ssDatePd].Points.AddXY(ssDate, ssCountd);
                        
                    }
                    Console.WriteLine($"Temp. count.{Temp.Count}");

                    for (int j=0; j<Temp.Count; j++)
                    {
                        Console.WriteLine($"...for ... Count....{ssDate}");
                        Date_array.Add(myreader.GetString("date"));
                        DatePD_array.Add(Temp[j]);
                        DateCount_array.Add(0);
                    }
                    for(int j=0; j< Date_array.Count; j++)
                    {
                        chartProd.Series[(string)DatePD_array[j]].Points.AddXY((string)Date_array[j], DateCount_array[j]);
                    }
                    Console.WriteLine($"...ProdList.Count...{ProdList.Count}");
                    
                    conPdCntDB.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + 1131421313);
                }
            }           
        }
        //월별 총매출액 그래프
        private void LblMonthChart_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblChart.Visible = true;
            LblSaleChart.Visible = true;
            LblProdChart.Visible = true;
            LblMonthChart.Visible = true;
            LblMonthChart1.Visible = true;
            picBoxCheck18.Visible = true;
            chartSum.Visible = true;

            int nowYear = DateTime.Now.Year; //오늘 년
            int nowMonth = DateTime.Now.Month;
            int nowDay = DateTime.Now.Day;
            DTPfirst2.Value = new DateTime(nowYear, nowMonth, nowDay);

            string Querysale = "SELECT date_format(buydate, '%Y-%m') AS date, sum(price) FROM `order` GROUP BY date";
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            MySqlConnection consaleDB = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB = new MySqlCommand(Querysale, consaleDB);
            MySqlDataReader myreadersale;
            consaleDB.Open();
            myreadersale = cmdsaleDB.ExecuteReader();
            chartSum.Series.Clear();
            Series Series1 = chartSum.Series.Add("매출액");
            //Series1.Color = Color.MediumPurple; // 막대 색
            Series1.MarkerSize = 5; // 막대 사이즈
            //chartSum.BackColor = Color.CornflowerBlue;
            Series1.IsValueShownAsLabel = true; // y값 표시
            Series1.LabelForeColor = Color.Black;
            try
            {
                while (myreadersale.Read())
                {
                    string date = myreadersale.GetString("date");
                    chartSum.Series["매출액"].Points.AddXY(date, myreadersale.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            consaleDB.Close();
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
        //입고 내역 상품별 콤보박스
        public void FillComboPdIB()
        {
            string Cstring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            string QueryPdIB = "SELECT product FROM `inbound` GROUP BY product";
            MySqlConnection conDB = new MySqlConnection(Cstring);
            MySqlCommand cmdDB = new MySqlCommand(QueryPdIB, conDB);
            MySqlDataReader myreader;
            try
            {
                conDB.Open();
                myreader = cmdDB.ExecuteReader();
                while(myreader.Read())
                {
                    string sProduct = myreader.GetString("product");
                    cbBoxProduct.Items.Add(sProduct);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDB.Close();
        }
        public void FillComboDateIB()
        {
            string Cstring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            string QueryDateIB = "SELECT date_format(date, '%Y-%m-%d') AS date FROM `inbound` GROUP BY date";
            MySqlConnection conDB = new MySqlConnection(Cstring);
            MySqlCommand cmdDB = new MySqlCommand(QueryDateIB, conDB);
            MySqlDataReader myreader;
            try
            {
                conDB.Open();
                myreader = cmdDB.ExecuteReader();
                while(myreader.Read())
                {
                    string sBuydate = myreader.GetString("date");
                    cbBoxDateIB.Items.Add(sBuydate);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDB.Close();
        }
        //회원 구매 내역 콤보박스
        public void FillComboMemID()
        {
            string Cstring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string QueryMem = "SELECT userID FROM user";
            MySqlConnection MemconDB = new MySqlConnection(Cstring);
            MySqlCommand MemcmdDB = new MySqlCommand(QueryMem, MemconDB);
            MySqlDataReader myReader;
            try
            {
                MemconDB.Open();
                myReader = MemcmdDB.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("userID");
                    cbBoxMemID.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MemconDB.Close();
        }
        //날짜별 판매 내역(출고 내역) 날짜 콤보 박스
        public void FillComboBuydate()
        {
            string Cstring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string QueryMem = "SELECT date_format(buydate, '%Y-%m-%d') AS date FROM `order` GROUP BY buydate";
            MySqlConnection MemconDB = new MySqlConnection(Cstring);
            MySqlCommand MemcmdDB = new MySqlCommand(QueryMem, MemconDB);
            MySqlDataReader myReader;
            try
            {
                MemconDB.Open();
                myReader = MemcmdDB.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("date");
                    cbBoxBuydate.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MemconDB.Close();
        }
        //회원 삭제
        private void btnMemDel_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            string QueryMemDel = "DELETE FROM user WHERE userName = '" + cbBoxMemName.SelectedItem + "'";

            MySqlConnection MemconDB2 = new MySqlConnection(constring);
            MySqlCommand MemcmdDB2 = new MySqlCommand(QueryMemDel, MemconDB2);
            MySqlDataReader myReader2;

            if (cbBoxMemName.SelectedIndex >= 0)
            {
                MessageBox.Show("삭제되었습니다.", "관리자");
            }
            else
            {
                MessageBox.Show("회원을 입력하시오", "관리자");
            }
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
            cbBoxMemName.Items.Clear();
            FillComboMemName();
                        
            textMemID.Text = "";
            textMemPassword.Text = "";
            textMemPhone.Text = "";
            textMemMail.Text = "";

            string sql = "SELECT userName FROM `user`";
            DataTable dt = db.GetDBTable(sql);
            dataGridView3.DataSource = dt;

            dataGridView3.Columns["userName"].HeaderText = "회원이름";
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
            int nowYear = DateTime.Now.Year; //오늘 년
            int nowMonth = DateTime.Now.Month; //오늘 월
            int lastDay = DateTime.Now.Day; //오늘 날짜

            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
            string QueryPdOrder1 = "SELECT * FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            string sQuantity = null;
            string PdQuantity = null;
            MySqlConnection PdconDB1 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB1 = new MySqlCommand(QueryPdOrder1, PdconDB1);
            MySqlDataReader myreader1;

            if ((cbBoxPdName.SelectedIndex >= 0) && (textPdQuantity.Text != "") && (Convert.ToInt32(textPdQuantity.Text) <= 100))
            {
                MessageBox.Show("주문되었습니다.", "관리자");
                try
                {
                    PdconDB1.Open();
                    myreader1 = PdcmdDB1.ExecuteReader();
                    while (myreader1.Read())
                    {
                        sQuantity = myreader1.GetString("quantity");
                        PdQuantity = textPdQuantity.Text;
                    }
                }
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + 33);
                }

                string sql = "SELECT name, quantity FROM `product`";
                DataTable dt = db.GetDBTable(sql);
                dataGridView3.DataSource = dt;

                // 주문 시 입고내역 데이터베이스에 추가
                string QueryPdOrder3 = $"INSERT INTO inbound (product, quantity, date) VALUES ('{cbBoxPdName.SelectedItem}', '{PdQuantity}', '{nowYear}-{nowMonth}-{lastDay}')";
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cbBoxPdName.SelectedIndex = -1;
                textPdQuantity.Text = "";

            }
            else if (cbBoxPdName.SelectedIndex < 0)
            {
                MessageBox.Show("상품을 입력하시오", "관리자");
            }
            else if (Convert.ToInt32(textPdQuantity.Text) > 100)
            {
                MessageBox.Show("입고 수량 범위를 벗어났습니다.(100 이하)");
            }
            else
            {
                MessageBox.Show("수량을 입력하시오", "관리자");
            }
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
            if ((textPdPrice.Text != "") && (cbBoxPdName.SelectedIndex > 0) && (Convert.ToInt32(textPdPrice.Text) < 100000))
            {
                MessageBox.Show("수정되었습니다.", "관리자");
                try
                {
                    PdconDB1.Open();
                    myreader1 = PdcmdDB1.ExecuteReader();
                    while (myreader1.Read())
                    {
                        PdPrice = textPdPrice.Text;
                    }
                }
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cbBoxPdName.SelectedIndex = -1;
                textPdPrice.Text = "";

                string sql = "SELECT name, price FROM `product`";
                DataTable dt = db.GetDBTable(sql);
                dataGridView3.DataSource = dt;

                dataGridView3.Columns["name"].HeaderText = "상품명";
                dataGridView3.Columns["price"].HeaderText = "상품가격";
            }
            else if ((cbBoxPdName.SelectedIndex < 0) && (textPdPrice.Text != ""))
            {
                MessageBox.Show("상품을 입력하시오", "관리자");
            }
            else if (Convert.ToInt32(textPdPrice.Text) > 100000)
            {
                MessageBox.Show("가격의 최대 범위를 벗어났습니다. (100,000원 이하)");
            }
            else
            {
                MessageBox.Show("가격을 입력하시오", "관리자");
            }
        }
        //상품 등록 버튼
        private void btnPdRegi_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; username=root; password=apmsetup; database=smartcart;";
            string QueryPdRegi = "INSERT INTO product (name, price) VALUES ('" + textPdName.Text + "', '" + textPdPrice.Text + "')";

            MySqlConnection PdconDB3 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB3 = new MySqlCommand(QueryPdRegi, PdconDB3);
            MySqlDataReader myreader3;

            if ((textPdName.Text != "") && (textPdPrice.Text != ""))
            {
                MessageBox.Show("등록되었습니다.", "관리자");
                try
                {
                    PdconDB3.Open();
                    myreader3 = PdcmdDB3.ExecuteReader();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(QueryPdRegi, PdconDB3);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                textPdName.Text = "";
                textPdPrice.Text = "";
                //cbBoxPdName.Items.Clear();
                //FillComboPdName();

                string sql = "SELECT name FROM `product`";
                DataTable dt = db.GetDBTable(sql);
                dataGridView3.DataSource = dt;
            }
            else if (textPdName.Text == "")
            {
                MessageBox.Show("상품을 입력하시오", "관리자");
            }
            else if (textPdPrice.Text == "")
            {
                MessageBox.Show("가격을 입력하시오", "관리자");
            }                     
        }
        //상품 삭제 버튼
        private void btnPdDel_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost; username=root; password=apmsetup; database=smartcart;";
            string QueryPdRegi = "DELETE FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
           
            MySqlConnection PdconDB3 = new MySqlConnection(constring);
            MySqlCommand PdcmdDB3 = new MySqlCommand(QueryPdRegi, PdconDB3);
            MySqlDataReader myreader3;
            if (cbBoxPdName.SelectedIndex>=0)
            {
                MessageBox.Show("삭제되었습니다.", "관리자");
                try
                {
                    PdconDB3.Open();
                    myreader3 = PdcmdDB3.ExecuteReader();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(QueryPdRegi, PdconDB3);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                cbBoxPdName.SelectedIndex = -1;
                cbBoxPdName.Items.Clear();
                FillComboPdName();

                string sql = "SELECT name FROM `product`";
                DataTable dt = db.GetDBTable(sql);
                dataGridView3.DataSource = dt;
            }
            else 
            {
                MessageBox.Show("상품을 입력하시오", "관리자");
            }
        }
        //총매출액 그래프 날짜 날짜 변경 후 조회 버튼 
        private void btnCheck1_Click(object sender, EventArgs e)
        {
            int firstyear1 = DTPfirst1.Value.Year;
            int firstmonth1 = DTPfirst1.Value.Month;
            int firstday1 = DTPfirst1.Value.Day;
            int lastyear1 = DTPlast1.Value.Year;
            int lastmonth1 = DTPlast1.Value.Month;
            int lastday1 = DTPlast1.Value.Day;

            if(lastday1 - firstday1 <= 7)
            {
                string QueryCheck1 = "SELECT date_format(buydate, '%m-%d') AS date, sum(price) FROM `order` WHERE buydate BETWEEN date('" + firstyear1 + "-" + firstmonth1 + "-" + firstday1 + "') AND date('" + lastyear1 + "-" + lastmonth1 + "-" + lastday1 + "') GROUP BY buydate";
                string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup";
                MySqlConnection conDB = new MySqlConnection(constring);
                MySqlCommand cmdDB = new MySqlCommand(QueryCheck1, conDB);
                MySqlDataReader myreader;
                conDB.Open();
                myreader = cmdDB.ExecuteReader();
                chartSum.Series.Clear();
                Series Series1 = chartSum.Series.Add("매출액");
                Series1.Color = Color.MediumPurple; // 막대 색
                Series1.MarkerSize = 5; // 막대 사이즈
                                        //chartSum.BackColor = Color.CornflowerBlue;
                Series1.IsValueShownAsLabel = true; // y값 표시
                Series1.LabelForeColor = Color.Black;
                try
                {
                    while (myreader.Read())
                    {
                        string date = myreader.GetString("date");
                        chartSum.Series["매출액"].Points.AddXY(date, myreader.GetString("sum(price)"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conDB.Close();
            }
            else
            {
                MessageBox.Show("날짜범위가 너무 큽니다.(7일 이하)");
            }

            
        }
        //상품별 매출액 그래프 날짜 변경 후 조회 버튼
        private void btnCheck2_Click(object sender, EventArgs e)
        {

            //상품별 매출액 그래프 날짜
            int firstyear2 = DTPfirst2.Value.Year;
            int firstmonth2 = DTPfirst2.Value.Month;
            int firstday2 = DTPfirst2.Value.Day;
            int lastyear2 = DTPlast2.Value.Year;
            int lastmonth2 = DTPlast2.Value.Month;
            int lastday2 = DTPlast2.Value.Day;
            //상품별 매출액 그래프
            ArrayList ProdList = new ArrayList();//order 상품 목록
            ArrayList sCount = new ArrayList();//order 날짜에 따른 상품 판매 개수
            ArrayList sDay = new ArrayList();//order 날짜
            ArrayList sProduct = new ArrayList();
            chartProd.Series.Clear();
            string constring = "datasource=localhost; database=smartcart; username=root; password=apmsetup;";
            string QueryPdMenu1 = "SELECT product FROM `order` GROUP BY product"; //order 테이블의 상품 목록들
            MySqlConnection conPdmenuDB1 = new MySqlConnection(constring);
            MySqlCommand cmdPdmenuDB1 = new MySqlCommand(QueryPdMenu1, conPdmenuDB1);
            MySqlDataReader myreaderPdmenu1;
            try
            {
                conPdmenuDB1.Open();
                myreaderPdmenu1 = cmdPdmenuDB1.ExecuteReader();
                while (myreaderPdmenu1.Read())
                {
                    string sName = myreaderPdmenu1.GetString("product");
                    ProdList.Add(sName);
                    chartProd.Series.Add(sName);
                }
                conPdmenuDB1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ArrayList QueryDay2 = new ArrayList();
            string QueryDay = $"SELECT date_format(buydate, '%Y-%m-%d') AS date FROM `order` WHERE buydate BETWEEN date('{firstyear2}-{firstmonth2}-{firstday2}') AND date('{lastyear2}-{lastmonth2}-{lastday2}') GROUP BY buydate";
            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(QueryDay, conDB);
            MySqlDataReader myreader1;
            try
            {
                conDB.Open();
                myreader1 = cmdDB.ExecuteReader();
                while (myreader1.Read())
                {
                    string sDay1 = myreader1.GetString("date");
                    QueryDay2.Add(sDay1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + 3344123);
            }
            ArrayList QueryDay1 = new ArrayList(); //판매 내역 날짜 목록
            ArrayList sDatePd = new ArrayList();
            ArrayList sDate = new ArrayList();
            ArrayList sCountd = new ArrayList();
            string ssDate = "";
            for (int i = 0; i < QueryDay2.Count; i++)
            {
                //선택한 처음날짜와 마지막 날짜 사이의 판매 내역 날짜에 따라 팔린 상품들 목록 조회
                QueryDay1.Add($"SELECT date_format(buydate, '%m-%d') AS date, product, count(product) AS cnt FROM `order` WHERE buydate = '{QueryDay2[i]}' GROUP BY product");
            }
            for (int i = 0; i < QueryDay2.Count; i++)
            {
                MySqlConnection conPdCntDB = new MySqlConnection(constring);
                MySqlCommand cmdPdCntDB = new MySqlCommand((string)QueryDay1[i], conPdCntDB);
                MySqlDataReader myreader;
                try
                {
                    conPdCntDB.Open();
                    myreader = cmdPdCntDB.ExecuteReader();

                    int count = ProdList.Count;
                    ArrayList Temp = new ArrayList();
                    for(int j=0; j<ProdList.Count; j++)
                    {
                        Temp.Add(ProdList[j]);
                    }
                    ArrayList Date_array = new ArrayList();
                    ArrayList DatePD_array = new ArrayList();
                    ArrayList DateCount_array = new ArrayList();
                    while (myreader.Read())
                    {
                        Date_array.Add(myreader.GetString("date"));
                        DatePD_array.Add(myreader.GetString("product"));
                        for(int j=0; j<Temp.Count; j++)
                        {
                            if(myreader.GetString("product") == (string)Temp[j])
                            {
                                Console.WriteLine($"....Temp.Remeove... {Temp[j]}");
                                Temp.RemoveAt(j);
                            }
                        }
                        DateCount_array.Add(myreader.GetString("cnt"));
                    }
                    Console.WriteLine($"Temp. count.{Temp.Count}");
                    for (int j = 0; j < Temp.Count; j++)
                    {
                        Console.WriteLine($"...for ... Count....{ssDate}");
                        Date_array.Add(myreader.GetString("date"));
                        DatePD_array.Add(Temp[j]);
                        DateCount_array.Add(0);
                    }
                    for (int j = 0; j < Date_array.Count; j++)
                    {
                        chartProd.Series[(string)DatePD_array[j]].Points.AddXY((string)Date_array[j], DateCount_array[j]);
                    }
                    Console.WriteLine($"...ProdList.Count...{ProdList.Count}");

                    conPdCntDB.Close();
                }                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + 1133);
                }
            }
        }
        //메인 창 x 버튼 클릭 시 이벤트
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadAbort();
        }
        //회원별 구매 내역
        private void LblMemOB_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblOutbound.Visible = true;
            LblPdOutbound.Visible = true;
            LblMemOB.Visible = true;
            LblMemOB1.Visible = true;
            LblMemID1.Visible = true;
            LblBuydateOB.Visible = true;
            picBoxCheck14.Visible = true;
            dataGridView2.Visible = true;
            cbBoxMemID.Visible = true;
            //dataGridView2.Rows.Clear();

            cbBoxMemID.SelectedIndex = -1;
            cbBoxMemID.Items.Clear();
            FillComboMemID();

            string sql = "SELECT product, buydate FROM `order` WHERE orderID = '" + cbBoxMemID.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;

        }
        //회원 ID 목록 인덱스 변경 시 이벤트
        private void cbBoxMemID_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT product, buydate FROM `order` WHERE orderID = '" + cbBoxMemID.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //날짜별 구매(출고) 목록
        private void LblBuydateOB_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblOutbound.Visible = true;
            LblPdOutbound.Visible = true;
            LblMemOB.Visible = true;
            LblBuydateOB.Visible = true;
            LblBuydateOB1.Visible = true;
            LblBuydate1.Visible = true;
            cbBoxBuydate.Visible = true;
            picBoxCheck15.Visible = true;
            dataGridView2.Visible = true;

            cbBoxBuydate.SelectedIndex = -1;
            cbBoxBuydate.Items.Clear();
            FillComboBuydate();

            string sql = "SELECT buydate, orderID, product FROM `order` WHERE buydate = '" + cbBoxBuydate.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //날짜별 출고 내역 value값 변경 시 이벤트
        private void cbBoxBuydate_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT buydate, orderID, product FROM `order` WHERE buydate = '" + cbBoxBuydate.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //상품별 입고 내역 라벨
        private void LblPdIB_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblDateIB.Visible = true;
            LblPdInbound.Visible = true;
            LblPdIB.Visible = true;
            LblInbound.Visible = true;
            LblPdIB1.Visible = true;
            picBoxCheck16.Visible = true;
            cbBoxProduct.Visible = true;
            LblPdMenu.Visible = true;
            dataGridView2.Visible = true;

            cbBoxProduct.SelectedIndex = -1;
            cbBoxProduct.Items.Clear();
            FillComboPdIB();

            string sql = "SELECT product, quantity, date FROM `inbound` WHERE product = '" + cbBoxProduct.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //날짜별 입고 내역
        private void LblDateIB_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblInbound.Visible = true;
            LblPdInbound.Visible = true;
            LblDateIB.Visible = true;
            LblPdIB.Visible = true;
            LblInbound.Visible = true;
            LblDateIB1.Visible = true;
            LblDate1.Visible = true;
            picBoxCheck17.Visible = true;
            cbBoxDateIB.Visible = true;
            dataGridView2.Visible = true;

            cbBoxDateIB.SelectedIndex = -1;
            cbBoxDateIB.Items.Clear();
            FillComboDateIB();

            string sql = "SELECT date, product, quantity FROM `inbound` WHERE date = '" + cbBoxDateIB.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //상품별 입고 내역 콤보박스 value값 변경 시 이벤트
        private void cbBoxProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT product, quantity, date FROM `inbound` WHERE product = '" + cbBoxProduct.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }
        //날짜별 입고 내역 콤보박스 value값 변경 시 이벤트
        private void cbBoxDateIB_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT date, product, quantity FROM `inbound` WHERE date = '" + cbBoxDateIB.SelectedItem + "'";
            DataTable dt = db.GetDBTable(sql);
            dataGridView2.DataSource = dt;
        }

        private void textPdQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textPdPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
