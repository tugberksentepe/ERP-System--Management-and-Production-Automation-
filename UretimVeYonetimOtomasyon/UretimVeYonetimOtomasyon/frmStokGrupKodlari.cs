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
    public partial class frmStokGrupKodlari : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmStokGrupKodlari()
        {
            InitializeComponent();
        }

        string x1 = "0";
        void grupkoduKontrol()
        {
            conn.Open();

            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }

        void grupkodubilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT GRUP_ADI FROM TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtGrupAdi.Text = dr[0].ToString();
            }
            conn.Close();
        }

        void grupkodulistele()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_GRUPKOD", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        void temizle()
        {
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
        }

        private void frmStokGrupKodlari_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable = false;
            grupkodulistele();  
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            DataRow satir = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtGrupKodu.Text = satir["GRUP_KODU"].ToString();
            txtGrupAdi.Text = satir["GRUP_ADI"].ToString();

        }

        private void txtGrupKodu_Leave(object sender, EventArgs e)
        {
            grupkoduKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                grupkodubilgisiCekme();
            }
            else
            {
                txtGrupAdi.Text = "";
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            grupkoduKontrol();
            if (Convert.ToInt16(x1)==1)
            {
                //güncelleme
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_GRUPKOD SET GRUP_ADI='"+txtGrupAdi.Text+"' WHERE GRUP_KODU='"+txtGrupKodu.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                grupkodulistele();
            }
            else
            {
                //yeni kayıt
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_GRUPKOD (GRUP_KODU,GRUP_ADI) VALUES ('"+txtGrupKodu.Text+"','"+txtGrupAdi.Text+"')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                grupkodulistele();
            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            grupkoduKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                grupkodulistele();
            }
            else
            {
                
            }
            
        }
    }
}
