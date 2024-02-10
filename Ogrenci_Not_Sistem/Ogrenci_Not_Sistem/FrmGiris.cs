using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Not_Sistem
{
    public partial class FrmOgrenciGiris : Form
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm =new FrmOgrenciDetay();
            frm.numara = maskedTextBox1.Text;
            frm.Show();
            
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text == "1111")
            {
                FrmOgretmenDetay fr = new FrmOgretmenDetay();
                fr.Show();
            }
        }
    }
}
