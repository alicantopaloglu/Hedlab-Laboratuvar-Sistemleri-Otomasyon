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

namespace SC_Stok_Takip
{

    public partial class Giris : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public static int id;
        public static int yy1;
        public static int yy2;
        public static int yy3;
        public static int yy4;
        public static int yy5;
        public static int yy6;
        public static int yy7;
        public static int yy8;
        public static int yy9;
        public static int yy10;
        public static int yy11;
        public static int yy12;
        public static int yy13;
        public static int yy14;

        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Kullanicilar where KullaniciID=@p1 and Sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextID.Text);
            komut.Parameters.AddWithValue("@p2", TextSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {


                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ID YA DA ŞİFRE", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            bgl.baglanti().Close();
        }

        private void TextID_TextChanged(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select KullaniciID,StokGirisi,StokCikisi,StokDurumu,KullaniciPaneli," +
                "SiparisGirisi,FirmaGirisi,Projeler,SatinAlma,Raporlar,StokCikisDuzenleme, StokGirisDuzenleme, SiparisDuzenle,SiparisIptal,RezerveAcma from Kullanicilar where KullaniciID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                id = Convert.ToInt32(dr["KullaniciID"]);

                yy1 = Convert.ToInt32(dr["StokGirisi"]);
               
                yy2 = Convert.ToInt32(dr["StokCikisi"]);
              

                yy3 = Convert.ToInt32(dr["StokDurumu"]);
               
                yy4 = Convert.ToInt32(dr["KullaniciPaneli"]);
             
                yy5 = Convert.ToInt32(dr["SiparisGirisi"]);
              
                yy6 = Convert.ToInt32(dr["FirmaGirisi"]);
          
                yy7 = Convert.ToInt32(dr["Projeler"]);
          
                yy8 = Convert.ToInt32(dr["SatinAlma"]);
         
                yy9 = Convert.ToInt32(dr["Raporlar"]);
          
                yy10 = Convert.ToInt32(dr["StokCikisDuzenleme"]);
                yy11 = Convert.ToInt32(dr["StokGirisDuzenleme"]);
                yy12 = Convert.ToInt32(dr["SiparisDuzenle"]);
                yy13 = Convert.ToInt32(dr["SiparisIptal"]);
                yy14 = Convert.ToInt32(dr["RezerveAcma"]);

            }
            //int y1 = Convert.ToInt32(komut.ExecuteScalar());
            //TextYetki.Text = yetki1.ToString();
            //yetki = int.Parse(TextYetki.Text);
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Font = new Font("Times New Roman", 9, FontStyle.Regular);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font("Times New Roman", 8, FontStyle.Regular);
        }
    }
    }

