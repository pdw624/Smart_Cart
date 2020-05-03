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
            string constring = "datasource = localhost; database=smartcart; username=root; password=apmsetup;";
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
    }
}
