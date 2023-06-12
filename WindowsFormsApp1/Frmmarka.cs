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
    public partial class Frmmarka : Form
    {
        public Frmmarka()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        bool durum;
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
        private void markaengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from markabilgileri", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (comboBox1.Text == r["kategori"].ToString() && textBox1.Text == r["marka"].ToString() || textBox1.Text == "" || comboBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void Frmmarka_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            markaengelle();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into markabilgileri(kategori,marka) values ('" + comboBox1.Text + "','" + textBox1.Text + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("marka eklendi...");
            }
            else
            {
                MessageBox.Show("bu marka zaten mevcut!!!");
            }
            textBox1.Text = "";
            comboBox1.Text = "";
        }
    }
}
