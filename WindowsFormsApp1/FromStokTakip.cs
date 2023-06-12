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
    public partial class FromStokTakip : Form
    {
        public FromStokTakip()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable dt;

        void listele()
        {
            dt = new DataTable();
            baglantı.Open();
            da = new SqlDataAdapter("select * from urun", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmBölgemüdürü t = new FrmBölgemüdürü();
            t.Show();
            this.Close();
        }

        private void stoktakip_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if(int.Parse(textBox2.Text) >= 200)
            {
                label7.Text = "Yeterli stok";
            }
            else if (int.Parse(textBox2.Text) >= 50 && int.Parse(textBox2.Text)<=200)
            {
                label7.Text = "İdare eder stok";
            }
            else if (int.Parse(textBox2.Text) <50 )
            {
                label7.Text = "Yetersiz stok";
            }
        }

 

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    baglantı.Open();
        //    SqlCommand komut = new SqlCommand("select *from urun",baglantı);
        //    SqlDataReader r = komut.ExecuteReader();    
        //    while(r.Read())
        //    {
        //        comboBox1.Items.Add(r[1]);
        //    }
        //    baglantı.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        { 
            if(int.Parse(textBox3.Text)>0)
            {
                baglantı.Open();
                SqlCommand cmd = new SqlCommand("update urun set miktari=miktari+'" + int.Parse(textBox3.Text) + "'where barkodno='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglantı);
                cmd.ExecuteNonQuery();
                baglantı.Close();
                textBox2.Text = "";
                textBox3.Text = "";
                listele();
                MessageBox.Show("mevcut ürüne ekleme yapıldı...");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            baglantı.Open();
            da = new SqlDataAdapter("select *from urun where urunadi like '" + textBox1.Text + "%'", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
            if (textBox1.Text == "")
            {
                listele();
            }
        }
    }
}
