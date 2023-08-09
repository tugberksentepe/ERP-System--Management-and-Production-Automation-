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
    public partial class frmUretimSonuKayitlari : Form
    {
        public static string fisX;
        SqlConnection conn = new SqlConnection("server=DESKTOP-IVC982I\\SQLEXPRESS; Initial Catalog=Uretim ve Yonetim Sistemi;Integrated Security=SSPI");
        public frmUretimSonuKayitlari()
        {
            InitializeComponent();
        }

        string x1 = "";

        void uretimSonuKayıtKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='" + txtFisNo.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while(dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }

        void uretimSonuKaydiBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while(dr.Read())
            {
                txtIsEmriNumarasi.Text = dr[0].ToString();
            }
            conn.Close();
            txtIsEmriNumarasi.Enabled = false;
            sbtnIsEmriListesi.Enabled = false;
        }

        string x2 = "";
        void isEmriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while(dr.Read())
            {
                x2 = dr[0].ToString();
            }
            conn.Close();
        }

        void isEmriBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT MR.SIPARIS_NO, MR.STOK_KODU, MR.STOK_ADI, MR.SIPKALEM_ID, MR.MIKTAR, SIP.MUSTERI_KODU, MK.MUSTERI_ADI FROM TBL_ISEMRI MR LEFT JOIN TBL_SIPARISLER SIP ON MR.SIPARIS_NO=SIP.SIPARIS_NO LEFT JOIN TBL_MUSTERIKAYITLARI MK ON SIP.MUSTERI_KODU = MK.MUSTERI_KODU WHERE MR.ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtSiparisNumarasi.Text = dr[0].ToString();
                txtStokKodu.Text = dr[1].ToString();
                txtStokAdi.Text = dr[2].ToString();
                txtKalemID.Text = dr[3].ToString();
                txtMiktar.Text = dr[4].ToString();
                txtMusteriKodu.Text = dr[5].ToString();
                txtMusteriAdi.Text= dr[6].ToString();
            }
            conn.Close();
        }

        void stokUretimeAlma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='A' WHERE SIPKALEM_ID='"+txtKalemID.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }
        void stokSevkeHazirlama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='B' WHERE SIPKALEM_ID='" + txtKalemID.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void isEmriAcma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET DURUM='Y' WHERE ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void isEmriKapat()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET DURUM='E' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void temizle()
        {
            txtIsEmriNumarasi.Text = "";
            txtKalemID.Text = "";
            txtMiktar.Text = "";
            txtMusteriAdi.Text = "";
            txtMusteriKodu.Text = "";
            txtSiparisNumarasi.Text = "";
            txtStokAdi.Text = "";
            txtStokKodu.Text = "";
            txtIsEmriNumarasi.Enabled = true;
            sbtnIsEmriListesi.Enabled = true;
        }

        void stokHareketKaydiGirisi()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_STOKHAREKETLERI (URETIMSONUKAYDI_NUMARASI, ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, G_MIKTAR, C_MIKTAR, MUSTERI_ADI, ACIKLAMA) VALUES ('"+txtFisNo.Text+"','"+txtIsEmriNumarasi.Text+"','"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtMiktar.Text.Replace(',','.')+"','0','"+txtMusteriAdi.Text+"','ÜRETİM')", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }
        void stokHareketKaydiSilme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("DELETE TBL_STOKHAREKETLERI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        private void sbtnFisListesi_Click(object sender, EventArgs e)
        {
            frmUretimSonuKayitListesi.fisNo = "uretimsonukaydi";
            frmUretimSonuKayitListesi frm = new frmUretimSonuKayitListesi();
            frm.Show();
        }

        private void frmUretimSonuKayitlari_Load(object sender, EventArgs e)
        {
            uretimSonuKaydiNumarasiHesaplama();
            txtFisNo.Text = y1;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void txtIsEmriNumarasi_Leave(object sender, EventArgs e)
        {
            if (txtIsEmriNumarasi.Text == "")
            {
                txtIsEmriNumarasi.Focus();
            }
            else
            {
                isEmriKontrol();
                if (Convert.ToInt16(x2) == 1)
                {
                    isEmriBilgisiCekme();
                }
                else
                {
                    MessageBox.Show("Bu İş Emri Numarasına Ait Üretim Sonu Kaydı Bulunmamaktadır.");
                    txtIsEmriNumarasi.Focus();
                }
            }
        }

        private void txtFisNo_Leave(object sender, EventArgs e)
        {
            if (txtFisNo.Text == "")
            {
                txtFisNo.Focus();
            }
            else
            {
                uretimSonuKayıtKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    uretimSonuKaydiBilgisiCekme();
                    isEmriBilgisiCekme();
                }
                else
                {
                    temizle();
                    txtIsEmriNumarasi.Enabled = true;
                    sbtnIsEmriListesi.Enabled = true;
                }
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if(txtFisNo.Text=="" || txtIsEmriNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli Olan Bilgileri Doldurunuz.");
            }
            else
            {
                uretimSonuKayıtKontrol();
                if(Convert.ToInt16(x1)==1)
                {
                    MessageBox.Show("Mevcut Üretim Sonu Kaydı Sistemde Bulunmaktadır.");
                }
                else
                {
                    stokHareketKaydiGirisi();
                    stokSevkeHazirlama();
                    isEmriKapat();
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_URETIMSONUKAYITLARI (URETIMSONUKAYDI_NUMARASI, ISEMRI_NUMARASI, STOK_KODU, STOK_ADI, MIKTAR, SIPARIS_NUMARASI, SIPKALEM_ID, MUSTERI_KODU, MUSTERI_ADI) VALUES ('"+txtFisNo.Text+"','"+txtIsEmriNumarasi.Text+"','"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtMiktar.Text.Replace(',','.')+"','"+txtSiparisNumarasi.Text+"','"+txtKalemID.Text+"','"+txtMusteriKodu.Text+"','"+txtMusteriAdi.Text+"')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtFisNo.Text = "";                    
                }
            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            if (txtFisNo.Text == "" || txtIsEmriNumarasi.Text == "")
            {
                temizle();
            }
            else
            {
                uretimSonuKayıtKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    //sil
                    stokHareketKaydiSilme();
                    stokUretimeAlma();
                    isEmriAcma();
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("DELETE TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtFisNo.Text = "";                   
                }
                else
                {
                    MessageBox.Show("Mevcut Üretim Sonu Kaydı Sistemde Bulunmamaktadır.");
                }
            }
        }

        private void sbtnIsEmriListesi_Click(object sender, EventArgs e)
        {
            frmIsEmriListesi.isEmriNo = "uretimsonukayit";
            frmIsEmriListesi frm = new frmIsEmriListesi();
            frm.Show();
        }

        private void frmUretimSonuKayitlari_Activated(object sender, EventArgs e)
        {
            if (fisX == "isemri")
            {
                txtIsEmriNumarasi.Text = frmIsEmriListesi.isEmriNo;
                isEmriBilgisiCekme();
                fisX = "";
            }
            if (fisX=="uretimsonukaydi")
            {
                txtFisNo.Text = frmUretimSonuKayitListesi.fisNo;
                uretimSonuKaydiBilgisiCekme();
                isEmriBilgisiCekme();
                fisX = "";
            }
        }

        private void frmUretimSonuKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            fisX = "";
        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {
            temizle();
            txtFisNo.Text = "";
        }

        string y1 = "";

        void uretimSonuKaydiNumarasiHesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 1 CONCAT('U',REPLICATE('0',10-(LEN(SUBSTRING(URETIMSONUKAYDI_NUMARASI,2,9)+1)+1)),SUBSTRING(URETIMSONUKAYDI_NUMARASI,2,9)+1) AS 'ÜRETİM SONU KAYDI NUMARASI' FROM TBL_URETIMSONUKAYITLARI ORDER BY URETIMSONUKAYDI_NUMARASI DESC", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                y1 = dr1[0].ToString();
            }
            conn.Close();
        }
    }
}
