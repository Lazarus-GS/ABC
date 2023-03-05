using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESOFT_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S24OOSNL\SQLEXPRESS;Initial Catalog=ems;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string username = txtUsername.Text;
            string pass = txtpassword.Text;

            string query_select = "SELECT * FROM login WHERE username ='" + username + " 'And password =' " + pass + "'";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();

            if (row.HasRows)
            {
                this.Hide();
                Manage_Employee obj = new Manage_Employee();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials, Please check Username and Password and try again !", "Invalid Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
