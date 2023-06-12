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
    public partial class Frmkategori : Form
    {
        public Frmkategori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        bool durum;

        private void kategoriengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (textBox1.Text == r["kategori"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            kategoriengelle();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into kategoribilgileri(kategori,kategori_ID) values ('" + textBox1.Text + "','"+ rastgele.Next(50,200) +"')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("kategori eklendi...");
            }
            else
            {
                MessageBox.Show("bu kategori zaten mevcut!!!");
            }
            textBox1.Text = "";
        }
    }
}
