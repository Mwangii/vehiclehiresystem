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
    public partial class Check_in : Form
    {
        public Check_in()
        {
            InitializeComponent();
        }

         private void cleanData()
        {
            cboClientID.Text = "";
            cboVehicleID.Text = "";
            dtReturn.Text = "";
            txtExtracost.Text = "";
          
            cboClientID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void Check_in_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            else if (dtReturn.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtReturn.Focus();
            }

            else if (txtExtracost.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExtracost.Focus();
            }

          /**  else
            {
                if (FindRecord(txtClientID.Text) == true)
                {
                    MessageBox.Show(txtClientID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtVehicleID.Focus();
                }**/
               
                    string query;
                    query = "INSERT INTO Check_in VALUES('" + cboClientID.Text + "','" + cboVehicleID.Text + "','" + dtReturn.Text + "','" + txtExtracost.Text + "')";
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

        private void txtExtracost_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query = "SELECT * FROM Check_in WHERE Client_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        cboClientID.Text = Datareader["Client_ID"].ToString();
                        cboVehicleID.Text = Datareader["Vehicle_ID"].ToString();
                       // dtReturn.Value = Convert.ToDateTime(Datareader["Return_Date"].ToString());
                        txtExtracost.Text = Datareader["Extra_Cost"].ToString();


                    }

                }
            }
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
            else if (dtReturn.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dtReturn.Focus();
            }
            else if (txtExtracost.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtExtracost.Focus();
            }
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "UPDATE Check_in SET Client_ID ='" + cboClientID.Text + "',Vehicle_ID='" + cboVehicleID.Text + "',Return_Date= '" + dtReturn.Text + "',Extra_Cost = '" + txtExtracost.Text + "' WHERE Client_ID LIKE '" + cboClientID.Text + "'";
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
            else if (dtReturn.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                dtReturn.Focus();
            }
            else if (txtExtracost.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtExtracost.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Check_in WHERE Client_ID   LIKE '" + cboClientID.Text + "'";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }
            }
        }

      /**  private bool FindRecord(string p)
        {
         return false;
           // throw new NotImplementedException();
        }**/
    
