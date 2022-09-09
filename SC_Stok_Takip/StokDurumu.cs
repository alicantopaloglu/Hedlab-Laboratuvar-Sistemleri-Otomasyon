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

    public partial class StokDurumu : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
        BindingSource bindingSource3 = new BindingSource();
        BindingSource bindingSource4 = new BindingSource();
        BindingSource bindingSource5 = new BindingSource();
        public StokDurumu()
        {
            InitializeComponent();
        }
        decimal rezervStok;
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Tanim[TANIM],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
               "Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],FORMAT(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],format(MinMiktar,'###,###,###.###')[MİNİMUM MİKTAR],format(MaxMiktar,'###,###,###.###')[MAXİMUM MİKTAR],Tarih[TARİH] from Devreden1", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bindingSource1.DataSource = dt;
            bgl.baglanti().Close();

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
        void listele2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Tanim[TANIM],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
               "Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],format(MinMiktar,'###,###,###.###')[MİNİMUM MİKTAR],format(MaxMiktar,'###,###,###.###')[MAXİMUM MİKTAR] from Devreden1", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bindingSource2.DataSource = dt;
            bgl.baglanti().Close();
            tablo2();
        }
        public void tablo2()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {

                if (Convert.ToString(dataGridView2.Rows[i].Cells[9].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[9].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[10].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[10].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[11].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[11].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[12].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[12].Value = 0;
                }
                if (Convert.ToString(dataGridView2.Rows[i].Cells[13].Value) == "")
                {
                    dataGridView2.Rows[i].Cells[13].Value = 0;
                }
            }
        }

        void listele3()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,RezerveID[REZERVE ID],RezerveIzinIsteyen[REZERVE İZİN İSTEYEN],RezerveAcan[REZERVE AÇAN],StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA]," +
                "Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK],Tanim[TANIM],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI]," +
                "KullanilacakProjeKodu[KULLANILACAĞI PROJE KODU],KullanilacakFirma[KULLANILACAĞI FİRMA], KullanilacakProje[KULLANILACAĞI PROJE],format(IstenenMiktar,'###,###,###.###')[İSTENEN MİKTAR],format(Tutar,'###,###,###.###')[TOPLAM TUTAR],Tarih[TARİH]  from RezervIzin where RezerveAcan=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TextRezervId.Text);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            bindingSource3.DataSource = dt;
            bgl.baglanti().Close();

        }
        void listele4()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],RezerveAcan[REZERVE AÇAN],StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ]," +
                "Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK],Tanim[TANIM],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],format(Tutar,'###,###,###.###')[TOPLAM TUTAR],Tarih[TARİH] from Rezerv where RezerveAcan=@p1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", TextRezervId.Text);
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            bindingSource4.DataSource = dt;
            bgl.baglanti().Close();
        }
        void listele5()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Tanim[TANIM],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN],Kalinlik[KALINLIK]," +
                "Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],format(MinMiktar,'###,###,###.###')[MİNİMUM MİKTAR],format(MaxMiktar,'###,###,###.###')[MAXİMUM MİKTAR] from Devreden1 where Miktar <= MinMiktar", bgl.baglanti());
            da.Fill(dt);
            dataGridView5.DataSource = dt;

            bindingSource5.DataSource = dt;
            bgl.baglanti().Close();
            tablo5();
        }
        public void tablo5()
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {

                if (Convert.ToString(dataGridView5.Rows[i].Cells[9].Value) == "")
                {
                    dataGridView5.Rows[i].Cells[9].Value = 0;
                }
                if (Convert.ToString(dataGridView5.Rows[i].Cells[10].Value) == "")
                {
                    dataGridView5.Rows[i].Cells[10].Value = 0;
                }
                if (Convert.ToString(dataGridView5.Rows[i].Cells[11].Value) == "")
                {
                    dataGridView5.Rows[i].Cells[11].Value = 0;
                }
                if (Convert.ToString(dataGridView5.Rows[i].Cells[12].Value) == "")
                {
                    dataGridView5.Rows[i].Cells[12].Value = 0;
                }
                if (Convert.ToString(dataGridView5.Rows[i].Cells[13].Value) == "")
                {
                    dataGridView5.Rows[i].Cells[13].Value = 0;
                }
            }
        }
        public void tablo_renk()
        {
            int stokKodu;
            decimal miktar;
            decimal minMiktar;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string MinMiktar = Convert.ToString(dataGridView1.Rows[i].Cells[13].Value);
                string MinMiktar2 = MinMiktar.Replace(",", "");
                minMiktar = Convert.ToDecimal(MinMiktar2.Replace(".", ","));

                string Miktar = Convert.ToString(dataGridView1.Rows[i].Cells[10].Value);
                string Miktar2 = Miktar.Replace(",", "");
                miktar = Convert.ToDecimal(Miktar2.Replace(".", ","));


                //stokKodu = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                //SqlCommand komut = new SqlCommand("select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                //komut.Parameters.AddWithValue("@p1", stokKodu);
                //miktar = Convert.ToDecimal(komut.ExecuteScalar());

                //SqlCommand komut2 = new SqlCommand("Select MinMiktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                //komut2.Parameters.AddWithValue("@p1",stokKodu);
                //minMiktar = Convert.ToDecimal(komut2.ExecuteScalar());

                bgl.baglanti().Close();




                if (miktar <= minMiktar)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                }

                else if (miktar > minMiktar && miktar < minMiktar + 10)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else if (miktar > minMiktar)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                

            }
        }

        public void listele_projekodu()
        {
            comboProje.Items.Clear();


            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler order by ID", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboProje.Items.Add(dr["ProjeKodu"]);
                comboProje2.Items.Add(dr["ProjeKodu"]);

            }
            bgl.baglanti().Close();

        }


        private void StokDurumu_Load(object sender, EventArgs e)
        {
            String rezerveAcma = Giris.yy14.ToString();
            if(int.Parse(rezerveAcma) == 0)
            {
                BtnOlustur.Enabled = false;
                BtnDuzenle.Enabled = false;
                BtnIzınVer.Enabled = false;
                button1.Enabled = false;
                BtnSil.Enabled = false;
            }
            int girisid = Giris.id;
            TextRezervId.Text = girisid.ToString();
            listele();

            tablo_renk();
            listele5();
            
            listele2();
            listele3();
            
            listele_projekodu();
            listele4();


        }



        private void dataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Filter = this.dataGridView2.FilterString;
        }

        private void dataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Sort = this.dataGridView2.SortString;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TextStokKodu.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            TextUrunAdi.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            RichTanim.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            TextUretici.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            TextYuzey.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            TextBoy.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            TextEn.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            TextKalinlik.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            TextBirim.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();
            string birimFiyat = dataGridView2.Rows[secilen].Cells[9].Value.ToString();
            string yenibirimFiyat = birimFiyat.Replace(",", "");
            TextBirimFiyat.Text = yenibirimFiyat.Replace(".", ",");

        }
        bool durum;
        void kontrol()
        {

            SqlCommand komut = new SqlCommand("Select * from Rezerv where StokKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextStokKodu.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = true;
                bgl.baglanti().Close();
            }
            else
            {
                durum = false;
                bgl.baglanti().Close();
            }
        }
        bool durum1;
        void kontrol1()
        {
            SqlCommand komut = new SqlCommand("Select * from Rezerv where StokKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum1 = true;
                bgl.baglanti().Close();
            }
            else
            {
                durum1 = false;
                bgl.baglanti().Close();
            }
        }
        bool durum2;
        void kontrol2()
        {
            foreach (char chr in comboProje.Text)
            {
                if (!char.IsNumber(chr))
                {
                    durum2 = false;
                }
                else
                {
                    SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", comboProje.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        durum2 = true;
                        bgl.baglanti().Close();
                    }
                    else
                    {
                        durum2 = false;
                        bgl.baglanti().Close();
                    }
                }
            }
        }
        bool durum3;
        void kontrol3()
        {
            foreach (char chr in comboProje2.Text)
            {
                if (!char.IsNumber(chr))
                {
                    durum3 = false;
                }
                else
                {
                    SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", comboProje2.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        durum3 = true;
                        bgl.baglanti().Close();
                    }
                    else
                    {
                        durum3 = false;
                        bgl.baglanti().Close();
                    }
                }
            }
        }


        private void BtnOlustur_Click(object sender, EventArgs e)
        {
            kontrol();
            if (durum == true)
            {
                kontrol2();
                if (durum2 == true)
                {
                    SqlCommand komut = new SqlCommand("Select Sum(Miktar) from Rezerv where StokKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextStokKodu.Text);
                    rezervStok = Convert.ToDecimal(komut.ExecuteScalar());

                    SqlCommand komut2 = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", TextStokKodu.Text);
                    decimal miktarDevreden = Convert.ToDecimal(komut2.ExecuteScalar());

                    if (decimal.Parse(TextMiktar.Text) <= miktarDevreden - rezervStok)
                    {
                        SqlCommand komut3 = new SqlCommand("insert into Rezerv (RezerveAcan,StokKodu,UrunAdi,Yuzey,Boy,En,Kalinlik,Tanim,Birim,BirimFiyati,Miktar,Tutar,Tarih,ProjeKodu,Firma,Proje,Uretici) values (@p1,@p2,@p3,@p4,@p5,@p6" +
                            ",@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", int.Parse(TextRezervId.Text));
                        komut3.Parameters.AddWithValue("@p2", int.Parse(TextStokKodu.Text));
                        komut3.Parameters.AddWithValue("@p3", TextUrunAdi.Text);
                        komut3.Parameters.AddWithValue("@p4", TextYuzey.Text);
                        komut3.Parameters.AddWithValue("@p5", TextBoy.Text);
                        komut3.Parameters.AddWithValue("@p6", TextEn.Text);
                        komut3.Parameters.AddWithValue("@p7", TextKalinlik.Text);
                        komut3.Parameters.AddWithValue("@p8", RichTanim.Text);
                        komut3.Parameters.AddWithValue("@p9", TextBirim.Text);
                        komut3.Parameters.AddWithValue("@p10", decimal.Parse(TextBirimFiyat.Text));
                        komut3.Parameters.AddWithValue("@p11", decimal.Parse(TextMiktar.Text));
                        komut3.Parameters.AddWithValue("@p12", decimal.Parse(TextBirimFiyat.Text) * decimal.Parse(TextMiktar.Text));
                        komut3.Parameters.AddWithValue("@p13", Tarih.Value);
                        komut3.Parameters.AddWithValue("@p14", int.Parse(comboProje.Text));
                        komut3.Parameters.AddWithValue("@p15", TextFirma.Text);
                        komut3.Parameters.AddWithValue("@p16", RichProje.Text);
                        komut3.Parameters.AddWithValue("@p17", TextUretici.Text);
                        komut3.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("REZERVE BAŞARIYLA OLUŞTURULDU", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele4();


                    }
                    else
                    {
                        MessageBox.Show("REZERV İŞLEMİ BAŞARISIZ YETERLİ STOK YOK. TOPLAM REZERVE MİKTARI: " + rezervStok + " TOPLAM STOK MİKTARI : " + miktarDevreden + "", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PROJE KODU TAM SAYI OLMALI", "BÖYLE BİR PROJE KODU BULUNAMADI ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
            {
                kontrol2();
                if (durum2 == true)
                {
                    SqlCommand komut = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextStokKodu.Text);
                    decimal miktarDevreden = Convert.ToDecimal(komut.ExecuteScalar());

                    if (decimal.Parse(TextMiktar.Text) <= miktarDevreden)
                    {
                        SqlCommand komut3 = new SqlCommand("insert into Rezerv (RezerveAcan,StokKodu,UrunAdi,Yuzey,Boy,En,Kalinlik,Tanim,Birim,BirimFiyati,Miktar,Tutar,Tarih,ProjeKodu,Firma,Proje,Uretici) values (@p1,@p2,@p3,@p4,@p5,@p6," +
                                "@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());

                        komut3.Parameters.AddWithValue("@p1", int.Parse(TextRezervId.Text));
                        komut3.Parameters.AddWithValue("@p2", int.Parse(TextStokKodu.Text));
                        komut3.Parameters.AddWithValue("@p3", TextUrunAdi.Text);
                        komut3.Parameters.AddWithValue("@p4", TextYuzey.Text);
                        komut3.Parameters.AddWithValue("@p5", TextBoy.Text);
                        komut3.Parameters.AddWithValue("@p6", TextEn.Text);
                        komut3.Parameters.AddWithValue("@p7", TextKalinlik.Text);
                        komut3.Parameters.AddWithValue("@p8", RichTanim.Text);
                        komut3.Parameters.AddWithValue("@p9", TextBirim.Text);
                        komut3.Parameters.AddWithValue("@p10", decimal.Parse(TextBirimFiyat.Text));
                        komut3.Parameters.AddWithValue("@p11", decimal.Parse(TextMiktar.Text));
                        komut3.Parameters.AddWithValue("@p12", decimal.Parse(TextBirimFiyat.Text) * decimal.Parse(TextMiktar.Text));
                        komut3.Parameters.AddWithValue("@p13", Tarih.Value);
                        komut3.Parameters.AddWithValue("@p14", int.Parse(comboProje.Text));
                        komut3.Parameters.AddWithValue("@p15", TextFirma.Text);
                        komut3.Parameters.AddWithValue("@p16", RichProje.Text);
                        komut3.Parameters.AddWithValue("@p17", TextUretici.Text);
                        komut3.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("REZERVE BAŞARIYLA OLUŞTURULDU", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele4();
                    }
                    else
                    {
                        MessageBox.Show("REZERVE İŞLEMİ BAŞARISIZ YETERLİ STOK YOK. TOPLAM STOK MİKTARI : " + miktarDevreden + "", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PROJE KODU TAM SAYI OLMALI", "BÖYLE BİR PROJE KODU BULUNAMADI ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }

        private void dataGridView1_FilterStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;
            tablo_renk();
        }

        private void dataGridView1_SortStringChanged_1(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void comboProje_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboProje.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma.Text = dr["Firma"].ToString();
                RichProje.Text = dr["Proje"].ToString();
            }
        }

        private void comboProje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach (char chr in comboProje.Text)
                {
                    if (!char.IsDigit(chr))
                    {
                        MessageBox.Show("PROJE KODU TAM SAYI OLMALI", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboProje.Text = "";
                        TextFirma.Text = "";
                        RichProje.Text = "";

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", comboProje.Text);
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

        private void TextMiktar_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in TextMiktar.Text)
            {
                if (char.IsLetter(chr))
                {
                    MessageBox.Show("MİKTAR SAYI OLMALIDIR", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextMiktar.Text = "";

                }
                else
                {
                    TextMiktar.Text = TextMiktar.Text;
                }
            }
        }

        private void dataGridView5_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource5.Filter = this.dataGridView5.FilterString;
        }

        private void dataGridView5_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource5.Sort = this.dataGridView5.SortString;
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView4.SelectedCells[0].RowIndex;
            TextID.Text = dataGridView4.Rows[secilen].Cells[0].Value.ToString();

            TextStokKodu2.Text = dataGridView4.Rows[secilen].Cells[2].Value.ToString();
            comboProje2.Text = dataGridView4.Rows[secilen].Cells[3].Value.ToString();
            TextFirma2.Text = dataGridView4.Rows[secilen].Cells[4].Value.ToString();
            RichProje2.Text = dataGridView4.Rows[secilen].Cells[5].Value.ToString();
            TextBirimFiyati2.Text = dataGridView4.Rows[secilen].Cells[14].Value.ToString();
            TextMiktar2.Text = dataGridView4.Rows[secilen].Cells[15].Value.ToString();
        }

        private void dataGridView4_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource4.Filter = this.dataGridView4.FilterString;
        }

        private void dataGridView4_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource4.Sort = this.dataGridView4.SortString;
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            kontrol1();
            if (durum1 == true)
            {
                kontrol3();
                if (durum3 == true)
                {
                    SqlCommand komut4 = new SqlCommand("Select Miktar from Rezerv where ID=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", TextID.Text);
                    decimal duzenlenenMiktar = Convert.ToDecimal(komut4.ExecuteScalar());


                    SqlCommand komut = new SqlCommand("Select Sum(Miktar) from Rezerv where StokKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                    rezervStok = Convert.ToDecimal(komut.ExecuteScalar());

                    SqlCommand komut2 = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                    decimal miktarDevreden = Convert.ToDecimal(komut2.ExecuteScalar());

                    if (decimal.Parse(TextMiktar2.Text) <= miktarDevreden - rezervStok + duzenlenenMiktar)
                    {
                        SqlCommand komut3 = new SqlCommand("update Rezerv set Miktar=@p1,ProjeKodu=@p2,Firma=@p3,Proje=@p4,Tutar=@p5 where ID=@p6", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", decimal.Parse(TextMiktar2.Text));
                        komut3.Parameters.AddWithValue("@p2", int.Parse(comboProje2.Text));
                        komut3.Parameters.AddWithValue("@p3", TextFirma2.Text);
                        komut3.Parameters.AddWithValue("@p4", RichProje2.Text);
                        komut3.Parameters.AddWithValue("@p5", decimal.Parse(TextMiktar2.Text) * decimal.Parse(TextBirimFiyati2.Text));
                        komut3.Parameters.AddWithValue("@p6", TextID.Text);
                        komut3.ExecuteNonQuery();
                        listele4();
                        bgl.baglanti().Close();
                        MessageBox.Show("REZERVE DÜZENLEME İŞLEMİ BAŞARILI", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("REZERVE DÜZENLEME İŞLEMİ BAŞARISIZ YETERLİ STOK YOK. TOPLAM REZERVE MİKTARI: " + (rezervStok - duzenlenenMiktar) + " TOPLAM STOK MİKTARI : " + miktarDevreden + "", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PROJE KODU TAM SAYI OLMALI", "BÖYLE BİR PROJE KODU BULUNAMADI ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                kontrol3();
                if (durum3 == true)
                {
                    SqlCommand komut4 = new SqlCommand("Select Miktar from Rezerv where ID=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", TextID.Text);
                    decimal duzenlenenMiktar = Convert.ToDecimal(komut4.ExecuteScalar());

                    SqlCommand komut = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TextStokKodu2.Text);
                    decimal miktarDevreden = Convert.ToDecimal(komut.ExecuteScalar());

                    if (decimal.Parse(TextMiktar.Text) <= miktarDevreden + duzenlenenMiktar)
                    {
                        SqlCommand komut3 = new SqlCommand("update Rezerv set Miktar=@p1,ProjeKodu=@p2,Firma=@p3,Proje=@p4,Tutar=@p5 where ID=@p6", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", decimal.Parse(TextMiktar2.Text));
                        komut3.Parameters.AddWithValue("@p2", int.Parse(comboProje2.Text));
                        komut3.Parameters.AddWithValue("@p3", TextFirma2.Text);
                        komut3.Parameters.AddWithValue("@p4", RichProje2.Text);
                        komut3.Parameters.AddWithValue("@p5", decimal.Parse(TextMiktar2.Text) * decimal.Parse(TextBirimFiyati2.Text));
                        komut3.Parameters.AddWithValue("@p6", TextID.Text);
                        komut3.ExecuteNonQuery();
                        listele4();
                        bgl.baglanti().Close();
                        MessageBox.Show("REZERVE DÜZENLEME İŞLEMİ BAŞARILI", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("REZERVE İŞLEMİ BAŞARISIZ YETERLİ STOK YOK. TOPLAM STOK MİKTARI : " + miktarDevreden + "", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PROJE KODU TAM SAYI OLMALI", "BÖYLE BİR PROJE KODU BULUNAMADI ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboProje2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboProje2.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma2.Text = dr["Firma"].ToString();
                RichProje2.Text = dr["Proje"].ToString();
            }
        }

        private void comboProje2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                foreach (char chr in comboProje2.Text)
                {
                    if (!char.IsNumber(chr))
                    {
                        MessageBox.Show("PROJE KODU TAM SAYI OLMALI", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboProje2.Text = "";
                        TextFirma2.Text = "";
                        RichProje2.Text = "";

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", comboProje2.Text);
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

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Rezerv where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele4();
            MessageBox.Show("REZERVE SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView3.SelectedCells[0].RowIndex;
            TextIstekID.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            TextRezerveID.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            RezerveIsteyen.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            TextRezerveAcan.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();


            TextStokKodu3.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
            comboProje3.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
            TextFirma3.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
            RichProje3.Text = dataGridView3.Rows[secilen].Cells[7].Value.ToString();
            TextUrunAdi3.Text = dataGridView3.Rows[secilen].Cells[8].Value.ToString();
            TextUretici3.Text = dataGridView3.Rows[secilen].Cells[9].Value.ToString();
            TextYuzey3.Text = dataGridView3.Rows[secilen].Cells[10].Value.ToString();
            TextBoy3.Text = dataGridView3.Rows[secilen].Cells[11].Value.ToString();
            TextEn3.Text = dataGridView3.Rows[secilen].Cells[12].Value.ToString();
            TextKalinlik3.Text = dataGridView3.Rows[secilen].Cells[13].Value.ToString();
            RichTanim3.Text = dataGridView3.Rows[secilen].Cells[14].Value.ToString();
            TextBirim3.Text = dataGridView3.Rows[secilen].Cells[15].Value.ToString();
            TextBirimFiyati3.Text = dataGridView3.Rows[secilen].Cells[16].Value.ToString();
            string miktar = dataGridView3.Rows[secilen].Cells[20].Value.ToString();
            string yeniMiktar = miktar.Replace(",", "");
            TextMiktar3.Text = yeniMiktar.Replace(".", ",");
            TextMiktar33.Text = yeniMiktar;


        }

        private void dataGridView3_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource3.Filter = this.dataGridView3.FilterString;
        }

        private void dataGridView3_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource3.Sort = this.dataGridView3.SortString;
        }
       

        private void BtnIzınVer_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Miktar from Rezerv where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextRezerveID.Text);
            decimal rezervMiktar = Convert.ToDecimal(komut.ExecuteScalar());

           
            if(decimal.Parse(TextMiktar3.Text) <= decimal.Parse(TextMiktar33.Text))
            {
                if (rezervMiktar - decimal.Parse(TextMiktar3.Text) == 0)
                {
                    SqlCommand komut3 = new SqlCommand("delete from Rezerv where ID=@p1", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", TextRezerveID.Text);
                    komut3.ExecuteNonQuery();

                    SqlCommand komut4 = new SqlCommand("delete from RezervIzin where ID=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", TextIstekID.Text);
                    komut4.ExecuteNonQuery();

                    bgl.baglanti().Close();
                    listele3();
                    MessageBox.Show("REZERVE MİKTARIN 0'A DÜŞTÜ", "REZERVE İZİN İSTEĞİ VERİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else
                {
                    decimal duzMiktar = rezervMiktar - decimal.Parse(TextMiktar3.Text);

                    SqlCommand komut3 = new SqlCommand("update Rezerv set Miktar=@p1,Tutar=@p2 where ID=@p3", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", duzMiktar);
                    komut3.Parameters.AddWithValue("@p2", duzMiktar * decimal.Parse(TextBirimFiyati3.Text));
                    komut3.Parameters.AddWithValue("@p3", TextRezerveID.Text);
                    komut3.ExecuteNonQuery();

                    SqlCommand komut4 = new SqlCommand("delete from RezervIzin where ID=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", TextIstekID.Text);
                    komut4.ExecuteNonQuery();
                    MessageBox.Show("REZERVE MİKTARIN : " + (rezervMiktar - decimal.Parse(TextMiktar3.Text)) + "'E,A DÜŞTÜ", "REZERVE İZİN İSTEĞİ VERİLDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    komut3.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listele3();
                    listele4();

                }
            }
            else
            {
                MessageBox.Show("İSTENİLEN REZERVE MİKTARINDAN FAZLA MİKTARI ONAYLAYAMAZSINIZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void TextMiktar3_TextChanged(object sender, EventArgs e)
        {
            foreach (char chr in TextMiktar3.Text)
            {
                if (char.IsLetter(chr))
                {
                    MessageBox.Show("MİKTAR SAYI OLMALIDIR", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextMiktar3.Text = "";
                    

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from RezervIzin where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextIstekID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele3();
            MessageBox.Show("İZİN İSTEĞİ İPTAL EDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
