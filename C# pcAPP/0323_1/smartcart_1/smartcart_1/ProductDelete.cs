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
    public partial class textPdDelete : Form
    {
        public void FillComboName()
        {
            string PdCstr = "datasource = localhost; database=smartcart; username=root; password=apmsetup;";
            string Query = "SELECT name FROM product";
            MySqlConnection PdconDB = new MySqlConnection(PdCstr);
            MySqlCommand PDcmdDB = new MySqlCommand(Query, PdconDB);
            MySqlDataReader Myreader;
            try
            {
                PdconDB.Open();
                Myreader = PDcmdDB.ExecuteReader();
                while(Myreader.Read())
                {
                    string sName = Myreader.GetString("name");
                    cbBoxPdName.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public textPdDelete()
        {
            InitializeComponent();
            FillComboName();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query2 = "DELETE FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(Query2, conDB);
            MySqlDataReader myreader;
            try
            {
                conDB.Open();
                myreader = cmdDB.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query2, conDB);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            

            MessageBox.Show("삭제되었습니다.", "관리자");
            Dispose(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소되었습니다.", "관리자");
            Dispose(true);
        }

        private void ProductDelete_Load(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(51, 153, 255);
            btnDelete.BackColor = Color.FromArgb(51, 153, 255);
        }

        private void cbBoxPdName_SelectedValueChanged(object sender, EventArgs e)
        {
            string PdCstr = "server=localhost; database=smartcart; uid=root; password=apmsetup;";
            string Query1 = "SELECT * FROM product WHERE name = '" + cbBoxPdName.SelectedItem + "'";
            MySqlConnection MemconDB1 = new MySqlConnection(PdCstr);
            MySqlCommand MemcmdDB1 = new MySqlCommand(Query1, MemconDB1);
            MySqlDataReader myReader1;

            MemconDB1.Open();
            myReader1 = MemcmdDB1.ExecuteReader();

            while (myReader1.Read())
            {
                string sName = myReader1.GetString("name");
                string sPrice = myReader1.GetString("price");
                string sQuantity = myReader1.GetString("quantity");

                textPdInfo.Text = "상품 이름 : " + sName + "\r\n가격 : " + sPrice + "\r\n수량 : " + sQuantity;
            }

        }
    }
}
