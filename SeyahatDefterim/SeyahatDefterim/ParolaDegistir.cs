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
    public partial class ParolaDegistir : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataAdapter da;
        SqlDataReader dr;
        //DataSet ds;
        public static string SqlCon = @"Data Source=.........\SQLEXPRESS;Initial Catalog=SeyahatDefteri;Integrated Security=True";
        int sonuc;
        
        public ParolaDegistir()
        {
            InitializeComponent();
        }


        private void ParolaDegistir_Load(object sender, EventArgs e)
        {
            labelMesaj.Text = RandomSayı();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (captchaTextBox.Text.Equals(sonuc.ToString()))
            {
                labelMesaj.Text = "";
                if (yeniParolaTextBox.Text == yeniParolaTekrarTextBox.Text)
                {
                    EskiParoaKontrol();
                }
                else
                {
                    labelMesaj.Text = "Yeni parola ve tekrarı aynı değil.";
                    labelMesaj.Text = RandomSayı();
                    Temizle();
                }

            }
            else
            {
                labelMesaj.Text = "Captcha hatalı girildi.";
                Temizle();
                labelMesaj.Text = RandomSayı();
            }
        }

        public void EskiParoaKontrol()
        {
            Client musteri =Client.getInstance();
            string sorgu = "select code from user where username=@user and code=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user",musteri.getUsername());
            cmd.Parameters.AddWithValue("@pass",musteri.getPass());
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string sql = "update user set code='"+VeriTabani.MD5Sifrele(yeniParolaTextBox.Text)+"'";
                VeriTabani.KomutYolla(sql);
                MessageBox.Show("işlem başarılı.");
                con.Close();
                this.Close();
            }
            else
            {
                labelMesaj.Text = "Eski parolanız hatalı.";
                eskiParolaTextBox.Clear();
                eskiParolaTextBox.Focus();
                Temizle();
                labelMesaj.Text = RandomSayı();
                con.Close();
            }

        }

        public string RandomSayı()
        {
            Random rn = new Random();
            int a = rn.Next(0, 100);
            int b = rn.Next(0, 100);
            sonuc = a + b;
            string metin = a.ToString() + " + " + b.ToString() + "=";

            return metin;
        }

        private void Temizle()
        {
            yeniParolaTextBox.Clear();
            yeniParolaTekrarTextBox.Clear();
            yeniParolaTextBox.Focus();
        }





    }
}
