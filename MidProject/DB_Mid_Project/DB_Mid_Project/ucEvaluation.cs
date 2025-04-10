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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Mid_Project
{
    public partial class ucEvaluation : UserControl
    {
        String name;
        int id;
        int ACID;
        int rlId;
        string selected_name_index;
        int name_id;
        int mid;
        int sid;
        string dateC;

        public ucEvaluation(String name, int id)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void btnView_Click(object sender, EventArgs e)
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"Select s.FirstName, s.LastName,s.RegistrationNumber,ac.Name , rl.MeasurementLevel from StudentResult as sr join student as s on sr.StudentId = s.Id join AssessmentComponent as ac on ac.Id = sr.AssessmentComponentId join RubricLevel as rl on rl.Id = sr.RubricMeasurementId join Assessment as a on a.Id = ac.AssessmentId where a.Title = @title order by s.LastName,s.RegistrationNumber,ac.Name , rl.MeasurementLevel ", con2);
            cmd2.Parameters.AddWithValue("@title", name);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEvaluation.DataSource = null;
            dgvEvaluation.DataSource = dt;
            dgvEvaluation.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dgvEvaluation_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cbStudent.Text = dgvEvaluation.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbAssessmentComp.Text = dgvEvaluation.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbMaesurementLevel.Text = dgvEvaluation.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
        
        private void loadAssessmentComp()
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand($"Select ac.Name from Assessment as a join AssessmentComponent as ac on a.Id = ac.AssessmentId where a.Id = '{id}'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbAssessmentComp.Items.Add(reader.GetString(0));
            }
            reader.Close();

            cmd.ExecuteNonQuery();
        }
        private void loadMeasurementLevel()
        {
            cbMaesurementLevel.Items.Clear();
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand($"  select CONCAT(rl.Details,' (', rl.MeasurementLevel,')')  from RubricLevel as rl join Rubric as r on r.Id = rl.RubricId join AssessmentComponent as ac on ac.RubricId = r.Id join Assessment as a on a.Id = ac.AssessmentId where ac.Name = '{cbAssessmentComp.Text}' and a.Title = '{name}' order by rl.MeasurementLevel ASC", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbMaesurementLevel.Items.Add(reader.GetString(0));
            }
           
            reader.Close();

            cmd.ExecuteNonQuery();



        }
        private void loadstudents()
        {
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand($"select RegistrationNumber from Student where status = '{5}' order by RegistrationNumber", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbStudent.Items.Add(reader.GetString(0));
            }
            reader.Close();

            cmd.ExecuteNonQuery();

        }
        private void ucEvaluation_Load(object sender, EventArgs e)
        {
            lblass.Text = name;
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"Select s.FirstName, s.LastName,s.RegistrationNumber,ac.Name , rl.MeasurementLevel from StudentResult as sr join student as s on sr.StudentId = s.Id join AssessmentComponent as ac on ac.Id = sr.AssessmentComponentId join RubricLevel as rl on rl.Id = sr.RubricMeasurementId join Assessment as a on a.Id = ac.AssessmentId where a.Title = @title order by s.LastName,s.RegistrationNumber,ac.Name , rl.MeasurementLevel ", con2);
            cmd2.Parameters.AddWithValue("@title", name);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEvaluation.DataSource = null;
            dgvEvaluation.DataSource = dt;
            dgvEvaluation.DefaultCellStyle.ForeColor = Color.Black;
            loadstudents();
            loadAssessmentComp();


            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            dgvEvaluation.Columns.Add(Update);
        }

        private void cbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_name_index = cbStudent.SelectedItem.ToString();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($" select Id from Student where RegistrationNumber like @reg", con);
            cmd.Parameters.AddWithValue("@reg", selected_name_index);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name_id = reader.GetInt32(0);
            }
            reader.Close();

            cmd.ExecuteNonQuery();
        }

        private void cbMaesurementLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mid = Convert.ToInt32(cbMaesurementLevel.Items[cbMaesurementLevel.SelectedIndex].ToString());
        }

        private void cbAssessmentComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMeasurementLevel();
        }
        private int getACId()
        {
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand command3 = new SqlCommand($"  SELECT Top(1) AC.Id FROM AssessmentComponent AC INNER JOIN Assessment A ON AC.AssessmentId = A.Id WHERE AC.Name = '{cbAssessmentComp.Text}' AND A.Title = '{name}'", con3);
            int count3 = (int)command3.ExecuteScalar();
            return int.Parse(count3.ToString());

        }
        private int getrlId()
        {
            string digit;
            string pattern = @"\((\d+)\)";
            Match match = Regex.Match(cbMaesurementLevel.Text, pattern);
            digit = match.Groups[1].Value; 
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand command3 = new SqlCommand($" SELECT Top(1) RL.Id FROM AssessmentComponent AC INNER JOIN Rubric R ON AC.RubricId = R.Id INNER JOIN RubricLevel RL ON R.Id = RL.RubricId WHERE AC.Name = '{cbAssessmentComp.Text}' AND RL.MeasurementLevel = '{digit}'", con3);
            int count3 = (int)command3.ExecuteScalar();
            return int.Parse(count3.ToString());
            

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            sid = ucStudenList.getId(cbStudent.Text);
            ACID = getACId();
            rlId = getrlId();
            dateC = DateTime.Now.ToString("yyyy-MM-dd");

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentResult (StudentId, AssessmentComponentId, RubricMeasurementId, EvaluationDate) VALUES (@sid, @ACID, @measurementLevel, @dateC)", con);
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@ACID", ACID);
            cmd.Parameters.AddWithValue("@measurementLevel", rlId);
            cmd.Parameters.AddWithValue("@dateC", dateC);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Evaluated");
        }

        private void dgvEvaluation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            cbStudent.Text = dgvEvaluation.Rows[dgvEvaluation.CurrentCell.RowIndex].Cells[3].Value.ToString();
            cbAssessmentComp.Text = dgvEvaluation.Rows[dgvEvaluation.CurrentCell.RowIndex].Cells[4].Value.ToString();
            cbMaesurementLevel.Text = dgvEvaluation.Rows[dgvEvaluation.CurrentCell.RowIndex].Cells[5].Value.ToString();

            int index = dgvEvaluation.CurrentCell.ColumnIndex;
            {

                if (index == 0)
                {

                    sid = ucStudenList.getId(cbStudent.Text);
                    ACID = getACId();
                    rlId = getrlId();
                    var con6 = Configuration.getInstance().getConnection();
                    SqlCommand cmd6 = new SqlCommand("Update StudentResult Set RubricMeasurementId = @measurmentLevel where StudentId = @sId and AssessmentComponentId = @acId", con6);
                    cmd6.Parameters.AddWithValue("@measurmentLevel", rlId);
                    cmd6.Parameters.AddWithValue("@sId", sid);
                    cmd6.Parameters.AddWithValue("@acId", ACID);
                    cmd6.ExecuteNonQuery();
                    MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        }
    }
}
