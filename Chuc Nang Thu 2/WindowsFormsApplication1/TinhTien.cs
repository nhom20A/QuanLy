using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class TinhTien
    {
        public SqlConnection conn = new SqlConnection
        ("Data Source=.\\SQLEXPRESS;Initial Catalog=god;Integrated Security=True;");
        public void connet()
        {
            conn.Open();
        }
        public void close()
        {
            conn.Close();
        }
        public void tinhtien(string sl,string dongia)
        {
            
        }
    }
}
