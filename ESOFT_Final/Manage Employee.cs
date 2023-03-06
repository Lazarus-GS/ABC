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
                int mobilePhone = int.Parse(txtMobile.Text);
                int homePhone = int.Parse(txtHphone.Text);
                string departmentName = txtDName.Text;
                string designation = txtDesignation.Text;
                string employeeType = txtEtype.Text;
                string query_insert = "insert into employee values('" + firstName + "','" + lastName + "','" + dtpDob.Text + "','" + gender + "','" + address + "','" + email + "'," +
                    mobilePhone + "," + homePhone + ", '" + departmentName + "', '" + designation + "'," + employeeType + ")";

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);

                cmnd.ExecuteNonQuery();

                MessageBox.Show("Record Added Successfully!", "Registered Employee!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            cmbReg.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dtpDob.Text = thisDay.ToString();

            rbMale.Checked = false;
            rbFmale.Checked = false;

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtHphone.Text = "";
            txtDName.Text = "";
            txtDesignation.Text = "";
            txtEtype.Text = "";        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to Delete this Record...?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string no = cmbReg.Text;

                string query_insert = "DELETE FROM employee WHERE empNo = " + no + "";
                con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Deleted Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Manage_Employee_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_select = "SELECT * FROM employee";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();
            cmbReg.Items.Add("New Register");
            while(row.Read())
            {
                cmbReg.Items.Add(row[0].ToString());
            }
            con.Close();
        }

        private void cmbReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = cmbReg.Text;
            if (no != "New Register")
            {
                con.Open();
                string query_select = "SELECT * FROM Registration2 WHERE regNo =" + no;
                SqlCommand cmd = new SqlCommand(query_select, con);
                SqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    txtFname.Text = row[1].ToString();
                    txtLname.Text = row[2].ToString();
                    dtpDob.Format = DateTimePickerFormat.Custom;
                    dtpDob.CustomFormat = "yyyy/MM/dd";
                    dtpDob.Text = row[3].ToString();
                    if (row[4].ToString() == "Male")
                    {
                        rbMale.Checked = true;
                        rbFmale.Checked = false;
                    }
                    else
                    {
                        rbMale.Checked = false;
                        rbFmale.Checked = true;
                    }
                    txtAddress.Text = row[5].ToString();
                    txtEmail.Text = row[6].ToString();
                    txtMobile.Text = row[7].ToString();
                    txtHphone.Text = row[8].ToString();
                    txtDName.Text = row[9].ToString();
                    txtDesignation.Text = row[10].ToString();
                    txtEtype.Text = row[11].ToString();
                }
                con.Close();
                btnRegister.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;            
            }
            else
            {
                txtFname.Text = "";
                txtLname.Text = "";
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dtpDob.Text = thisDay.ToString();

                    rbMale.Checked = true;
                    rbFmale.Checked = false;

                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtMobile.Text = "";
                    txtHphone.Text = "";
                    txtDName.Text = "";
                    txtDesignation.Text = "";
                    txtEtype.Text = "";
                    btnRegister.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
            }
        }
        
    }
}
