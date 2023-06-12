using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ad.Text == "eray" && sifre.Text == "1234")
            {
                magazamudur x = new magazamudur();
                x.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Yanlış ad veya parola girilid");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAnaEkran v = new FrmAnaEkran();
            v.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bolgemudur m = new bolgemudur();
            m.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmAnaEkran f = new FrmAnaEkran();
            f.Show();
            this.Hide();
        }
    }
}
