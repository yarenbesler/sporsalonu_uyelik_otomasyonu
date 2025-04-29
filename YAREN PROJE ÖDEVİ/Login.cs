using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAREN_PROJE_ÖDEVİ
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RNBSRFD\\SQLEXPRESS;Initial Catalog=UyeIslemlerii;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            kayit frm = new kayit();
            frm.Show();
        }

        private void logingirişbutton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From dbo.KayitTbl Where KullaniciAdi=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", loginadtxt.Text);
            komut.Parameters.AddWithValue("@p2", loginşifretxt.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Uyeislemleri uyeislem = new Uyeislemleri();
                uyeislem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();


        }
    }
}
