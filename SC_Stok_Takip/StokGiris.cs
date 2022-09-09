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
    
    public partial class StokGiris : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
        BindingSource bindingSource3 = new BindingSource();
        public StokGiris()
        {
            InitializeComponent();
        }
        public void tablo1()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
             
                if(Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) =="")
                {
                    dataGridView1.Rows[i].Cells[10].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[11].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[11].Value = 0;
                }
            }
        }
        public void tablo2()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
               
                if (Convert.ToString(dataGridView2.Rows[i].Cells[10].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[10].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[11].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[11].Value = 0;
                }
                
            }
        }
        public void tablo3()
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                
                if (Convert.ToString(dataGridView3.Rows[i].Cells[14].Value) == "")
                {
                    dataGridView3.Rows[i].Cells[14].Value = 0;
                }
                if (Convert.ToString(dataGridView3.Rows[i].Cells[24].Value) == "")
                {
                    dataGridView3.Rows[i].Cells[24].Value = 0;
                }
            }
        }
        

        void listele_stok_karti()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
                "Birim[BİRİM],Tanim[TANIM],Tarih[TARİH],FORMAT(MinMiktar,'###,###,###.###')[MİN MİKTAR],FORMAT(MaxMiktar,'###,###,###.###')[MAX MİKTAR] from StokKarti order by StokKodu DESC", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bindingSource3.DataSource = dt;
            bgl.baglanti().Close();
        }
        void listele_stok_karti2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
                " Birim[BİRİM],Tanim[TANIM],Tarih[TARİH],FORMAT(MinMiktar,'###,###,###.###')[MİN MİKTAR],FORMAT(MaxMiktar,'###,###,###.###')[MAX MİKTAR] from StokKarti where StokKodu=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TextAra.Text);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();
            tablo2();
        }

        void listele_stok_girisi_2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY]," +
                "Boy[BOY],En[EN],Kalinlik[KALINLIK],Birim[BİRİM],Format(Miktar,'###,###,###.###')[MİKTAR],format(AlinanMiktar,'###,###,###.###')[ALINAN MİKTAR],format(KalanMiktar,'###,###,###.###')[KALAN MİKTAR],Tanim[TANIM],Aciklama[AÇIKLAMA], SAciklama[SATIN ALMA AÇIKLAMA]," +
                "TalepTarihi[TALEP TARİHİ],SiparisTarihi[SİPARİŞ TARİHİ],TerminTarihi[TERMİN TARİHİ],SiparisAcan[SİPARİŞİ AÇAN],Durumu[DURUMU],FirmaBilgisi[FİRMA BİLGİSİ],format(StokEklenenMiktar,'###,###,###.###')[STOK EKLENEN MİKTAR] from Siparis where Durumu != @p1 and Durumu != @p2 order by ID DESC", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", "STOĞA EKLENDİ");
            da.SelectCommand.Parameters.AddWithValue("@p2", "");

            da.Fill(dt);
            dataGridView3.DataSource = dt;
            bindingSource1.DataSource = dt;
            bgl.baglanti().Close();

        }
        void listele_stok_giris_duzenleme()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK],Tanim[TANIM],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI]," +
                "format(Miktar,'###,###,###.###')[MİKTAR],Tarih[TARİH],FirmaAdi[FİRMA ADI],VergiDairesi[VERGİ DAİRESİ],VergiNo[VERGİ NO],IrsaliyeNo[İRSALİYE NO],IrsaliyeTarihi[İRSALİYE TARİHİ],FaturaNo[FATURA NO],FaturaTarihi[FATURA TARİHİ]," +
                "KDV,format(KdvTutari,'###,###,###.###')[KDV TUTARI],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],ProjeKodu[PROJE KODU],GirisID[GİRİŞ ID],SiparisID[SİPARİŞ ID],Aciklama[AÇIKLAMA],SAciklama[SATIN ALMA AÇIKLAMA] From Stok_Girisleri where StokKodu=@p1 order by ID DESC", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TextStokKodu3.Text);
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            bindingSource2.DataSource = dt;
            bgl.baglanti().Close();
        }
        void listele_projekodu()
        {
            SqlCommand komut = new SqlCommand("Select top 10 * from Projeler order by ID DESC ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboProje.Items.Add(dr["ProjeKodu"]);
            }

        }
        public void FirmaList()
        {
            listBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select FirmaAdi from Firmalar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["FirmaAdi"]);
                listBox2.Items.Add(dr["FirmaAdi"]);
            }

        }

        private void BtnOlustur_Click(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand("insert into StokKarti (Yuzey,Uretici,Tanim,Boy,En,Kalinlik,Birim,Tarih,UrunAdi,MinMiktar,MaxMiktar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextYuzey.Text);
            komut.Parameters.AddWithValue("@p2", TextUretici.Text);
            komut.Parameters.AddWithValue("@p3", RichTanim.Text);
            komut.Parameters.AddWithValue("@p4", TextBoy.Text);
            komut.Parameters.AddWithValue("@p5", TextEn.Text);
            komut.Parameters.AddWithValue("@p6", TextKalinlik.Text);
            komut.Parameters.AddWithValue("@p7", TextBirim.Text);
            komut.Parameters.AddWithValue("@p8", Tarih.Value);
            komut.Parameters.AddWithValue("@p9", TextUrunAdi.Text);
            if(TextMax.Text == "" && TextMin.Text == "")
            {
                komut.Parameters.AddWithValue("@p10", 0);
                komut.Parameters.AddWithValue("@p11", 0);
                komut.ExecuteNonQuery();
            }
            else if(TextMax.Text == "")
            {
                komut.Parameters.AddWithValue("@p10", decimal.Parse(TextMin.Text));
                komut.Parameters.AddWithValue("@p11", 0);
                komut.ExecuteNonQuery();
            }
            else if(TextMin.Text == "")
            {
                komut.Parameters.AddWithValue("@p10", 0);
                komut.Parameters.AddWithValue("@p11", decimal.Parse(TextMax.Text));
               
                komut.ExecuteNonQuery();
            }
            else
            {
                komut.Parameters.AddWithValue("@p10", decimal.Parse(TextMin.Text));
                komut.Parameters.AddWithValue("@p11", decimal.Parse(TextMax.Text));
                komut.ExecuteNonQuery();
            }
           
            
            SqlCommand komut2 = new SqlCommand("insert into Devreden1 (Yuzey,Uretici,Tanim,Boy,En,Kalinlik,Birim,Tarih,UrunAdi,BirimFiyati,Miktar,ToplamTutar,MinMiktar,MaxMiktar) values (@p1," +
                "@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TextYuzey.Text);
            komut2.Parameters.AddWithValue("@p2", TextUretici.Text);
            komut2.Parameters.AddWithValue("@p3", RichTanim.Text);
            komut2.Parameters.AddWithValue("@p4", TextBoy.Text);
            komut2.Parameters.AddWithValue("@p5", TextEn.Text);
            komut2.Parameters.AddWithValue("@p6", TextKalinlik.Text);
            komut2.Parameters.AddWithValue("@p7", TextBirim.Text);
            komut2.Parameters.AddWithValue("@p8", Tarih.Value);
            komut2.Parameters.AddWithValue("@p9", TextUrunAdi.Text);
            komut2.Parameters.AddWithValue("@p10", 0);
            komut2.Parameters.AddWithValue("@p11", 0);
            komut2.Parameters.AddWithValue("@p12", 0);
            if (TextMax.Text == "" && TextMin.Text == "")
            {
                komut2.Parameters.AddWithValue("@p13", 0);
                komut2.Parameters.AddWithValue("@p14", 0);
               
                komut2.ExecuteNonQuery();
            }
            else if (TextMax.Text == "")
            {
                komut2.Parameters.AddWithValue("@p13", decimal.Parse(TextMin.Text));
                komut2.Parameters.AddWithValue("@p14", 0);
                komut2.ExecuteNonQuery();
            }
            else if (TextMin.Text == "")
            {
                komut2.Parameters.AddWithValue("@p13", 0);
                komut2.Parameters.AddWithValue("@p14", decimal.Parse(TextMax.Text));
                komut2.ExecuteNonQuery();
            }
            else
            {
                komut2.Parameters.AddWithValue("@p13", decimal.Parse(TextMin.Text));
                komut2.Parameters.AddWithValue("@p14", decimal.Parse(TextMax.Text));
                komut2.ExecuteNonQuery();
            }
            

            listele_stok_karti();
            bgl.baglanti().Close();
            TextYuzey.Text = String.Empty;
            TextUretici.Text = String.Empty;
            TextBoy.Text = String.Empty;
            TextEn.Text = String.Empty;
            TextKalinlik.Text = String.Empty;
            TextBirim.Text = String.Empty;
            TextUrunAdi.Text = String.Empty;
            RichTanim.Text = String.Empty;
            Tarih.ResetText();



        }

        int girisid = Giris.id;
        String Giris_duzenleme = Giris.yy11.ToString();
        private void StokGiris_Load(object sender, EventArgs e)
        {
            if(int.Parse(Giris_duzenleme) == 0)
            {
                BtnDuzenle2.Enabled = false;
            }
            timer1.Interval = 360000;
            TextGirisID.Text = girisid.ToString();
            //listele_stok_karti2();
            listele_stok_karti();
            listele_stok_girisi_2();
            listele_projekodu();
            FirmaList();
            tablo1();
           // tablo2();
            tablo3();
          

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TextStokKodu.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            TextYuzey2.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            TextUretici2.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            RichTanim2.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();
            TextBoy2.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            TextEn2.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            TextKalinlik2.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            TextBirim2.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            Tarih2.Text = dataGridView2.Rows[secilen].Cells[9].Value.ToString();
            TextUrunAdi2.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            string min = dataGridView2.Rows[secilen].Cells[10].Value.ToString();
           string minYeni=min.Replace(",","");
            TextMin2.Text = minYeni.Replace(".", ",");
            string max = dataGridView2.Rows[secilen].Cells[11].Value.ToString();
            string maxYeni = max.Replace(",", "");
            TextMax2.Text = maxYeni.Replace(".",",");
      

        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            duzenleme_kontrol();
            if (duzenleme_durum == true)
            {
               
                    SqlCommand komut = new SqlCommand("update StokKarti set Yuzey=@p1,Uretici=@p2,Tanim=@p3,Boy=@p4,En=@p5,Kalinlik=@p6,Birim=@p7,Tarih=@p8,UrunAdi=@p9,MinMiktar=@p10,MaxMiktar=@p11 where StokKodu=@p12", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextYuzey2.Text);
                    komut.Parameters.AddWithValue("@p2", TextUretici2.Text);
                    komut.Parameters.AddWithValue("@p3", RichTanim2.Text);
                    komut.Parameters.AddWithValue("@p4", TextBoy2.Text);
                    komut.Parameters.AddWithValue("@p5", TextEn2.Text);
                    komut.Parameters.AddWithValue("@p6", TextKalinlik2.Text);
                    komut.Parameters.AddWithValue("@p7", TextBirim2.Text);
                    komut.Parameters.AddWithValue("@p8", Tarih2.Value);
                    komut.Parameters.AddWithValue("@p9", TextUrunAdi2.Text);
                    komut.Parameters.AddWithValue("@p10", decimal.Parse(TextMin2.Text));
                    komut.Parameters.AddWithValue("@p11", decimal.Parse(TextMax2.Text));
                    komut.Parameters.AddWithValue("@p12", TextStokKodu.Text);
                    komut.ExecuteNonQuery();

                    SqlCommand komut2 = new SqlCommand("update Devreden1 set Yuzey=@p1,Uretici=@p2,Tanim=@p3,Boy=@p4,En=@p5,Kalinlik=@p6,Birim=@p7,Tarih=@p8,UrunAdi=@p9,MinMiktar=@p10,MaxMiktar=@p11 where StokKodu=@p12", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", TextYuzey2.Text);
                    komut2.Parameters.AddWithValue("@p2", TextUretici2.Text);
                    komut2.Parameters.AddWithValue("@p3", RichTanim2.Text);
                    komut2.Parameters.AddWithValue("@p4", TextBoy2.Text);
                    komut2.Parameters.AddWithValue("@p5", TextEn2.Text);
                    komut2.Parameters.AddWithValue("@p6", TextKalinlik2.Text);
                    komut2.Parameters.AddWithValue("@p7", TextBirim2.Text);
                    komut2.Parameters.AddWithValue("@p8", Tarih2.Value);
                    komut2.Parameters.AddWithValue("@p9", TextUrunAdi2.Text);
                    komut2.Parameters.AddWithValue("@p10", decimal.Parse(TextMin2.Text));
                    komut2.Parameters.AddWithValue("@p11", decimal.Parse(TextMax2.Text));
                    komut2.Parameters.AddWithValue("@p12", TextStokKodu.Text);
                    komut2.ExecuteNonQuery();

                    SqlCommand komut3 = new SqlCommand("update Siparis set Yuzey=@p1,Uretici=@p2,Tanim=@p3,Boy=@p4,En=@p5,Kalinlik=@p6,Birim=@p7,UrunAdi=@p9 where StokKodu=@p10", bgl.baglanti());

                    komut3.Parameters.AddWithValue("@p1", TextYuzey2.Text);
                    komut3.Parameters.AddWithValue("@p2", TextUretici2.Text);
                    komut3.Parameters.AddWithValue("@p3", RichTanim2.Text);
                    komut3.Parameters.AddWithValue("@p4", TextBoy2.Text);
                    komut3.Parameters.AddWithValue("@p5", TextEn2.Text);
                    komut3.Parameters.AddWithValue("@p6", TextKalinlik2.Text);
                    komut3.Parameters.AddWithValue("@p7", TextBirim2.Text);

                    komut3.Parameters.AddWithValue("@p9", TextUrunAdi2.Text);
                    komut3.Parameters.AddWithValue("@p10", TextStokKodu.Text);
                    komut3.ExecuteNonQuery();
                    MessageBox.Show("KAYIT DÜZENLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele_stok_karti2();
                    bgl.baglanti().Close();
                   
               
                
            }
            else
            {
                
                    SqlCommand komut = new SqlCommand("update StokKarti set Yuzey=@p1,Uretici=@p2,Tanim=@p3,Boy=@p4,En=@p5,Kalinlik=@p6,Birim=@p7,Tarih=@p8,UrunAdi=@p9,MinMiktar=@p10,MaxMiktar=@p11 where StokKodu=@p12", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextYuzey2.Text);
                    komut.Parameters.AddWithValue("@p2", TextUretici2.Text);
                    komut.Parameters.AddWithValue("@p3", RichTanim2.Text);
                    komut.Parameters.AddWithValue("@p4", TextBoy2.Text);
                    komut.Parameters.AddWithValue("@p5", TextEn2.Text);
                    komut.Parameters.AddWithValue("@p6", TextKalinlik2.Text);
                    komut.Parameters.AddWithValue("@p7", TextBirim2.Text);
                    komut.Parameters.AddWithValue("@p8", Tarih2.Value);
                    komut.Parameters.AddWithValue("@p9", TextUrunAdi2.Text);
                    komut.Parameters.AddWithValue("@p10", decimal.Parse(TextMin2.Text));
                    komut.Parameters.AddWithValue("@p11", decimal.Parse(TextMax2.Text));
                    komut.Parameters.AddWithValue("@p12", TextStokKodu.Text);
                    komut.ExecuteNonQuery();

                    SqlCommand komut2 = new SqlCommand("update Devreden1 set Yuzey=@p1,Uretici=@p2,Tanim=@p3,Boy=@p4,En=@p5,Kalinlik=@p6,Birim=@p7,Tarih=@p8,UrunAdi=@p9,MinMiktar=@p10,MaxMiktar=@p11 where StokKodu=@p12", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", TextYuzey2.Text);
                    komut2.Parameters.AddWithValue("@p2", TextUretici2.Text);
                    komut2.Parameters.AddWithValue("@p3", RichTanim2.Text);
                    komut2.Parameters.AddWithValue("@p4", TextBoy2.Text);
                    komut2.Parameters.AddWithValue("@p5", TextEn2.Text);
                    komut2.Parameters.AddWithValue("@p6", TextKalinlik2.Text);
                    komut2.Parameters.AddWithValue("@p7", TextBirim2.Text);
                    komut2.Parameters.AddWithValue("@p8", Tarih2.Value);
                    komut2.Parameters.AddWithValue("@p9", TextUrunAdi2.Text);
                    komut2.Parameters.AddWithValue("@p10", decimal.Parse(TextMin2.Text));
                    komut2.Parameters.AddWithValue("@p11", decimal.Parse(TextMax2.Text));
                    komut2.Parameters.AddWithValue("@p12", TextStokKodu.Text);
                    komut2.ExecuteNonQuery();
                    listele_stok_karti2();
                    bgl.baglanti().Close();
                    MessageBox.Show("KAYIT DÜZENLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void ComboFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ComboFirma_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
      
        
        
       
        bool duzenleme_durum;
        void duzenleme_kontrol()
        {
            SqlCommand komut = new SqlCommand("Select * from Siparis where StokKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                duzenleme_durum = true;
            }
            else
            {
                duzenleme_durum = false;
            }
        }
   
        

        bool durum3;
        void kontrol3()
        {
            SqlCommand komut = new SqlCommand("Select AlinanMiktar from Siparis where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            decimal AlinanMiktar = Convert.ToDecimal(komut.ExecuteScalar());

            SqlCommand komut2 = new SqlCommand("Select StokEklenenMiktar from Siparis where ID=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            decimal StokEklenenMiktar = Convert.ToDecimal(komut2.ExecuteScalar());
            decimal YeniStok = StokEklenenMiktar + decimal.Parse(TextGelenMiktar.Text);
            decimal x = 0.001M;

            if(YeniStok > AlinanMiktar + x)
            {
                durum3 = false;
            }
            else
            {
                durum3 = true;
            }


        }
        
        public decimal ToplamKdvTutar(decimal BirimFiyati, decimal KDV, decimal Miktar)
        {

            decimal totalKdvTutar = BirimFiyati * KDV / 100 * Miktar;
            return totalKdvTutar;

        }
        public decimal ToplamTutar(decimal BirimFiyati, decimal KDV, decimal Miktar)
        {
            decimal kdvTutar = (BirimFiyati * KDV / 100);// bir ürün için kdv bedeli
            //decimal ToplamkdvTutar = (BirimFiyati * KDV / 100) * Miktar; // ürünlerin tümüne uygluanan kdv tutarı
            decimal yeniBirimFiyat = BirimFiyati + kdvTutar;
            decimal toplamTutar = Miktar * yeniBirimFiyat;
            return toplamTutar;
        }

        private void BtnYeniKayit_Click(object sender, EventArgs e)
        {
            kontrol3();
            if(durum3 == false)
            {
                MessageBox.Show("SATINALMANIN ALDIĞI MİKTARDAN FAZLA GİRİŞ YAPILAMAZ", "GİRİŞ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                if (listBox1.SelectedItem==null)
                {
                    MessageBox.Show("FİRMA BİLGİSİ BOŞ BIRAKILAMAZ", "GİRİŞ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                        SqlCommand komut2 = new SqlCommand("Select ToplamTutar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                        komut2.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                        decimal eskiToplamTutar = Convert.ToDecimal(komut2.ExecuteScalar());

                        SqlCommand komut1 = new SqlCommand("Select Miktar from devreden1 where StokKodu=@p1", bgl.baglanti());
                        komut1.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                        decimal EskiMiktar = Convert.ToDecimal(komut1.ExecuteScalar());

                        decimal YeniToplamTutar = ToplamTutar(decimal.Parse(TextBirimFiyati.Text), decimal.Parse(TextKdv.Text), decimal.Parse(TextGelenMiktar.Text)) + eskiToplamTutar;
                        decimal YBirimFiyat = YeniToplamTutar / (decimal.Parse(TextGelenMiktar.Text) + EskiMiktar);


                        SqlCommand komut14 = new SqlCommand("Select StokEklenenMiktar from siparis where ID=@p1", bgl.baglanti());
                        komut14.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
                        decimal StokEklenenMiktar = Convert.ToDecimal(komut14.ExecuteScalar());
                        decimal yeniStokEklenen = StokEklenenMiktar + decimal.Parse(TextGelenMiktar.Text);
                        decimal yeniMiktar = decimal.Parse(TextGelenMiktar.Text) + EskiMiktar;






                        SqlCommand komut = new SqlCommand("update Devreden1 set Miktar=@p1,BirimFiyati=@p2," +
                            "ToplamTutar=@p4 where StokKodu=@p5", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", yeniMiktar);
                        komut.Parameters.AddWithValue("@p2", YBirimFiyat);
                        ////komut.Parameters.AddWithValue("@p3", SonKdvTutar);
                        komut.Parameters.AddWithValue("@p4", YeniToplamTutar);
                        komut.Parameters.AddWithValue("@p5", TextStokKodu2.Text);
                        komut.ExecuteNonQuery();


                        SqlCommand komut3 = new SqlCommand("insert into Stok_Girisleri (StokKodu,Yuzey,Uretici,Tanim,Boy,En,Kalinlik,Miktar,Birim,BirimFiyati,Tarih,UrunAdi,FirmaAdi,VergiDairesi,VergiNo,IrsaliyeNo," +
                                   "FaturaNo,FaturaTarihi,IrsaliyeTarihi,KDV,KdvTutari,ToplamTutar,GirisID,ProjeKodu,SiparisID,Aciklama,SAciklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27)", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu2.Text));
                        komut3.Parameters.AddWithValue("@p2", TextYuzey3.Text);
                        komut3.Parameters.AddWithValue("@p3", TextUretici3.Text);
                        komut3.Parameters.AddWithValue("@p4", RichTanim3.Text);
                        komut3.Parameters.AddWithValue("@p5", TextBoy3.Text);
                        komut3.Parameters.AddWithValue("@p6", TextEn3.Text);
                        komut3.Parameters.AddWithValue("@p7", decimal.Parse(TextKalinlik3.Text));
                        komut3.Parameters.AddWithValue("@p8", decimal.Parse(TextGelenMiktar.Text));
                        komut3.Parameters.AddWithValue("@p9", TextBirim3.Text);
                        komut3.Parameters.AddWithValue("@p10", decimal.Parse(TextBirimFiyati.Text));
                        komut3.Parameters.AddWithValue("@p11", Tarih3.Value);
                        komut3.Parameters.AddWithValue("@p12", TextUrunAdi3.Text);
                        komut3.Parameters.AddWithValue("@p13", listBox1.SelectedItem);
                        komut3.Parameters.AddWithValue("@p14", TextVergiDairesi.Text);
                        komut3.Parameters.AddWithValue("@p15", TextVergiNo.Text);
                        komut3.Parameters.AddWithValue("@p16", TextIrsaliyeNo.Text);
                        komut3.Parameters.AddWithValue("@p17", TextFaturaNo.Text);
                        komut3.Parameters.AddWithValue("@p18", FaturaTarih.Value);
                        komut3.Parameters.AddWithValue("@p19", IrsaliyeTarih.Value);
                        komut3.Parameters.AddWithValue("@p20", decimal.Parse(TextKdv.Text));
                        komut3.Parameters.AddWithValue("@p21", ToplamKdvTutar(decimal.Parse(TextBirimFiyati.Text), decimal.Parse(TextKdv.Text), decimal.Parse(TextGelenMiktar.Text)));
                        komut3.Parameters.AddWithValue("@p22", ToplamTutar(decimal.Parse(TextBirimFiyati.Text), decimal.Parse(TextKdv.Text), decimal.Parse(TextGelenMiktar.Text)));
                        komut3.Parameters.AddWithValue("@p23", TextGirisID.Text);
                        komut3.Parameters.AddWithValue("@p24", int.Parse(ComboProje.Text));
                        komut3.Parameters.AddWithValue("@p25", int.Parse(TextID.Text));
                        komut3.Parameters.AddWithValue("@p26", TextAciklama.Text);
                        komut3.Parameters.AddWithValue("@p27", TextSAciklama.Text);
                        komut3.ExecuteNonQuery();

                        SqlCommand komut11 = new SqlCommand("Select Miktar from Siparis where ID = @p1", bgl.baglanti());
                        komut11.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
                        decimal SMiktar = Convert.ToDecimal(komut11.ExecuteScalar());




                        decimal Kmiktar = SMiktar - yeniStokEklenen;



                        SqlCommand komut13 = new SqlCommand("update Siparis set KalanMiktar=@p1, StokEklenenMiktar=@p3, Durumu =@p4 where ID=@p2", bgl.baglanti());

                        if (Kmiktar != 0)
                        {
                            komut13.Parameters.AddWithValue("@p2", TextID.Text);
                            komut13.Parameters.AddWithValue("@p1", Kmiktar);
                            komut13.Parameters.AddWithValue("@p4", "EKSİK VAR");
                            komut13.Parameters.AddWithValue("@p3", yeniStokEklenen);
                            //komut13.Parameters.AddWithValue("@p3", Aamiktar);
                        }
                        else
                        {
                            komut13.Parameters.AddWithValue("@p2", TextID.Text);
                            komut13.Parameters.AddWithValue("@p1", Kmiktar);
                            komut13.Parameters.AddWithValue("@p4", "STOĞA EKLENDİ");
                            komut13.Parameters.AddWithValue("@p3", yeniStokEklenen);
                            //komut13.Parameters.AddWithValue("@p3", Aamiktar);

                        }
                        komut13.ExecuteNonQuery();
                        listele_stok_girisi_2();
                        bgl.baglanti().Close();
                        MessageBox.Show("GİRİŞ BAŞARILI", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
                }
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BnAra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK],Tanim[TANIM],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI]," +
                "format(Miktar,'###,###,###.###')[MİKTAR],Tarih[TARİH],FirmaAdi[FİRMA ADI],VergiDairesi[VERGİ DAİRESİ],VergiNo[VERGİ NO],IrsaliyeNo[İRSALİYE NO],IrsaliyeTarihi[İRSALİYE TARİHİ],FaturaNo[FATURA NO],FaturaTarihi[FATURA TARİHİ]," +
                "KDV,format(KdvTutari,'###,###,###.###')[KDV TUTARI],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],ProjeKodu[PROJE KODU],GirisID[GİRİŞ ID],SiparisID[SİPARİŞ ID],Aciklama[AÇIKLAMA],SAciklama[SATIN ALMA AÇIKLAMA] From Stok_Girisleri  where StokKodu='" + TextStokKodu3.Text + "' ORDER BY ID DESC", bgl.baglanti());
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            bindingSource2.DataSource = dt;
            bgl.baglanti().Close();
          
        }

        private void BtnDuzenle2_Click(object sender, EventArgs e)
        {
           

           
            if (listBox2.SelectedItem == null | TextMiktar4.Text == "")
            {
               
                MessageBox.Show("FİRMA BİLGİSİ VE MİKTAR BOŞ BIRAKILAMAZ", "DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand DevredenMiktar = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                DevredenMiktar.Parameters.AddWithValue("@p1", TextStokKodu3.Text);
                decimal Dmiktar = Convert.ToDecimal(DevredenMiktar.ExecuteScalar());


                SqlCommand StokGirisMiktar = new SqlCommand("Select Miktar from Stok_Girisleri where ID=@p1", bgl.baglanti());
                StokGirisMiktar.Parameters.AddWithValue("@p1", TextID2.Text);
                decimal Smiktar = Convert.ToDecimal(StokGirisMiktar.ExecuteScalar());
                //int KMiktar = Smiktar - int.Parse(textEdit28.Text);
                decimal duzMiktar = Dmiktar - Smiktar;
                decimal Ymiktar = decimal.Parse(TextMiktar4.Text) + duzMiktar; // Devreden1 için yeni miktar 


                SqlCommand StokGirisToplamTutar = new SqlCommand("Select ToplamTutar from Stok_Girisleri where ID=@p1", bgl.baglanti());
                StokGirisToplamTutar.Parameters.AddWithValue("@p1", TextID2.Text);
                decimal StoplamTutar = Convert.ToDecimal(StokGirisToplamTutar.ExecuteScalar());

                SqlCommand DevredenToplamTutar = new SqlCommand("Select ToplamTutar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                DevredenToplamTutar.Parameters.AddWithValue("@p1", TextStokKodu3.Text);
                decimal DtoplamTutar = Convert.ToDecimal(DevredenToplamTutar.ExecuteScalar());


                decimal DuzToplamTutar = DtoplamTutar - StoplamTutar;

                decimal YtoplamTutar = (ToplamTutar(decimal.Parse(TextBirimFiyati4.Text), decimal.Parse(TextKdv3.Text), decimal.Parse(TextMiktar4.Text)) + DuzToplamTutar);//devreden1 için toplam tutar

                decimal YbirimFiyat = (YtoplamTutar  /*ToplamKdvTutar(decimal.Parse(TextBirimFiyati4.Text), decimal.Parse(TextKdv3.Text), decimal.Parse(TextMiktar4.Text)))*/ / Ymiktar); // devreden1 için yeni birim fiyat

                SqlCommand komut = new SqlCommand("Select StokEklenenMiktar from Siparis where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(TextSiparisID.Text));
                decimal stokEklenen = Convert.ToDecimal(komut.ExecuteScalar());

                SqlCommand komut2 = new SqlCommand("Select AlinanMiktar from Siparis where ID=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", int.Parse(TextSiparisID.Text));
                decimal alinanMiktar = Convert.ToDecimal(komut2.ExecuteScalar());



                decimal duzenlemeDuzMiktar = stokEklenen - Smiktar;

                decimal yeniStokEklenen = duzenlemeDuzMiktar + decimal.Parse(TextMiktar4.Text);
                if(yeniStokEklenen > alinanMiktar | decimal.Parse(TextMiktar4.Text)<0)
                {
                    MessageBox.Show("SATINALMANIN ALDIĞI MİKTARDAN FAZLA GİRİŞ YAPILAMAZ", "GİRİŞ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand komut5 = new SqlCommand("update Siparis set StokEklenenMiktar=@p1 where ID=@p2", bgl.baglanti());
                    komut5.Parameters.AddWithValue("@p1", yeniStokEklenen);
                    komut5.Parameters.AddWithValue("@p2", int.Parse(TextSiparisID.Text));
                    komut5.ExecuteNonQuery();

                    SqlCommand komut6 = new SqlCommand("Select Miktar from Siparis where ID=@p1", bgl.baglanti());
                    komut6.Parameters.AddWithValue("@p1", int.Parse(TextSiparisID.Text));
                    decimal duzenlemeMiktar = Convert.ToDecimal(komut6.ExecuteScalar());

                    SqlCommand komut4 = new SqlCommand("Select StokEklenenMiktar from Siparis where ID=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", int.Parse(TextSiparisID.Text));
                    decimal eklenenMiktar = Convert.ToDecimal(komut4.ExecuteScalar());

                    decimal siparisKalan = duzenlemeMiktar - eklenenMiktar;





                    SqlCommand komut3 = new SqlCommand("update Siparis set Durumu=@p2, KalanMiktar=@p4 where ID=@p3", bgl.baglanti());
                    if (siparisKalan == 0)
                    {

                        komut3.Parameters.AddWithValue("@p2", "STOĞA EKLENDİ");
                        komut3.Parameters.AddWithValue("@p3", int.Parse(TextSiparisID.Text));
                        komut3.Parameters.AddWithValue("@p4", siparisKalan);


                        komut3.ExecuteNonQuery();

                        bgl.baglanti().Close();
                        MessageBox.Show("STOK DÜZENLENDİ", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        komut3.Parameters.AddWithValue("@p2", "EKSİK VAR");
                        komut3.Parameters.AddWithValue("@p3", int.Parse(TextSiparisID.Text));
                        komut3.Parameters.AddWithValue("@p4", siparisKalan);
                        komut3.ExecuteNonQuery();

                        bgl.baglanti().Close();
                        MessageBox.Show("STOK DÜZENLENDİ", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    SqlCommand Skomut = new SqlCommand("update Stok_Girisleri set Miktar=@p1," +
                    "FirmaAdi=@p3,VergiDairesi=@p4,VergiNo=@p5,IrsaliyeNo=@p6,IrsaliyeTarihi=@p7,FaturaNo=@p8,FaturaTarihi=@p9,BirimFiyati=@p10,KDV=@p11,KdvTutari=@p12,ToplamTutar =@p13 where ID =@p14", bgl.baglanti());
                    Skomut.Parameters.AddWithValue("@p1", decimal.Parse(TextMiktar4.Text));

                    Skomut.Parameters.AddWithValue("@p3", listBox2.SelectedItem);
                    Skomut.Parameters.AddWithValue("@p4", TextVergiDairesi3.Text);
                    Skomut.Parameters.AddWithValue("@p5", TextVergiNo3.Text);
                    Skomut.Parameters.AddWithValue("@p6", TextIraliyeNo3.Text);
                    Skomut.Parameters.AddWithValue("@p7", IrsaliyeTarih3.Value);
                    Skomut.Parameters.AddWithValue("@p8", TextFaturaNo3.Text);
                    Skomut.Parameters.AddWithValue("@p9", FaturaTarih3.Value);
                    Skomut.Parameters.AddWithValue("@p10", decimal.Parse(TextBirimFiyati4.Text));
                    Skomut.Parameters.AddWithValue("@p11", decimal.Parse(TextKdv3.Text));
                    Skomut.Parameters.AddWithValue("@p12", ToplamKdvTutar(decimal.Parse(TextBirimFiyati4.Text), decimal.Parse(TextKdv3.Text), decimal.Parse(TextMiktar4.Text)));
                    Skomut.Parameters.AddWithValue("@p13", ToplamTutar(decimal.Parse(TextBirimFiyati4.Text), decimal.Parse(TextKdv3.Text), decimal.Parse(TextMiktar4.Text)));
                    Skomut.Parameters.AddWithValue("@p14", TextID2.Text);
                    Skomut.ExecuteNonQuery();

                    SqlCommand Dkomut = new SqlCommand("update Devreden1 set BirimFiyati=@p1,ToplamTutar=@p2,Miktar=@p3 where StokKodu=@p4", bgl.baglanti());
                    Dkomut.Parameters.AddWithValue("@p1", YbirimFiyat);
                    Dkomut.Parameters.AddWithValue("@p2", YtoplamTutar);
                    Dkomut.Parameters.AddWithValue("@p3", Ymiktar);
                    Dkomut.Parameters.AddWithValue("@p4", int.Parse(TextStokKodu3.Text));
                    Dkomut.ExecuteNonQuery();












                    listele_stok_giris_duzenleme();
                    bgl.baglanti().Close();
                }



               
                
            }
           

        }

        private void dataGridView4_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listele_stok_karti2();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele_stok_girisi_2();
        }

        private void dataGridView3_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView3.SelectedCells[0].RowIndex;
            TextID.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            TextStokKodu2.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            TextUrunAdi3.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
            TextYuzey3.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();
            TextUretici3.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
            TextBoy3.Text = dataGridView3.Rows[secilen].Cells[8].Value.ToString();
            TextEn3.Text = dataGridView3.Rows[secilen].Cells[9].Value.ToString();
            TextKalinlik3.Text = dataGridView3.Rows[secilen].Cells[10].Value.ToString();
            TextBirim3.Text = dataGridView3.Rows[secilen].Cells[11].Value.ToString();
            TextMiktar3.Text = dataGridView3.Rows[secilen].Cells[13].Value.ToString();
            ComboProje.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            
            RichTanim3.Text = dataGridView3.Rows[secilen].Cells[15].Value.ToString();
            
            TextSAciklama.Text = dataGridView3.Rows[secilen].Cells[17].Value.ToString();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Firmalar where FirmaAdi=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextVergiDairesi.Text = dr["VergiDairesi"].ToString();
                TextVergiNo.Text = dr["VergiNo"].ToString();


            }
            bgl.baglanti().Close();
        }

        private void dataGridView3_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView3.FilterString;
        }

        private void dataGridView3_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView3.SortString;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Firmalar where FirmaAdi=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", listBox2.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextVergiDairesi3.Text = dr["VergiDairesi"].ToString();
                TextVergiNo3.Text = dr["VergiNo"].ToString();


            }
            bgl.baglanti().Close();
        }

        private void dataGridView4_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Filter = this.dataGridView4.FilterString;
        }

        private void dataGridView4_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Sort = this.dataGridView4.SortString;
        }

        private void dataGridView4_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView4.SelectedCells[0].RowIndex;
            TextID2.Text = dataGridView4.Rows[secilen].Cells[0].Value.ToString();
            TextBirimFiyati4.Text = dataGridView4.Rows[secilen].Cells[10].Value.ToString();
            string miktar = dataGridView4.Rows[secilen].Cells[11].Value.ToString();
            string yeniMiktar = miktar.Replace(",", "");
            TextMiktar4.Text = yeniMiktar.Replace(".", ","); 

            TextVergiDairesi3.Text = dataGridView4.Rows[secilen].Cells[14].Value.ToString();
            TextVergiNo3.Text = dataGridView4.Rows[secilen].Cells[15].Value.ToString();
            TextIraliyeNo3.Text = dataGridView4.Rows[secilen].Cells[16].Value.ToString();
            IrsaliyeTarih3.Text = dataGridView4.Rows[secilen].Cells[17].Value.ToString();
            TextFaturaNo3.Text = dataGridView4.Rows[secilen].Cells[18].Value.ToString();
            FaturaTarih3.Text = dataGridView4.Rows[secilen].Cells[19].Value.ToString();
            TextKdv3.Text = dataGridView4.Rows[secilen].Cells[20].Value.ToString();
            TextSiparisID.Text = dataGridView4.Rows[secilen].Cells[25].Value.ToString();
        }

        private void dataGridView4_FilterStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource2.Filter = this.dataGridView4.FilterString;
        }

        private void dataGridView4_SortStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource2.Sort = this.dataGridView4.SortString;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource3.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource3.Sort = this.dataGridView1.SortString;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ComboProje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextMin_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in TextMin.Text)
            {
                if (char.IsLetter(chr))
                {
                    MessageBox.Show("MİNİMUM MİKTAR SAYI OLMALIDIR", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextMin.Text = "";


                }
            }
        }

        private void TextMax_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in TextMax.Text)
            {
                if (char.IsLetter(chr))
                {
                    MessageBox.Show("MAXİMUM MİKTAR SAYI OLMALIDIR", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextMax.Text = "";


                }
            }
        }
    }
}
