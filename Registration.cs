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
using System.Xml.Linq;

namespace DesktopApplication
{
    public partial class Registration : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=API;Integrated Security=True");
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {

            con.Open();


            string str = "INSERT INTO user_registration(username,password,confirm_password) VALUES( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

            SqlCommand cmd = new SqlCommand(str, con);

            cmd.ExecuteNonQuery();

            //-------------------------------------------//

            string str1 = "select max(id) from user_registration";
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Record saved Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }


            con.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login obj3 = new Login();
            obj3.Show();

        }
    }
}