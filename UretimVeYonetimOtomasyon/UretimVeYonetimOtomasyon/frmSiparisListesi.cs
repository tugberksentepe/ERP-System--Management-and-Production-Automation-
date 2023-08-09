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
    public partial class frmSiparisListesi : Form
    {
        public static string siparisNo;
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        
        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT S.SIPARIS_NO, M.MUSTERI_ADI, S.SIPARIS_TARIHI, S.TESLIM_TARIHI FROM TBL_SIPARISLER S LEFT JOIN TBL_MUSTERIKAYITLARI M ON S.MUSTERI_KODU=M.MUSTERI_KODU WHERE S.SIPARIS_NO LIKE '%"+txtSiparisNumarasi.Text+"%' AND M.MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource= dt;
            conn.Close();
        }
        
        public frmSiparisListesi()
        {
            InitializeComponent();
        }

        private void frmSiparisListesi_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable = false;
            arama();
        }

        private void txtSiparisNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (siparisNo == "sipariskayit")
            {
                siparisNo = x["SIPARIS_NO"].ToString();
                frmSiparisler.siparisx = "siparis";
                this.Hide();
                frmSiparisler frm = new frmSiparisler();
                frm.Activate();
            }
            else
            {

            }
        }

        private void frmSiparisListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            siparisNo = "";
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\Siparis_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\Siparis_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
