using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC_Stok_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StokGiris stokgiris = new StokGiris();
        private void button1_Click(object sender, EventArgs e)
        {

            StokGiris stokgiris = new StokGiris();
            stokgiris.Show();
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SiparisVerme siparisverme = new SiparisVerme();
            siparisverme.Show();
        }
        String yetki1 = Giris.yy1.ToString();
        String yetki2 = Giris.yy2.ToString();
        String yetki3 = Giris.yy3.ToString();
        String yetki4 = Giris.yy4.ToString();
        String yetki5 = Giris.yy5.ToString();
        String yetki6 = Giris.yy6.ToString();
        String yetki7 = Giris.yy7.ToString();
        String yetki8 = Giris.yy8.ToString();
        String yetki9 = Giris.yy9.ToString();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (int.Parse(yetki1) == 0)
            {
                button1.Enabled = false;
            }
            if (int.Parse(yetki2) == 0)
            {
                button2.Enabled = false;
            }
            if (int.Parse(yetki3) == 0)
            {
                button3.Enabled = false;
            }
            if (int.Parse(yetki4) == 0)
            {
                button5.Enabled = false;
            }
            if (int.Parse(yetki5) == 0)
            {
                button6.Enabled = false;
            }
            if (int.Parse(yetki6) == 0)
            {
                button7.Enabled = false;
            }
            if (int.Parse(yetki7) == 0)
            {
                button4.Enabled = false;
            }
            if (int.Parse(yetki8) == 0)
            {
                button8.Enabled = false;
            }
            if (int.Parse(yetki9) == 0)
            {
                button9.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SatınAlma satinalma = new SatınAlma();
            satinalma.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FirmaGirisi firmagirisi = new FirmaGirisi();
            firmagirisi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Projeler projeler = new Projeler();
            projeler.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StokCikisi stokcikisi = new StokCikisi();
            stokcikisi.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Raporlar raporlar = new Raporlar();
            raporlar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StokDurumu stokDurumu = new StokDurumu();
            stokDurumu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KullaniciPaneli kullaniciPaneli = new KullaniciPaneli();
            kullaniciPaneli.Show();
        }

     
    }
}
