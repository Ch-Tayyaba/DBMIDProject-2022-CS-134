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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Mid_Project
{
    public partial class ucStudentResult : UserControl
    {
        string name;
        int id;
        public ucStudentResult()
        {
            InitializeComponent();
        }
        public ucStudentResult(int id, string name)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
        }
        private void load_student_result()
        {
            int sid = ucStudenList.getId(cbStudentID.Text);
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($" SELECT s.RegistrationNumber, s.FirstName, s.LastName, ac.Name, ac.TotalMarks, rl.MeasurementLevel as ObtainedLevel, MAXLevel.MaximumLevel, ((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel) as FinalObtainedMarks FROM StudentResult as sr JOIN student as s ON sr.StudentId = s.Id JOIN AssessmentComponent as ac ON ac.Id = sr.AssessmentComponentId JOIN RubricLevel as rl ON rl.Id = sr.RubricMeasurementId JOIN Assessment as a ON ac.AssessmentId = a.Id JOIN (SELECT MAX(MeasurementLevel) AS MaximumLevel FROM RubricLevel) AS MAXLevel ON 1=1 WHERE a.Title = '{name}' and s.Id = '{sid}' order by s.RegistrationNumber,ac.Name", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResult.DataSource = null;
            dgvResult.DataSource = dt;
            dgvResult.DefaultCellStyle.ForeColor = Color.DarkBlue;


        }
        private void load_basic_data()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"  SELECT s.RegistrationNumber, s.FirstName, s.LastName, ac.Name, ac.TotalMarks, rl.MeasurementLevel as ObtainedLevel, MAXLevel.MaximumLevel, ((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel) as FinalObtainedMarks FROM StudentResult as sr JOIN student as s ON sr.StudentId = s.Id JOIN AssessmentComponent as ac ON ac.Id = sr.AssessmentComponentId JOIN RubricLevel as rl ON rl.Id = sr.RubricMeasurementId JOIN Assessment as a ON ac.AssessmentId = a.Id JOIN (SELECT MAX(MeasurementLevel) AS MaximumLevel FROM RubricLevel) AS MAXLevel ON 1=1 WHERE a.Title = '{name}' order by s.RegistrationNumber,ac.Name", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvResult.DataSource = null;
            dgvResult.DataSource = dt;
            dgvResult.DefaultCellStyle.ForeColor = Color.DarkBlue;
        }
        private void ucStudentResult_Load(object sender, EventArgs e)
        {
            load_basic_data();
            LBLX.Text = name;
        }

        private void btnResultByStudent_Click(object sender, EventArgs e)
        {
            cbStudentID.Items.Clear();
            label2.Visible = true;
            cbStudentID.Visible = true;
            loads_box();

        }
        private void loads_box()
        {
            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand("Select  student.RegistrationNumber FROM student", con2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                cbStudentID.Items.Add(reader2.GetString(0));
            }
            reader2.Close();

            cmd2.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbStudentID.Items.Clear();
            label2.Visible = false;
            cbStudentID.Visible = false;
            load_basic_data();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            load_student_result();

        }
    }
}
