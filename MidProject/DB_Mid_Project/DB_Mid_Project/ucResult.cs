using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class ucResult : UserControl
    {
        String Name;
        int ID;
        public ucResult()
        {
            InitializeComponent();
        }
        
        private void ucResult_Load(object sender, EventArgs e)
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Id,Title,TotalMarks,TotalWeightage,DateCreated  from Assessment order by Title", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResult.DataSource = null;
            dgvResult.DataSource = dt;
            dgvResult.DefaultCellStyle.ForeColor = Color.Black;

            DataGridViewButtonColumn Evaluate = new DataGridViewButtonColumn();
            Evaluate.HeaderText = "Evaluate";
            Evaluate.Text = "Evaluate";
            Evaluate.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Result = new DataGridViewButtonColumn();
            Result.HeaderText = "Result";
            Result.Text = "Result";
            Result.UseColumnTextForButtonValue = true;
            dgvResult.Columns.Add(Evaluate);
            dgvResult.Columns.Add(Result);
        }

        private void dgvResult_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Name = dgvResult.Rows[e.RowIndex].Cells[3].Value.ToString();
            ID = Convert.ToInt16(dgvResult.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name = dgvResult.Rows[dgvResult.CurrentCell.RowIndex].Cells[3].Value.ToString();
            ID = Convert.ToInt16(dgvResult.Rows[dgvResult.CurrentCell.RowIndex].Cells[2].Value.ToString());
            int index = dgvResult.CurrentCell.ColumnIndex;
            {
                if (index == 0)
                {
                    ucEvaluation newUserControl = new ucEvaluation(Name, ID);
                    newUserControl.Dock = DockStyle.Fill;
                    this.Parent.Controls.Add(newUserControl);
                    newUserControl.BringToFront();
                    this.Hide();


                }
                else if (index == 1)
                {
                    ucStudentResult newUserControl = new ucStudentResult(ID, Name);
                    newUserControl.Dock = DockStyle.Fill;
                    this.Parent.Controls.Add(newUserControl);
                    newUserControl.BringToFront();
                    this.Hide();
                }
            }
        }

    }
}
