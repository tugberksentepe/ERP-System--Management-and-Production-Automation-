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
    public partial class frmStokHareketleri : Form
    {
        public static string stokHareketX;
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmStokHareketleri()
        {
            InitializeComponent();
        }

        void stokBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SK.STOK_ADI, GK.GRUP_ADI FROM TBL_STOKKAYITLARI SK LEFT JOIN TBL_GRUPKOD GK ON SK.GRUP_KODU=GK.GRUP_KODU WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[0].ToString();
                txtGrupAdi.Text = dr[1].ToString();
            }
            conn.Close();

            conn.Open();
            SqlCommand sorgu2 = new SqlCommand("SELECT ISNULL((SUM(G_MIKTAR)-SUM(C_MIKTAR)),0) AS 'STOK MİKTARI' FROM TBL_STOKHAREKETLERI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataReader dr1 = sorgu2.ExecuteReader();
            while (dr1.Read())
            {
                txtStokMiktari.Text = dr1[0].ToString();
            }
            conn.Close();
        }

        void stokHareketListesiCekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMSONUKAYDI_NUMARASI AS 'ÜRETİM SONU KAYDI', ISEMRI_NUMARASI AS 'İŞ EMRİ NUMARASI', ACIKLAMA AS 'AÇIKLAMA', STOK_KODU 'STOK KODU', STOK_ADI AS 'STOK ADI', G_MIKTAR AS 'ÜRETİM MİKTARI', C_MIKTAR AS 'SEVK MİKTARI', MUSTERI_ADI AS 'MÜŞTERİ ADI' FROM TBL_STOKHAREKETLERI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        void temizle()
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtGrupAdi.Text = "";
            txtStokMiktari.Text = "";
            gridControl1.DataSource = "";
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            frmStokListesi.stokkodu = "stokhareket";
            frmStokListesi frm = new frmStokListesi();
            frm.Show();
        }

        private void frmStokHareketleri_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable=false;
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokBilgisiCekme();
            stokHareketListesiCekme();
        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void frmStokHareketleri_Activated(object sender, EventArgs e)
        {
            if (stokHareketX == "stok")
            {
                txtStokKodu.Text = frmStokListesi.stokkodu;
                stokBilgisiCekme();
                stokHareketListesiCekme();
                stokHareketX = "";
            }
        }

        private void frmStokHareketleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStokListesi.stokkodu = "";
            stokHareketX = "";
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tur = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle,"AÇIKLAMA"));
            if (tur == "ÜRETİM")
            {
                e.Appearance.BackColor = Color.Green;
            }
            else
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\StokHareketleri_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\StokHareketleri_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
