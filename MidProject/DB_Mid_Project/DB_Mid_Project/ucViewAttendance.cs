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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Mid_Project
{
    public partial class ucViewAttendance : UserControl
    {
        string x;
        public ucViewAttendance()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            view();
          
        }
        private void view()
        {
            dgvAttendance.CellFormatting += dgvAttendance_CellFormatting;
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select  s.FirstName,s.LastName,s.RegistrationNumber, sa.AttendanceStatus from StudentAttendance as sa join Student as s on s.Id = sa.StudentId", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAttendance.DataSource = null;
            dgvAttendance.DataSource = dt;
            dgvAttendance.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void loads_box()
        {
            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand("\r\nselect Distinct(AttendanceDate) from ClassAttendance join StudentAttendance on StudentAttendance.AttendanceId=ClassAttendance.Id\r\n", con2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                cbDateTime.Items.Add((reader2.GetSqlDateTime(0)).ToString());
            }
            reader2.Close();

            cmd2.ExecuteNonQuery();



        }

        private void load_student_attendance()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"  select CONCAT(FirstName,LastName)as NAME,RegistrationNumber,Lookup.Name as STATUS,AttendanceDate\r\nfrom ClassAttendance\r\njoin StudentAttendance\r\non StudentAttendance.AttendanceId=ClassAttendance.Id\r\njoin Student \r\non StudentAttendance.StudentId=Student.Id\r\njoin Lookup\r\non LookupId=StudentAttendance.AttendanceStatus\r\nwhere ClassAttendance.AttendanceDate='{x}'", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAttendance.DataSource = null;
            dgvAttendance.DataSource = dt;
            dgvAttendance.DefaultCellStyle.ForeColor = Color.DarkBlue;
        }

        private void cbDateTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = cbDateTime.Items[cbDateTime.SelectedIndex].ToString();
            load_student_attendance();
        }

        private void ucViewAttendance_Load(object sender, EventArgs e)
        {
            cbDateTime.Items.Clear();
            load_student_attendance();
            loads_box();
        }

        private void dgvAttendance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                // Assuming your column contains integers, you can convert the cell value to an int for comparison
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue))
                {
                    // Your specific condition
                    if (cellValue == 1)
                    {
                        e.Value = "Present";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                    if (cellValue == 2)
                    {
                        e.Value = "Absent";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                    if (cellValue == 3)
                    {
                        e.Value = "Leave";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                    if (cellValue == 4)
                    {
                        e.Value = "Late";
                        e.FormattingApplied = true; // Mark the event as handled
                    }
                }
            }
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
