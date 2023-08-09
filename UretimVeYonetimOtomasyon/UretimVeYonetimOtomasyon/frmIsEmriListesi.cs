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
    public partial class frmIsEmriListesi : Form
    {
        public static string isEmriNo;
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmIsEmriListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, SIPARIS_NO FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI LIKE '%"+txtIsEmriNumarasi.Text+"%' AND STOK_KODU LIKE '%"+txtStokKodu.Text+"%' AND STOK_ADI LIKE '%"+txtStokAdi.Text+"%' AND SIPARIS_NO LIKE '%"+txtSiparisNumarasi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        void arama2()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, SIPARIS_NO FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI LIKE '%" + txtIsEmriNumarasi.Text + "%' AND STOK_KODU LIKE '%" + txtStokKodu.Text + "%' AND STOK_ADI LIKE '%" + txtStokAdi.Text + "%' AND SIPARIS_NO LIKE '%" + txtSiparisNumarasi.Text + "%' AND DURUM='Y'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        private void frmIsEmriListesi_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable = false;
            if (isEmriNo=="uretimsonukayit")
            {
                arama2();
            }
            else
            {
                arama();
            }
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (isEmriNo == "isemrikayit")
            {
                isEmriNo = x["ISEMRI_NUMARASI"].ToString();
                frmIsEmri.isEmriX = "isemri";
                this.Hide();
                frmIsEmri frm = new frmIsEmri();
                frm.Activate();
            }
            if (isEmriNo == "uretimsonukayit")
            {
                isEmriNo = x["ISEMRI_NUMARASI"].ToString();
                frmUretimSonuKayitlari.fisX = "isemri";
                this.Hide();
                frmUretimSonuKayitlari frm = new frmUretimSonuKayitlari();
                frm.Activate();
            }
        }

        private void frmIsEmriListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            isEmriNo = "";
        }

        private void txtIsEmriNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (isEmriNo == "uretimsonukayit")
            {
                arama2();
            }
            else
            {
                arama();
            }
        }

        private void txtSiparisNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (isEmriNo == "uretimsonukayit")
            {
                arama2();
            }
            else
            {
                arama();
            }
        }

        private void txtStokKodu_TextChanged(object sender, EventArgs e)
        {
            if (isEmriNo == "uretimsonukayit")
            {
                arama2();
            }
            else
            {
                arama();
            }
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            if (isEmriNo == "uretimsonukayit")
            {
                arama2();
            }
            else
            {
                arama();
            }
        }
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\IsEmri_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\IsEmri_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
