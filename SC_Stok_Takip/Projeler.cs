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
using System.IO;

namespace SC_Stok_Takip
{
    public partial class Projeler : Form
    {
        public Projeler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
        bool durum;
        void kontrol()
        {
            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler where ProjeKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextProjeKodu.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = true;
            }
            else durum = false;
            bgl.baglanti().Close();
        }
        bool durum2;
        void kontrol2()
        {
            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler where ProjeKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum2 = true;
            }
            else durum2 = false;
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kontrol();
            if (durum == false )

            {
                if (TextProjeKodu.Text != "")
                {
                    SqlCommand komut = new SqlCommand("insert into Projeler (ProjeKodu,Firma,Proje) values (@p1,@p2,@p3)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", int.Parse(TextProjeKodu.Text));
                    komut.Parameters.AddWithValue("@p2", TextFirmaAdi.Text);
                    komut.Parameters.AddWithValue("@p3", RichProje.Text);
                    MessageBox.Show("Proje Kartı Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //siparisVerme.listele_projekodu();
                    //stokCikisi.listele_projekodu();

                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                
                else MessageBox.Show("PROJE KODU BOŞ GEÇİLEMEZ", "Proje Kartı Oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else MessageBox.Show("BÖYLE BİR PROJE KARTI ZATEN VAR", "Proje Kartı Oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Projeler", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
            bindingSource1.DataSource = dt;
           // bindingSource2.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void Projeler_Load(object sender, EventArgs e)
        {
            listele();

        }
        void yazdir()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TextWriter tw = new StreamWriter(path + @"\Projeler.csv",false,Encoding.UTF8);
            tw.Write("\n");
            for (int a = 1; a < dataGridView1.Columns.Count + 1; a++)
            {
                tw.Write(dataGridView1.Columns[a - 1].HeaderText.ToString() + ";");
            }
            tw.Write("\n");

            for (int x = 0; x < dataGridView1.Rows.Count-1; x++)
            {
                for (int j = 0; j < dataGridView1.Rows[x].Cells.Count; j++)
                {

                    tw.Write(dataGridView1.Rows[x].Cells[j].Value.ToString() + ";");
                    
                }

                tw.Write("\n");

            }
            
            tw.Close();
            MessageBox.Show("Proje Bilgileri Excell'e Başarıyla Aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yazdir();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
          
            
                if(textBox2.Text != "")
                {

                    SqlCommand komut = new SqlCommand("update Projeler set ProjeKodu=@p1,Firma=@p2,Proje=@p3 where ID=@p4", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox2.Text);
                    komut.Parameters.AddWithValue("@p2", textBox3.Text);
                    komut.Parameters.AddWithValue("@p3", textBox1.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listele();
                }
             else MessageBox.Show("PROJE KODU BOŞ GEÇİLEMEZ", "Proje Kartı Oluşturulamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kontrol2();
            if(durum2 == true)
            {
                SqlCommand komut = new SqlCommand("delete from Projeler where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox4.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("KAYIT SİLİNDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("BÖYLE BİR KAYIT BULUNAMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox4.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            textBox1.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
        }

        private void dataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView2.FilterString;
        }

        private void dataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView2.SortString;
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            yazdir();
                
        }
    }
}
