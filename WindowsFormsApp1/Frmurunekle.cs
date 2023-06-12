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
    public partial class Frmurunekle : Form
    {
        public Frmurunekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        bool durum;
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable dt;
        private void kategorigetir()
        {

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kategori"].ToString());

            }
            baglanti.Close();
        }
        void listele()
        {
            dt = new DataTable();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from urun", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["barkodno"].ToString() || textBox1.Text == "")
                    durum = false;
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmkategori d = new Frmkategori();
            d.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frmmarka f = new Frmmarka();
            f.ShowDialog();
        }

        private void btnekle_Click_1(object sender, EventArgs e)
        {
            barkodkontrol();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktari,alisfiyati,satisfiyati,puan,tarih) values(@barkodno, @kategori, @marka, @urunadi, @miktari, @alisfiyati,@satisfiyati,@puan,@tarih)", baglanti);
                cmd.Parameters.AddWithValue("@barkodno", textBox1.Text);
                cmd.Parameters.AddWithValue("@kategori", comboBox1.Text);
                cmd.Parameters.AddWithValue("@marka", comboBox2.Text);
                cmd.Parameters.AddWithValue("@urunadi", textBox4.Text);
                cmd.Parameters.AddWithValue("@miktari", Convert.ToInt32(textBox5.Text));
                cmd.Parameters.AddWithValue("@alisfiyati", double.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@satisfiyati", Convert.ToDecimal(textBox7.Text));
                cmd.Parameters.AddWithValue("@puan", Convert.ToInt32(textBox8.Text));
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("ürün eklendi...");
            }
            else
            {
                MessageBox.Show("bu barkoda sahip ürün zaten var!!!");
            }
            comboBox2.Items.Clear();
            foreach (Control x in groupBox1.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                }
                if (x is ComboBox)
                {
                    x.Text = "";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            comboBox2.Items.Clear();
            comboBox2.Text = "";
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from markabilgileri where kategori='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["marka"].ToString());
            }
            baglanti.Close();
        }

        private void Frmurunekle_Load_1(object sender, EventArgs e)
        {
            kategorigetir();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBölgemüdürü m = new FrmBölgemüdürü();
            m.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
