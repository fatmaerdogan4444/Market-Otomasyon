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
    public partial class FrmMüsteri : Form
    {
        public FrmMüsteri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
        DataSet ds = new DataSet();
        bool durum;
        private void müsteriengelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from müsteri", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (textBox1.Text == r["tel"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

        private void kayıtgöster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from müsteri", baglanti);
            da.Fill(ds, "müsteri");
            dataGridView1.DataSource = ds.Tables["müsteri"];
            baglanti.Close();
        }

        private void FrmMüsteri_Load(object sender, EventArgs e)
        {
            kayıtgöster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            müsteriengelle();
            if(durum==true)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into müsteri(tel,ad,soyad,adres,email) values (@tel,@ad,@soyad,@adres,@email)", baglanti);
                cmd.Parameters.AddWithValue("@tel", textBox1.Text);
                cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
                cmd.Parameters.AddWithValue("@adres", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["müsteri"].Clear();
                kayıtgöster();
                MessageBox.Show("Kayıt Eklendi...");
            }
            else
            {
                MessageBox.Show("aynı müsteriyi ekleyemezsiniz");
            }
            foreach (Control i in this.Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update müsteri set ad=@ad,soyad=@soyad,adres=@adres,email=@email where tel=@tel", baglanti);
            cmd.Parameters.AddWithValue("@tel", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
           ds.Tables["müsteri"].Clear();
            kayıtgöster();
            MessageBox.Show("Kayıt guncellendi...");
            foreach (Control i in this.Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from müsteri where tel='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            ds.Tables["müsteri"].Clear();
            kayıtgöster();
            MessageBox.Show("kayıt silindi...");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from müsteri where tel like '" + textBox6.Text + "%'", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBölgemüdürü n = new FrmBölgemüdürü();
            n.Show();
            this.Hide();
        }
    }
}
