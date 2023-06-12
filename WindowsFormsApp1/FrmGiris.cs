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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa v = new FrmAnaSayfa();
            v.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-J1TC895;Initial Catalog=marketoto3;Integrated Security=True");
            string sorgu = "SELECT * FROM users where usr=@user AND pass=@pass";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", ad.Text);
            cmd.Parameters.AddWithValue("@pass", sifre.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (ad.Text == "admin")
                {
                    FrmAnaSayfa x = new FrmAnaSayfa();
                    x.Show();
                    this.Hide();
                }
                else if(ad.Text=="guest")
                {
                    FrmSatis x = new FrmSatis();
                    x.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                ad.Text = "";
                sifre.Text = "";
                
            }
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmAnaSayfa f = new FrmAnaSayfa();
            f.Show();
            this.Hide();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
