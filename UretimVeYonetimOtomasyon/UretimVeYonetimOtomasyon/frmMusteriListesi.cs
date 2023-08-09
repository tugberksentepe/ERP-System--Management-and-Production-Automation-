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
    public partial class frmMusteriListesi : Form
    {
        public static string musterikodu;

        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmMusteriListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_KODU, MUSTERI_ADI, IL, ILCE FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU LIKE '%"+txtMusteriKodu.Text+"%' AND MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%' AND IL LIKE '%"+txtIl.Text+"%' AND ILCE LIKE '%"+txtIlce.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        private void frmMusteriListesi_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable= false;
            arama();
        }

        private void txtMusteriKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtIl_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtIlce_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (musterikodu == "musterikayit")
            {
                musterikodu =x["MUSTERI_KODU"].ToString();
                this.Hide();
                frmMusteriKayitlari frm = new frmMusteriKayitlari();
                frm.Activate();
            }
            else
            {
                if (musterikodu == "sipariskayit")
                {
                    musterikodu = x["MUSTERI_KODU"].ToString();
                    frmSiparisler.siparisx = "musteri";
                    this.Hide();
                    frmSiparisler frm = new frmSiparisler();
                    frm.Activate();
                }
            }
        }

        private void frmMusteriListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            musterikodu = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\MUSTERI_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\MUSTERI_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
