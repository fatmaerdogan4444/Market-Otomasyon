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
    public partial class FrmSatis : Form
    {
        
        public FrmSatis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True"); 
        DataSet ds = new DataSet();
        Random rand = new Random();


        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from sepet", baglanti);
            da.Fill(ds, "sepet");
            dataGridView1.DataSource = ds.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            baglanti.Close();

        }
        private void temizle()
        {
            if (txtBarkod.Text == "")
            {
                foreach (Control item in groupBox6.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtMiktar)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }
        private void hesapla()
        {

               baglanti.Open();
             SqlCommand cmd = new SqlCommand("select sum(toplamfiyati) from sepet", baglanti);
            richTextBox2.Text = cmd.ExecuteScalar() + "TL";
            baglanti.Close();     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtadsoyad.Enabled = false;
            textBox3.Enabled = false;   
            txtpuan.Enabled = false;
            sepetlistele();
           ds.Tables["sepet"].Clear();
            textBox1.Text = DateTime.Now.ToShortDateString().ToString();
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
            textBox4.Text = rand.Next(10, 999).ToString();
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM users where calisan_ID = @calisan_ID", con);
            
            //string id = cmd.ExecuteScalar().ToString();
            //con.Close();
            //textBox7.Text = id;



        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtID.Enabled = true;
            }
            else
            {
                txtID.Enabled = false;
                txtID.Text = "";
            }
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            temizle();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select *from urun where barkodno like'" + txtBarkod.Text + "'", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                txtÜrünA.Text = r["urunadi"].ToString();
                txtSatışF.Text = r["satisfiyati"].ToString();
            }
            baglanti.Close();
        }
        bool durum;
        private void üstüneekleme()
        {
            durum = true;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from sepet", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (txtBarkod.Text == r["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
            Random random = new Random();
            üstüneekleme();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert  into sepet(tel,ad,soyad,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih,sepet_ID) values (@tel,@ad,@soyad,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih,'" + random.Next(50, 100) + "') ", baglanti);

                {
                    cmd.Parameters.AddWithValue("@tel", txtID.Text);
                    cmd.Parameters.AddWithValue("@ad", txtadsoyad.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtpuan.Text);
                    cmd.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
                    cmd.Parameters.AddWithValue("@urunadi", txtÜrünA.Text);
                    cmd.Parameters.AddWithValue("@miktari", int.Parse(txtMiktar.Text));
                    cmd.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatışF.Text));
                    cmd.Parameters.AddWithValue("@toplamfiyati", double.Parse(txtToplamF.Text));
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }

            }
            else
            {
                baglanti.Open();
                SqlCommand cmd2 = new SqlCommand("update sepet set miktari=miktari +'" + int.Parse(txtMiktar.Text) + "' where barkodno='" + txtBarkod.Text + "'", baglanti);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("update sepet set toplamfiyati=miktari * satisfiyati where barkodno='" + txtBarkod.Text + "'", baglanti);
                cmd3.ExecuteNonQuery();
                baglanti.Close();

            }
            txtMiktar.Text = "1";
            ds.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();

            foreach (Control item in groupBox6.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtMiktar)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void txtSatışF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamF.Text = (double.Parse(txtMiktar.Text) * double.Parse(txtSatışF.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamF.Text = (double.Parse(txtMiktar.Text) * double.Parse(txtSatışF.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("ürüns sepetten silindi");
            ds.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
            textBox4.Text = rand.Next(10, 999).ToString();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from sepet", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ürüns sepeti iptal edildi");
            ds.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
            textBox4.Text = rand.Next(10, 999).ToString();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("insert into satis(tel,ad,soyad,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih,satis_ID) values (@tel,@ad,@soyad,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih,'" + rand.Next(50, 100) + "') ", baglanti);

                {
                    cmd.Parameters.AddWithValue("@tel", txtID.Text);
                    cmd.Parameters.AddWithValue("@ad", txtadsoyad.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtpuan.Text);
                    cmd.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                    cmd.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                    cmd.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    cmd.ExecuteNonQuery();
                }


                SqlCommand cmd2 = new SqlCommand("update urun set miktari=miktari -'" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "'where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);
                cmd2.ExecuteNonQuery();
                baglanti.Close();
            }
            baglanti.Open();
            SqlCommand cmd3 = new SqlCommand("delete from sepet", baglanti);
            cmd3.ExecuteNonQuery();
            baglanti.Close();
            ds.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();

            Frmkasiyermusteri p = new Frmkasiyermusteri();
            p.ShowDialog();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToShortTimeString().ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FrmAnaSayfa c = new FrmAnaSayfa();
            c.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            if (txtID.Text == "")
            {
                txtadsoyad.Text = "";
                txtpuan.Text = "";

            }

            SqlCommand cmd = new SqlCommand("Select *from müsteri where tel like'" + txtID.Text + "'", baglanti);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                txtadsoyad.Text = r["ad"].ToString();
                textBox3.Text = r["soyad"].ToString();
                txtpuan.Text = r["puan"].ToString();
            }
            baglanti.Close();
        }
    }
}

