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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;
        public string lbldurum;
        
        

        SqlConnection baglanti = new SqlConnection(@"Data Source=KAAN;Initial Catalog=DbNotKayit;Integrated Security=True;Encrypt=False");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString()+ " "+ dr[3];
                lblSınav1.Text = dr[4].ToString();
                lblSınav2.Text = dr[5].ToString();
                lblSınav3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();
            }

            

            if (lblDurum.Text == "True")
            {
                lblDurum.Text = "Geçti";
            }
            else if (lblDurum.Text == "False")
            {
                lblDurum.Text = "Kaldı";
            }

            baglanti.Close();
        }
    }
}
