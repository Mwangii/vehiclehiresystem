using System;
using System.Windows.Forms;

namespace Vehicle
{
    public partial class Basic : Form
    {
        public Basic()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           /* StudentEntities de = new StudentEntities();
            CrystalReport crb = new CrystalReport();
            crb.SetDataSource(de.Student.Select(C => new
            {
                Owner_ID = C.Owner_ID,
                Owner_Name = C.Owner_Name,
                Phone_No = C.Phone_No
            }).Tolist());
            this.crystalReportViewer1.ReportSource = crb;**/
        }
    }
}
