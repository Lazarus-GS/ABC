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
    public partial class Manage_Employee : Form
    {
        public Manage_Employee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S24OOSNL\SQLEXPRESS;Initial Catalog=ems;Integrated Security=True");
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                string gender;

                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {

                    gender = "Female";

                }
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                int mobilephone = int.Parse(txtMobile.Text);
                int homePhone = int.Parse(txtHphone.Text);
                string departmentName = txtDName.Text;
                string designation = txtDesignation.Text;
                string employeeType = txtEtype.Text;
                string query_insert = "insert into employee values('" + firstName + "','" + lastName + "','" + dtpDob.Text + "','" + gender + "','" + address + "','" + email + "','" + mobilephone, +"','" + homePhone + "','" + departmentName + "','" + designation + "','" + employeeType + ")";

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);

                cmnd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Added Successfully!", "Registered Employee!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (SqlException ex)

            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string no = cmbReg.Text;

            if (no != "New Register")
            {
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                string gender;
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                int mobilePhone = int.Parse(txtMobile.Text);
                int homePhone = int.Parse(txtHphone.Text);
                string departmentName = txtDName.Text;
                string designation = txtDesignation.Text;
                string employeeType = txtEtype.Text;

                string query_insert = "UPDATE employee SET firstName = '" + firstName + "',lastName ='" + lastName + "',dateOfBirth = '" + dtpDob.Text + "',gender = '" + 
                    gender + "',address = '" + address + "',email = '" + email + "',mobilePhone = " + mobilePhone + ",homePhone = " + homePhone + ",departmentName = '" +
                    departmentName + "',designation = '" + designation + "',employeeType = " + employeeType + " WHERE empNO ="+ no;

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recird Updated Successfully!", "Updated Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
