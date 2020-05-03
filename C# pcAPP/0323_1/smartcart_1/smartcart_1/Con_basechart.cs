using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace smartcart_1
{
    class Con_basechart
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
            if (conn.State.ToString().Equals("Closed"))
            {
                conn.ConnectionString = sConnString;
                conn.Open();
            }
        }

        public void CloseDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public MySqlDataReader MySqlDataReader(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            
            return cmd.ExecuteReader();
        }
    }
}
