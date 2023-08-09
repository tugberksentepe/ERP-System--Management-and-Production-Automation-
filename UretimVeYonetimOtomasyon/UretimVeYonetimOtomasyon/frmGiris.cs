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
using DevExpress.XtraEditors;

namespace UretimVeYonetimOtomasyon
{
    public partial class frmGiris : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public frmGiris()
        {
            InitializeComponent();
        }

        private void sbtnGiris_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM TBL_Giris where K_Adi=@user AND Sifre=@pass";
            conn = new SqlConnection("server=DESKTOP-IVC982I\\SQLEXPRESS; Initial Catalog=Uretim ve Yonetim Sistemi;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu,conn);
            cmd.Parameters.AddWithValue("@user", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@pass", txtParola.Text);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi konrol edin ve tekrar deneyin.");
            }
            conn.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.CheckState == CheckState.Checked)
            {
                txtParola.UseSystemPasswordChar = true;
            }
            else { txtParola.UseSystemPasswordChar = false; }
        }
    }
}
