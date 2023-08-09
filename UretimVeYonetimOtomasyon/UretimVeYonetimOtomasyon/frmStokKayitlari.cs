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
    public partial class frmStokKayitlari : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");

        public frmStokKayitlari()
        {
            InitializeComponent();
        }

        string x1 = "0";
        void stokkartiKontrol()
        {
            conn.Open();

            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }
        string x2 = "0";
        void grupkodukontrol()
        {
            conn.Open();

            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_GRUPKOD WHERE GRUP_KODU='"+ txtGrupKodu.Text +"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr[0].ToString();
            }
            conn.Close();
        }

        void temizle()
        {
            txtStokAdi.Text = "";
            txtGrupKodu.Text = "";
            txtFiyat.Text = "";
            txtKDVOrani.Text = "";
            txtGrupAdi.Text = "";
        }

        void stokbilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[1].ToString(); 
                txtGrupKodu.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();   
                txtKDVOrani.Text = dr[4].ToString();    
            }
            conn.Close();
        }
        void grupbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT GRUP_ADI FROM TBL_GRUPKOD WHERE GRUP_KODU='"+ txtGrupKodu.Text +"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtGrupAdi.Text = dr[0].ToString(); 
            }
            conn.Close();
        }
        private void frmStokKayitlari_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            stokkartiKontrol();
            txtFiyat.Text = "0,00";
            txtKDVOrani.Text = "0,00";
        }

       

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            frmStokListesi.stokkodu = "kayit";
            frmStokListesi frm = new frmStokListesi();  
            frm.Show();
        }

        private void sbtnGrupKodListesi_Click(object sender, EventArgs e)
        {
            frmStokGrupKodlari frm = new frmStokGrupKodlari();
            frm.Show();
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            if (txtStokKodu.Text == "")
            {
                txtStokKodu.Focus();    
            }
            else
            {   
                frmStokListesi.stokkodu+= txtStokKodu.Text;
                stokkartiKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    stokbilgisiCekme();
                    grupbilgisicekme();
                }
                else 
                {
                    temizle();
                    txtFiyat.Text = "0,00";
                    txtKDVOrani.Text = "0,00"; 
                }
            } 
        }

        private void frmStokKayitlari_Activated(object sender, EventArgs e)
        {
            if (frmStokListesi.stokkodu == "")
            {
                temizle();
                txtStokKodu.Text = "";
            }
            else
            {
                txtStokKodu.Text = frmStokListesi.stokkodu;
                stokbilgisiCekme();
                grupbilgisicekme();
            }
           
        }

        private void txtGrupKodu_Leave(object sender, EventArgs e)
        {
            grupkodukontrol();
            if (Convert.ToInt16(x2) == 1)
            {
                grupbilgisicekme();
            }
            else
            {
                txtGrupKodu.Focus();
            }
        }

        private void frmStokKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStokListesi.stokkodu = "";
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            stokkartiKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                //güncelleme
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_STOKKAYITLARI SET STOK_ADI='"+txtStokAdi.Text+"'," +
                    "GRUP_KODU='"+txtGrupKodu.Text+"', FIYAT='"+txtFiyat.Text.Replace(',','.')+"', KDV_ORANI='"+txtKDVOrani.Text.Replace(',', '.') + "' " +
                    "WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = "";
            }
            else
            {
                //yeni kayıt
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_STOKKAYITLARI (STOK_KODU, STOK_ADI, GRUP_KODU, FIYAT, KDV_ORANI) " +
                    "VALUES ('"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtGrupKodu.Text+"','"+txtFiyat.Text.Replace(',', '.') + "','"+txtKDVOrani.Text.Replace(',', '.') + "')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = "";
            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            stokkartiKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                //sil
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_STOKKAYITLARI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = "";
            }
            else
            {
                //zaten yok
                MessageBox.Show("Böyle bir Stok Kodu bulunmamaktadır.");
            }
        }
    }
}
