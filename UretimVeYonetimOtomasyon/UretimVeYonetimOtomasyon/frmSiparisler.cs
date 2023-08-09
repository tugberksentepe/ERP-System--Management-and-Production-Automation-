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
    public partial class frmSiparisler : Form
    {
        public static string siparisx;
        string sipKalem = "";

        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmSiparisler()
        {
            InitializeComponent();
        }

        string x1 = "0";

        void siparisKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISLER WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }

        void siparisBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_SIPARISLER WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtMusteriKodu.Text = dr[1].ToString();
                txtSiparisTarihi.Text = dr[2].ToString();
                txtTeslimTarihi.Text = dr[3].ToString();
                txtToplamTutar.Text = dr[4].ToString();
            }
            conn.Close();
        }

        void siparisBilgisiCekme2()
        {
            conn.Open();
            DataTable dt = new DataTable(); 
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU, STOK_ADI, MIKTAR, FIYAT, KDV, SIPKALEM_ID FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        string x2 = "0";
        void musteriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr[0].ToString();
            }
            conn.Close();
        }
        void musteriBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_ADI, IL, ILCE FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtMusteriAdi.Text = dr[0].ToString();
                txtIl.Text= dr[1].ToString();
                txtIlce.Text= dr[2].ToString();              
            }
            conn.Close();          
        }

        string x3 = "";
        void stokKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x3 = dr[0].ToString();
            }
            conn.Close();
        }

        void stokBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_ADI, GRUP_KODU, FIYAT, KDV_ORANI FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
               txtStokAdi.Text= dr[0].ToString();
               txtKDV.Text= dr[1].ToString();   
               txtFiyat.Text= dr[2].ToString(); 
            }
            conn.Close();
        }

        string x4 = "0";

        void kalemSayma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x4 = dr[0].ToString();
            }
            conn.Close();
        }

        void genelToplamHesapla()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SUM((MIKTAR*FIYAT)*((KDV/100)+1)) AS GENELTOPLAM FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "' GROUP BY SIPARIS_NO", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtToplamTutar.Text= dr[0].ToString();
            }
            conn.Close();
        }

        void temizle1()
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtUrunAciklamasi.Text = "";
            txtFiyat.Text = "";
            txtKDV.Text = "";
            txtMiktar.Text = "";
        }

        void temizle2()
        {
            txtSiparisTarihi.Text = "";
            txtTeslimTarihi.Text = "";
            txtMusteriKodu.Text = "";
            txtMusteriAdi.Text = "";
            txtIl.Text = "";
            txtIlce.Text = "";
            txtToplamTutar.Text = "";
            temizle1();
        }

        string x6 = "0";

        void sipGenelIsEmriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"' " +
                "AND (URETIMDURUMU='A' OR URETIMDURUMU ='B' OR URETIMDURUMU='S')", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x6 = dr[0].ToString();
            }
            conn.Close();
        }
        
        string x5= "0";
        void sipKalemIsEmriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMDURUMU FROM TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='"+sipKalem+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x5 = dr[0].ToString();
            }
            conn.Close();
        }
        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            frmSiparisListesi.siparisNo = "sipariskayit";
            frmSiparisListesi frm = new frmSiparisListesi();
            frm.Show();
        }

        private void txtSiparisNumarasi_Leave(object sender, EventArgs e)
        {
            txtMusteriAdi.Enabled = false;
            txtIl.Enabled= false;
            txtIlce.Enabled= false;
            txtStokKodu.Enabled= true;

            siparisKontrol();
            if(Convert.ToInt16(x1)==1)
            {
                siparisBilgisiCekme();
                siparisBilgisiCekme2();
                musteriBilgisiCekme();
                txtMusteriKodu.Enabled= false;
            }
            else
            {
                if (txtSiparisNumarasi.Text == "")
                {
                    txtSiparisNumarasi.Focus();
                }
                else
                {
                    siparisBilgisiCekme2();
                    temizle2();
                    txtMusteriKodu.Enabled = true;
                }
            }
        }

        private void txtMusteriKodu_Leave(object sender, EventArgs e)
        {
            musteriKontrol();
            if(Convert.ToInt16(x2)==1)
            {
                musteriBilgisiCekme();
            }
            else
            {
                txtMusteriKodu.Focus();
            }
        }

        private void frmSiparisler_Load(object sender, EventArgs e)
        {
            siparisNumarasiHesaplama();
            txtSiparisNumarasi.Text = y1;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gridView1.OptionsBehavior.Editable= false;
            txtStokAdi.Enabled=false;
            txtKDV.Enabled=false;
            txtFiyat.Enabled=false;
            txtUrunAciklamasi.Enabled=false;
            txtMiktar.Enabled=false;
        }

        string y1 = "";

        void siparisNumarasiHesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 1 CONCAT('S',REPLICATE('0',10-(LEN(SUBSTRING(SIPARIS_NO,2,9)+1)+1)),SUBSTRING(SIPARIS_NO,2,9)+1) AS 'SİPARİŞ NUMARASI' FROM TBL_SIPARISLER ORDER BY SIPARIS_NO DESC", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                y1 = dr1[0].ToString();
            }
            conn.Close();
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokKontrol();
            if (Convert.ToInt16(x3) == 1)
            {
                stokBilgisiCekme();
                txtUrunAciklamasi.Enabled = true;
                txtKDV.Enabled = true;
                txtFiyat.Enabled = true;
                txtMiktar.Enabled = true;
                txtMiktar.Text = "0,00";
            }
            else
            {
                txtStokKodu.Focus();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtStokKodu.Text = x["STOK_KODU"].ToString();
            txtStokAdi.Text = x["STOK_ADI"].ToString();
            txtFiyat.Text = x["FIYAT"].ToString();
            txtMiktar.Text = x["MIKTAR"].ToString();
            txtKDV.Text= x["KDV"].ToString();
            sipKalem = x["SIPKALEM_ID"].ToString();
            txtStokKodu.Enabled = false;
            txtMiktar.Enabled = true;
            txtFiyat.Enabled = true;
            txtKDV.Enabled = true;
            txtUrunAciklamasi.Enabled = true;         
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtStokKodu.Text == "")
            {
                
            }
            else
            {
                if (sipKalem == "")
                {
                    //INSERT
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISKALEMLERI (SIPARIS_NO, STOK_KODU, STOK_ADI, MIKTAR, URUN_ACIKLAMASI, FIYAT, KDV, URETIMDURUMU) VALUES ('" + txtSiparisNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','" + txtUrunAciklamasi.Text + "','" + txtFiyat.Text.Replace(',', '.') + "','" + txtKDV.Text.Replace(',', '.') + "','K')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle1();
                    siparisBilgisiCekme2();
                    genelToplamHesapla();
                    sipKalem = "";
                }
                else
                {
                    //GÜNCELLEME
                    sipKalemIsEmriKontrol();
                    if (x5 == "K")
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET MIKTAR='" + txtMiktar.Text.Replace(',', '.') + "', URUN_ACIKLAMASI='" + txtUrunAciklamasi.Text + "', FIYAT='" + txtFiyat.Text.Replace(',', '.') + "', KDV='" + txtKDV.Text.Replace(',', '.') + "' WHERE SIPKALEM_ID='" + sipKalem + "'", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        temizle1();
                        siparisBilgisiCekme2();
                        genelToplamHesapla();
                        sipKalem = "";
                    }
                    else
                    {
                        MessageBox.Show("Bu Sipariş Kalemine Ait İş Emri Kaydı Bulunmaktadır.");
                        temizle1();
                        sipKalem = "";
                    }
                }

                siparisKontrol();

                if (Convert.ToInt16(x1) == 1)
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "', TESLIM_TARIHI='" + txtTeslimTarihi.Text + "', TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISLER (SIPARIS_NO, MUSTERI_KODU, SIPARIS_TARIHI, TESLIM_TARIHI, TOPLAM_TUTAR) VALUES ('" + txtSiparisNumarasi.Text + "','" + txtMusteriKodu.Text + "','" + txtSiparisTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtToplamTutar.Text.Replace(',', '.') + "')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                }
            }          
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            if (txtStokKodu.Text == "")
            {

            }
            else
            {
                sipKalemIsEmriKontrol();
                if (x5 == "K")
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("DELETE TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='" + sipKalem + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle1();
                    siparisBilgisiCekme2();
                    sipKalem = "";
                    txtStokKodu.Enabled = true;
                    kalemSayma();
                    if (Convert.ToInt16(x4) == 0)
                    {
                        txtToplamTutar.Text = "0,00";
                    }
                    else
                    {
                        genelToplamHesapla();
                    }
                    conn.Open();
                    SqlCommand sorgu2 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "', TESLIM_TARIHI='" + txtTeslimTarihi.Text + "', TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                    sorgu2.ExecuteNonQuery();
                    conn.Close();
                    sipKalem = "";
                }
                else
                {
                    MessageBox.Show("Bu Sipariş Kalemine Ait İş Emri Kaydı Bulunmaktadır.");
                    sipKalem = "";
                    temizle1();
                }
            }                    
        }

        private void sbtnSiparisSil_Click(object sender, EventArgs e)
        {
            sipGenelIsEmriKontrol();
            if(Convert.ToInt16(x6)==0)
            {
                //delete
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_SIPARISLER WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                SqlCommand sorgu2 = new SqlCommand("DELETE TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu2.ExecuteNonQuery();
                conn.Close();
                temizle2();
                txtSiparisNumarasi.Text = "";
                siparisBilgisiCekme2();
            }
            else
            {
                MessageBox.Show("Bu Siparişe Ait İş Emri Kaydı ya da Kayıtları Bulunmaktadır.");
            }
        }

        private void sbtnSiparisKaydet_Click(object sender, EventArgs e)
        {
            siparisKontrol();

            if (Convert.ToInt16(x1) == 1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "', TESLIM_TARIHI='" + txtTeslimTarihi.Text + "', TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISLER (SIPARIS_NO, MUSTERI_KODU, SIPARIS_TARIHI, TESLIM_TARIHI, TOPLAM_TUTAR) VALUES ('" + txtSiparisNumarasi.Text + "','" + txtMusteriKodu.Text + "','" + txtSiparisTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtToplamTutar.Text.Replace(',', '.') + "')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }
            siparisBilgisiCekme();
            temizle2();
            txtSiparisNumarasi.Text = "";
            siparisBilgisiCekme2();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmMusteriListesi.musterikodu = "sipariskayit";
            frmMusteriListesi frm = new frmMusteriListesi();
            frm.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmStokListesi.stokkodu = "sipariskayit";
            frmStokListesi frm = new frmStokListesi();
            frm.Show();
        }

        private void frmSiparisler_Activated(object sender, EventArgs e)
        {
            if (siparisx == "siparis")
            {
                if (frmSiparisListesi.siparisNo == "")
                {

                }
                else
                {
                    txtSiparisNumarasi.Text = frmSiparisListesi.siparisNo;
                    siparisBilgisiCekme();
                    siparisBilgisiCekme2();
                    musteriBilgisiCekme();
                }
            }

            if (siparisx == "musteri")
            {
                if (frmMusteriListesi.musterikodu == "")
                {

                }
                else
                {
                    txtMusteriKodu.Text = frmMusteriListesi.musterikodu;
                    musteriBilgisiCekme();
                }
            }
            if (siparisx == "stok")
            {
                if (frmStokListesi.stokkodu == "")
                {

                }
                else
                {
                    txtStokKodu.Text = frmStokListesi.stokkodu;
                    stokBilgisiCekme();
                }
            }
        }

        private void frmSiparisler_FormClosed(object sender, FormClosedEventArgs e)
        {
            siparisx = "";
            frmMusteriListesi.musterikodu = "";
            frmSiparisListesi.siparisNo = "";
        }
    }
}
