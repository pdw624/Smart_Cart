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
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;


namespace smartcart_1
{

    public partial class Main : Form
    {
        Con_database db;
        Con_basechart dc;

        Login loginForm;

     

        public Main()
        {
            InitializeComponent();
            db = new Con_database();
            db.ConnectDB();
            dc = new Con_basechart();
            dc.ConnectDB();
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
            
            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            int firstDay = DateTime.Now.Day-7;
            int lastDay = DateTime.Now.Day;

            lastDTP.Value = new DateTime(nowYear, nowMonth, lastDay);
            firstDTP.Value = new DateTime(nowYear, nowMonth, firstDay);
            lastDTP2.Value = new DateTime(nowYear, nowMonth, lastDay);
            firstDTP2.Value = new DateTime(nowYear, nowMonth, firstDay);

            int firstyear = firstDTP.Value.Year;
            int firstmonth = firstDTP.Value.Month;
            int firstday = firstDTP.Value.Day;
            int lastyear = lastDTP.Value.Year;
            int lastmonth = lastDTP.Value.Month;
            int lastday = lastDTP.Value.Day;

            int firstyear2 = firstDTP2.Value.Year;
            int firstmonth2 = firstDTP2.Value.Month;
            int firstday2 = firstDTP2.Value.Day;
            int lastyear2 = lastDTP2.Value.Year;
            int lastmonth2 = lastDTP2.Value.Month;
            int lastday2 = lastDTP2.Value.Day;

            //총매출액 그래프
            string Querysale = "  select date_format(buydate, '%m-%d') as date, sum(price) from `order` where buydate between date('" + firstyear + "-" + firstmonth + "-" + firstday + "') AND date('" + lastyear + "-" + lastmonth + "-" + lastday + "') group by buydate";
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            MySqlConnection consaleDB = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB = new MySqlCommand(Querysale, consaleDB);
            MySqlDataReader myreadersale;
            consaleDB.Open();
            myreadersale = cmdsaleDB.ExecuteReader();
            MySqlDataReader dk = dc.MySqlDataReader(Querysale);
            chartSales.Series[0].Points.Clear();
            try
            {
                while (myreadersale.Read())
                {
                    string date = myreadersale.GetString("date");
                    chartSales.Series["price"].Points.AddXY(date, myreadersale.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            consaleDB.Close();

            //임시 datagridview
            DataTable da = db.GetDBTable(Querysale);
            dataGridView2.DataSource = da;
            dataGridView2.Visible = false;
            consaleDB.Close();

            ArrayList chartpdsale2 = new ArrayList();
            //상품판매액
            //string Querysale1 = "select name from `product`";
            ////select count(product) from `order` where product = 'mask' and buydate between date('2020-03-11') and date('2020-03-13') group by buydate
            //MySqlConnection consaleDB1 = new MySqlConnection(constring);
            //MySqlCommand cmdsaleDB1 = new MySqlCommand(Querysale1, consaleDB1);
            //MySqlDataReader myreadersale1;
            //try
            //{
            //    consaleDB1.Open();
            //    myreadersale1 = cmdsaleDB1.ExecuteReader();
            //    while (myreadersale1.Read())
            //    {
            //        string sName = myreadersale1.GetString("name");
            //        chartpdsale2.Add(sName);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            ////chartSales2.Series[0].Points.Clear();
            ////chartSales2.Series[1].Points.Clear();
            ////chartSales2.Series[2].Points.Clear();
            ////chartSales2.Series[3].Points.Clear();
            ////chartSales2.Series[4].Points.Clear();
            ////chartSales2.Series[5].Points.Clear();
            ////chartSales2.Series[6].Points.Clear();

            //chartSales2.Series.Clear();
            //Series series1 = chartSales2.Series.Add((string)chartpdsale2[0]);
            //Series series2 = chartSales2.Series.Add((string)chartpdsale2[1]);
            //Series series3 = chartSales2.Series.Add((string)chartpdsale2[2]);
            //Series series4 = chartSales2.Series.Add((string)chartpdsale2[3]);
            //Series series5 = chartSales2.Series.Add((string)chartpdsale2[4]);
            //Series series6 = chartSales2.Series.Add((string)chartpdsale2[5]);
            //Series series7 = chartSales2.Series.Add((string)chartpdsale2[6]);
            
            //string Query0 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[0] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 +"-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB0 = new MySqlConnection(constring);
            //MySqlCommand cmdDB0 = new MySqlCommand((string)Query0, conDB0);
            //MySqlDataReader myreader0;
            //try
            //{
            //    conDB0.Open();
            //    myreader0 = cmdDB0.ExecuteReader();
            //    while (myreader0.Read())
            //    {   
            //        string sCount = myreader0.GetString("count(product)");
            //        string sDay = myreader0.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[0]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "00");
            //}

            //string Query1 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[1] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB1 = new MySqlConnection(constring);
            //MySqlCommand cmdDB1 = new MySqlCommand(Query1, conDB1);
            //MySqlDataReader myreader1;
            //try
            //{
            //    conDB1.Open();
            //    myreader1 = cmdDB1.ExecuteReader();
            //    while (myreader1.Read())
            //    {
            //        string sCount = myreader1.GetString("count(product)");
            //        string sDay = myreader1.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[1]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "11");
            //}
            //string Query2 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[2] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB2 = new MySqlConnection(constring);
            //MySqlCommand cmdDB2 = new MySqlCommand(Query2, conDB2);
            //MySqlDataReader myreader2;
            //try
            //{
            //    conDB2.Open();
            //    myreader2 = cmdDB2.ExecuteReader();
            //    while (myreader2.Read())
            //    {
            //        string sCount = myreader2.GetString("count(product)");
            //        string sDay = myreader2.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[2]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "22");
            //}
            //string Query3 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[3] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB3 = new MySqlConnection(constring);
            //MySqlCommand cmdDB3 = new MySqlCommand((string)Query3, conDB3);
            //MySqlDataReader myreader3;
            //try
            //{
            //    conDB3.Open();
            //    myreader3 = cmdDB3.ExecuteReader();
            //    while (myreader3.Read())
            //    {
            //        string sCount = myreader3.GetString("count(product)");
            //        string sDay = myreader3.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[3]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "33");
            //}
            //string Query4 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[4] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB4 = new MySqlConnection(constring);
            //MySqlCommand cmdDB4 = new MySqlCommand(Query4, conDB4);
            //MySqlDataReader myreader4;
            //try
            //{
            //    conDB4.Open();
            //    myreader4 = cmdDB4.ExecuteReader();
            //    while (myreader4.Read())
            //    {
            //        string sCount = myreader4.GetString("count(product)");
            //        string sDay = myreader4.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[4]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "44");
            //}
            //string Query5 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[5] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB5 = new MySqlConnection(constring);
            //MySqlCommand cmdDB5 = new MySqlCommand(Query5, conDB5);
            //MySqlDataReader myreader5;
            //try
            //{
            //    conDB5.Open();
            //    myreader5 = cmdDB5.ExecuteReader();
            //    while (myreader5.Read())
            //    {
            //        string sCount = myreader5.GetString("count(product)");
            //        string sDay = myreader5.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[5]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "55");
            //}
            //string Query6 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[6] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            //MySqlConnection conDB6 = new MySqlConnection(constring);
            //MySqlCommand cmdDB6 = new MySqlCommand(Query6, conDB6);
            //MySqlDataReader myreader6;
            //try
            //{
            //    conDB6.Open();
            //    myreader6 = cmdDB6.ExecuteReader();
            //    while (myreader6.Read())
            //    {
            //        string sCount = myreader6.GetString("count(product)");
            //        string sDay = myreader6.GetString("date");
            //        chartSales2.Series[(string)chartpdsale2[6]].Points.AddXY(sDay, sCount);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "66");
            //}

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
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            btnChartDate.Visible = false;
            LbBetween.Visible = false;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;

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
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            btnChartDate.Visible = false;
            LbBetween.Visible = false;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;
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
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false; ;
            btnChartDate.Visible = false;
            LbBetween.Visible = false;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;
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
            firstDTP.Visible = true;
            lastDTP.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            btnChartDate.Visible = true;
            LbBetween.Visible = true;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;
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

            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            int firstDay = DateTime.Now.Day - 7;
            int lastDay = DateTime.Now.Day;

            lastDTP.Value = new DateTime(nowYear, nowMonth, lastDay);
            firstDTP.Value = new DateTime(nowYear, nowMonth, firstDay);

            int firstyear = firstDTP.Value.Year;
            int firstmonth = firstDTP.Value.Month;
            int firstday = firstDTP.Value.Day;
            int lastyear = lastDTP.Value.Year;
            int lastmonth = lastDTP.Value.Month;
            int lastday = lastDTP.Value.Day;

            string Query1 = "select date_format(buydate, '%m-%d') as date, sum(price) from `order` where buydate between date('" + firstyear + "-" + firstmonth + "-" + firstday + "') AND date('" + lastyear + "-" + lastmonth + "-" + lastday + "') group by buydate";          
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            MySqlConnection conDB1 = new MySqlConnection(constring);
            MySqlCommand cmdDB1 = new MySqlCommand(Query1, conDB1);
            MySqlDataReader myreader1;
            conDB1.Open();
            myreader1 = cmdDB1.ExecuteReader();
            chartSales.Series[0].Points.Clear();
            try
            {
                while (myreader1.Read())
                {
                    string date = myreader1.GetString("date");
                    chartSales.Series["price"].Points.AddXY(date, myreader1.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //임시 datagridview
            DataTable da = db.GetDBTable(Query1);
            dataGridView2.DataSource = da;
            dataGridView2.Visible = false;
            //da.Columns["date_format(buydate, '%m-%d')"].ColumnName = "buydate";
            conDB1.Close();

            chartSales.Visible = true;
            chartSales2.Visible = false;
            firstDTP.Visible = true;
            lastDTP.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            btnChartDate.Visible = true;
            LbBetween.Visible = true;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;

        }

        //상품별 판매 그래프 버튼
        private void btnPdChart_Click(object sender, EventArgs e)
        {
            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            int firstDay = DateTime.Now.Day - 7;
            int lastDay = DateTime.Now.Day;

            lastDTP2.Value = new DateTime(nowYear, nowMonth, lastDay);
            firstDTP2.Value = new DateTime(nowYear, nowMonth, firstDay);
            
            int firstyear2 = firstDTP2.Value.Year;
            int firstmonth2 = firstDTP2.Value.Month;
            int firstday2 = firstDTP2.Value.Day;
            int lastyear2 = lastDTP2.Value.Year;
            int lastmonth2 = lastDTP2.Value.Month;
            int lastday2 = lastDTP2.Value.Day;

            ArrayList chartpdsale2 = new ArrayList();
            //상품판매액
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Querysale1 = "select name from `product`";
            //select count(product) from `order` where product = 'mask' and buydate between date('2020-03-11') and date('2020-03-13') group by buydate
            MySqlConnection consaleDB1 = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB1 = new MySqlCommand(Querysale1, consaleDB1);
            MySqlDataReader myreadersale1;
            try
            {
                consaleDB1.Open();
                myreadersale1 = cmdsaleDB1.ExecuteReader();
                while (myreadersale1.Read())
                {
                    string sName = myreadersale1.GetString("name");
                    chartpdsale2.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chartSales2.Series[0].Points.Clear();
            chartSales2.Series[1].Points.Clear();
            chartSales2.Series[2].Points.Clear();
            chartSales2.Series[3].Points.Clear();
            chartSales2.Series[4].Points.Clear();
            chartSales2.Series[5].Points.Clear();
            chartSales2.Series[6].Points.Clear();

            chartSales2.Series.Clear();
            Series series1 = chartSales2.Series.Add((string)chartpdsale2[0]);
            Series series2 = chartSales2.Series.Add((string)chartpdsale2[1]);
            Series series3 = chartSales2.Series.Add((string)chartpdsale2[2]);
            Series series4 = chartSales2.Series.Add((string)chartpdsale2[3]);
            Series series5 = chartSales2.Series.Add((string)chartpdsale2[4]);
            Series series6 = chartSales2.Series.Add((string)chartpdsale2[5]);
            Series series7 = chartSales2.Series.Add((string)chartpdsale2[6]);

            string Query0 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[0] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB0 = new MySqlConnection(constring);
            MySqlCommand cmdDB0 = new MySqlCommand((string)Query0, conDB0);
            MySqlDataReader myreader0;
            try
            {
                conDB0.Open();
                myreader0 = cmdDB0.ExecuteReader();
                while (myreader0.Read())
                {
                    string sCount = myreader0.GetString("count(product)");
                    string sDay = myreader0.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[0]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "00");
            }

            string Query1 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[1] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB1 = new MySqlConnection(constring);
            MySqlCommand cmdDB1 = new MySqlCommand(Query1, conDB1);
            MySqlDataReader myreader1;
            try
            {
                conDB1.Open();
                myreader1 = cmdDB1.ExecuteReader();
                while (myreader1.Read())
                {
                    string sCount = myreader1.GetString("count(product)");
                    string sDay = myreader1.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[1]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "11");
            }
            string Query2 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[2] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB2 = new MySqlConnection(constring);
            MySqlCommand cmdDB2 = new MySqlCommand(Query2, conDB2);
            MySqlDataReader myreader2;
            try
            {
                conDB2.Open();
                myreader2 = cmdDB2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sCount = myreader2.GetString("count(product)");
                    string sDay = myreader2.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[2]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "22");
            }
            string Query3 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[3] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB3 = new MySqlConnection(constring);
            MySqlCommand cmdDB3 = new MySqlCommand((string)Query3, conDB3);
            MySqlDataReader myreader3;
            try
            {
                conDB3.Open();
                myreader3 = cmdDB3.ExecuteReader();
                while (myreader3.Read())
                {
                    string sCount = myreader3.GetString("count(product)");
                    string sDay = myreader3.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[3]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "33");
            }
            string Query4 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[4] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB4 = new MySqlConnection(constring);
            MySqlCommand cmdDB4 = new MySqlCommand(Query4, conDB4);
            MySqlDataReader myreader4;
            try
            {
                conDB4.Open();
                myreader4 = cmdDB4.ExecuteReader();
                while (myreader4.Read())
                {
                    string sCount = myreader4.GetString("count(product)");
                    string sDay = myreader4.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[4]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "44");
            }
            string Query5 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[5] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB5 = new MySqlConnection(constring);
            MySqlCommand cmdDB5 = new MySqlCommand(Query5, conDB5);
            MySqlDataReader myreader5;
            try
            {
                conDB5.Open();
                myreader5 = cmdDB5.ExecuteReader();
                while (myreader5.Read())
                {
                    string sCount = myreader5.GetString("count(product)");
                    string sDay = myreader5.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[5]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "55");
            }
            string Query6 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[6] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB6 = new MySqlConnection(constring);
            MySqlCommand cmdDB6 = new MySqlCommand(Query6, conDB6);
            MySqlDataReader myreader6;
            try
            {
                conDB6.Open();
                myreader6 = cmdDB6.ExecuteReader();
                while (myreader6.Read())
                {
                    string sCount = myreader6.GetString("count(product)");
                    string sDay = myreader6.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[6]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "66");
            }

            chartSales.Visible = false;
            chartSales2.Visible = true;
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView3.Visible = true;
            dataGridView2.Visible = false;
            btnChartDate.Visible = false;
            LbBetween.Visible = true;
            btnChartDate2.Visible = true;
            firstDTP2.Visible = true;
            lastDTP2.Visible = true;
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
            //dt.DefaultView.Sort = "buydate desc";
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
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            btnChartDate.Visible = false;
            LbBetween.Visible = false;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;

        }

        //입고내역 버튼
        private void btnIB_Click(object sender, EventArgs e)
        {
            string sql = "select * from `inbound`";
            DataTable dt = db.GetDBTable(sql);

            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

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
            firstDTP.Visible = false;
            lastDTP.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            btnChartDate.Visible = false;
            LbBetween.Visible = false;
            btnChartDate2.Visible = false;
            firstDTP2.Visible = false;
            lastDTP2.Visible = false;
        }

        private void btnPdRegi_Click(object sender, EventArgs e)
        {
            ProductRegister f = new ProductRegister();
            DialogResult = DialogResult.OK;
            f.Show();
        }

        private void firstDTP_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnChartDate_Click(object sender, EventArgs e)
        {
            int firstyear = firstDTP.Value.Year;
            int firstmonth = firstDTP.Value.Month;
            int firstday = firstDTP.Value.Day;
            int lastyear = lastDTP.Value.Year;
            int lastmonth = lastDTP.Value.Month;
            int lastday = lastDTP.Value.Day;

            string Query1 = "select date_format(buydate, '%m-%d') as date, sum(price) from `order` where buydate between date('"+firstyear +"-" + firstmonth + "-" + firstday + "') AND date('" + lastyear + "-" + lastmonth + "-" + lastday +"') group by buydate";
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            MySqlConnection conDB1 = new MySqlConnection(constring);
            MySqlCommand cmdDB1 = new MySqlCommand(Query1, conDB1);
            MySqlDataReader myreader1;
            conDB1.Open();
            myreader1 = cmdDB1.ExecuteReader();
            chartSales.Series[0].Points.Clear();
            try
            {
                while (myreader1.Read())
                {
                    string date = myreader1.GetString("date");
                    chartSales.Series["price"].Points.AddXY(date, myreader1.GetString("sum(price)"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //임시 datagridview
            DataTable da = db.GetDBTable(Query1);
            dataGridView2.DataSource = da;
            dataGridView2.Visible = true;
            conDB1.Close();
        }

        private void btnChartDate2_Click(object sender, EventArgs e)
        {
            int firstyear2 = firstDTP2.Value.Year;
            int firstmonth2 = firstDTP2.Value.Month;
            int firstday2 = firstDTP2.Value.Day;
            int lastyear2 = lastDTP2.Value.Year;
            int lastmonth2 = lastDTP2.Value.Month;
            int lastday2 = lastDTP2.Value.Day;

            ArrayList chartpdsale2 = new ArrayList();
            //상품판매액
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Querysale1 = "select name from `product`";
            //select count(product) from `order` where product = 'mask' and buydate between date('2020-03-11') and date('2020-03-13') group by buydate
            MySqlConnection consaleDB1 = new MySqlConnection(constring);
            MySqlCommand cmdsaleDB1 = new MySqlCommand(Querysale1, consaleDB1);
            MySqlDataReader myreadersale1;
            try
            {
                consaleDB1.Open();
                myreadersale1 = cmdsaleDB1.ExecuteReader();
                while (myreadersale1.Read())
                {
                    string sName = myreadersale1.GetString("name");
                    chartpdsale2.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            chartSales2.Series.Clear();
            Series series1 = chartSales2.Series.Add((string)chartpdsale2[0]);
            Series series2 = chartSales2.Series.Add((string)chartpdsale2[1]);
            Series series3 = chartSales2.Series.Add((string)chartpdsale2[2]);
            Series series4 = chartSales2.Series.Add((string)chartpdsale2[3]);
            Series series5 = chartSales2.Series.Add((string)chartpdsale2[4]);
            Series series6 = chartSales2.Series.Add((string)chartpdsale2[5]);
            Series series7 = chartSales2.Series.Add((string)chartpdsale2[6]);

            string Query0 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[0] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB0 = new MySqlConnection(constring);
            MySqlCommand cmdDB0 = new MySqlCommand(Query0, conDB0);
            MySqlDataReader myreader0;
            try
            {
                conDB0.Open();
                myreader0 = cmdDB0.ExecuteReader();
                while (myreader0.Read())
                {
                    string sCount = myreader0.GetString("count(product)");
                    string sDay = myreader0.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[0]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "00");
            }
            string Query1 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[1] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB1 = new MySqlConnection(constring);
            MySqlCommand cmdDB1 = new MySqlCommand(Query1, conDB1);
            MySqlDataReader myreader1;
            try
            {
                conDB1.Open();
                myreader1 = cmdDB1.ExecuteReader();
                while (myreader1.Read())
                {
                    string sCount = myreader1.GetString("count(product)");
                    string sDay = myreader1.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[1]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "11");
            }

            string Query2 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[2] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB2 = new MySqlConnection(constring);
            MySqlCommand cmdDB2 = new MySqlCommand(Query2, conDB2);
            MySqlDataReader myreader2;
            try
            {
                conDB2.Open();
                myreader2 = cmdDB2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sCount = myreader2.GetString("count(product)");
                    string sDay = myreader2.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[2]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "22");
            }

            string Query3 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[3] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB3 = new MySqlConnection(constring);
            MySqlCommand cmdDB3 = new MySqlCommand(Query3, conDB3);
            MySqlDataReader myreader3;
            try
            {
                conDB3.Open();
                myreader3 = cmdDB3.ExecuteReader();
                while (myreader3.Read())
                {
                    string sCount = myreader3.GetString("count(product)");
                    string sDay = myreader3.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[3]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "33");
            }

            string Query4 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[4] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB4 = new MySqlConnection(constring);
            MySqlCommand cmdDB4 = new MySqlCommand(Query4, conDB4);
            MySqlDataReader myreader4;
            try
            {
                conDB4.Open();
                myreader4 = cmdDB4.ExecuteReader();
                while (myreader4.Read())
                {
                    string sCount = myreader4.GetString("count(product)");
                    string sDay = myreader4.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[4]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "44");
            }

            string Query5 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[5] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB5 = new MySqlConnection(constring);
            MySqlCommand cmdDB5 = new MySqlCommand(Query5, conDB5);
            MySqlDataReader myreader5;
            try
            {
                conDB5.Open();
                myreader5 = cmdDB5.ExecuteReader();
                while (myreader5.Read())
                {
                    string sCount = myreader5.GetString("count(product)");
                    string sDay = myreader5.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[5]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "55");
            }

            string Query6 = "select date_format(buydate, '%m-%d') as date, count(product) from `order` where product = '" + chartpdsale2[6] + "' and buydate between date('" + firstyear2 + "-" + firstmonth2 + "-" + firstday2 + "') and date('" + lastyear2 + "-" + lastmonth2 + "-" + lastday2 + "') group by buydate";
            MySqlConnection conDB6 = new MySqlConnection(constring);
            MySqlCommand cmdDB6 = new MySqlCommand(Query6, conDB6);
            MySqlDataReader myreader6;
            try
            {
                conDB6.Open();
                myreader6 = cmdDB6.ExecuteReader();
                while (myreader6.Read())
                {
                    string sCount = myreader6.GetString("count(product)");
                    string sDay = myreader6.GetString("date");
                    chartSales2.Series[(string)chartpdsale2[6]].Points.AddXY(sDay, sCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "66");
            }

        }
    }
}
