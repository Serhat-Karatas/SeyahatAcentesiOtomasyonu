using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeyahatDefterim
{
    public partial class Yönetici_innerjoin : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        string sqlSorgu;
        public static string SqlCon = @"Data Source=.......\SQLEXPRESS;Initial Catalog=SeyahatDefteri;Integrated Security=True";

        public Yönetici_innerjoin()
        {
            InitializeComponent();
        }
        public void GridDoldur(String sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sefer");
            dataGridView1.DataSource = ds.Tables["Sefer"];
            con.Close();
        }
        private void Yönetici_innerjoin_Load(object sender, EventArgs e)
        {
            sqlSorgu = "select Sefer.*, user.* from Seferler INNER JOIN user ON Sefer.sID = user.sID";
            GridDoldur(sqlSorgu);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                sqlSorgu = "select Sefer.*, user.* from Seferler INNER JOIN user ON Sefer.sID = user.sID where Sefer.hedef like '%" + textBox1.Text + "%'";
                GridDoldur(sqlSorgu);
            }
        }
    }
}
