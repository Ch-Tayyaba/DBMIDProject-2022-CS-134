using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DB_Mid_Project
{
    public partial class ucStudenList : UserControl
    {
        string first, last, registeration, email, contact;
        int id, status;
        public ucStudenList()
        {
            InitializeComponent();
            
        }
        private void SetDataGridViewProperties()
        {
            // Assuming dataGridView1 is the name of your DataGridView control
            dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudentList.AllowUserToAddRows = false;
            dgvStudentList.AllowUserToDeleteRows = false;
            dgvStudentList.AllowUserToOrderColumns = true;
            dgvStudentList.AllowUserToResizeColumns = true;
            dgvStudentList.AllowUserToResizeRows = false;
            dgvStudentList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void ucStudenList_Load(object sender, EventArgs e)
        {
            load_data_table();
            loadInacticeCount();
            loadTotalCount();
            loadActiveCount();
        }
        private void DataBind()
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            dgvStudentList.Columns.Add(Update);
        }
        private void load_data_table()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select RegistrationNumber,FirstName,LastName,Contact,Email,Status from Student order by RegistrationNumber", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudentList.DataSource = dt;
            dgvStudentList.CellFormatting += dgvStudentList_CellFormatting;
            SetDataGridViewProperties();
            dgvStudentList.DefaultCellStyle.ForeColor = Color.Black;
            DataBind();
            dgvStudentList.ForeColor = Color.Navy;
        }
        private void loadInacticeCount()
        {
            var con4 = Configuration.getInstance().getConnection();
            SqlCommand command4 = new SqlCommand("Select count(id) from Student where status=6", con4);
            int count2 = (int)command4.ExecuteScalar();
            lblInActiveCount.Text = count2.ToString();
        }

        private void dgvStudentList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                // Assuming your column contains integers, you can convert the cell value to an int for comparison
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue))
                {
                    // Your specific condition
                    if (cellValue == 5)
                    {
                        // Set the cell value to "Active" (or any other value you prefer)
                        e.Value = "Active";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                    if (cellValue == 6)
                    {
                        // Set the cell value to "Inactive" (or any other value you prefer)
                        e.Value = "InActive";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                }
            }
        }

        private void loadTotalCount()
        {
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand command3 = new SqlCommand("Select count(id) from Student", con3);
            int count3 = (int)command3.ExecuteScalar();
            lblTotalCount.Text = count3.ToString();

        }
        private void loadActiveCount()
        {
            var con4 = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("Select count(id) from Student where status=5", con4);
            int count = (int)command.ExecuteScalar();
            lblActiveCount.Text = count.ToString();
        }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            registeration = dgvStudentList.Rows[e.RowIndex].Cells[1].Value.ToString();
            first = dgvStudentList.Rows[e.RowIndex].Cells[2].Value.ToString();
            last = dgvStudentList.Rows[e.RowIndex].Cells[3].Value.ToString();
            contact = dgvStudentList.Rows[e.RowIndex].Cells[4].Value.ToString();
            email = dgvStudentList.Rows[e.RowIndex].Cells[5].Value.ToString();
            status = int.Parse(dgvStudentList.Rows[e.RowIndex].Cells[6].Value.ToString());
          

            int index = dgvStudentList.CurrentCell.ColumnIndex;
            {

                if (index == 0)
                {
                    id = getId(registeration);
                    ucStudent newUserControl = new ucStudent(id,first, last, registeration, email, contact, status, true);
                    newUserControl.Dock = DockStyle.Fill;
                    this.Parent.Controls.Add(newUserControl);
                    newUserControl.BringToFront();
                    this.Hide();
                }

            }
        }
        public static int getId(string reg)
        {
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand command3 = new SqlCommand($"Select Top(1) id from Student where  RegistrationNumber = '{reg}'", con3);
            int count3 = (int)command3.ExecuteScalar();
            return int.Parse(count3.ToString());
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void dgvStudentList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            registeration = dgvStudentList.Rows[e.RowIndex].Cells[1].Value.ToString();
            first = dgvStudentList.Rows[e.RowIndex].Cells[2].Value.ToString();
            last = dgvStudentList.Rows[e.RowIndex].Cells[3].Value.ToString();
            contact = dgvStudentList.Rows[e.RowIndex].Cells[4].Value.ToString();
            email = dgvStudentList.Rows[e.RowIndex].Cells[5].Value.ToString();
            status = int.Parse(dgvStudentList.Rows[e.RowIndex].Cells[6].Value.ToString());
           
        }

    }
}
