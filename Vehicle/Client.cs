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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
      

        private bool FindRecord(string p)

        {
            return false;
            //throw new NotImplementedException();
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cleanData();
        }
        private void cleanData()
        {
            //throw new NotImplementedException();
            txtClientID.Text = "";
            txtClientName.Text = "";
            txtMobileNo.Text = "";
            txtCountry.Text = "";
            //txtVehicleID.Text = "";
            chckStatus.Checked = false;
            txtSearch.Text = "";
            // pic.Image = null;
            txtSearch.Focus();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chckStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void VehicleID_Click(object sender, EventArgs e)
        {

        }

        private void txtVehicleID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

            if (txtSearch.Text != "")
            {
                string query;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query = "SELECT * FROM Client WHERE Client_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtClientID.Text = Datareader["Client_ID"].ToString();
                        txtClientName.Text = Datareader["Client_Name"].ToString();
                        txtMobileNo.Text = Datareader["Mobile_No"].ToString();
                        txtCountry.Text = Datareader["Country"].ToString();
                        chckStatus.Text = Datareader["Status"].ToString(); 
                        if (Datareader["Status"].ToString() == "True")
                        {
                            chckStatus.CheckState = CheckState.Checked;
                        }

                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtClientID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClientID.Focus();
            }
            else if (txtClientName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClientName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
            }
            /** else if (!IsValidEmail(txtEmail.Text.Replace(" ", "").ToString()))
             {
                 MessageBox.Show("Invalid Email", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtEmail.Focus();
             }*/
            else if (txtCountry.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCountry.Focus();
            }

            /** else if (txtOwnerID.Text == "")
             {
                 MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtOwnerID.Focus();
             }
              else if (!long.TryParse(phn, out phone))
              {
                  MessageBox.Show("Invalid Phone Number!", "Looptech International Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  txtPhoneNo.Focus();
              }
              else if (!txtPhoneNo.Text.Contains("+"))
              {
                  MessageBox.Show("Invalid Phone Number!", "Looptech International Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  txtPhoneNo.Focus();
              }*/
            else
            {
                if (FindRecord(txtClientID.Text) == true)
                {
                    MessageBox.Show(txtClientID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtClientID.Focus();
                }
                else
                {
                    int sts;
                    //string gnder;
                    if (chckStatus.CheckState == CheckState.Checked)
                    {
                        sts = 1;
                    }
                    else
                    {
                        sts = 0;
                    }
                    /** if (rbtnFemale.Checked == true)
                     {
                         gnder = "Female";
                     }
                     else
                     {
                         gnder = "Male";
                     }*/
                    string query;
                    //  pic = txtPic.Text.Replace("\\", "__");
                    query = "INSERT INTO Client VALUES('" + txtClientID.Text + "','" + txtClientName.Text + "','" + txtMobileNo.Text + "','" + txtCountry.Text + "','" + sts + "')";
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
                            txtClientID.Focus();
                        }
                    }
                    cn.CloseConnection();
                }
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtClientID.Focus();
            }
            else if (txtClientName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtClientName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
            }
            else if (txtCountry.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCountry.Focus();
            }
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                int sts;
                // string gnder;
                if (chckStatus.CheckState == CheckState.Checked)
                {
                    sts = 1;
                }
                else
                {
                    sts = 0;
                }
                string query;
                query = "UPDATE Client SET Client_ID ='" + txtClientID.Text + "',Client_Name='" + txtClientName.Text + "',Mobile_No= '" + txtMobileNo.Text + "',Country= '" + txtCountry.Text + "',Status= '" + sts + "' WHERE Client_ID LIKE '" + txtClientID.Text + "'";
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtClientID.Focus();
            }
            else if (txtClientName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtClientName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
            }
            else if (txtCountry.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtCountry.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Client WHERE Client_ID   LIKE '" + txtClientID.Text + "'";
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private void txtClientID_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
