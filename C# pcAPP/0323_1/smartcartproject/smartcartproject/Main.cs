using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace smartcartproject
{
    
    public partial class Main : Form
    {

        Thread _thread = null;
        Con_datatable db;
        Login loginForm;
        
        private int index;

        public Main()
        {
            InitializeComponent();
            db = new Con_datatable();
            db.ConnectDB();
        }

        public void fThreadStart()
        {            
            _thread = new Thread(Run);

            _thread.Start();
        }

        private void Run()
        {

            while(true)
            {
                if(this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate ()
                    {
                    
                        string sql = "SELECT * FROM cart";
                        DataTable dt = db.GetDBTable(sql);
                        dataGridView1.DataSource = dt;

                        string sql1 = "select * from `order`";
                        DataTable dt1 = db.GetDBTable(sql1);
                        dataGridView4.DataSource = dt1;
                       
                        this.Refresh();
                    }));

                    Thread.Sleep(3000);
                }
            }
        }

        //private void autoUpdate(object sender, EventArgs e)
        //{

        //    int goIndex = 0;

        //    for (int i = 0; i < dataGridView1.RowCount; i++)
        //    {
        //        if (dataGridView1[0, i].Value.Equals(currentRowUpdateDate))
        //        {
        //            goIndex = i;
        //            break;
        //        }
        //    }
        //    if (currentRowIndex == 0)
        //    {
        //        dataGridView1.FirstDisplayedCell = dataGridView1.Rows[0].Cells[0];

        //    }
        //    else
        //    {
        //        dataGridView1.FirstDisplayedCell = dataGridView1.Rows[goIndex].Cells[0];
        //    }
        //}

        private void RowChartClear()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                //for (int i = 0; i < 9; i++)
                //{
                //    chart1.Series[i].Points.Clear();
                //}
            }
        }

        private void UpdateProdPrice(DateTime updatedDate, long[] prodArr)
        {
            List<string> prodPriceList = new List<string>();
            for (int i = 0; i < prodArr.Length; i++)
            {
                if (prodArr[i] != 0)
                {
                    prodPriceList.Add(prodArr[i].ToString());
                }
            }
            string[] rowData = new string[prodPriceList.Count + 1];
            rowData[0] = string.Format("{0:yyyy-MM-dd}", updatedDate);

            for (int i = 0; i < prodPriceList.Count; i++)
            {
                rowData[i + 1] = prodPriceList[i];
            }
        }

        //private void GridScroll(object sender, ScrollEventArgs e)
        //{
        //    currentRowIndex = dataGridView1.FirstDisplayedCell.RowIndex;
        //    currentRowUpdateDate = dataGridView1[0, currentRowIndex].Value.ToString();
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
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

            //실시간 카트 현황
            string sql = "SELECT * FROM cart";
            DataTable dt = db.GetDBTable(sql);
            dataGridView1.DataSource = dt;

            //출고 내역(판매 내역)
            string sql1 = "select * from `order`";
            DataTable dt1 = db.GetDBTable(sql1);
            dataGridView4.DataSource = dt1;

            //쓰레드 시작
            fThreadStart();
            
            //currentRowIndex = 0;

            //currentRowUpdateDate = dataGridView1[0, currentRowIndex].Value.ToString();

            //dataGridView1.Scroll += new ScrollEventHandler(GridScroll);
        }   

        private void button1_Click(object sender, EventArgs e)
        {
        }        

        public void ThreadAbort()
        {
            if(_thread.IsAlive)
            {
                _thread.Abort();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadAbort();
        }
    }
}
