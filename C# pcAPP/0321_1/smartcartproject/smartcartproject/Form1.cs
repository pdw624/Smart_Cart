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
    public partial class Form1 : Form
    {
        Con_datatable db;
        public Form1()
        {
            InitializeComponent();
            db = new Con_datatable();
            db.ConnectDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                Thread worker = new Thread(Run);

                worker.Start();
        }

        private void Run()
        {
            while (true)
            {
                string sql = "SELECT * FROM cart";
                DataTable dt = db.GetDBTable(sql);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTextBox(string.Empty);
        }
        
        private void UpdateTextBox(string data)
        {
            if (textBox7.InvokeRequired)
            {
                textBox7.BeginInvoke(new Action(() => textBox7.Text = data));
            }
            else
            {
                textBox7.Text = data;
            }
        }

    }
}
