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
    public partial class RezerveIzin : Form
    {
        public RezerveIzin()
        {
            InitializeComponent();
        }
        int StokKodu = StokCikisi.StokKodu;
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        int IzinIsteyen = Giris.id;

        void listele()
        {
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],RezerveAcan[REZERVE AÇAN],StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ]," +
                "Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK],Tanim[TANIM],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],format(Tutar,'###,###,###.###')[TOPLAM TUTAR],Tarih[TARİH] from Rezerv where StokKodu=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", StokKodu);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bindingSource1.DataSource = dt;
            bgl.baglanti().Close();
        }
        public void listele_projekodu()
        {
            
            comboProje4.Items.Clear();

            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboProje4.Items.Add(dr["ProjeKodu"]);
               
            }
            bgl.baglanti().Close();

        }
        bool durum;
        void kontrol()
        {
            for (int i = 0; i < comboProje4.Text.Length; i++)
                if (!char.IsDigit(comboProje4.Text[i]))
                {
                    durum = false;
                }
                else
                {
                    durum = true;
                }
    
        }
        bool durum2;
        void kontrol2()
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboProje4.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum2 = true;
            }
            else durum2 = false;
            bgl.baglanti().Close();

        }
        bool durum3;
        void kontrol3()
        {
            
            SqlCommand komut = new SqlCommand("Select * from RezervIzin where RezerveID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextRezerveID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum3 = true;
            }
            else
            {
                durum3 = false;
            }
        }
        bool durum4;
        void kontrol4()
        {
            kontrol3();
            if(durum3 == true)
            {
                SqlCommand komut = new SqlCommand("Select Miktar from Rezerv where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TextRezerveID.Text);
                decimal RezervMiktar = Convert.ToDecimal(komut.ExecuteScalar());

                SqlCommand komut2 = new SqlCommand("Select sum(IstenenMiktar) from RezervIzin where RezerveID=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TextRezerveID.Text);
                decimal izinMiktar = Convert.ToDecimal(komut2.ExecuteScalar());
                if (decimal.Parse(TextMiktar3.Text) <= RezervMiktar - izinMiktar)
                {
                    durum4 = true;
                }
                else
                {
                    durum4 = false;
                }
                
                bgl.baglanti().Close();


            }
            else
            {
                durum4 = true;
            }
        }
        private void RezerveIzin_Load(object sender, EventArgs e)
        {
            listele();
            listele_projekodu();

            

        }

        private void comboProje4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach (char chr in comboProje4.Text)
                {
                    if (!char.IsNumber(chr))
                    {
                        MessageBox.Show("PROJE KODU TAM SAYI OLMALI", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboProje4.Text = "";
                        TextFirma4.Text = "";
                        RichProje4.Text = "";

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", comboProje4.Text);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            TextFirma4.Text = dr["Firma"].ToString();
                            RichProje4.Text = dr["Proje"].ToString();
                        }
                    }

                }
                bgl.baglanti().Close();


            }
        }

        private void comboProje4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboProje4.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma4.Text = dr["Firma"].ToString();
                RichProje4.Text = dr["Proje"].ToString();
            }
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;

        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TextRezerveID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TextRezerveAcan.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextStokKodu3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboProje3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TextFirma3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            RichProje3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TextUrunAdi3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TextUretici3.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            TextYuzey3.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            TextBoy3.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            TextEn3.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            TextKalinlik3.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            RichTanim3.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            TextBirim3.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            string birimFiyati = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
            string yenibirimFiyati = birimFiyati.Replace(",", "");

            TextBirimFiyati.Text = yenibirimFiyati.Replace(".", ",");
            string miktar = dataGridView1.Rows[secilen].Cells[15].Value.ToString();
            string yeniMiktar = miktar.Replace(",", "");
            TextMiktar.Text = yeniMiktar.Replace(".", ",");



        }
        decimal izinMiktar;
        private void button1_Click(object sender, EventArgs e)
        {
            if(decimal.Parse(TextMiktar3.Text) <= decimal.Parse(TextMiktar.Text))
            {
                kontrol();
                if (durum == true)
                {
                    kontrol2();
                    if (durum2 == true)
                    {
                        
                        kontrol4();
                        if (durum4 == true)
                        {

                            SqlCommand komut = new SqlCommand("insert into RezervIzin (RezerveIzinIsteyen,RezerveAcan,StokKodu,ProjeKodu,Firma,Proje,UrunAdi,Uretici,Yuzey,Boy,En,Kalinlik," +
                                "Tanim,Birim,KullanilacakProjeKodu,KullanilacakFirma,KullanilacakProje,BirimFiyati,IstenenMiktar,Tutar,Tarih,RezerveID) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14," +
                                "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", IzinIsteyen);
                            komut.Parameters.AddWithValue("@p2", TextRezerveAcan.Text);
                            komut.Parameters.AddWithValue("@p3", TextStokKodu3.Text);
                            komut.Parameters.AddWithValue("@p4", comboProje3.Text);
                            komut.Parameters.AddWithValue("@p5", TextFirma3.Text);
                            komut.Parameters.AddWithValue("@p6", RichProje3.Text);
                            komut.Parameters.AddWithValue("@p7", TextUrunAdi3.Text);
                            komut.Parameters.AddWithValue("@p8", TextUretici3.Text);
                            komut.Parameters.AddWithValue("@p9", TextYuzey3.Text);
                            komut.Parameters.AddWithValue("@p10", TextBoy3.Text);
                            komut.Parameters.AddWithValue("@p11", TextEn3.Text);
                            komut.Parameters.AddWithValue("@p12", TextKalinlik3.Text);
                            komut.Parameters.AddWithValue("@p13", RichTanim3.Text);
                            komut.Parameters.AddWithValue("@p14", TextBirim3.Text);
                            komut.Parameters.AddWithValue("@p15", comboProje4.Text);
                            komut.Parameters.AddWithValue("@p16", TextFirma4.Text);
                            komut.Parameters.AddWithValue("@p17", RichProje4.Text);
                            komut.Parameters.AddWithValue("@p18", decimal.Parse(TextBirimFiyati.Text));
                            komut.Parameters.AddWithValue("@p19", decimal.Parse(TextMiktar3.Text));
                            komut.Parameters.AddWithValue("@p20", decimal.Parse(TextBirimFiyati.Text) * decimal.Parse(TextMiktar3.Text));
                            komut.Parameters.AddWithValue("@p21", dateTimePicker1.Value);
                            komut.Parameters.AddWithValue("@p22", TextRezerveID.Text);
                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            MessageBox.Show("İSTEK OLUŞTURULDU", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                         
                            SqlCommand komut = new SqlCommand("Select Miktar from Rezerv where ID=@p1", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", TextRezerveID.Text);
                            decimal rezervMiktar = Convert.ToDecimal(komut.ExecuteScalar());
                            
                            SqlCommand komut2 = new SqlCommand("Select sum(IstenenMiktar) from RezervIzin where RezerveID=@p1", bgl.baglanti());
                            komut2.Parameters.AddWithValue("@p1", TextRezerveID.Text);
                            izinMiktar = Convert.ToDecimal(komut2.ExecuteScalar());

                            
                           

                            MessageBox.Show("BU REZERVDEN ZATEN İSTEKTE BULUNULDU. REZERVE MİKTARI : " + rezervMiktar + " İZİN İSTENİLMİŞ MİKTAR :" + izinMiktar + "", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                    }
                    else
                    {
                        MessageBox.Show("BÖYLE BİR PROJE KODU BULUNAMADI", "İZİN İSTEĞİ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PROJE KODU TAM SAYI OLMALIDIR", "İZİN İSTEĞİ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("İSTENİLEN MİKTAR REZERVE EDİLMİŞ MİKTARDAN FAZLA OLAMAZ", "İZİN İSTEĞİ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextMiktar3_TextChanged(object sender, EventArgs e)
        {

                foreach (char chr in TextMiktar3.Text)
                {
                    if (!char.IsDigit(chr))
                    {
                        MessageBox.Show("MİKTAR SAYI OLMALIDIR", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextMiktar3.Text = "";

                    }
                   
                }


            
        }
    }
}
