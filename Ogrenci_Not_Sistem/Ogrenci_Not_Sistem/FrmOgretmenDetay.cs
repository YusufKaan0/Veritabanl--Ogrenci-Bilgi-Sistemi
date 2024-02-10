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

namespace Ogrenci_Not_Sistem
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=False");

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotKayitDataSet2.TBLDERS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLDERSTableAdapter2.Fill(this.dbNotKayitDataSet2.TBLDERS);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1", mskNumara.Text);
            komut.Parameters.AddWithValue("@p2", txtAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter2.Fill(this.dbNotKayitDataSet2.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var secilen = dataGridView1.SelectedCells[0].RowIndex;

            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1=Convert.ToDouble(txtSinav1.Text);
            s2=Convert.ToDouble(txtSinav2.Text);
            s3=Convert.ToDouble(txtSinav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@P1, OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6",baglanti);
            komut.Parameters.AddWithValue("@p1", txtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", txtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", txtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", mskNumara.Text);

            komut.ExecuteNonQuery();

            

            
            MessageBox.Show("Öğrenci Notları Güncellendi");
            this.tBLDERSTableAdapter2.Fill(this.dbNotKayitDataSet2.TBLDERS);
            baglanti.Close();            
        }
    }
}
