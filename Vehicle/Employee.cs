using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Vehicle
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        private void cleanData()
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtMobileNo.Text = "";

            txtEmployeeID.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private bool FindRecord(string p)
        {
            return false;
            // throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeID.Focus();
            }
            else if (txtEmployeeName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
            }


            else
            {
                if (FindRecord(txtEmployeeID.Text) == true)
                {
                    MessageBox.Show(txtEmployeeID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmployeeID.Focus();
                }

                string query;
                query = "INSERT INTO Employee VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtMobileNo.Text + "')";
                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to save record?", "KUNIS Messaging System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                        cmd.ExecuteNonQuery();

                        cleanData();
                        MessageBox.Show("Records Saved!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Records not Saved!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEmployeeID.Focus();
                    }
                }
                cn.CloseConnection();
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query = "SELECT * FROM Employee WHERE Employee_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtEmployeeID.Text = Datareader["Employee_ID"].ToString();
                        txtEmployeeName.Text = Datareader["Employee_Name"].ToString();
                        txtMobileNo.Text = Datareader["Mobile_No"].ToString();


                    }

                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtEmployeeID.Focus();
            }
            else if (txtEmployeeName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
            }
           
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "UPDATE Employee SET Employee_ID ='" + txtEmployeeID.Text + "',Employee_Name='" + txtEmployeeName.Text + "',Mobile_No= '" + txtMobileNo.Text + "' WHERE Employee_ID LIKE '" + txtEmployeeID.Text + "'";
                conn cn = new conn();

                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to make this changes?", "Kunis messaging system", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                        cmd.ExecuteNonQuery();
                        cleanData();
                        txtSearch.Text = "";
                        MessageBox.Show("Record saved", "Kunis messaging system", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        txtSearch.Focus();
                    }
                    else
                    {
                        cleanData();
                        txtSearch.Text = "";
                        MessageBox.Show("Record not saved", "Kunis messaging system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSearch.Focus();
                    }
                }

            }
        
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtEmployeeID.Focus();
            }
            else if (txtEmployeeName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
            }
           
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Employee WHERE Employee_ID   LIKE '" + txtEmployeeID.Text + "'";
                conn cn = new conn();

                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to make this changes?", "Kunis messaging system", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                        cmd.ExecuteNonQuery();
                        cleanData();
                        txtSearch.Text = "";
                        MessageBox.Show("Record deleted", "Kunis messaging system", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        txtSearch.Focus();
                    }
                    else
                    {
                        cleanData();
                        txtSearch.Text = "";
                        MessageBox.Show("Record not deleted", "Kunis messaging system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSearch.Focus();
                    }
                }
            }
             
        }
    }
}
