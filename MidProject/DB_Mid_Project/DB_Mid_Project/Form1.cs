using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class frmMain : Form
    {
        bool evaluation;
        string e_name;
        int e_id;
        bool studentlist;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ForDateTime.Enabled = true;
        }
        private void ForDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy       hh:mm:ss");
            if (evaluation == true)
            {

                loadNewForm(new ucEvaluation(e_name, e_id));
                evaluation = false;
            }
            else if (studentlist == true)
            {
                loadNewForm(new ucStudenList());
                studentlist = false;
            }
        }
        public void loadNewForm(object usercontrol)
        {
            try
            {
                UserControl newOne = usercontrol as UserControl;
                newOne.Dock = DockStyle.Fill;
                this.tlpChangeable.Controls.Add(newOne);
                this.tlpChangeable.Tag = newOne;
                newOne.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblStudent_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucStudent());

        }

        private void lblClo_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucClo());
        }

        private void lblRubric_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucRubric());
        }

        private void lblAssessment_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucAssessment());
        }

        private void lblAttendance_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucMarkAttendance());
        }

        private void lblResult_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucResult());
        }

        private void lblReport_Click(object sender, EventArgs e)
        {
            this.tlpChangeable.Controls.Clear();
            loadNewForm(new ucReport());
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
