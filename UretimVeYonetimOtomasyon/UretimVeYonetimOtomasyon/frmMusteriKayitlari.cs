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
    public partial class frmMusteriKayitlari : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Uretim ve Yonetim Sistemi\";Integrated Security=True");
        public frmMusteriKayitlari()
        {
            InitializeComponent();
        }


        string x1 = "0";

        void musteriKontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }

        void musteriBilgisiCekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtMusteriAdi.Text = dr[1].ToString();
                txtAdres.Text = dr[2].ToString();   
                cbxIl.Text = dr[3].ToString();
                cbxIlce.Text = dr[4].ToString();  
                txtTelefon.Text = dr[5].ToString(); 
                txtEposta.Text = dr[6].ToString();
                string x = dr[7].ToString();
                if (x == "A")
                {
                    rbtnAlici.Checked = true;
                }
                else
                {
                    rbtnSatici.Checked = true;
                }
            }
            conn.Close();
            ilListele();
            ilceListele();
        }

        void ilListele()
        {
            cbxIl.Properties.Items.Clear();
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISIM FROM TBL_IL", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                cbxIl.Properties.Items.Add(dr[0]);   
            }
            conn.Close();
        }

        void ilceListele()
        {
            cbxIlce.Properties.Items.Clear();
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISIM FROM TBL_ILCE WHERE IL_ID='"+(cbxIl.SelectedIndex+1)+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                cbxIlce.Properties.Items.Add(dr[0]);
            }
            conn.Close();
        }

        void temizle()
        {
            txtAdres.Text = "";
            txtEposta.Text = "";
            txtMusteriAdi.Text = "";
            txtTelefon.Text = "";
            cbxIl.Properties.Items.Clear();
            cbxIl.Text = "";
            cbxIlce.Properties.Items.Clear();
            cbxIlce.Text = "";
            rbtnAlici.Checked = false;
            rbtnSatici.Checked = false;
        }

        private void frmMusteriKayitlari_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ilListele();
        }

        string y1 = "";

        void musteriNumarasiHesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 1 CONCAT('320.01.',SUBSTRING(MUSTERI_KODU,8,3)+1) AS 'MÜŞTERİ NUMARASI' FROM TBL_MUSTERIKAYITLARI ORDER BY MUSTERI_KODU DESC", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                y1 = dr1[0].ToString();
            }
            conn.Close();
        }

        private void txtMusteriKodu_Leave(object sender, EventArgs e)
        {
            if(txtMusteriKodu.Text == "")
            {
                txtMusteriKodu.Focus();
            }
            else
            {
                musteriKontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    //bilgi çek 
                    musteriBilgisiCekme();
                    ilceListele();
                }
                else
                {
                    temizle();
                    ilListele();
                }
            }         
        }

      
        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            musteriKontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                if (rbtnAlici.Checked == true)
                {
                    //alici güncelleme
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_MUSTERIKAYITLARI " +
                        "SET MUSTERI_ADI='"+txtMusteriAdi.Text+"', ADRES='"+txtAdres.Text+"'," +
                        " IL='"+cbxIl.Text+"', ILCE='"+cbxIlce.Text+"', TELEFON='"+txtTelefon.Text+"', E_POSTA='"+txtEposta.Text+"', TIP='A' WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
                    sorgu1.ExecuteNonQuery();   
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
                else
                {
                    //satici güncelleme
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_MUSTERIKAYITLARI " +
                        "SET MUSTERI_ADI='" + txtMusteriAdi.Text + "', ADRES='" + txtAdres.Text + "'," +
                        " IL='" + cbxIl.Text + "', ILCE='" + cbxIlce.Text + "', TELEFON='" + txtTelefon.Text + "', E_POSTA='" + txtEposta.Text + "', TIP='S' WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
            }
            else
            {
                if (rbtnAlici.Checked == true)
                {
                    //alici eklemesi
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_MUSTERIKAYITLARI (MUSTERI_KODU, MUSTERI_ADI, ADRES, IL, ILCE, TELEFON, E_POSTA, TIP) " +
                        "VALUES ('"+txtMusteriKodu.Text+ "','" + txtMusteriAdi.Text + "','" + txtAdres.Text + "','" + cbxIl.Text + "','" + cbxIlce.Text + "','" + txtTelefon.Text + "','" + txtEposta.Text + "','A')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
                else
                {
                    //satici eklemesi
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_MUSTERIKAYITLARI (MUSTERI_KODU, MUSTERI_ADI, ADRES, IL, ILCE, TELEFON, E_POSTA, TIP) " +
                        "VALUES ('" + txtMusteriKodu.Text + "','" + txtMusteriAdi.Text + "','" + txtAdres.Text + "','" + cbxIl.Text + "','" + cbxIlce.Text + "','" + txtTelefon.Text + "','" + txtEposta.Text + "','S')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
            }
            
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("DELETE TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
            temizle();
            txtMusteriKodu.Text = "";
        }

        private void cbxIl_Leave(object sender, EventArgs e)
        {
            ilceListele();
            cbxIlce.Text = "";
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            frmMusteriListesi.musterikodu = "musterikayit";
            frmMusteriListesi frm = new frmMusteriListesi();
            frm.Show();
        }

        private void frmMusteriKayitlari_Activated(object sender, EventArgs e)
        {

            if (frmMusteriListesi.musterikodu == "")
            {
                temizle();
                txtMusteriKodu.Text = "";
            }
            else
            {
                txtMusteriKodu.Text = frmMusteriListesi.musterikodu;
                musteriBilgisiCekme();
            }
        }

        private void frmMusteriKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMusteriListesi.musterikodu = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            musteriNumarasiHesaplama();
            txtMusteriKodu.Text = y1;
        }
    }
}
