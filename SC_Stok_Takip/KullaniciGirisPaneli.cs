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
    public partial class KullaniciGirisPaneli : Form
    {
        public KullaniciGirisPaneli()
        {
            InitializeComponent();
        }
        public static int id;
        public static int yetki;
        SqlBaglanti bgl = new SqlBaglanti();
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
            SqlCommand komut = new SqlCommand("Select Yetki from Kullanicilar where KullaniciID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            int yetki1 = Convert.ToInt32(komut.ExecuteScalar());
            TextYetki.Text = yetki1.ToString();
            yetki = int.Parse(TextYetki.Text);

            SqlCommand komut2 = new SqlCommand("Select KullaniciID from Kullanicilar where KullaniciID=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            int id1 = Convert.ToInt32(komut2.ExecuteScalar());
            ID.Text = id1.ToString();
            id = int.Parse(ID.Text);

        }
    }
}
