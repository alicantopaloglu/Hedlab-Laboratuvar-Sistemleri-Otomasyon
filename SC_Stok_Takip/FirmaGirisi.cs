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
    public partial class FirmaGirisi : Form
    {
        public string x;

        public FirmaGirisi()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
       

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Firmalar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           
            bindingSource1.DataSource = dt;
            
            bgl.baglanti().Close();
        }
        void listele2()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Firmalar", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bindingSource2.DataSource = dt;
            bgl.baglanti().Close();
        }
        
        bool durum1;
        bool durum2;
        bool durum3;
        
        void kontrol1()
        {
            if (TextFirmaAdi.Text == ""  | TextVergiNo.Text == "" | TextVergiDairesi.Text == "" )
            {
                durum1 = false;
            }
            else durum1 = true;
        }
        void kontrol2()
        {

            if (TextFirmaAdi2.Text == ""  | TextVergiNo2.Text == "" | TextVergiDairesi2.Text == "" )
            {
                durum2 = false;
            }
            else durum2 = true;
        }
        void kontrol3()
        {
            SqlCommand komut = new SqlCommand("Select FirmaAdi from Firmalar where FirmaAdi=@p1", bgl.baglanti());
            
            komut.Parameters.AddWithValue("@p1",TextFirmaAdi.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum3 = true;
            }
            else durum3 = false;
                
            
        }
       
        void yazdir()
        {
           
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            TextWriter tw = new StreamWriter(path+ @"\Firmalar.csv",false,Encoding.UTF8);
            tw.Write("\n");
            for (int a = 1; a < dataGridView1.Columns.Count + 1; a++)
            {
                tw.Write(dataGridView1.Columns[a - 1].HeaderText.ToString() + ";");
            }
            tw.Write("\n");

            for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
            {
                for (int j = 0; j < dataGridView1.Rows[x].Cells.Count; j++)
                {

                    tw.Write(dataGridView1.Rows[x].Cells[j].Value.ToString() + ";");

                }

                tw.Write("\n");

            }

            tw.Close();
            MessageBox.Show("Firma Bilgileri Excell'e Başarıyla Aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kontrol1();

            if (durum1 == true)
            {
                kontrol3();
                if( durum3 == false)
                {
                   
                    SqlCommand komut = new SqlCommand("insert into Firmalar (FirmaAdi,VergiDairesi,VergiNo,AdresBilgisi,Telefon) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextFirmaAdi.Text);
                    komut.Parameters.AddWithValue("@p2", TextVergiDairesi.Text);
                    komut.Parameters.AddWithValue("@p3", TextVergiNo.Text);
                    komut.Parameters.AddWithValue("@p4", TextAdres.Text);
                    komut.Parameters.AddWithValue("@p5", TextTel.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Firma Kartı Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    //satınAlma.FirmaList();
                    //stokGiris.FirmaList();
                }
                else MessageBox.Show("BÖYLE BİR FİRMA ZATEN VAR", "FİRMA KARTI OLUŞTURULAMADI", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else MessageBox.Show("BOŞ ALANLARI DOLDURUNUZ", "FİRMA KARTI OLUŞTURULAMADI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FirmaGirisi_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            yazdir();
        }

        private void TextTel_TextChanged(object sender, EventArgs e)
        {

            
         if(TextTel.Text.Length == 10)
            {
                TextTel.Text = String.Format("{0:(###) ###-####}", long.Parse(TextTel.Text));
            }
            
            

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TextFirmaAdi2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextVergiDairesi2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TextVergiNo2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TextAdres2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TexTel2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();



        }

        private void TexTel2_TextChanged(object sender, EventArgs e)
        {
            if (TexTel2.Text.Length == 10)
            {
                TexTel2.Text = String.Format("{0:(###) ###-####}", long.Parse(TexTel2.Text));
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kontrol2();
            if (durum2 == true)
            {
               
                    SqlCommand komut = new SqlCommand("update Firmalar set FirmaAdi=@p1,VergiDairesi=@p2,VergiNo=@p3,AdresBilgisi=@p4,Telefon=@p5 where ID=@p6", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextFirmaAdi2.Text);
                    komut.Parameters.AddWithValue("@p2", TextVergiDairesi2.Text);
                    komut.Parameters.AddWithValue("@p3", TextVergiNo2.Text);
                    komut.Parameters.AddWithValue("@p4", TextAdres2.Text);
                    komut.Parameters.AddWithValue("@p5", TexTel2.Text);
                    komut.Parameters.AddWithValue("@p6", textBox1.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("FirmaBilgisi Düzenlendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                listele2();


                    bgl.baglanti().Close();
                



            }
            else MessageBox.Show("BOŞ ALANLARI DOLDURUNUZ", "FİRMA KARTI DÜZENLENEMEDİ", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Firmalar where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("KAYIT SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            listele2();
            bgl.baglanti().Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            yazdir();
        }

        private void dataGridView1_FilterStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_SortStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Filter = this.dataGridView2.FilterString;
        }

        private void dataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Sort = this.dataGridView2.SortString;
        }
    }
}
