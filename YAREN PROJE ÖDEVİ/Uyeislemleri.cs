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
    public partial class Uyeislemleri : Form
    {
        public Uyeislemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RNBSRFD\\SQLEXPRESS;Initial Catalog=UyeIslemlerii;Integrated Security=True;");
        private void Uyeislemleri_Load(object sender, EventArgs e)
        {


            label3.Visible = false;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.uyeTblTableAdapter1.Fill(this.uyeIslemleriiDataSet1.UyeTbl);

        }

        private void üyeeklebutton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into dbo.UyeTbl (UAdSoyad,UTelefon,Uyas,UCinsiyet,UKayitTarihi,UOdeme) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti );

            komut.Parameters.AddWithValue("@p1", üyeadsoyadtxt.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", yaştxt.Text);
            komut.Parameters.AddWithValue("@p4", label3.Text);
            komut.Parameters.AddWithValue("@p5", kaittarihitxt.Text);
            komut.Parameters.AddWithValue("@p6", üyeliktxt.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked== true)
            {
                label3.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label3.Text = "False";
            }

        }



        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if (label3.Text == "False")
            {
                radioButton2.Checked = false;
            }

            
        }

        private void temizlebutton_Click(object sender, EventArgs e)
        {
            üyeidtxt.Text = "";
            üyeadsoyadtxt.Text = "";
            maskedTextBox1.Text = "";
            yaştxt.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            kaittarihitxt.Text = "";
            üyeliktxt.Text = "";
            üyeadsoyadtxt.Focus();
        }

        private void üyesilbutton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete From dbo.UyeTbl Where UyeID=@k1", baglanti);
            komutSil.Parameters.AddWithValue("@k1", üyeidtxt.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Slindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void üyegüncellebutton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update dbo.UyeTbl Set UAdSoyad=@a1,UTelefon=@a2,UYas=@a3,UCinsiyet=@a4,UKayitTarihi=@a5,UOdeme=@a6 Where UyeID=@a7", baglanti);
            guncelle.Parameters.AddWithValue("@a1", üyeadsoyadtxt.Text);
            guncelle.Parameters.AddWithValue("@a2", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@a3", yaştxt.Text);
            guncelle.Parameters.AddWithValue("@a4", label3.Text);
            guncelle.Parameters.AddWithValue("@a5", kaittarihitxt.Text);
            guncelle.Parameters.AddWithValue("@a6", üyeliktxt.Text);
            guncelle.Parameters.AddWithValue("@a7", üyeidtxt.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            üyeidtxt.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            üyeadsoyadtxt.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            yaştxt.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            label3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            kaittarihitxt.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            üyeliktxt.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
