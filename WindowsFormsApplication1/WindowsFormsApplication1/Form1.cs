using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
            string chuoi = "Data Source=.\\SQLEXPRESS;Initial Catalog=god;Integrated Security=True;";
            SqlCommand cmd;
            SqlConnection conn;
            SqlDataReader dr,dr1;
            DataTable dt,dt1;
            public void kn()
            {
                try
                {
                    conn = new SqlConnection(chuoi);
                    conn.Open();
                }
                catch (Exception ex) { }
            }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                kn();
                cmd = new SqlCommand("select * from BanAn", conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Columns.Add("Tenban", typeof(string));
                dt.Columns.Add("MaBan", typeof(string));
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "TenBan";
                comboBox1.DisplayMember = "TenBan";
                conn.Close();
            }
            catch (Exception ex) { }
            try
            {
                kn();
                cmd = new SqlCommand("select * from Menu", conn);
                dr1 = cmd.ExecuteReader();
                dt1 = new DataTable();
                dt1.Columns.Add("TenMon", typeof(string));
                dt1.Columns.Add("MaMon", typeof(string));
                dt1.Load(dr1);
                comboBox2.DataSource = dt1;
                comboBox2.ValueMember = "TenMon";
                comboBox2.DisplayMember = "TenMon";
                conn.Close();
            }
            catch (Exception ex) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kn();
            cmd = new SqlCommand("select * from Sodobandan where TenBan='" + comboBox1.SelectedValue + "'", conn);
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kn();
            cmd = new SqlCommand("select *from Sodobandan where TenBan='"+comboBox1.SelectedValue+"'", conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            cmd.CommandText = "Insert into Sodobandan values('"+comboBox1.SelectedValue+"','"+comboBox2.SelectedValue+"','"+soluong.Text+"','"+dongia.Text+"','"+thanhtien.Text+"')";
            int i = cmd.ExecuteNonQuery();
            if (i > 0) MessageBox.Show("Thanh Cong", "Thong Bao");
            else
                MessageBox.Show("Loi");
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            conn.Close();
            cmd.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                kn();
                cmd = new SqlCommand("select *from Sodobandan where TenBan='" + comboBox1.SelectedValue + "'", conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                cmd.CommandText = "delete from Sodobandan where TenBan='" + comboBox1.SelectedValue + "'";
                int i = cmd.ExecuteNonQuery();
                if (i > 0) MessageBox.Show("Thanh Cong", "Thong Bao");
                else
                    MessageBox.Show("Loi");
                dataGridView1.DataSource = dt;
                dataGridView1.Show();
                conn.Close();
                cmd.Dispose();
            }
            catch(Exception ex){}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kn();
            cmd = new SqlCommand("select *from Sodobandan where TenBan='" + comboBox1.SelectedValue + "'", conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            cmd.CommandText = "delete from Sodobandan where TenBan='" + comboBox1.SelectedValue + "'";
            int i = cmd.ExecuteNonQuery();
            if (i > 0) MessageBox.Show("Thanh Cong", "Thong Bao");
            else
                MessageBox.Show("Loi");
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
            conn.Close();
            cmd.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
