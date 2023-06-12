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
    public partial class fiyatguncelle : Form
    {
        public fiyatguncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=market2;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable dt;

        void listele()
        {
            dt = new DataTable();
            baglantı.Open();
            da= new SqlDataAdapter("select * from urunler",baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            bolgemudur x = new bolgemudur();
            x.Show();
            this.Close();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            barkod.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            urunAdı.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            fıyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE urunler  SET fiyat=@fiyat,puan=@puan WHERE urun_ID=@urun_ID";
            komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@urun_ID", Convert.ToInt32(barkod.Text));
            if(yenıPuan.Text != "")
            {
                komut.Parameters.AddWithValue("@puan", Convert.ToInt32(yenıPuan.Text));
                yenıPuan.Text = "";
            }
            else
            {
                komut.Parameters.AddWithValue("@puan", Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value.ToString()));
                yenıPuan.Text = "";
            }
            if(yenıFıyat.Text != "")
            {
                komut.Parameters.AddWithValue("@fiyat", Convert.ToInt32(yenıFıyat.Text));
                yenıFıyat.Text = "";
            }
            else
            {
                komut.Parameters.AddWithValue("@fiyat",Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
                yenıFıyat.Text = "";
            }
            baglantı.Open();     
            komut.ExecuteNonQuery();
            baglantı.Close();   
            listele();

        }
        private void barkodAra_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            baglantı.Open();
            da = new SqlDataAdapter("select *from urunler where urun_ID like '"+barkodAra.Text+"'",baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
            if(barkodAra.Text=="")
            {
                listele();
            }


        }

        private void urunAra_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            baglantı.Open();
            da = new SqlDataAdapter("select *from urunler where urun_ismi like '" + urunAra.Text + "%'", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
            if (urunAra.Text == "")
            {
                listele();
            }
        }
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            style1.ForeColor = Color.Azure;
            style1.BackColor = Color.Crimson;



            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle = style1;
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.ForeColor = Color.Black;
            style2.BackColor = Color.WhiteSmoke;

            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle = style2;
            }

        }
    }
}
