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
    public partial class ProductModify : Form
    {
        public ProductModify()
        {
            InitializeComponent();
            FillComboProduct();
        }

        private void ProductModify_Load(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(51, 153, 255);
            btnMdfy.BackColor = Color.FromArgb(51, 153, 255);
        }
        
        public void FillComboProduct()
        {
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query = "SELECT * FROM product";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while(myReader.Read())
                {
                    string sName = myReader.GetString("name");
                    cbBPdName.Items.Add(sName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "  11");
            }
        }

        private void btnMdfy_Click(object sender, EventArgs e)
        {
            string constring1 = "server=localhost; uid=root; password=apmsetup; database=smartcart;";
            string Query1 = "SELECT * FROM product WHERE name = '" + cbBPdName.SelectedItem + "'";
            string PdPrice = null;
            MySqlConnection condata1 = new MySqlConnection(constring1);
            MySqlCommand cmddata1 = new MySqlCommand(Query1, condata1);
            MySqlDataReader myreader;
            try
            {
                condata1.Open();
                myreader = cmddata1.ExecuteReader();
                while(myreader.Read())
                {
                    PdPrice = textPriceMdfy.Text;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "  22");
            }

            string Query2 = "UPDATE product SET price = " + Convert.ToInt32(PdPrice) + " WHERE name = '" + cbBPdName.SelectedItem + "'";
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
                MessageBox.Show(ex.Message +"  33");
            }

            MessageBox.Show("수정되었습니다.", "관리자");
            Dispose(true);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("취소되었습니다.", "관리자");
            Dispose(true);
        }
    }
}
