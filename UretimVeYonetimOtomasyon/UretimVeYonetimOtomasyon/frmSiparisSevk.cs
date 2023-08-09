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
    public partial class frmSiparisSevk : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmSiparisSevk()
        {
            InitializeComponent();
        }

        void musteriListesiCekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_KODU, MUSTERI_ADI FROM TBL_MUSTERIKAYITLARI", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            searchLookUpEdit1.Properties.ValueMember = "MUSTERI_KODU";
            searchLookUpEdit1.Properties.DisplayMember= "MUSTERI_ADI";
            searchLookUpEdit1.Properties.DataSource = dt;
            conn.Close();
        }

        void siparisListesiCekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO, TESLIM_TARIHI, TOPLAM_TUTAR FROM TBL_SIPARISLER WHERE SIPARIS_NO NOT IN (SELECT DISTINCT SIPARIS_NO FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU='K' OR URETIMDURUMU='A' OR URETIMDURUMU='S') AND MUSTERI_KODU='"+searchLookUpEdit1.EditValue+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSiparis.DataSource = dt;
            conn.Close();
        }

        private void frmSiparisSevk_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            searchLookUpEdit1.EditValue = "";
            gViewSiparis.OptionsBehavior.Editable= false;
            gViewUrunler.OptionsBehavior.Editable= false; 
            musteriListesiCekme();
        }

        private void sbtnSiparisRapor_Click(object sender, EventArgs e)
        {
            siparisListesiCekme();
        }

        string z = "";
        private void gViewSiparis_Click(object sender, EventArgs e)
        {
            DataRow x = gViewSiparis.GetDataRow(gViewSiparis.FocusedRowHandle);
            z = x["SIPARIS_NO"].ToString();
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU, STOK_ADI, MIKTAR, URUN_ACIKLAMASI, SIPKALEM_ID FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+z+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlUrunler.DataSource = dt;
            conn.Close();
        }

        private void sbtnSevkEmri_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(gViewUrunler.RowCount.ToString());
            for (int i = 0; i <= x-1; i++)
            {
                string musteriKodu = "";
                string stokKodu = "";
                string stokAdi = "";
                string miktar = "";
                string musteriAdi = "";
                string kalemId = gViewUrunler.GetRowCellValue(i, "SIPKALEM_ID").ToString();
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("SELECT S.MUSTERI_KODU, SK.STOK_KODU, SK.STOK_ADI, SK.MIKTAR, MK.MUSTERI_ADI FROM TBL_SIPARISKALEMLERI SK LEFT JOIN TBL_SIPARISLER S ON SK.SIPARIS_NO=S.SIPARIS_NO LEFT JOIN TBL_MUSTERIKAYITLARI MK ON S.MUSTERI_KODU=MK.MUSTERI_KODU WHERE SIPKALEM_ID='"+kalemId+"'", conn);
                SqlDataReader dr = sorgu1.ExecuteReader();
                while(dr.Read())
                {
                    musteriKodu = dr[0].ToString();
                    stokKodu = dr[1].ToString();
                    stokAdi = dr[2].ToString();
                    miktar = dr[3].ToString();
                    musteriAdi = dr[4].ToString();
                }
                conn.Close() ;

                conn.Open();
                SqlCommand sorgu2 = new SqlCommand("INSERT INTO TBL_STOKHAREKETLERI (URETIMSONUKAYDI_NUMARASI, ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, G_MIKTAR, C_MIKTAR, MUSTERI_ADI, ACIKLAMA) VALUES ('"+musteriKodu+"','','"+stokKodu+"','"+stokAdi+"','0','"+miktar.Replace(',','.')+"','"+musteriAdi+"','SEVKİYAT')", conn);
                sorgu2.ExecuteNonQuery();
                conn.Close();
            }
            conn.Open();
            SqlCommand sorgu3 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='S' WHERE SIPARIS_NO='" + z + "'", conn);
            sorgu3.ExecuteNonQuery();
            conn.Close();
            siparisListesiCekme();
            gControlUrunler.DataSource = "";
        }
    }
}
