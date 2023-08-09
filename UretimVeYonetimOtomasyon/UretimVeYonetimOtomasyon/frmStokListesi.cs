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
    public partial class frmStokListesi : Form
    {
        public static string stokkodu;

        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmStokListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_STOKKAYITLARI WHERE STOK_KODU LIKE '%" + txtStokKodu.Text + "%' AND STOK_ADI LIKE '%" + txtStokAdi.Text + "%' AND GRUP_KODU LIKE '%" + txtGrupKodu.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource= dt;    
            conn.Close();
        }

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable= false;  
            arama();
        }

        private void txtStokKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtGrupKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow satir = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (stokkodu == "kayit")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                this.Hide();
                frmStokKayitlari frm = new frmStokKayitlari();
                frm.Activate();
            }
            if (stokkodu == "sipariskayit")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                frmSiparisler.siparisx = "stok";
                this.Hide();
                frmSiparisler frm = new frmSiparisler();
                frm.Activate();
            }
            if (stokkodu == "isemri")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                frmIsEmri.isEmriX = "stok";
                this.Hide();
                frmIsEmri frm = new frmIsEmri();
                frm.Activate();
            }
            if (stokkodu == "stokhareket")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                frmStokHareketleri.stokHareketX = "stok";
                this.Hide();
                frmStokHareketleri frm = new frmStokHareketleri();
                frm.Activate();
            }


        }

        private void frmStokListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            stokkodu = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\STOK_Listesi.pdf");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ExportToXls(@"F:\Yönetim ve Üretim Otomasyonu\PDF VE EXCEL\STOK_Listesi.xls");
            MessageBox.Show("Dosyanız başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
