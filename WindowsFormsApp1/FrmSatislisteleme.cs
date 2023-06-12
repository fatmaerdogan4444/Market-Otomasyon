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

namespace WindowsFormsApp1
{
    public partial class FrmSatislisteleme : Form
    {
        public FrmSatislisteleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        DataSet ds = new DataSet();

        private void satislistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from satis", baglanti);
            da.Fill(ds, "satis");
            dataGridView1.DataSource = ds.Tables["satis"];


            baglanti.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from satis", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            ds.Tables["satis"].Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmSatislisteleme_Load(object sender, EventArgs e)
        {
            satislistele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBölgemüdürü p = new FrmBölgemüdürü();
            p.Show();
            this.Hide();
        }
    }
}
