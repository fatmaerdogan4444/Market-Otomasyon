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
    public partial class FrmFiyatguncelle : Form
    {
        public FrmFiyatguncelle()
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
            da= new SqlDataAdapter("select * from urun",baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FrmBölgemüdürü x = new FrmBölgemüdürü();
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
            urunAdı.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            fıyat.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE urun  SET satisfiyati=@satisfiyati,puan=@puan WHERE barkodno=@barkodno";
            komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@barkodno", (barkod.Text));
            if(yenıPuan.Text != "")
            {
                komut.Parameters.AddWithValue("@puan", Convert.ToInt32(yenıPuan.Text));
                yenıPuan.Text = "";
            }
            else
            {
                komut.Parameters.AddWithValue("@puan", Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value.ToString()));
                yenıPuan.Text = "";
            }
            if(yenıFıyat.Text != "")
            {
                komut.Parameters.AddWithValue("@satisfiyati",Convert.ToDecimal(yenıFıyat.Text));
                yenıFıyat.Text = "";
            }
            else
            {
                komut.Parameters.AddWithValue("@satisfiyati",Convert.ToDecimal(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
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
            da = new SqlDataAdapter("select *from urun where barkodno like '"+barkodAra.Text+"'",baglantı);
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
            da = new SqlDataAdapter("select *from urun where urunadi like '" + urunAra.Text + "%'", baglantı);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
            if (urunAra.Text == "")
            {
                listele();
            }
        }
    }
}
