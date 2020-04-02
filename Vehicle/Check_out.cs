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
    public partial class Check_out : Form
    {
        public Check_out()
        {
            InitializeComponent();
        }
        private void cleanData()
        {
            cboClientID.Text = "";
            cboVehicleID.Text = "";
            dtHire.Text = "";
            txtDuration.Text = "";
            txtDescription.Text = "";
            txtAmountPaid.Text = "";
            txtSearch.Text = "";


            chckStatus.Checked = false;
            txtSearch.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private bool FindRecord(string p)
        {
            return false;
            //throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Check_out_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            addClient();
            addVehicle();
        }
        private void addClient()
        {
            string query;
            query = "SELECT * FROM Client ORDER BY Client_ID ASC";
            conn cn = new conn();
            if (cn.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cboClientID.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Client_ID"].ToString().Replace(" ", "") != "")
                    {
                        this.cboClientID.Items.Add(dataReader["Client_ID"].ToString());
                    }
                }

            }
        }
        private void addVehicle()
        {
            string query;
            query = "SELECT * FROM Vehicle ORDER BY Vehicle_ID ASC";
            conn cn = new conn();
            if (cn.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, cn.connect);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                this.cboVehicleID.Items.Clear();
                while (dataReader.Read())
                {
                    if (dataReader["Vehicle_ID"].ToString().Replace(" ", "") != "")
                    {
                        this.cboVehicleID.Items.Add(dataReader["Vehicle_ID"].ToString());
                    }
                }

            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboClientID.Focus();
            }
            else if (cboVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboVehicleID.Focus();
            }
            else if (dtHire.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtHire.Focus();
            }
            /** else if (!IsValidEmail(txtEmail.Text.Replace(" ", "").ToString()))
             {
                 MessageBox.Show("Invalid Email", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtEmail.Focus();
             }*/
            else if (txtDuration.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuration.Focus();
            }
            else if (txtDuration.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuration.Focus();
            }
            else if (txtAmountPaid.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmountPaid.Focus();
            }

            else
            {
                if (FindRecord(cboClientID.Text) == true)
                {
                    MessageBox.Show(cboClientID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboClientID.Focus();
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
                    query = "INSERT INTO Check_out VALUES('" + cboClientID.Text + "','" + cboVehicleID.Text + "','" + dtHire.Value.ToString("yyyy-MM-dd") + "','" + txtDuration.Text + "','" + txtDescription.Text + "','" + sts + "','" + txtAmountPaid.Text + "')";
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
                            cboClientID.Focus();
                        }
                    }
                    cn.CloseConnection();
                }
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboClientID.Focus();
            }
            else if (cboVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboVehicleID.Focus();
            }
            else if (dtHire.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dtHire.Focus();
            }
            else if (txtDuration.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDuration.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }

            else if (txtAmountPaid.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtAmountPaid.Focus();
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

                query3 = "UPDATE Check_out SET Client_ID ='" + cboClientID.Text + "',Vehicle_ID = '" + cboVehicleID.Text + "',Date= '" + dtHire.Text + "',Duration = '" + txtDuration.Text + "',Description= '" + txtDescription.Text + "',Status= '" + sts + "' WHERE Client_ID LIKE '" + cboClientID.Text + "'";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboClientID.Focus();
            }
            else if (cboVehicleID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboVehicleID.Focus();
            }
            else if (dtHire.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dtHire.Focus();
            }
            else if (txtDuration.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDuration.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else if (txtAmountPaid.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtAmountPaid.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Check_out WHERE Client_ID   LIKE '" + cboClientID.Text + "'";
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
                string query;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query = "SELECT * FROM Check_out WHERE Client_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        cboClientID.Text = Datareader["Client_ID"].ToString();
                        cboVehicleID.Text = Datareader["Vehicle_ID"].ToString();
                       // dtHire.Text = Datareader["Date"].ToString();


                        txtDuration.Text = Datareader["Duration"].ToString();
                        txtDescription.Text = Datareader["Description"].ToString();

                        chckStatus.Text = Datareader["Status"].ToString();
                        txtAmountPaid.Text = Datareader["Amount_Paid"].ToString();

                        if (Datareader["Status"].ToString() == "True")
                        {
                            chckStatus.CheckState = CheckState.Checked;
                        }
                    }

                }
            }
        }

        private void cboVehicleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            /**if (string.IsNullOrEmpty(cboClientID.Text))
            {
                MessageBox.Show("Available");
            }
            else
            {
                MessageBox.Show("Not available");
            }
             
            int i = cboVehicleID.Items.Count;
            for(int j=0; j<i; j++)
            {
                if(cboVehicleID.Items[j].Selected ==true)
                {
                    cboVehicleID.Items.Remove(cboVehicleID.Items[i].ToString());
                    i--;
                }
            }
            **/
        }

        private void cboClientID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
