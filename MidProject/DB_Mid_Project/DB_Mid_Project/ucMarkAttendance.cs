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
    public partial class ucMarkAttendance : UserControl
    {
        bool check_date = false;
        bool check_update = false;
        int id;
        public ucMarkAttendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDateTime = dtpTime.Value;
                string sqlDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                loadDate(sqlDateTime);
                loadId(sqlDateTime);

                MessageBox.Show(id.ToString());
                if (dgvAttendance.Rows.Count != 0)
                {
                    var connection = Configuration.getInstance().getConnection();
                    for (int i = 0; i < dgvAttendance.Rows.Count - 1; i++)
                    {
                        if (dgvAttendance.Rows[i].Cells[0].Value != null)
                        {
                            string SI = dgvAttendance.Rows[i].Cells[1].Value.ToString();
                            string S = dgvAttendance.Rows[i].Cells[0].Value.ToString();
                            int x = 1;

                            if (S == "Present") { x = 1; }
                            else if (S == "Absent") { x = 2; }
                            else if (S == "Leave") { x = 3; }
                            else if (S == "Late") { x = 4; }
                            string cmd3 = $"INSERT INTO StudentAttendance  VALUES ({id},{SI},{x})";
                            SqlCommand command = new SqlCommand(cmd3, connection);
                            /// MessageBox.Show(x.ToString());

                            command.ExecuteNonQuery();
                            MessageBox.Show("Saved Successfully");
                        }
                        else { MessageBox.Show("Mark the attendance first it!!!"); }
                    }
                }
            }
            catch (Exception exp) { MessageBox.Show(exp.Message.ToString()); }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void loadDate(string sqlDateTime)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into ClassAttendance values (@date)", con);
            cmd.Parameters.AddWithValue("@date", (sqlDateTime));
            cmd.ExecuteNonQuery();
        }
        private void loadId(string sqlDateTime)
        {
            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand("select max(Id) from ClassAttendance where AttendanceDate=@date", con2);
            cmd2.Parameters.AddWithValue("@date", sqlDateTime);
            cmd2.ExecuteNonQuery();
            id = (Int32)cmd2.ExecuteScalar();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            ucViewAttendance newUserControl = new ucViewAttendance();
            MessageBox.Show("Select the date and click on result to generate Report");
            newUserControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(newUserControl);
            newUserControl.BringToFront();
            this.Hide();
        }
        private void DataBind()
        {
            DataGridViewComboBoxColumn Update = new DataGridViewComboBoxColumn();
            Update.HeaderText = "Status";
            Update.Items.Add("Present");
            Update.Items.Add("Absent");
            Update.Items.Add("Late");
            Update.Items.Add("Leave");
            dgvAttendance.Columns.Add(Update); 
        }

        private void ucMarkAttendance_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($"select Student.Id , Concat(Student.FirstName,Student.LastName)   as StudentName,RegistrationNumber from Student where Status = {5}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAttendance.DataSource = dt;
            dgvAttendance.DefaultCellStyle.ForeColor = Color.Black;
            DataBind();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check_update == true)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select   AttendanceId, AttendanceDate, Concat(FirstName, LastName) as StudentName, RegistrationNumber  from StudentAttendance AS S join Student as SA on S.StudentId = SA.Id  join ClassAttendance as C ON C.Id = S.AttendanceId", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAttendance.DataSource = dt;
                dgvAttendance.DefaultCellStyle.ForeColor = Color.Black;
                DataBind();
                check_update = false;
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
