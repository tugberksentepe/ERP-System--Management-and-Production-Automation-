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

namespace UretimVeYonetimOtomasyon
{
    public partial class frmGenelRapor : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmGenelRapor()
        {
            InitializeComponent();
        }

        void sevkeHazirSiparisListeleme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO AS 'SİPARİŞ NUMARASI', MK.MUSTERI_ADI AS 'MÜŞTERİ ADI', TESLIM_TARIHI AS 'TESLİM TARİHİ', TOPLAM_TUTAR AS 'TOPLAM TUTAR'" +
                " FROM TBL_SIPARISLER SIP LEFT JOIN TBL_MUSTERIKAYITLARI MK ON SIP.MUSTERI_KODU=MK.MUSTERI_KODU " +
                "WHERE SIPARIS_NO NOT IN(SELECT DISTINCT SIPARIS_NO FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU ='A' OR URETIMDURUMU='K' OR URETIMDURUMU='S')", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSiparisListesi.DataSource= dt;
            conn.Close();
        }

        void stokKontrolRaporu()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT SK.STOK_KODU AS 'STOK KODU', SK.STOK_ADI AS 'STOK ADI', " +
                "(SELECT ISNULL(SUM(MIKTAR),0) FROM TBL_SIPARISKALEMLERI SIP WHERE SIP.STOK_KODU=SK.STOK_KODU AND (URETIMDURUMU='K' OR URETIMDURUMU='B' OR URETIMDURUMU='A')) AS 'SİPARİŞ MIKTARI', " +
                "(SELECT ISNULL(SUM(MIKTAR),0) FROM TBL_ISEMRI MR WHERE MR.STOK_KODU=SK.STOK_KODU AND DURUM='Y') AS 'İŞ EMRİ MİKTARI', " +
                "(SELECT ISNULL(SUM(G_MIKTAR)-SUM(C_MIKTAR),0) FROM TBL_STOKHAREKETLERI SH WHERE SH.STOK_KODU=SK.STOK_KODU) AS 'STOK MİKTARI' " +
                "FROM TBL_STOKKAYITLARI SK", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlStokKontrol.DataSource = dt;
            conn.Close();
        }

        void eksikIsEmirleri()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU AS 'STOK KODU', STOK_ADI AS 'STOK ADI', MIKTAR AS 'MİKTAR', SIPKALEM_ID AS 'SİPARİŞ ID'" +
                " FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU='K'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlIsEmri.DataSource = dt;
            conn.Close();
        }

        void stokSatisRaporu()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 25 STOK_ADI AS 'STOK ADI', SUM(MIKTAR) AS 'TOPLAM SATIŞ MİKTARI' " +
                "FROM TBL_SIPARISKALEMLERI SIP GROUP BY STOK_ADI ORDER BY SUM(MIKTAR) DESC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSatisRaporu.DataSource = dt;
            conn.Close();
        }

        void musteriListeleme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 10 MUSTERI_ADI AS 'MÜŞTERİ ADI', SUM(TOPLAM_TUTAR) AS 'TOPLAM CİRO' " +
                "FROM TBL_SIPARISLER S LEFT JOIN TBL_MUSTERIKAYITLARI MK ON S.MUSTERI_KODU=MK.MUSTERI_KODU GROUP BY MK.MUSTERI_ADI ORDER BY SUM(TOPLAM_TUTAR) DESC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlMusteriCiro.DataSource = dt;
            conn.Close();
        }

        private void frmGenelRapor_Load(object sender, EventArgs e)
        {
            gViewIsEmri.OptionsBehavior.Editable = false;
            gViewMusteriCiro.OptionsBehavior.Editable = false;
            gViewSatisRaporu.OptionsBehavior.Editable = false;
            gViewSiparisListesi.OptionsBehavior.Editable = false;
            gViewStokKontrol.OptionsBehavior.Editable = false;
            sevkeHazirSiparisListeleme();
            stokKontrolRaporu();
            eksikIsEmirleri();
            stokSatisRaporu();
            musteriListeleme();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
