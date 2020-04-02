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
    public partial class vehicle_details : Form
    {
       // private string txt.Text;
        public vehicle_details()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void vihile_details_Load(object sender, EventArgs e)
        {
            this.Height = this.MdiParent.Height;
            this.Width = this.MdiParent.Width;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            addOwner();
            
        }
        private void addOwner()
        {
            query = "SELECT * FROM Owner ORDER BY Owner_ID ASC";
            conn cn = new conn();
            if (cn.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cboOwnerID.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Owner_ID"].ToString().Replace(" ", "") != "")
                    {
                        this.cboOwnerID.Items.Add(dataReader["Owner_ID"].ToString());
                    }
                }

            }
        }
           
    
        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public string query { get; set; }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           // long phone;
           // string phn = txtPhoneNo.Text.Replace("+", "").Trim().ToString();
           
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
           
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chckStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        { }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVehicleID.Focus();
            }
            else if (txtMake.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMake.Focus();
            }
            else if (txtModel.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
            }

            else if (txtRate.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate.Focus();
            }
            else if (cboOwnerID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboOwnerID.Focus();
            }

            else
            {
                if (FindRecord(txtVehicleID.Text) == true)
                {
                    MessageBox.Show(txtVehicleID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtVehicleID.Focus();
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

                    string pic;
                    pic = txtPic.Text.Replace("\\", "__");
                    query = "INSERT INTO Vehicle VALUES('" + txtVehicleID.Text + "','" + txtMake.Text + "','" + txtModel.Text + "','" + dtpicDoR.Value.ToString("yyyy-MM-dd") + "','" + txtRate.Text + "','" + cboOwnerID.Text +"', '" + sts + "','" + pic + "')";
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
                            txtVehicleID.Focus();
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
        private void cleanData()
        {
            //throw new NotImplementedException();
             cboOwnerID.Text = "";
            txtModel.Text = "";
            txtMake.Text = "";
            txtRate.Text = "";
            txtPic.Text = "";
            txtVehicleID.Text = "";
            chckStatus.Checked = false;

            txtSearch.Text = "";
            dtpicDoR.Value = DateTime.Now;
            pic.Image = null;
            txtSearch.Focus();

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVehicleID.Focus();
            }
            else if (txtMake.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMake.Focus();
            }
            else if (txtModel.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
            }
            else if (dtpicDoR.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpicDoR.Focus();
            }

            else if (txtRate.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate.Focus();
            }
            else if (cboOwnerID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboOwnerID.Focus();
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

                string pic;
                pic = txtPic.Text.Replace("\\", "__");
                query = "UPDATE Vehicle SET Vehicle_ID='" + txtVehicleID.Text + "',Make='" + txtMake.Text + "',Model='" + txtModel.Text + "',Reg_Date='" + dtpicDoR.Value.ToString("yyyy-MM-dd") + "',Rate='" + txtRate.Text + "',Owner_ID='" + cboOwnerID.Text + "',Status='" + sts + "',Photo='" + pic + "' WHERE Vehicle_ID='" + txtVehicleID.Text + "'";
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
                        txtVehicleID.Focus();
                    }
                }
                cn.CloseConnection();




            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (txtVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVehicleID.Focus();
            }
            else if (txtMake.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMake.Focus();
            }
            else if (txtModel.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
            }
            else
            {

                query = "DELETE FROM Vehicle WHERE Vehicle_ID='" + txtSearch.Text + "'";
                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    if (MessageBox.Show("Are you sure you want to delete record?", "Vehicle Messaging System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                        cmd.ExecuteNonQuery();

                        cleanData();
                        MessageBox.Show("Record deleted!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record failed to delete!", "Vehicle Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtVehicleID.Focus();
                    }
                }

                cn.CloseConnection();

            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //display image in picture box
                pic.Image = new Bitmap(open.FileName);
                //image file path
                txtPic.Text = open.FileName;
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
                query2 = "SELECT * FROM Vehicle WHERE Vehicle_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtVehicleID.Text = Datareader["Vehicle_ID"].ToString();
                        txtMake.Text = Datareader["Make"].ToString();
                        txtModel.Text = Datareader["Model"].ToString();
                        txtRate.Text = Datareader["Rate"].ToString();
                        chckStatus.Text = Datareader["Status"].ToString();
                        // dtpicDoR.Value = Convert.ToDateTime(Datareader["Reg_Date"].ToString());

                         cboOwnerID.Text = Datareader["Owner_ID"].ToString();
                        txtPic.Text = Datareader["Photo"].ToString().Replace("__", "\\");
                        if (txtPic.Text != "")
                        {
                            pic.Image = Image.FromFile(txtPic.Text);
                        }
                        else
                        {
                            pic.Image = null;
                        }
                        if (Datareader["Status"].ToString() == "True")
                        {
                            chckStatus.CheckState = CheckState.Checked;
                        }
                    }

                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dtpicDoR_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}  



