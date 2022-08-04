using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SeyahatDefterim
{
    public partial class Loading : Form 
    {
        int sayac;
        int a;
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataAdapter da;
        SqlDataReader dr;
        //DataSet ds;
        public static string SqlCon = @"Data Source=......\SQLEXPRESS;Initial Catalog=SeyahatDefteri;Integrated Security=True";
        public Loading()
        {
            InitializeComponent();
            sayac = 0;
            a = 0;
            // VeriTabani.BaglantiDurum();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* public void Login()
         {
             string sorgu = "select * from user where username=@user and code=@pass";
             con = new SqlConnection(SqlCon);
             cmd = new SqlCommand(sorgu, con);
             cmd.Parameters.AddWithValue("@user", textBox1.Text);
             cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox2.Text));
             con.Open(); 
             dr = cmd.ExecuteReader();

             if (dr.Read())
             {

             }
             else
             {
                 MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                 textBox1.Clear();
                 textBox2.Clear();
                 textBox1.Focus();
                 sayac++;

             }
             con.Close();

             if (sayac == 3)
             {
                 textBox1.Enabled = false;
                 textBox2.Enabled = false;
                 timer1.Enabled = true;
             }
         }*/
        //textBox1.Text, VeriTabani.MD5Sifrele(textBox2.Text), "123"
        private void button1_Click(object sender, EventArgs e)
        {

            // Login();

            if (VeriTabani.GirisKontrol(textBox1.Text, textBox2.Text))
            {
                Client musteri =Client.getInstance();
                musteri.set(textBox1.Text, VeriTabani.MD5Sifrele(textBox2.Text), "123");
                this.Hide();         
                Seferler a = new Seferler();
                a.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                sayac++;
                if (sayac == 3)
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    timer1.Enabled = true;
                }
            }
            

            /* string sorgu = "select * from user where username='"+textBox1.Text+"' and code='"+VeriTabani.MD5Sifrele(textBox2.Text)+"'";
             con = new SqlConnection(SqlCon);
             cmd = new SqlCommand(sorgu,con);
             con.Open();
             dr = cmd.ExecuteReader();

             if (dr.Read()) 
             { 

             
             }
             else
             {
                 MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                 textBox1.Clear();
                 textBox2.Clear();
                 textBox1.Focus();
                 sayac++;                
             }

             con.Close();

             if (sayac == 3) 
             {
                 textBox1.Enabled = false;
                 textBox2.Enabled = false;
                 timer1.Enabled = true;
             }*/

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = (3 - a).ToString() + " saniye bekleyiniz.";
            if (a++ == 3)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                timer1.Enabled = false;
            }

        }
    }
}
