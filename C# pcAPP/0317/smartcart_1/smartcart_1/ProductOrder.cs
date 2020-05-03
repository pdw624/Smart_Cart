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

    public partial class ProductOrder : Form
    {
        //콤보박스
        public void FillComboName()
        {
            string constring = "datasource = localhost; database=smartcart; username=root; password=apmsetup;";
            string Query = "select * from product";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
                while(myReader.Read())
                {
                    string sName = myReader.GetString("name");
                    //"select " + cbBoxPdName.SelectedItem.ToString + " "
                    cbBoxPdName.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        public ProductOrder()
        {
            InitializeComponent();
            FillComboName();
        }

        //주문 폼 실행 시 
        private void ProductOrder_Load(object sender, EventArgs e)
        {
            btnOrder.BackColor = Color.FromArgb(51, 153, 255);
            btnCancel.BackColor = Color.FromArgb(51, 153, 255);
        }

        //상품 주문 버튼 클릭 시 
        private void btnOrder_Click(object sender, EventArgs e)
        {

            string constring1 = "datasource = localhost; username = root; password = apmsetup; database = smartcart;";
            string Query1 = "SELECT * FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            string sQuantity = null;
            string PdQuantity = null;
            MySqlConnection condata1 = new MySqlConnection(constring1);
            MySqlCommand cmddata1 = new MySqlCommand(Query1, condata1);
            MySqlDataReader myreader;
            try
            {
                condata1.Open();
                myreader = cmddata1.ExecuteReader();
                while(myreader.Read())
                {
                    sQuantity = myreader.GetString("quantity");
                    PdQuantity = textQuanAdd.Text;
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string Query2 = "UPDATE product SET quantity = " + (Convert.ToInt32(sQuantity) + Convert.ToInt32(PdQuantity)) + " WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            MySqlConnection condata2 = new MySqlConnection(constring1);
            MySqlCommand cmddata2 = new MySqlCommand(Query2, condata2);
            MySqlDataReader myreader2;
            try
            {
                condata2.Open();
                myreader2 = cmddata2.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query2, condata2);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("주문되었습니다.", "관리자");
            Dispose(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소되었습니다.", "관리자");
            Dispose(true);
        }
    }
    
}
