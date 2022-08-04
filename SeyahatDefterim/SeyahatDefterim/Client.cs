using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeyahatDefterim
{
    class Client
    {
        //public static Client musteri=new Client();     //Singleton sınıfını kullanmadan da yapabiliriz.Hatta daha iyi oldu
        static Client musteri;
        private string username;
        private string pass;
        private int balance;
        private bool admin;

        private Client()
        {

        }
        public static Client getInstance()
        {
            if (musteri == null)
            {
                musteri = new Client();
            }

            return musteri;

        }
        
        public void set(string isim,string sifre,int bakiye,bool yetki, string parola)
        {
            if (parola == "123")
            {
               musteri.username = isim;
               musteri.pass = sifre;
               musteri.balance = bakiye;
               musteri.admin = yetki;
            }
            else
            {
                MessageBox.Show("Yetkilendirme başarısız.");
            }
        }


        public void set(string isim, string sifre, string parola)
        {
            if (parola == "123")
            {
                musteri.username = isim;
                musteri.pass = sifre;
            }
            else
            {
                MessageBox.Show("Yetkilendirme başarısız.");
            }
        }

        public void set( string sifre, string parola)
        {
            if (parola == "123")
            {
                musteri.pass = sifre;
            }
            else
            {
                MessageBox.Show("Yetkilendirme başarısız.");
            }
        }



        public void set(int bakiye, string parola)
        {
            if (parola == "123")
            {
                musteri.balance = bakiye;
            }
            else
            {
                MessageBox.Show("Yetkilendirme başarısız.");
            }
        }
        public void set(bool yetki, string parola)
        {
            if (parola == "123")
            {
                musteri.admin = yetki;
            }
            else
            {
                MessageBox.Show("Yetkilendirme başarısız.");
            }
        }

        public string getUsername()
        {
            return musteri.username;
        }
        public string getPass()
        {
            return musteri.pass;
        }
        public int getBalance()
        {
            return musteri.balance;
        }
        public bool Yetki()
        {
            return musteri.admin;
        }




    }
}
