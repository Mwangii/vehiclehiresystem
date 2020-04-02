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
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

            Main main = new Main();
            main.MdiParent = this;
            if (Sessions.prev == "Admin")
            {
                userToolStripMenuItem.Visible = true;
            }
            else
            {
                userToolStripMenuItem.Visible = false;
            }
            main.Show();
        }

        private void schoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner oid = new Owner();
            oid.MdiParent = this;
            oid.Visible = true;
        }

        private void programmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vehicle_details vid = new vehicle_details();
            vid.MdiParent = this;
            vid.Visible = true;
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client cid = new Client();
            cid.MdiParent = this;
            cid.Visible = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee eid = new Employee();
            eid.MdiParent = this;
            eid.Visible = true;
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_in cin = new Check_in();
            cin.MdiParent = this;
            cin.Visible = true;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_out ct = new Check_out();
            ct.MdiParent = this;
            ct.Visible = true;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sessions.prev == "Admin")
            {
                Users us = new Users();
                us.MdiParent = this;
                us.Visible = true;
            }
            else
            {
                MessageBox.Show("You dont have authority,Please contact admin", "Kunis message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments py = new Payments();
            py.MdiParent = this;
            py.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
