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

namespace DesktopApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=API;Integrated Security=True");
            con.Open();
            string str = "SELECT id FROM user_registration WHERE username ='" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Successfully login!!");
                textBox1.Text = "";
                textBox2.Text = "";
            }


            else
            {
                MessageBox.Show("Invalid username and Password.");
            }


        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Registration obj2 = new Registration();
            obj2.ShowDialog();

        }
    }
}