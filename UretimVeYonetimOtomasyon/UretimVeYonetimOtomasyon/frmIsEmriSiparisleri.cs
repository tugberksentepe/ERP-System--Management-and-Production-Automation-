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
    public partial class frmIsEmriSiparisleri : Form
    {   
        public static string kalemId;

        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmIsEmriSiparisleri()
        {
            InitializeComponent();
        }
        
        private void frmIsEmriSiparisleri_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO, STOK_KODU, STOK_ADI, MIKTAR, SIPKALEM_ID FROM TBL_SIPARISKALEMLERI WHERE STOK_KODU='"+frmIsEmri.stokKodu+"' AND URETIMDURUMU='K'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource= dt;
            conn.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            kalemId = x["SIPKALEM_ID"].ToString();
            frmIsEmri.isEmriX = "siparis";
            this.Hide();
            frmIsEmri frm = new frmIsEmri();
            frm.Activate();
        }

        private void frmIsEmriSiparisleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            kalemId = "";
        }
    }
}
