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
    public partial class StokCikisi : Form
    {
        public StokCikisi()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();

        public static int StokKodu;
        void listele_stok_cikis()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select StokKodu[STOK KODU],UrunAdi[ÜRÜN ADI],Tanim[TANIM],Uretici[ÜRETİCİ],Yuzey[YÜZEY],Boy[BOY],En[EN]," +
                "Kalinlik[KALINLIK],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI],format(Miktar,'###,###,###.###')[MİKTAR],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR]," +
                "format(MinMiktar,'###,###,###.###')[MİN MİKTAR],format(MaxMiktar,'###,###,###.###')[MAX MİKTAR],Tarih[TARİH] from Devreden1 order by StokKodu DESC", bgl.baglanti());
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
        public void listele_projekodu()
        {
            ComboProje.Items.Clear();
            ComboProje2.Items.Clear();

            SqlCommand komut = new SqlCommand("Select ProjeKodu from Projeler", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ComboProje.Items.Add(dr["ProjeKodu"]);
                ComboProje2.Items.Add(dr["ProjeKodu"]);
            }
            bgl.baglanti().Close();

        }
       
        void listele()
        {
            
            
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select ID,StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI]," +
                    "Uretici[ÜRETİCİ],Yuzey[YÜZEY],Tanim[TANIM],Boy[BOY],En[EN],Kalinlik[KALINLIK],Birim[BİRİM],format(BirimFiyati,'###,###,###.###')[BİRİM FİYATI]," +
                    "format(Miktar,'###,###,###.###')[MİKTAR],format(ToplamTutar,'###,###,###.###')[TOPLAM TUTAR],Tarih[TARİH],CikisID[ÇIKIŞ ID] From Proje_Stok_Cikislari  where StokKodu='" + TextStokKodu2.Text + "' ORDER BY ID DESC", bgl.baglanti());
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                bindingSource2.DataSource = dt; 
                bgl.baglanti().Close();

        }
        
        bool durum2;

        void kontrol2()
        {
            SqlCommand komut = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
           decimal miktar = Convert.ToDecimal(komut.ExecuteScalar());
            if(miktar < decimal.Parse(TextMiktar.Text))
            {
                durum2 = false;
                bgl.baglanti().Close();
            }
            else
            {
                durum2 = true;
                bgl.baglanti().Close();
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
       

        
        int girisid = Giris.id;
        String stok_cikis_duzenleme = Giris.yy10.ToString();
        private void StokCikisi_Load(object sender, EventArgs e)
        {
            if(int.Parse(stok_cikis_duzenleme) == 0)
            {
                button1.Enabled = false;
            }
            TextCikisID.Text = girisid.ToString();
            listele_stok_cikis();
            listele_projekodu();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TextStokKodu.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TextUrunAdi.Text= dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            TextUretici.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TextYuzey.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextBoy.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TextEn.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TextKalinlik.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TextBirim.Text= dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            RichTanim.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            
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
        bool durum7;
        void kontrol7()
        {
            foreach(char chr in ComboProje.Text)
            {
                if (!char.IsNumber(chr))
                {
                    durum7 = false;
                }
                else
                {
                    SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", ComboProje.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        durum7 = true;
                    }
                    else
                    {
                        durum7 = false;
                    }
                }
            }
            
            

        }
        
        decimal rezervStok;
        public void kontrol3()
        {
            SqlCommand komut2 = new SqlCommand("Select * from Rezerv where StokKodu=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TextStokKodu.Text);
            SqlDataReader dr = komut2.ExecuteReader();
            if (!dr.Read())
            {
                rezervStok = 0;
            }
            else
            {
                SqlCommand komut = new SqlCommand("Select Sum(Miktar) from Rezerv where StokKodu=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TextStokKodu.Text);
                rezervStok = Convert.ToDecimal(komut.ExecuteScalar());
            }

        }
        
        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {
            kontrol7();
            if(durum7 == true)
            {
                if (TextMiktar.Text == "")
                {
                    MessageBox.Show("MİKTAR BOŞ BIRAKILAMAZ", "ÇIKIŞ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {




                    kontrol2();
                    SqlCommand Kmiktar = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                    Kmiktar.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
                    decimal devredenMiktar = Convert.ToDecimal(Kmiktar.ExecuteScalar());
                    if (durum2 == true)
                    {
                        kontrol3();
                        if(decimal.Parse(TextMiktar.Text) > devredenMiktar - rezervStok)
                        {
                            DialogResult dialogResult = MessageBox.Show("STOK DÜŞME İŞLEMİ BAŞARISIZ REZERVE ALINMIŞ STOKLAR VAR REZERVE İZNİ İSTİYOR MUSUNUZ?", "HATA", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if(dialogResult == DialogResult.Yes)
                            {
                                
                                StokKodu = int.Parse(TextStokKodu.Text);
                                RezerveIzin rezerveIzin = new RezerveIzin();
                                rezerveIzin.Show();
                            }
                         
                        }

                        else
                        {
                            SqlCommand KbirimFiyati = new SqlCommand("Select BirimFiyati from Devreden1 where StokKodu=@p1", bgl.baglanti());
                            KbirimFiyati.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
                            decimal devredenBirimFiyat = Convert.ToDecimal(KbirimFiyati.ExecuteScalar());

                            SqlCommand komut = new SqlCommand("insert into Proje_Stok_Cikislari(StokKodu,Yuzey,Uretici,Boy,En,Kalinlik,Birim,UrunAdi,Miktar,Tarih,ProjeKodu,Firma,Proje,CikisID,Tanim,BirimFiyati,ToplamTutar) values (" +
                           "@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu.Text));
                            komut.Parameters.AddWithValue("@p2", TextYuzey.Text);
                            komut.Parameters.AddWithValue("@p3", TextUretici.Text);
                            komut.Parameters.AddWithValue("@p4", TextBoy.Text);
                            komut.Parameters.AddWithValue("@p5", TextEn.Text);
                            komut.Parameters.AddWithValue("@p6", decimal.Parse(TextKalinlik.Text));
                            komut.Parameters.AddWithValue("@p7", TextBirim.Text);
                            komut.Parameters.AddWithValue("@p8", TextUrunAdi.Text);
                            komut.Parameters.AddWithValue("@p9", decimal.Parse(TextMiktar.Text));
                            komut.Parameters.AddWithValue("@p10", Tarih.Value);
                            komut.Parameters.AddWithValue("@p11", int.Parse(ComboProje.Text));
                            komut.Parameters.AddWithValue("@p12", TextFirma.Text);
                            komut.Parameters.AddWithValue("@p13", RichProje.Text);
                            komut.Parameters.AddWithValue("@p14", int.Parse(TextCikisID.Text));
                            komut.Parameters.AddWithValue("@p15", RichTanim.Text);
                            komut.Parameters.AddWithValue("@p16", devredenBirimFiyat);
                            komut.Parameters.AddWithValue("@p17", devredenBirimFiyat * decimal.Parse(TextMiktar.Text));

                            komut.ExecuteNonQuery();





                            decimal yeniMiktar = devredenMiktar - decimal.Parse(TextMiktar.Text);
                            decimal yeniTutar = devredenBirimFiyat * yeniMiktar;

                            SqlCommand komut2 = new SqlCommand("update Devreden1 set Miktar=@p1,ToplamTutar=@p2 where StokKodu=@p3", bgl.baglanti());
                            komut2.Parameters.AddWithValue("@p1", yeniMiktar);
                            komut2.Parameters.AddWithValue("@p2", yeniTutar);
                            komut2.Parameters.AddWithValue("@p3", int.Parse(TextStokKodu.Text));
                            komut2.ExecuteNonQuery();


                            MessageBox.Show("STOKTAN DÜŞÜLDÜ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bgl.baglanti().Close();
                            listele_stok_cikis();
                          
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("STOKTAN DÜŞME BAŞARISIZ (DÜŞÜLECEK MİKTARDA STOK YOK)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else
            {
                MessageBox.Show("STOKTAN DÜŞME BAŞARISIZ (BÖYLE BİR PROJE KODU BULUNAMADI)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

     

        private void ComboProje2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextFirma2.Text = "";
           RichProje2.Text = "";

            SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ComboProje2.SelectedItem);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextFirma2.Text = dr["Firma"].ToString();
                RichProje2.Text = dr["Proje"].ToString();
            }
            bgl.baglanti().Close();
        }
        bool durum6;
        void kontrol6()
        {
            foreach (char chr in ComboProje2.Text)
            {
                if (!char.IsNumber(chr))
                {
                    durum6 = false;
                }
                else
                {
                    SqlCommand komut = new SqlCommand("Select * from Projeler where ProjeKodu=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", ComboProje2.Text);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        durum6 = true;
                    }
                    else
                    {
                        durum6 = false;
                    }

                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kontrol5();
            if (durum5 == true)
            {
                kontrol6();
                if (durum6 == true)
                {
                    if (TextMiktar2.Text == "")
                    {
                        MessageBox.Show("MİKTAR BOŞ BIRAKILAMAZ", "ÇIKIŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (decimal.Parse(TextMiktar2.Text) < 0)
                        {
                            MessageBox.Show("ÇIKIŞ DÜZENLEME İŞLEMİ BAŞARISIZ (MİKTAR SIFIRDAN KÜÇÜK OLAMAZ)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {

                            SqlCommand komut9 = new SqlCommand("Select Miktar from Proje_Stok_Cikislari where ID=@p1", bgl.baglanti());
                            komut9.Parameters.AddWithValue("@p1", TextID.Text);
                            decimal Cikis_eski_miktar = Convert.ToDecimal(komut9.ExecuteScalar());




                            if (decimal.Parse(TextMiktar2.Text) <= Cikis_eski_miktar)
                            {
                                SqlCommand Dbirimfiyat = new SqlCommand("Select BirimFiyati from Devreden1 where StokKodu=@p1", bgl.baglanti());
                                Dbirimfiyat.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu2.Text));
                                decimal DBirimfiyat = Convert.ToDecimal(Dbirimfiyat.ExecuteScalar());


                                SqlCommand komut = new SqlCommand("update Proje_Stok_Cikislari set Miktar=@p1, ToplamTutar =@p2,ProjeKodu=@p3,Firma=@p4,Proje=@p5 where ID=@p6", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p2", DBirimfiyat * decimal.Parse(TextMiktar2.Text));
                                komut.Parameters.AddWithValue("@p3", ComboProje2.Text);
                                komut.Parameters.AddWithValue("@p4", TextFirma2.Text);
                                komut.Parameters.AddWithValue("@p5", RichProje2.Text);
                                komut.Parameters.AddWithValue("@p6", int.Parse(TextID.Text));


                                SqlCommand Dmiktar = new SqlCommand("Select Miktar from Devreden1 where StokKodu=@p1", bgl.baglanti());
                                Dmiktar.Parameters.AddWithValue("@p1", int.Parse(TextStokKodu2.Text));
                                decimal DMiktar = Convert.ToDecimal(Dmiktar.ExecuteScalar());



                                decimal DuzMiktar = DMiktar + Cikis_eski_miktar;
                                decimal YeniMiktar = DuzMiktar - decimal.Parse(TextMiktar2.Text);



                                decimal ToplamTutar = YeniMiktar * DBirimfiyat;

                                SqlCommand komut2 = new SqlCommand("update Devreden1 set Miktar=@p1,ToplamTutar=@p2 where StokKodu=@p3", bgl.baglanti());
                                komut2.Parameters.AddWithValue("@p1", YeniMiktar);
                                komut2.Parameters.AddWithValue("@p2", ToplamTutar);
                                komut2.Parameters.AddWithValue("@p3", int.Parse(TextStokKodu2.Text));



                                komut.ExecuteNonQuery();
                                komut2.ExecuteNonQuery();

                                listele();

                                bgl.baglanti().Close();




                            }
                            else
                            {
                                MessageBox.Show("STOKTAN DÜŞME BAŞARISIZ (İLK GİRİLEN MİKTARDAN FAZLA STOK DÜŞÜLEMEZ)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                
               
                    
                }
                else
                {
                    MessageBox.Show("STOKTAN DÜŞME BAŞARISIZ (BÖYLE BİR PROJE KODU BULUNAMADI)", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
               
            }
            else 
            {
                MessageBox.Show("PROJE KODU TAM SAYI OLMALIDIR", "ÇIKIŞ DÜZENLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                
            }
           

            
                
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView1.FilterString;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void TextBoy_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void ComboProje_KeyDown(object sender, KeyEventArgs e)
        {

           




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

        private void ComboProje_SelectedValueChanged(object sender, EventArgs e)
        {

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

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TextStokKodu2.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            TextID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            ComboProje2.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            string miktar = dataGridView2.Rows[secilen].Cells[14].Value.ToString();
            string yeniMiktar = miktar.Replace(",", "");
            TextMiktar2.Text = yeniMiktar.Replace(".", ",");
            TextFirma2.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            RichProje2.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
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
