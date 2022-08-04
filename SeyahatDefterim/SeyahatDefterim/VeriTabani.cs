using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace SeyahatDefterim
{
    
    class VeriTabani
    {
        private static int blu;
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source=........\SQLEXPRESS;Initial Catalog=SeyahatDefteri;Integrated Security=True";
        //User Id=sa, password=XXXXXXXXX

        public static bool BaglantiDurum()
        {
            using (con=new SqlConnection(SqlCon))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (SqlException exp)
                {                 
                    MessageBox.Show(exp.Message);
                    return false;
                }

            }

        }

        public static void GridTumunuDoldur(DataGridView gridim,string tablo)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from "+tablo, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, tablo);
            gridim.DataSource = ds.Tables[tablo];
            // gridim.DataSource = ds.Tables[0];
            con.Close(); 


        }


        public static string MD5Sifrele(string sifrelenecekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            dizi = md5.ComputeHash(dizi);   //dizinin hash degeri cikariliyor.

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            string metin = sb.ToString();
            if (blu == 0)
            {
                blu++;
                metin = MD5Sifrele(metin);       //2 kere md5 sifreler.
                blu--;
            }
           
            return metin.ToString();

        }
       
        public static bool GirisKontrol(string usr,string sifre)
        {
            Client musteri =Client.getInstance();
            string sorgu = "select * from user where username=@name and code=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@name",usr);
            cmd.Parameters.AddWithValue("@pass", MD5Sifrele(sifre));
            con.Open(); 
            dr = cmd.ExecuteReader();
           
            if (dr.Read())
            {
                string column = dr["admin"].ToString();
                bool columnValue = Convert.ToBoolean(dr["admin"]);
                musteri.set(columnValue, "123");
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }


        public static void KomutYolla(String sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
