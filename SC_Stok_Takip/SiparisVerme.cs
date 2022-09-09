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
    public partial class SiparisVerme : Form
    {
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
        SqlBaglanti bgl = new SqlBaglanti();
        public SiparisVerme()
        {
            InitializeComponent();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Tanim[TANIM],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
               "Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],FORMAT(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],format(MinMiktar,'###,###,###.###')[MİNİMUM MİKTAR],format(MaxMiktar,'###,###,###.###')[MAXİMUM MİKTAR],Tarih[TARİH] from Devreden1 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bindingSource1.DataSource = dt;
            tablo1();

        }
        public void tablo1()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                if (Convert.ToString(dataGridView1.Rows[i].Cells[9].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[9].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[10].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[10].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[11].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[11].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[12].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[12].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[13].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[13].Value = 0;
                }
            }
        }
        void listele_siparis_duzenleme()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN]," +
                "Kalinlik[KALINLIK],Birim[BİRİM],format(Miktar,'###,###,###.###')[MİKTAR],format(AlinanMiktar,'###,###,###.###')[ALINAN MİKTAR],format(KalanMiktar,'###,###,###.###')[KALAN MİKTAR]," +
                "Tanim[TANIM],Aciklama[AÇIKLAMA],SAciklama[SATIN ALMA AÇIKLAMA],TalepTarihi[TALEP TARİHİ],SiparisTarihi[SİPARİŞ TARİHİ],TerminTarihi[TERMİN TARİHİ],SiparisAcan[SİPARİŞİ AÇAN]," +
                "Durumu[DURUMU],FirmaBilgisi[FİRMA BİLGİSİ],format(StokEklenenMiktar,'###,###,###.###')[STOĞA EKLENEN MİKTAR] from Siparis where Durumu!=@p1 order by ID DESC", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", "STOĞA EKLENDİ");
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bindingSource2.DataSource = dt;
            tablo2();
        }
        public void tablo2()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {

                if (Convert.ToString(dataGridView2.Rows[i].Cells[13].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[13].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[14].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[14].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[24].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[24].Value = 0;
                }

            }
        }
        public void listele_projekodu()
        {
            ComboProje.Items.Clear();
            ComboProje2.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboProje.Items.Add(dr["ProjeKodu"]);
                ComboProje2.Items.Add(dr["ProjeKodu"]);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool durum;
        bool durum2;
      
        void kontrol()
        {
            foreach (char chr in ComboProje.Text)
            {
                if (!char.IsNumber(chr))
                {
                    durum = false;

                }
                else
                {

                    SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", int.Parse(ComboProje.Text));
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        durum = true;
                    }
                    else
                    {
                        durum = false;
                    }
                    bgl.baglanti().Close();
                }
            }

        }

        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {
            
                kontrol();
                if (durum == false )
                {
                    MessageBox.Show("SİPARİŞ GİRİŞİ BAŞARISIZ (Böyle Bir Proje Kodu Bulunamadı)", "PROJELER SEGMESİNDEN YENİ PROJE KARTI OLUŞTURABİLİRSİNİZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TextMiktar.Text == "" )
                    {
                        MessageBox.Show("SİPARİŞ GİRİŞİ BAŞARISIZ (MİKTAR BOŞ BIRAKILAMAZ)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    else
                    {
                         if (decimal.Parse(TextMiktar.Text) <=0 )
                        {
                             MessageBox.Show("SİPARİŞ GİRİŞİ BAŞARISIZ (MİKTAR 0 YA DA 0'DAN KÜÇÜK OLAMAZ)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                         else
                         {
                            SqlCommand komut = new SqlCommand("insert into Siparis (StokKodu,ProjeKodu,Firma,Proje,Yuzey,UrunAdi,Uretici,Tanim,SiparisAcan,Boy,En,Kalinlik,Miktar,Birim," +
                            "Aciklama,TalepTarihi,Durumu,AlinanMiktar,KalanMiktar,StokEklenenMiktar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17," +
                             "@p22,@p23,@p24)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
                            komut.Parameters.AddWithValue("@p2", int.Parse(ComboProje.Text));
                            komut.Parameters.AddWithValue("@p3", TextFirma.Text);
                        komut.Parameters.AddWithValue("@p4", RichProje.Text);
                        komut.Parameters.AddWithValue("@p5", TextYuzey.Text);
                        komut.Parameters.AddWithValue("@p6", TextUrunAdi.Text);
                        komut.Parameters.AddWithValue("@p7", TextUretici.Text);
                        komut.Parameters.AddWithValue("@p8", RichTanim.Text);
                        komut.Parameters.AddWithValue("@p9", int.Parse(TextSiparisAcan.Text));
                        komut.Parameters.AddWithValue("@p10", TextBoy.Text);
                        komut.Parameters.AddWithValue("@p11", TextEn.Text);
                        komut.Parameters.AddWithValue("@p12", TextKalinlik.Text);
                        komut.Parameters.AddWithValue("@p13", decimal.Parse(TextMiktar.Text));
                        komut.Parameters.AddWithValue("@p14", TextBirim.Text);
                        komut.Parameters.AddWithValue("@p15", TextAciklama.Text);
                        komut.Parameters.AddWithValue("@p16", TalepTarihi.Value);

                        komut.Parameters.AddWithValue("@p17", "");

                        komut.Parameters.AddWithValue("@p22", 0);
                        komut.Parameters.AddWithValue("@p23", decimal.Parse(TextMiktar.Text));
                        komut.Parameters.AddWithValue("@p24", 0);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("BİLGİ", "SİPARİŞ VERİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bgl.baglanti().Close();
                        listele();

                    }


                }
                }
                
            
           
        }
        int girisid = Giris.id;
        String siparis_duzenle = Giris.yy12.ToString();
        String siparis_iptal = Giris.yy13.ToString();
        private void SiparisVerme_Load(object sender, EventArgs e)
        {
            if(int.Parse(siparis_duzenle) == 0)
            {
                BtnDuzenle.Enabled = false;
            }
            if (int.Parse(siparis_iptal) == 0)
            {
                SiparisIptal.Enabled = false;
            }
            TextSiparisAcan.Text = girisid.ToString();
            listele();
            listele_projekodu();
            listele_siparis_duzenleme();
            timer1.Interval = 360000;
            timer1.Start();
        }

        private void TextStokKodu_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from StokKarti where StokKodu =@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextStokKodu.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RichTanim.Text = dr["Tanim"].ToString();
                TextYuzey.Text = dr["Yuzey"].ToString();
                TextUretici.Text = dr["Uretici"].ToString();
                TextBoy.Text = dr["Boy"].ToString();
                TextEn.Text = dr["En"].ToString();
                TextKalinlik.Text = dr["Kalinlik"].ToString();
                TextBirim.Text = dr["Birim"].ToString();
                TextUrunAdi.Text = dr["UrunAdi"].ToString();

            }
        }

        private void ComboProje_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ComboProje.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma.Text = dr["Firma"].ToString();
                RichProje.Text = dr["Proje"].ToString();
            }
        }

       

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TextStokKodu.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TextUrunAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextUretici.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TextYuzey.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TextBoy.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TextEn.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TextKalinlik.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TextBirim.Text= dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            RichTanim.Text= dataGridView1.Rows[secilen].Cells[8].Value.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
           //this.bindingSource1.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            
            //this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_SortStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_FilterStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TextStokKodu.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TextUrunAdi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextUretici.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TextYuzey.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TextBoy.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TextEn.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TextKalinlik.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            TextBirim.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            RichTanim.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void TextMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {

            this.bindingSource2.Sort = this.dataGridView2.SortString;
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Filter = this.dataGridView2.FilterString;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TextID2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            TextStokKodu2.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            ComboProje2.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            string miktar = dataGridView2.Rows[secilen].Cells[12].Value.ToString();
            string yeniMiktar = miktar.Replace(",", "");

            TextMiktar2.Text = yeniMiktar.Replace(".", ",");
            TextAciklama2.Text = dataGridView2.Rows[secilen].Cells[16].Value.ToString();
            TextFirma2.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            RichProje2.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();

        }

        private void ComboProje2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ComboProje2.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma2.Text = dr["Firma"].ToString();
                RichProje2.Text = dr["Proje"].ToString();
            }
        }
        bool durum_duzenleme;
        void kontrol_duzenleme()
        {
            if(decimal.Parse(TextMiktar2.Text) <= 0)
            {
                durum_duzenleme = false;
            }
            else
            {
                durum_duzenleme = true;
            }
        }
        bool durum5 = true;
        void kontrol5()
        {

            for (int i = 0; i < ComboProje2.Text.Length; i++)
                if (!char.IsDigit(ComboProje2.Text[i]))
                {
                    durum5 = false;
                }
                else
                {
                    durum5 = true;
                }



        }
        bool durum6;
        void kontrol6()
        {


            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(ComboProje2.Text));
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum6 = true;
            }
            else
            {
                durum6 = false;
            }
            bgl.baglanti().Close();


        }
      

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            kontrol5();
            if (durum5 == false)
            {
                MessageBox.Show("PROJE KODU TAM SAYI OLMALI", "SİPARİŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                kontrol6();
                if (durum6 == false)
                {
                   
                    MessageBox.Show("BÖYLE BİR PROJE KODU BULUNAMADI", "SİPARİŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(TextMiktar2.Text == "" )
                    {
                        MessageBox.Show("MİKTAR BOŞ BIRAKILAMAZ", "SİPARİŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    else
                    {
                        kontrol_duzenleme();
                        if (durum_duzenleme == false)
                        {
                            MessageBox.Show("MİKTAR 0 YADA 0 DAN KÜÇÜK OLAMAZ", "SİPARİŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            SqlCommand komut2 = new SqlCommand("Select Miktar from Siparis where StokKodu=@p1", bgl.baglanti());
                            komut2.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                            decimal siparisMiktar = Convert.ToDecimal(komut2.ExecuteScalar());
                            if (decimal.Parse(TextMiktar2.Text) < siparisMiktar)
                            {
                                SqlCommand komut = new SqlCommand("update Siparis set ProjeKodu=@p1,Miktar=@p2,Aciklama=@p3,Firma=@p4,Proje=@p5,KalanMiktar=@p7, Durumu=@p8,AlinanMiktar=@p9 where ID=@p6", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", ComboProje2.Text);
                                komut.Parameters.AddWithValue("@p2", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p3", TextAciklama2.Text);
                                komut.Parameters.AddWithValue("@p4", TextFirma2.Text);
                                komut.Parameters.AddWithValue("@p5", RichProje2.Text);
                                komut.Parameters.AddWithValue("@p6", TextID2.Text);
                                komut.Parameters.AddWithValue("@p7", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p8", "EKSİK VAR");
                                komut.Parameters.AddWithValue("@p9", 0);

                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                listele_siparis_duzenleme();
                                MessageBox.Show("SİPARİŞ DÜZENLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if(decimal.Parse(TextMiktar2.Text) > siparisMiktar)
                            {

                                SqlCommand komut = new SqlCommand("update Siparis set ProjeKodu=@p1,Miktar=@p2,Aciklama=@p3,Firma=@p4,Proje=@p5,KalanMiktar=@p7, Durumu=@p8 where ID=@p6", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", ComboProje2.Text);
                                komut.Parameters.AddWithValue("@p2", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p3", TextAciklama2.Text);
                                komut.Parameters.AddWithValue("@p4", TextFirma2.Text);
                                komut.Parameters.AddWithValue("@p5", RichProje2.Text);
                                komut.Parameters.AddWithValue("@p6", TextID2.Text);
                                komut.Parameters.AddWithValue("@p7", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p8", "EKSİK VAR");
                                

                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                listele_siparis_duzenleme();
                                MessageBox.Show("SİPARİŞ DÜZENLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                SqlCommand komut = new SqlCommand("update Siparis set ProjeKodu=@p1,Miktar=@p2,Aciklama=@p3,Firma=@p4,Proje=@p5,KalanMiktar=@p7 where ID=@p6", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", ComboProje2.Text);
                                komut.Parameters.AddWithValue("@p2", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p3", TextAciklama2.Text);
                                komut.Parameters.AddWithValue("@p4", TextFirma2.Text);
                                komut.Parameters.AddWithValue("@p5", RichProje2.Text);
                                komut.Parameters.AddWithValue("@p6", TextID2.Text);
                                komut.Parameters.AddWithValue("@p7", decimal.Parse(TextMiktar2.Text));
                                


                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                listele_siparis_duzenleme();
                                MessageBox.Show("SİPARİŞ DÜZENLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                    }
                    
                    
                }
            }

        }

        private void SiparisIptal_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Siparis where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextID2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele_siparis_duzenleme();
            MessageBox.Show("SİPARİŞ İPTAL EDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
            listele_projekodu();
            listele_siparis_duzenleme();
        }

        private void ComboProje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach (char chr in ComboProje.Text)
                {
                    if (!char.IsNumber(chr))
                    {
                        MessageBox.Show("PROJE KODU TAM SAYI OLMALI", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ComboProje.Text = "";
                        TextFirma.Text = "";
                        RichProje.Text = "";

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", ComboProje.Text);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            TextFirma.Text = dr["Firma"].ToString();
                            RichProje.Text = dr["Proje"].ToString();
                        }
                    }
                }


            }
        }

        private void ComboProje2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach (char chr in ComboProje2.Text)
                {
                    if (!char.IsNumber(chr))
                    {
                        MessageBox.Show("PROJE KODU TAM SAYI OLMALI", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ComboProje2.Text = "";
                        TextFirma2.Text = "";
                        RichProje2.Text = "";

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", ComboProje2.Text);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            TextFirma2.Text = dr["Firma"].ToString();
                            RichProje2.Text = dr["Proje"].ToString();
                        }
                    }
                }


            }
        }
    }
}
