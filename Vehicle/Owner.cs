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
    public partial class Owner : Form
    {
        public Owner()
        {
            InitializeComponent();
        }
        private void cleanData()
        {
            txtOwnerID.Text = "";
            txtOwnerName.Text = "";
            txtMobileNo.Text = "";
            //txtVehicleID.Text = "";
            txtSearch.Text = "";
            chckStatus.Checked =false;
            txtOwnerID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }
     /**  private void cleanData()
        {
            //throw new NotImplementedException();
            txtOwnerID.Text = "";
            txtOwnerName.Text = "";
            txtMobileNo.Text = "";
            txtVehicleID.Text = "";
            chckStatus.Checked = false;
            txtSearch.Text = "";
             txtpic.Text
            txtSearch.Focus();

        }**/
        private bool FindRecord(string p)
        {
            return false;
           // throw new NotImplementedException();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
          // cleanData();
        }
     

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtOwnerID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOwnerID.Focus();
            }
            else if (txtOwnerName.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOwnerName.Focus();
            }
            else if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobileNo.Focus();
            }



            else
            {
                if (FindRecord(txtOwnerID.Text) == true)
                {
                    MessageBox.Show(txtOwnerID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOwnerID.Focus();
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
                    query = "INSERT INTO Owner VALUES('" + txtOwnerID.Text + "','" + txtOwnerName.Text + "','" + txtMobileNo.Text + "','" + sts + "')";
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
                            txtOwnerID.Focus();
                        }
                    }
                    cn.CloseConnection();
                }
            }

        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            cleanData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtOwnerID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtOwnerID.Focus();
            }
            else if (txtOwnerName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtOwnerName.Focus();
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

                string query3;
                query3 = "UPDATE Owner SET Owner_ID ='" + txtOwnerID.Text + "',Owner_Name='" + txtOwnerName.Text + "',Mobile_No= '" + txtMobileNo.Text + "',Status ='" + sts + "' WHERE Owner_ID LIKE '" + txtOwnerID.Text + "'";
                conn cn = new conn();

                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to make this changes?", "Kunis messaging system", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        MySqlCommand cmd = new MySqlCommand(query3, cn.connect);
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

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query2;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query2 = "SELECT * FROM Owner WHERE Owner_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtOwnerID.Text = Datareader["Owner_ID"].ToString();
                        txtOwnerName.Text = Datareader["Owner_Name"].ToString();
                        txtMobileNo.Text = Datareader["Mobile_No"].ToString();
                        chckStatus.Text = Datareader["Status"].ToString();


                        /**  dtpicDoR.Value = Convert.ToDateTime(Datareader["DoR"].ToString());
                        cboOwnerID.Text = Datareader["Owner_ID"].ToString();
                        txtPic.Text = Datareader["Photo"].ToString().Replace("__", "\\");
                        if (txtPic.Text != "")
                        {
                            pic.Image = Image.FromFile(txtPic.Text);
                        }
                        else
                        {
                            pic.Image = null;
                        }**/
                        if (Datareader["Status"].ToString() == "True")
                        {
                            chckStatus.CheckState = CheckState.Checked;
                        }
                    }

                }
            }
        }

        private void chckStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Owner_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtOwnerID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtOwnerID.Focus();
            }
            else if (txtOwnerName.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtOwnerName.Focus();
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
                query = "DELETE FROM Owner WHERE Owner_ID   LIKE '" + txtOwnerID.Text + "'";
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
        }
    }

