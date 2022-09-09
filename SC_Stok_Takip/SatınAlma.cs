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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DataTable = System.Data.DataTable;

namespace SC_Stok_Takip
{
    public partial class SatınAlma : Form
    {
        public SatınAlma()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        BindingSource bindingSource2 = new BindingSource();
        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {


        }
        public void FirmaList()
        {
            listBox1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select FirmaAdi from Firmalar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["FirmaAdi"]);
            }

        }
        void listele()
        {



            SqlDataAdapter da = new SqlDataAdapter("Select ID[ID],StokKodu[STOK KODU],ProjeKodu[PROJE KODU],Firma[FİRMA],Proje[PROJE],UrunAdi[ÜRÜN ADI],Uretici[ÜRETİCİ],Yuzey[YÜZEY], " +
                "Boy[BOY],En[EN],Kalinlik[KALINLIK],Birim[BİRİM],FORMAT(Miktar,'###,###,###.###')[MİKTAR],FORMAT(AlinanMiktar,'###,###,###.###')[ALINAN MİKTAR],FORMAT(KalanMiktar,'###,###.###')[KALAN MİKTAR],Tanim[TANIM],Aciklama[AÇIKLAMA],SAciklama[SATIN ALMA AÇIKLAMA],TalepTarihi[TALEP TARİHİ]," +
                "SiparisTarihi[SİPARİŞ TARİHİ],TerminTarihi[TERMİN TARİHİ],SiparisAcan[SİPARİŞİ AÇAN],Durumu[DURUMU],FirmaBilgisi[FİRMA BİLGİSİ],format(StokEklenenMiktar,'###,###,###.###')[STOĞA EKLENEN MİKTAR] from Siparis where Durumu!=@p1 and Durumu!= @p2 order by ID DESC", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", "SİPARİŞ VERİLDİ");
            da.SelectCommand.Parameters.AddWithValue("@p2", "STOĞA EKLENDİ");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bindingSource2.DataSource = dt;
            tablo1();
            

        }
        public void tablo1()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                if (Convert.ToString(dataGridView1.Rows[i].Cells[14].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[14].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[15].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[15].Value = 0;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells[25].Value) == "")
                {
                    dataGridView1.Rows[i].Cells[25].Value = 0;
                }
            }
        }
        void listele_firmalar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Firmalar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bindingSource1.DataSource = dt;
        }
        bool durum;
        void kontrol()
        {
            if (listBox1.SelectedItem == null)
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
            SqlCommand komut = new SqlCommand("Select AlinanMiktar from Siparis where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            decimal AlinanMiktar = Convert.ToDecimal(komut.ExecuteScalar());

            SqlCommand komut2 = new SqlCommand("Select Miktar from Siparis where ID=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
            decimal Miktar = Convert.ToDecimal(komut2.ExecuteScalar());
            decimal x = 0.001M;
            decimal ToplamAlinanMiktar = AlinanMiktar + decimal.Parse(TextAlinanMiktar.Text);
            if(ToplamAlinanMiktar > Miktar+x)
            {
                durum2 = false;
            }
            else
            {
                durum2 = true;
            }
            
        }
        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (TextAlinanMiktar.Text == "" | listBox1.SelectedItem==null | ComboDurum.SelectedItem==null)
            {
                MessageBox.Show("KAYIT BAŞARISIZ MİKTAR, FİRMA BİLGİSİ VE DURUM BOŞ BIRAKILAMAZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                kontrol2();
                if (durum2 == false)
                {
                    MessageBox.Show("SİPARİS MİKTARINDAN FAZLA MİKTARI ONAYLAYAMAZSINIZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    kontrol();
                    if (durum == true)
                    {


                        if (decimal.Parse(TextAlinanMiktar.Text) <= 0)
                        {
                            MessageBox.Show("KAYIT BAŞARISIZ (ALINAN MİKTAR 0 YA DA 0 DAN KÜÇÜK OLAMAZ)", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            SqlCommand komut4 = new SqlCommand("Select Miktar from Siparis where ID = @p1", bgl.baglanti());
                            komut4.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
                            decimal SMiktar = Convert.ToDecimal(komut4.ExecuteScalar());
                            SqlCommand komut5 = new SqlCommand("Select AlinanMiktar from Siparis where ID = @p1", bgl.baglanti());
                            komut5.Parameters.AddWithValue("@p1", int.Parse(TextID.Text));
                           decimal Amiktar = Convert.ToDecimal(komut5.ExecuteScalar());

                           decimal Aamiktar = Amiktar + decimal.Parse(TextAlinanMiktar.Text); // Bu bölüm stok girişinde olacaktı satın almada değil.

                            SqlCommand komut = new SqlCommand("update Siparis set SiparisTarihi=@p1,FirmaBilgisi=@p4,TerminTarihi=@p5, SAciklama=@p3, AlinanMiktar=@p2 where ID=@p7", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", SiparisTarihi.Value);
                            komut.Parameters.AddWithValue("@p2", Aamiktar);
                            komut.Parameters.AddWithValue("@p4", listBox1.SelectedItem);
                            komut.Parameters.AddWithValue("@p3", TextSAciklama.Text);
                            komut.Parameters.AddWithValue("@p5", TerminTarih.Value);
                            komut.Parameters.AddWithValue("@p7", int.Parse(TextID.Text));
                            komut.ExecuteNonQuery();


                            decimal Kmiktar = SMiktar - Aamiktar;



                            SqlCommand komut3 = new SqlCommand("update Siparis set KalanMiktar=@p1, Durumu =@p4 where ID=@p2", bgl.baglanti());
                            if (Kmiktar != 0)
                            {
                                komut3.Parameters.AddWithValue("@p2", TextID.Text);
                                komut3.Parameters.AddWithValue("@p1", Kmiktar);
                                komut3.Parameters.AddWithValue("@p4", "EKSİK VAR");

                            }
                            else
                            {
                                komut3.Parameters.AddWithValue("@p2", TextID.Text);
                                komut3.Parameters.AddWithValue("@p1", Kmiktar);
                                komut3.Parameters.AddWithValue("@p4", ComboDurum.SelectedItem);


                            }
                            komut3.ExecuteNonQuery();

                            MessageBox.Show("BİLGİ", "SİPARİŞ ONAYLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            bgl.baglanti().Close();
                            listele();

                        }
                    }



                    else
                    {
                        MessageBox.Show("FİRMA BİLGİSİ GİRİLMEDİ", "KAYIT BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            
        }
       

        private void SatınAlma_Load(object sender, EventArgs e)
        {
            
            listele_firmalar();
            timer1.Interval = 360000;
            timer1.Start();
            listele();
            FirmaList();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.ReadOnly = true;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = false;
            }
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
        }

      

        private void TextAlinanMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboProje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var v = @"SatınAlma.csv";
            StreamWriter tw = new StreamWriter(path + @"\SatinAlma.csv",false,Encoding.UTF8);
            
            
            for (int a = 1; a < dataGridView1.Columns.Count + 1; a++)
            {
                tw.Write(dataGridView1.Columns[a - 1].HeaderText.ToString() + ";");
            }
            tw.Write("\n");

            //foreach (DataGridViewRow item in dataGridView1.Rows)
           // {
                //if ((bool)item.Cells[0].Value == true)
               
                
                    for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        for (int j = 0; j < dataGridView1.Rows[x].Cells.Count; j++)
                        {
                    DataGridViewCheckBoxCell chk = dataGridView1.Rows[x].Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        tw.Write(dataGridView1.Rows[x].Cells[j].Value.ToString() + ";");
                    }
                        
                          
                        }
                        tw.Write("\n");


                    }
                
         
            tw.Close();
            MessageBox.Show("Seçilen Ürünler Excell'e Başarıyla Aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        

       

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {

        }

        private void ComboDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource1.Filter = this.dataGridView2.FilterString;
        }

        private void dataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            

            this.bindingSource1.Sort = this.dataGridView2.SortString;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            listBox1.SelectedItem = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
        }

        private void TextFirmaBilgisi_TextChanged(object sender, EventArgs e)
        {

        }

       





        

       
  

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TextID.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TextStokKodu.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            ComboProje.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TextFirma.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            RichProje.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TextUrunAdi.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            TextUretici.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            TextYuzey.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            TextBoy.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            TextEn.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            TextKalinlik.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            TextBirim.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            TextMiktar.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            string alinan = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
            string yeniAlinan = alinan.Replace(",", "");

            TextAlinanMiktar.Text = yeniAlinan.Replace(".", ",");


            TextSAciklama.Text = dataGridView1.Rows[secilen].Cells[18].Value.ToString();
            SiparisTarihi.Text = dataGridView1.Rows[secilen].Cells[20].Value.ToString();
            TerminTarih.Text = dataGridView1.Rows[secilen].Cells[21].Value.ToString();
            TextSiparisAcan.Text = dataGridView1.Rows[secilen].Cells[22].Value.ToString();
            ComboDurum.Text = dataGridView1.Rows[secilen].Cells[23].Value.ToString();

            RichTanim.Text = dataGridView1.Rows[secilen].Cells[16].Value.ToString();
        }
        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Sort = this.dataGridView1.SortString;
        }

        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindingSource2.Filter= this.dataGridView1.FilterString;
        }

       
    }
}       
