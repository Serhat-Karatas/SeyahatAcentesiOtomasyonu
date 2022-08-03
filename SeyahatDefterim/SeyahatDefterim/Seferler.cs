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
    public partial class Seferler : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        public static string SqlCon = @"Data Source=......\SQLEXPRESS;Initial Catalog=SeyahatDefteri;Integrated Security=True";
        string sqlSorgu;
        public Seferler()
        {
            InitializeComponent();
        }

        public void GridDoldur(String sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"Sefer");
            dataGridView1.DataSource = ds.Tables["Sefer"];
            con.Close();
        }

        private void Seferler_Load(object sender, EventArgs e)
        {
             if (!Client.musteri.Yetki())               //NORMAL KULLANICI
             {
                 yöneticiİnnerJoinToolStripMenuItem.Visible = false;     
                 button2.Visible = false;
                 button3.Visible = false;
                 button4.Visible = false;
                 button5.Visible = false;               
             }
             else
             {
                 button1.Visible = false;              //ADMİN
                 paraYükleToolStripMenuItem.Visible = false;
             }
            VeriTabani.GridTumunuDoldur(dataGridView1, "Sefer");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Sefer";
            dataGridView1.Columns[3].HeaderCell.Value = "Alınan Bilet Sayısı";  //header text ile aynı işi yapar.
            dataGridView1.Columns[4].HeaderText = "Fiyat";
            dataGridView1.Columns[5].HeaderText = "Tarih";


        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            HedefTextBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            izahTextBox.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DolulukTextBox.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            FiyatTextBox.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if(Convert.ToInt32(DolulukTextBox.Text) == 10)
            {
                button1.Enabled = false;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            HedefTextBox.Clear();
            izahTextBox.Clear();
            DolulukTextBox.Clear();
            FiyatTextBox.Clear();
            dateTimePicker1.Value = DateTime.Now; 
        }

        private void button4_Click(object sender, EventArgs e)
        {                                                                                                                                                                  //money tipi
             string sql = "insert into Sefer(hedef, izah, doluluk, fiyat, tarih) values ('"+HedefTextBox.Text+"','"+izahTextBox.Text+"',"+DolulukTextBox.Text+","+ FiyatTextBox.Text +",'"+dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")+"')";
            VeriTabani.KomutYolla(sql);

           /* con = new SqlConnection(SqlCon);
            string sql = "insert into Sefer(hedef, izah, doluluk, fiyat, tarih) values (@travel,@explanation,@fullness,@price,@date)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@travel", HedefTextBox.Text);
            cmd.Parameters.AddWithValue("@explanation", izahTextBox.Text);
            cmd.Parameters.AddWithValue("@fullness", Convert.ToInt32(DolulukTextBox.Text));
            cmd.Parameters.AddWithValue("@price", Convert.ToInt32(FiyatTextBox.Text));
            cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();*/

            VeriTabani.GridTumunuDoldur(dataGridView1, "Sefer");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "delete from Sefer where sID="+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + " and hedef='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
            VeriTabani.KomutYolla(sql);
            VeriTabani.GridTumunuDoldur(dataGridView1, "Sefer");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sil = FiyatTextBox.Text.Remove(FiyatTextBox.Text.Length-5,5);
            string sql = "update Sefer set hedef='" + HedefTextBox.Text + "',izah='"+ izahTextBox.Text + "',doluluk="+DolulukTextBox.Text+",fiyat="+sil+ ",tarih='" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' where sID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
            VeriTabani.KomutYolla(sql);
            VeriTabani.GridTumunuDoldur(dataGridView1, "Sefer");
        }

        private void parolaDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParolaDegistir a = new ParolaDegistir();
            a.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          if (textBox1.Text != "")
          {     
             if (radioButton1.Checked)
             {//isme göre
                 if (radioButton4.Checked)
                 {
                     sqlSorgu = "select * from Sefer where hedef like '%" + textBox1.Text + "%' order by hedef ASC";
                     GridDoldur(sqlSorgu);
                 }
                 else if (radioButton5.Checked)
                 {
                     sqlSorgu = "select * from Sefer where hedef like '%" + textBox1.Text + "%' order by hedef DESC";
                     GridDoldur(sqlSorgu);
                 }
             }
             else if (radioButton2.Checked)
             {//doluluk
                 if (radioButton4.Checked)
                 {
                     sqlSorgu = "select * from Sefer where doluluk>" + textBox1.Text;
                     GridDoldur(sqlSorgu);
                 }
                 else if (radioButton5.Checked)
                 {
                     sqlSorgu = "select * from Sefer where doluluk<=" + textBox1.Text;
                     GridDoldur(sqlSorgu);
                 }
             }

             else if (radioButton6.Checked)
             {//fiyat
                 if (radioButton4.Checked)
                 {
                     sqlSorgu = "select * from Sefer where fiyat>" + textBox1.Text + " order by fiyat ASC";
                     GridDoldur(sqlSorgu);
                 }
                 else if (radioButton5.Checked)
                 {
                     sqlSorgu = "select * from Sefer where fiyat<=" + textBox1.Text + " order by fiyat DESC";
                     GridDoldur(sqlSorgu);
                 }
             }
          }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (radioButton4.Checked)
                {
                    sqlSorgu = "select * from Sefer where tarih>='" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' order by tarih ASC";
                    GridDoldur(sqlSorgu);
                }
                else if (radioButton5.Checked)
                {
                    sqlSorgu = "select * from Sefer where tarih<'" + dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' order by tarih DESC";
                    GridDoldur(sqlSorgu);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (Client.musteri.getBalance() >= Convert.ToInt32(FiyatTextBox.Text))
            {
                int doluluk = Convert.ToInt32(DolulukTextBox.Text)+1;
                int bakiye = Client.musteri.getBalance() - Convert.ToInt32(FiyatTextBox.Text);
                Client.musteri.set(bakiye,"123");
                string sql = "update user set balance="+bakiye.ToString()+",user.sID="+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + " where username='"+Client.musteri.getUsername()+"' and code='"+Client.musteri.getPass()+"'";
                VeriTabani.KomutYolla(sql);
                string sql2 = "update Sefer set doluluk=" + doluluk.ToString() + " where hedef='" + HedefTextBox.Text + "' and sID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ";
                VeriTabani.KomutYolla(sql2);
                VeriTabani.GridTumunuDoldur(dataGridView1, "Sefer");
            }
        }

        private void yöneticiİnnerJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yönetici_innerjoin a = new Yönetici_innerjoin();
            a.ShowDialog();
        }
    }
}
