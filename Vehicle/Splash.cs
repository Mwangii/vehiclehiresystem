using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle
{
    public partial class Splash : Form
    {
        public int counter;

        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter += 20;
            if (counter >= 100)
            {
                progressBar1.Value = 100;
                lblProgress.Text = "Progress..100%";
            }
            else
            {
                progressBar1.Value = counter;
                lblProgress.Text = "Progress.." + counter + "%";
            }
            if (counter == 100)
            {
                Login lg = new Login();
                lg.Visible = true;
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            counter = 0;
        }


        private void lblProgress_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load_1(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            counter = 0;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
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
    }
}
