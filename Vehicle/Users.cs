using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vehicle
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void cleanData()
        {
            //throw new NotImplementedException();
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cboPriveledges.Text = "";
            txtSearch.Text = "";
            chckStatus.Checked = false;
           /** txtVehicleID.Text = "";

            txtSearch.Text = "";
            dtpicDoR.Value = DateTime.Now;
            pic.Image = null;**/
            txtSearch.Focus();

        }

        private bool FindRecord(string p)
        {
            return false;
            //throw new NotImplementedException();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }

            else if (cboPriveledges.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPriveledges.Focus();
            }

            else
            {
                if (FindRecord(txtUserID.Text) == true)
                {
                    MessageBox.Show(txtUserID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserID.Focus();
                }
                else
                {
                    int sts;
                    if (chckStatus.CheckState == CheckState.Checked)
                    {
                        sts = 1;
                    }
                    else
                    {
                        sts = 0;
                    }

                    string query;
                    query = "INSERT INTO Users VALUES('" + txtUserID.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "','" + cboPriveledges.Text + "','" + sts + "')";
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
                            txtUserID.Focus();
                        }
                    }
                    cn.CloseConnection();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
          
            else if (cboPriveledges.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPriveledges.Focus();
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
                //pic = txtPic.Text.Replace("\\", "__");
                query = "UPDATE Users SET User_ID='" + txtUserID.Text + "',User_Name='" + txtUserName.Text + "',Password='" + txtPassword.Text + "',Priveledges='" + cboPriveledges.Text + "',Status='" + sts + "' WHERE User_ID='" + txtUserID.Text + "'";
                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to save changes?", "KUNIS Messaging System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                        cmd.ExecuteNonQuery();

                        cleanData();
                        MessageBox.Show("Records Saved!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Records not Saved!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUserID.Focus();
                    }
                }
                cn.CloseConnection();




            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtUserID.Focus();
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }
            else if (cboPriveledges.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboPriveledges.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Users WHERE User_ID   LIKE '" + txtUserID.Text + "'";
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query2;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query2 = "SELECT * FROM Users WHERE User_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtUserID.Text = Datareader["User_ID"].ToString();
                        txtUserName.Text = Datareader["User_Name"].ToString();
                        txtPassword.Text = Datareader["Password"].ToString();
                        cboPriveledges.Text = Datareader["Priveledges"].ToString();
                        chckStatus.Text = Datareader["Status"].ToString();
                        // dtpicDoR.Value = Convert.ToDateTime(Datareader["Reg_Date"].ToString());

                        //  dtpicDoR.Value = Convert.ToDateTime(Datareader["DoR"].ToString());
                        
                        if (Datareader["Status"].ToString() == "True")
                        {
                            chckStatus.CheckState = CheckState.Checked;
                        }
                    }

                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
         //   this.reportViewer1.RefreshReport();
        }
    }
}
