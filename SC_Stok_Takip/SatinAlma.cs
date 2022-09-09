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
    public partial class SatinAlma : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        BindingSource bindingSource1 = new BindingSource();
        public SatinAlma()
        {
            InitializeComponent();
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



            //System.Data.DataTable dt = new System.Data.DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("Select * from Siparis where Durumu != @p1 and Durumu!= @p2 order by ID DESC", bgl.baglanti());
            //da.SelectCommand.Parameters.AddWithValue("@p1", "SİPARİŞ VERİLDİ");
            //da.SelectCommand.Parameters.AddWithValue("@p2", "STOĞA EKLENDİ");
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            SqlDataAdapter da = new SqlDataAdapter("Select * from Siparis where Durumu!=@p1 and Durumu!= @p2 order by ID DESC", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", "SİPARİŞ VERİLDİ");
            da.SelectCommand.Parameters.AddWithValue("@p2", "STOĞA EKLENDİ");
            DataTable dt = new DataTable();
            da.Fill(dt);

            //dataGridView1.Rows.Clear();

            //foreach (DataRow item in dt.Rows)
            //{
            //    int n = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[n].Cells[0].Value = false;
            //    dataGridView1.Rows[n].Cells[1].Value = item["ID"].ToString();
            //    dataGridView1.Rows[n].Cells[2].Value = item["StokKodu"].ToString();
            //    dataGridView1.Rows[n].Cells[3].Value = item["ProjeKodu"].ToString();
            //    dataGridView1.Rows[n].Cells[4].Value = item["Firma"].ToString();
            //    dataGridView1.Rows[n].Cells[5].Value = item["Proje"].ToString();
            //    dataGridView1.Rows[n].Cells[6].Value = item["UrunAdi"].ToString();
            //    dataGridView1.Rows[n].Cells[7].Value = item["Uretici"].ToString();

            //    dataGridView1.Rows[n].Cells[8].Value = item["Yuzey"].ToString();
            //    dataGridView1.Rows[n].Cells[9].Value = item["Boy"].ToString();
            //    dataGridView1.Rows[n].Cells[10].Value = item["En"].ToString();
            //    dataGridView1.Rows[n].Cells[11].Value = item["Kalinlik"].ToString();
            //    dataGridView1.Rows[n].Cells[12].Value = item["Birim"].ToString();
            //    dataGridView1.Rows[n].Cells[13].Value = item["Miktar"].ToString();
            //    dataGridView1.Rows[n].Cells[14].Value = item["AlinanMiktar"].ToString();
            //    dataGridView1.Rows[n].Cells[15].Value = item["KalanMiktar"].ToString();
            //    dataGridView1.Rows[n].Cells[16].Value = item["Tanim"].ToString();
            //    dataGridView1.Rows[n].Cells[17].Value = item["Aciklama"].ToString();
            //    dataGridView1.Rows[n].Cells[18].Value = item["SAciklama"].ToString();
            //    dataGridView1.Rows[n].Cells[19].Value = item["TalepTarihi"].ToString();
            //    dataGridView1.Rows[n].Cells[20].Value = item["SiparisTarihi"].ToString();
            //    dataGridView1.Rows[n].Cells[21].Value = item["TerminTarihi"].ToString();
            //    dataGridView1.Rows[n].Cells[22].Value = item["SiparisAcan"].ToString();
            //    dataGridView1.Rows[n].Cells[23].Value = item["Durumu"].ToString();
            //    dataGridView1.Rows[n].Cells[24].Value = item["FirmaBilgisi"].ToString();
            //    dataGridView1.Rows[n].Cells[25].Value = item["StokEklenenMiktar"].ToString();


            //}





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
            if (ToplamAlinanMiktar > Miktar + x)
            {
                durum2 = false;
            }
            else
            {
                durum2 = true;
            }

        }

        private void SatinAlma_Load(object sender, EventArgs e)
        {
            listele_firmalar();
            timer1.Interval = 360000;
            timer1.Start();
            listele();
            FirmaList();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (TextAlinanMiktar.Text == "" | listBox1.SelectedItem == null | ComboDurum.SelectedItem == null)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var v = @"SatınAlma.csv";
            StreamWriter tw = new StreamWriter(path + @"\SatinAlma.csv", false, Encoding.UTF8);


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

                    //if ((bool)dataGridView1.Rows[x].Cells[0].Value == true)

                   // DataRow row = dataGridView1.Rows[x];
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
//int secilen = dataGridView1.SelectedCells[0].RowIndex;
//TextID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
//TextStokKodu.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
//ComboProje.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
//TextFirma.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
//RichProje.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
//TextUrunAdi.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
//TextUretici.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
//TextYuzey.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
//TextBoy.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
//TextEn.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
//TextKalinlik.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
//TextBirim.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
//TextMiktar.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
//TextAlinanMiktar.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
//RichTanim.Text = dataGridView1.Rows[secilen].Cells[15].Value.ToString();

//TextSiparisAcan.Text = dataGridView1.Rows[secilen].Cells[21].Value.ToString();
//listBox1.Text = dataGridView1.Rows[secilen].Cells[23].Value.ToString();