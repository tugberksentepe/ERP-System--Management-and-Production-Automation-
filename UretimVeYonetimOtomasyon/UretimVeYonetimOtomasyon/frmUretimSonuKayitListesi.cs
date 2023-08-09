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
    public partial class frmUretimSonuKayitListesi : Form
    {
        public static string fisNo;
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmUretimSonuKayitListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMSONUKAYDI_NUMARASI, SIPARIS_NUMARASI, STOK_KODU, STOK_ADI, MUSTERI_ADI, ISEMRI_NUMARASI FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI LIKE '%"+txtFisNo.Text+"%' AND SIPARIS_NUMARASI LIKE '%"+txtSiparisNumarasi.Text+"%' AND STOK_KODU LIKE '%"+txtStokKodu.Text+"%' AND STOK_ADI LIKE '%"+txtStokAdi.Text+"%' AND MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%' AND ISEMRI_NUMARASI LIKE '%"+txtIsEmriNumarasi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        private void frmUretimSonuKayitListesi_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable= false;  
            arama();
        }

        private void txtFisNo_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtSiparisNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtIsEmriNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (fisNo == "uretimsonukaydi")
            {
                fisNo = x["URETIMSONUKAYDI_NUMARASI"].ToString();
                frmUretimSonuKayitlari.fisX = "uretimsonukaydi";
                this.Hide();
                frmUretimSonuKayitlari frm = new frmUretimSonuKayitlari();
                frm.Activate();
            }
        }
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\UretimSonuKaydi_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\UretimSonuKaydi_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
