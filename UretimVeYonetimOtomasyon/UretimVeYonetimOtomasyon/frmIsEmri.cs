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
    public partial class frmIsEmri : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmIsEmri()
        {
            InitializeComponent();
        }
        string x1 = "0";
        void isEmriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while(dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }

        void isEmriBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokKodu.Text = dr[1].ToString();
                txtStokAdi.Text = dr[2].ToString();
                txtIsEmriAciklamasi.Text = dr[3].ToString();
                txtIsEmriTarihi.Text = dr[4].ToString();
                txtTeslimTarihi.Text = dr[5].ToString();    
                txtSiparisNumarasi.Text = dr[6].ToString();
                txtMiktar.Text = dr[7].ToString();
                txtKalemID.Text = dr[8].ToString();
                string x = dr[9].ToString();
                if (x == "Y")
                {
                    rbtnYeni.Checked = true;
                }
                else
                {
                    rbtnTamamlanmis.Checked = true;
                }
            }
            conn.Close();
            txtStokKodu.Enabled= false;
            txtMiktar.Enabled= false;
            txtSiparisNumarasi.Enabled= false;
            sbtnStokListesi.Enabled= false;
            sbtnSiparisListesi.Enabled = false;
        }

        string x2 = "0";
        void stokKartiKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2= dr[0].ToString();
            }
            conn.Close();
        }

        void stokBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_ADI FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[0].ToString();
            }
            conn.Close();
        }

        void siparisKalemiAcma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='A' WHERE SIPKALEM_ID='"+txtKalemID.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void siparisKalemiKapatma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='K' WHERE SIPKALEM_ID='" + txtKalemID.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void siparisKalemiBitirme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='B' WHERE SIPKALEM_ID='" + txtKalemID.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        private void sbtnIsEmriListesi_Click(object sender, EventArgs e)
        {
            frmIsEmriListesi.isEmriNo = "isemrikayit";
            frmIsEmriListesi frm = new frmIsEmriListesi();
            frm.Show();
        }

        public static string stokKodu;
        public static string isEmriX;
        private void sbtnSiparisListesi_Click(object sender, EventArgs e)
        {
            stokKodu = txtStokKodu.Text;
            frmIsEmriSiparisleri frm = new frmIsEmriSiparisleri();
            frm.Show();
        }

        void isEmriListesiCekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, SIPARIS_NO, MIKTAR, DURUM FROM TBL_ISEMRI", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        void sipNoVeMiktaraUlasma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO, MIKTAR FROM TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='"+txtKalemID.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while(dr.Read())
            {
                txtSiparisNumarasi.Text = dr[0].ToString();
                txtMiktar.Text = dr[1].ToString();
            }
            conn.Close();
        }

        void temizle()
        {
            txtIsEmriAciklamasi.Text = "";
            txtIsEmriTarihi.Text = "";
            txtMiktar.Text = "0,00";
            txtSiparisNumarasi.Text = "";
            txtKalemID.Text = "";
            txtStokAdi.Text = "";
            txtStokKodu.Text = "";
            txtTeslimTarihi.Text = "";
            txtStokKodu.Enabled = true;
            txtMiktar.Enabled= true;
            txtSiparisNumarasi.Enabled= true;
            rbtnYeni.Checked= true;
            sbtnSiparisListesi.Enabled= true;
            sbtnStokListesi.Enabled = true;
        }

        private void frmIsEmri_Load(object sender, EventArgs e)
        {
            isEmriNumarasiHesaplama();
            txtIsEmriNumarasi.Text = y1;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable = false;
            isEmriListesiCekme();
        }

        string y1 = "";

        void isEmriNumarasiHesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 1 CONCAT('I',REPLICATE('0',10-(LEN(SUBSTRING(ISEMRI_NUMARASI,2,9)+1)+1)),SUBSTRING(ISEMRI_NUMARASI,2,9)+1) AS 'İŞ EMRİ NUMARASI' FROM TBL_ISEMRI ORDER BY ISEMRI_NUMARASI DESC", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                y1 = dr1[0].ToString();
            }
            conn.Close();
        }

        private void txtIsEmriNumarasi_Leave(object sender, EventArgs e)
        {
            txtKalemID.Text = "";
            if (txtIsEmriNumarasi.Text == "")
            {
                txtIsEmriNumarasi.Focus();
            }
            isEmriKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                isEmriBilgisiCekme();
                
            }
            else
            {
                temizle();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtIsEmriNumarasi.Text = dr["ISEMRI_NUMARASI"].ToString();
            isEmriBilgisiCekme();
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            if (rbtnTamamlanmis.Checked == true)
            {
                MessageBox.Show("Bu İş Emrine Ait Üretim Sonu Kaydı Vardır Silinemez.");
            }
            else
            {
                isEmriKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("DELETE TBL_ISEMRI WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    siparisKalemiKapatma();
                    temizle();
                    txtIsEmriNumarasi.Text = "";
                    isEmriListesiCekme();
                }
                else
                {
                    MessageBox.Show("Böyle Bir İş Emri Kaydı Bulunmamaktadır.");
                }
            }
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if (rbtnTamamlanmis.Checked == true)
            {
                MessageBox.Show("Bu İş Emrine Ait Üretim Sonu Kaydı Vardır Kayıt Üzerinde Güncelleme İşlemi Yapılamaz.");
            }
            else
            {
                isEmriKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    //update
                    if (rbtnYeni.Checked == true)
                    {
                        isEmriKontrol();
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET ISEMRI_ACIKLAMASI='" + txtIsEmriAciklamasi.Text + "', ISEMRI_TARIHI='" + txtIsEmriTarihi.Text + "', TESLIM_TARIHI='" + txtTeslimTarihi.Text + "', DURUM='Y' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        siparisKalemiAcma();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isEmriListesiCekme();
                    }
                    else
                    {
                        isEmriKontrol();
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET ISEMRI_ACIKLAMASI='" + txtIsEmriAciklamasi.Text + "', ISEMRI_TARIHI='" + txtIsEmriTarihi.Text + "', TESLIM_TARIHI='" + txtTeslimTarihi.Text + "', DURUM='E' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        siparisKalemiBitirme();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isEmriListesiCekme();
                    }
                }
                else
                {
                    //insert
                    if (rbtnYeni.Checked == true)
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_ISEMRI (ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, ISEMRI_ACIKLAMASI, ISEMRI_TARIHI, TESLIM_TARIHI, SIPARIS_NO, MIKTAR, SIPKALEM_ID, DURUM) VALUES ('" + txtIsEmriNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txtIsEmriAciklamasi.Text + "','" + txtIsEmriTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtSiparisNumarasi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','" + txtKalemID.Text + "','Y')", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        siparisKalemiAcma();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isEmriListesiCekme();
                    }
                    else
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_ISEMRI (ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, ISEMRI_ACIKLAMASI, ISEMRI_TARIHI, TESLIM_TARIHI, SIPARIS_NO, MIKTAR, SIPKALEM_ID, DURUM) VALUES ('" + txtIsEmriNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txtIsEmriAciklamasi.Text + "','" + txtIsEmriTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtSiparisNumarasi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','" + txtKalemID.Text + "','E')", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        siparisKalemiBitirme();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isEmriListesiCekme();
                    }
                }
            }
            
        }

        private void frmIsEmri_Activated(object sender, EventArgs e)
        {

            if (isEmriX == "isemri")
            {
                txtIsEmriNumarasi.Text = frmIsEmriListesi.isEmriNo;
                isEmriBilgisiCekme();
                isEmriX = "";
            }

            if (isEmriX == "stok")
            {
                txtStokKodu.Text = frmStokListesi.stokkodu;
                stokBilgisiCekme();
                isEmriX = "";
            }



            if (isEmriX == "siparis")
            {
                txtKalemID.Text = frmIsEmriSiparisleri.kalemId;
                if (txtKalemID.Text == "")
                {

                }
                else
                {
                    sipNoVeMiktaraUlasma();
                    txtMiktar.Enabled = false;
                    isEmriX = "";
                }
            }
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokKartiKontrol();
            if (Convert.ToInt16(x2)==1)
            {
                stokBilgisiCekme();
                txtSiparisNumarasi.Text = "";
                txtMiktar.Text = "";
                txtKalemID.Text = "";
                txtStokAdi.Enabled=false;
            }
            else
            {
                txtStokKodu.Focus();
            }
        }

        private void frmIsEmri_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIsEmriSiparisleri.kalemId = "";
            frmStokListesi.stokkodu = "";
            frmIsEmriListesi.isEmriNo = "";
            isEmriX = "";
        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {
            temizle();
            txtIsEmriNumarasi.Text = "";
            txtIsEmriNumarasi.Focus();
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            frmStokListesi.stokkodu = "isemri";
            frmStokListesi frm = new frmStokListesi();
            frm.Show();
        }
    }
}
