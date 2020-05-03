using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace smartcart
{
    class Con_datatable
    {
        public static string constring1 = "datasource=localhost; username=root; password=apmsetup; database=smartcart";
        MySqlConnection conn = new MySqlConnection();
        private string sConnString = "";
        public void ConnectDB()
        {
            try
            {
                sConnString = constring1;
            }
            catch
            {
            }
            if(conn.State.ToString().Equals("closed"))
            {
                conn.ConnectionString = sConnString;
                conn.Open();
            }
        }

        private  void CloseDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        public DataTable GetDBTable(string sql)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataTable dataTable1 = new DataTable();
            DataTable dt = dataTable1;
            adapter.Fill(dt);
            return dt;
        }
    }
}
