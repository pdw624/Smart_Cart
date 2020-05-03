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
    public partial class ProductRegister : Form
    {
        public ProductRegister()
        {
            InitializeComponent();
        }

        private void ProductRegister_Load(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(51, 153, 255);
            btnCancel.BackColor = Color.FromArgb(51, 153, 255); 
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost; database=smartcart; usid=root; password=apmsetup;";
            string Query = "INSERT INTO product (name, price) VALUES ('" + textPdName.Text + "', '" + textPdPrice.Text + "')";

            MySqlConnection conDB = new MySqlConnection(constring);
            MySqlCommand cmdDB = new MySqlCommand(Query, conDB);
            MySqlDataReader MyReader;
            try
            {
                conDB.Open();
                MyReader = cmdDB.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, conDB);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("등록되었습니다.", "관리자");
            Dispose(true);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소되었습니다.", "관리자");
            Dispose(true);
        }
    }
}
