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
    public partial class bolgemudur : Form
    {
        public bolgemudur()
        {
            InitializeComponent();
        }



        private void button7_Click(object sender, EventArgs e)
        {
            FrmAnaEkran g = new FrmAnaEkran();
            g.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmFiyatGüncelle form5 = new FrmFiyatGüncelle();  
            form5.Show();
            this.Hide();
        }
    }
}
