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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLoginName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
            }
            else
            {
                conn connect = new conn();
                string query = "SELECT * FROM  Users WHERE User_Name='" + txtLoginName.Text.ToString() + "' AND Password='" + txtPassword.Text.ToString() + "' AND Status=1";

                //open connection
                if (connect.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connect.connect);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    if (dataReader.Read())
                    {
                        //list[0].Add(dataReader["id"] + "");
                        //list[1].Add(dataReader["name"] + "");
                        if (dataReader["User_Name"].ToString() == txtLoginName.Text && dataReader["Password"].ToString() == txtPassword.Text)
                        {
                            Sessions.username = dataReader["User_Name"].ToString();
                            Sessions.prev = dataReader["Priveledges"].ToString();
                            Sessions.userID = dataReader["User_ID"].ToString();
                            Sessions.loginTime = DateTime.Now.ToString();
                            MDI mdi = new MDI();
                            mdi.Visible = true;
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Username/Password Mismatch!\nPlease Try again!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtLoginName.Text = "";
                            txtPassword.Text = "";
                            txtLoginName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username/Password Mismatch!\nPlease Try again!", "KUNIS Messaging System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtLoginName.Text = "";
                        txtPassword.Text = "";
                        txtLoginName.Focus();
                    }

                    //close Data Reader
                    dataReader.Close();


                    //close connection
                    connect.CloseConnection();
                }
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Login_Load(object sender, EventArgs e)
        {
              panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
              panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
