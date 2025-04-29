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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RNBSRFD\\SQLEXPRESS;Initial Catalog=UyeIslemlerii;Integrated Security=True;");
        private void kayit_Load(object sender, EventArgs e)
        {

        }

        private void kayıtolbutton_Click(object sender, EventArgs e)
        {
            Uyeislemleri frm = new Uyeislemleri();
            frm.Show();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into dbo.KayitTbl (KullaniciAdi,Sifre,E_posta) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", kullaniciaditxt.Text);
            komut.Parameters.AddWithValue("@p2", şifretxt.Text);
            komut.Parameters.AddWithValue("@p3", epostatxt.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
