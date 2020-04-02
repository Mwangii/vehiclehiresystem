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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private void cleanData()
        {
            txtPaymentID.Text = "";
            cboPaymentmethod.Text = "";
            cboClientID.Text = "";

            txtPaymentID.Focus();
        }
        private void Payments_Load(object sender, EventArgs e)
        {

            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            addClient();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private bool FindRecord(string p)
        {
            return false;
           // throw new NotImplementedException();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          
        
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtPaymentID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentID.Focus();
            }
            else if (cboPaymentmethod.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPaymentmethod.Focus();
            }
            else if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboClientID.Focus();
            }


            else
            {
                if (FindRecord(txtPaymentID.Text) == true)
                {
                    MessageBox.Show(txtPaymentID.Text + " already exists!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPaymentID.Focus();
                }

                string query;
                query = "INSERT INTO Payments VALUES('" + txtPaymentID.Text + "','" + cboClientID.Text + "','" + cboPaymentmethod.Text + "')";
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
                        txtPaymentID.Focus();
                    }
                }
                cn.CloseConnection();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtPaymentID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtPaymentID.Focus();
            }
            else if (cboPaymentmethod.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboPaymentmethod.Focus();
            }
            else if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboClientID.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "UPDATE Payments SET Payment_ID ='" + txtPaymentID.Text + "',Client_ID='" + cboClientID.Text + "',Payment_Method= '" + cboPaymentmethod.Text + "' WHERE Payment_ID LIKE '" + txtPaymentID.Text + "'";
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (txtPaymentID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtPaymentID.Focus();
            }
            else if (cboClientID.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboClientID.Focus();
            }
            else if (cboPaymentmethod.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cboPaymentmethod.Focus();
            }

            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Ensure all field are filled", "Warning Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtSearch.Focus();
            }
            else
            {
                string query;
                query = "DELETE FROM Payments WHERE Payment_ID   LIKE '" + txtPaymentID.Text + "'";
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

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string query2;
                string hq;
                // syta
                hq = "%" + txtSearch.Text + "%";
                query2 = "SELECT * FROM Payments WHERE Payment_ID like '" + hq + "'";

                conn cn = new conn();
                if (cn.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query2, cn.connect);

                    MySqlDataReader Datareader = cmd.ExecuteReader();
                    if (Datareader.Read())
                    {

                        txtPaymentID.Text = Datareader["Payment_ID"].ToString();
                        cboClientID.Text = Datareader["Client_ID"].ToString();
                        cboPaymentmethod.Text = Datareader["Payment_Method"].ToString();
                        // txtPaymentID.Text = Datareader["Payment_ID"].ToString();




                    }

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cleanData();
        }
    }
}
