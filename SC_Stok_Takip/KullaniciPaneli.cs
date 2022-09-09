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
    public partial class KullaniciPaneli : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public KullaniciPaneli()
        {
            InitializeComponent();
        }
        int yetki1, yetki2, yetki3, yetki4, yetki5, yetki6, yetki7, yetki8, yetki9, yetki10, yetki11, yetki12, yetki13,yetki14;

        void listele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kullanicilar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();
        }
        
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                yetki8 = 1;
            }
            else
            {
                yetki8 = 0;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                yetki9 = 1;
            }
            else
            {
                yetki9 = 0;
            }
        }
        bool durum1 = true;
        bool durum2 = true;

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                yetki11 = 1;
            }
            else
            {
                yetki11 = 0;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                yetki10 = 1;
            }
            else
            {
                yetki10 = 0;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                yetki13 = 1;
            }
            else
            {
                yetki13 = 0;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                yetki12 = 1;
            }
            else
            {
                yetki12 = 0;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TextKullaniciAdi.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            TextID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            TextSifre.Text= dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            textBox1.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            textBox2.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            textBox4.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            textBox5.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            textBox6.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();
            textBox7.Text = dataGridView2.Rows[secilen].Cells[9].Value.ToString();
            textBox8.Text = dataGridView2.Rows[secilen].Cells[10].Value.ToString();
            textBox9.Text = dataGridView2.Rows[secilen].Cells[11].Value.ToString();
            textBox10.Text = dataGridView2.Rows[secilen].Cells[13].Value.ToString();
            textBox11.Text = dataGridView2.Rows[secilen].Cells[12].Value.ToString();
            textBox12.Text = dataGridView2.Rows[secilen].Cells[14].Value.ToString();
            textBox13.Text = dataGridView2.Rows[secilen].Cells[13].Value.ToString();
            textBox14.Text = dataGridView2.Rows[secilen].Cells[15].Value.ToString();

            if (int.Parse(textBox1.Text) == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (int.Parse(textBox2.Text) == 1)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (int.Parse(textBox3.Text) == 1)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (int.Parse(textBox4.Text) == 1)
            {
                checkBox6.Checked = true;
            }
            else
            {
                checkBox6.Checked = false;
            }
            if (int.Parse(textBox5.Text) == 1)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
            if (int.Parse(textBox6.Text) == 1)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if (int.Parse(textBox7.Text) == 1)
            {
                checkBox9.Checked = true;
            }
            else
            {
                checkBox9.Checked = false;
            }
            if (int.Parse(textBox8.Text) == 1)
            {
                checkBox8.Checked = true;
            }
            else
            {
                checkBox8.Checked = false;
            }
            if (int.Parse(textBox9.Text) == 1)
            {
                checkBox7.Checked = true;
            }
            else
            {
                checkBox7.Checked = false;
            }
            if (int.Parse(textBox10.Text) == 1)
            {
                checkBox10.Checked = true;
            }
            else
            {
                checkBox10.Checked = false;
            }
            if (int.Parse(textBox11.Text) == 1)
            {
                checkBox11.Checked = true;
            }
            else
            {
                checkBox11.Checked = false;
            }
            if (int.Parse(textBox12.Text) == 1)
            {
                checkBox12.Checked = true;
            }
            else
            {
                checkBox12.Checked = false;
            }
            if (int.Parse(textBox13.Text) == 1)
            {
                checkBox13.Checked = true;
            }
            else
            {
                checkBox13.Checked = false;
            }
            if (int.Parse(textBox14.Text) == 1)
            {
                checkBox14.Checked = true;
            }
            else
            {
                checkBox14.Checked = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kontrol();
            kontrol2();
            if (durum1 == false && durum2 == false)
            {
                MessageBox.Show("KAYIT BAŞARISIZ", "Kullanıcı ID ve Şifresi Tam Sayı Olmalıdır", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (durum1 == true && durum2 == true)
            {

                SqlCommand komut = new SqlCommand("update Kullanicilar set KullaniciAdi=@p1,Sifre=@p2,StokGirisi=@p3,StokCikisi=@p4,StokDurumu=@p5," +
                "KullaniciPaneli=@p6,SiparisGirisi=@p7,FirmaGirisi=@p8,Projeler=@p9,SatinAlma=@p10,Raporlar=@p11,StokCikisDuzenleme=@p12,StokGirisDuzenleme=@p13,SiparisDuzenle=@p14,SiparisIptal=@p15,RezerveAcma=@p16 where KullaniciID=@p17", bgl.baglanti());
                komut.Parameters.AddWithValue("@p17", int.Parse(TextID.Text));
                komut.Parameters.AddWithValue("@p1", TextKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", TextSifre.Text);
                komut.Parameters.AddWithValue("@p3", yetki1);
                komut.Parameters.AddWithValue("@p4", yetki2);
                komut.Parameters.AddWithValue("@p5", yetki3);
                komut.Parameters.AddWithValue("@p6", yetki4);
                komut.Parameters.AddWithValue("@p7", yetki5);
                komut.Parameters.AddWithValue("@p8", yetki6);
                komut.Parameters.AddWithValue("@p9", yetki7);
                komut.Parameters.AddWithValue("@p10", yetki8);
                komut.Parameters.AddWithValue("@p11", yetki9);
                komut.Parameters.AddWithValue("@p12", yetki10);
                komut.Parameters.AddWithValue("@p13", yetki11);
                komut.Parameters.AddWithValue("@p14", yetki12);
                komut.Parameters.AddWithValue("@p15", yetki13);
                komut.Parameters.AddWithValue("@p16", yetki14);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Kullanıcı Düzenlendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                yetki14 = 1;
            }
            else
            {
                yetki14 = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Kullanicilar where KullaniciID=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TextID.Text);
            komut.ExecuteNonQuery();
            listele();
            bgl.baglanti().Close();
            
        }

        void kontrol()
        {

            for (int i = 0; i < TextID.Text.Length; i++)
                if (!char.IsDigit(TextID.Text[i]))
                    durum1 = false;   //Eğer karakter sayı değilse false döner
            
        }
        void kontrol2()
        {

            for (int i = 0; i < TextSifre.Text.Length; i++)
                if (!char.IsDigit(TextSifre.Text[i]))
                    durum2 = false;   //Eğer karakter sayı değilse false döner

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kontrol();
            kontrol2();
            
            if (durum1 == false && durum2 == false)
            {
                MessageBox.Show("KAYIT BAŞARISIZ", "Kullanıcı ID ve Şifresi Tam Sayı Olmalıdır", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ( durum1 ==true && durum2 == true)
            {
                SqlCommand komut = new SqlCommand("insert into Kullanicilar (KullaniciID,KullaniciAdi,Sifre,StokGirisi,StokCikisi,StokDurumu," +
                "KullaniciPaneli,SiparisGirisi,FirmaGirisi,Projeler,SatinAlma,Raporlar,StokCikisDuzenleme,StokGirisDuzenleme,SiparisDuzenle,SiparisIptal,RezerveAcma) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p8,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
                komut.Parameters.AddWithValue("@p2", TextKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p3", TextSifre.Text);
                komut.Parameters.AddWithValue("@p4", yetki1);
                komut.Parameters.AddWithValue("@p5", yetki2);
                komut.Parameters.AddWithValue("@p6", yetki3);
                komut.Parameters.AddWithValue("@p7", yetki4);
                komut.Parameters.AddWithValue("@p8", yetki5);
                komut.Parameters.AddWithValue("@p9", yetki6);
                komut.Parameters.AddWithValue("@p10", yetki7);
                komut.Parameters.AddWithValue("@p11", yetki8);
                komut.Parameters.AddWithValue("@p12", yetki9);
                komut.Parameters.AddWithValue("@p13", yetki10);
                komut.Parameters.AddWithValue("@p14", yetki11);
                komut.Parameters.AddWithValue("@p15", yetki12);
                komut.Parameters.AddWithValue("@p16", yetki13);
                komut.Parameters.AddWithValue("@p17", yetki14);


                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Oluşturuldu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                yetki7 = 1;
            }
            else
            {
                yetki7 = 0;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                yetki6 = 1;
            }
            else
            {
                yetki6 = 0;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                yetki5 = 1;
            }
            else
            {
                yetki5 = 0;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                yetki4 = 1;
            }
            else
            {
                yetki4 = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                yetki3 = 1;
            }
            else
            {
                yetki3 = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                yetki2 = 1;
            }
            else
            {
                yetki2 = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                yetki1 = 1;
            }
            else
            {
                yetki1 = 0;
            }
        }

        private void KullaniciPaneli_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
