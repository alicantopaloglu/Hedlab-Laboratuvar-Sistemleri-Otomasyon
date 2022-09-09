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
using Microsoft.Reporting.WinForms;

namespace SC_Stok_Takip
{
    public partial class Raporlar : Form
    {
        SqlBaglanti bgl = new SqlBaglanti();
        public Raporlar()
        {
            InitializeComponent();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer8.RefreshReport();
            FirmaList();
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Proje_Stok_Cikislari where Tarih between @tr1 and @tr2 order by ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@tr1", BaslangicTarihi2.Value.Date);
            komut.Parameters.AddWithValue("@tr2", BitisTarihi2.Value.Date.AddDays(1));
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokCikislari", dt);
            reportViewer2.LocalReport.ReportPath = "Report4.rdlc";
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(rds);
            reportViewer2.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * where StokKodu='" + TextStokKodu2.Text + "' order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokCikislari", dt);
            reportViewer6.LocalReport.ReportPath = "Report4.rdlc";
            reportViewer6.LocalReport.DataSources.Clear();
            reportViewer6.LocalReport.DataSources.Add(rds);
            reportViewer6.RefreshReport();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Proje_Stok_Cikislari where ProjeKodu='" + TextProjeKodu2.Text + "' order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokCikislari", dt);
            reportViewer7.LocalReport.ReportPath = "Report4.rdlc";
            reportViewer7.LocalReport.DataSources.Clear();
            reportViewer7.LocalReport.DataSources.Add(rds);
            reportViewer7.RefreshReport();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Proje_Stok_Cikislari order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokCikislari", dt);
            reportViewer8.LocalReport.ReportPath ="Report4.rdlc";
            reportViewer8.LocalReport.DataSources.Clear();
            reportViewer8.LocalReport.DataSources.Add(rds);
            reportViewer8.RefreshReport();
        }

        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri where Tarih between @tr1 and @tr2 order by ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@tr1", BaslangicTarihi1.Value.Date);
            komut.Parameters.AddWithValue("@tr2", BitisTarihi1.Value.Date.AddDays(1));
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
           
            reportViewer1.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri where StokKodu='" + TextStokKodu.Text + "' order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
            reportViewer3.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.DataSources.Add(rds);
            reportViewer3.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri where ProjeKodu='" + TextProjeKodu.Text + "' order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
            reportViewer4.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer4.LocalReport.DataSources.Clear();
            reportViewer4.LocalReport.DataSources.Add(rds);
            reportViewer4.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri order by ID", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
            reportViewer5.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer5.LocalReport.DataSources.Clear();
            reportViewer5.LocalReport.DataSources.Add(rds);
            reportViewer5.RefreshReport();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri where FirmaAdi=@p1 order by ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
            reportViewer9.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer9.LocalReport.DataSources.Clear();
            reportViewer9.LocalReport.DataSources.Add(rds);
            reportViewer9.RefreshReport();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Stok_Girisleri where FirmaAdi=@p1 and Tarih between @tr1 and @tr2 order by ID", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", listBox1.SelectedItem);
            komut.Parameters.AddWithValue("@tr1", dateTimePicker2.Value.Date);
            komut.Parameters.AddWithValue("@tr2", dateTimePicker1.Value.Date.AddDays(1));
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("StokGirisleri", dt);
            reportViewer9.LocalReport.ReportPath = "Report5.rdlc";
            reportViewer9.LocalReport.DataSources.Clear();
            reportViewer9.LocalReport.DataSources.Add(rds);
            reportViewer9.RefreshReport();

        }
    }
}
