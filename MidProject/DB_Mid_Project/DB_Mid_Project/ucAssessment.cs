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
    public partial class ucAssessment : UserControl
    {
        string DateC;
        bool check_update;
        int id, marks, weightage;
        string title;
        bool check_t = false; bool check_M = false; bool check_W = false;

        public ucAssessment()
        {
            InitializeComponent();
        }

        private String check()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($" IF ( select MAX(1) FROM Assessment WHERE Assessment.Title ='{txtbxTitle.Text}') > 0 BEGIN   SELECT '1' END ELSE BEGIN   SELECT '2' END", con);
            string X = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetString(0));
            }
            reader.Close();

            cmd.ExecuteNonQuery();
            return X;
        }
        private void blnAddComponent_Click(object sender, EventArgs e)
        {
            ucAssessmentComponent newUserControl = new ucAssessmentComponent();
            newUserControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(newUserControl);
            newUserControl.BringToFront();
            this.Hide();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxTitle.Text = String.Empty;
            txtbxMarks.Text = String.Empty;
            txtbxWeightage.Text = String.Empty;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string y = check();
            //DateTime selectedDateTime = dtpDateOfCreation.Value;
            DateC = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (check_M && check_M && check_W)
            {
                if (check_update == false && y != "1")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Assessment values (@title,@date,@Marks,@Weightage)", con);
                    cmd.Parameters.AddWithValue("@title", (txtbxTitle.Text));
                    cmd.Parameters.AddWithValue("@date", DateC);
                    cmd.Parameters.AddWithValue("@Marks", txtbxMarks.Text);
                    cmd.Parameters.AddWithValue("@Weightage", txtbxWeightage.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Added  SuccessFully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbxTitle.Text = String.Empty;
                    txtbxMarks.Text = String.Empty;
                    txtbxWeightage.Text = String.Empty;
                    //MessageBox.Show("ADD Assessment Components ");
                    //ucAssessmentComponent newUserControl = new ucAssessmentComponent();
                    //newUserControl.Dock = DockStyle.Fill;
                    //this.Parent.Controls.Add(newUserControl);
                    //newUserControl.BringToFront();
                    //this.Hide();
                }
                else if (check_update == true)
                {
                    id = getAssessmentId(title);

                    var con2 = Configuration.getInstance().getConnection();
                    SqlCommand cmd2 = new SqlCommand("Update Assessment Set Title = @title, DateCreated = @date, TotalMarks = @Marks, TotalWeightage = @Weightage  WHERE Id = @ID", con2);
                    cmd2.Parameters.AddWithValue("@title", (txtbxTitle.Text));
                    cmd2.Parameters.AddWithValue("@date", DateC);
                    cmd2.Parameters.AddWithValue("@Marks", txtbxMarks.Text);
                    cmd2.Parameters.AddWithValue("@Weightage", txtbxWeightage.Text);
                    cmd2.Parameters.AddWithValue("@ID", id);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    check_update = false;
                    txtbxTitle.Text = String.Empty;
                    txtbxMarks.Text = String.Empty;
                    txtbxWeightage.Text = String.Empty;
                }
                else
                {
                    if (y == "1") { MessageBox.Show("Already Exist"); }
                }
            }

        }
        private void txtbxTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtbxTitle.Text == string.Empty)
            {// check is empty
                lblTitalSingal.Text = "Enter the name";
                check_t = false;
            }
            else if (txtbxTitle.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {//check isSpecialCharactor
                lblTitalSingal.Text = "Allowed characters: a-z, A-Z";
                check_t = false;
            }
            else
            {//ready for storage or action
                lblTitalSingal.Text = " ";

            }
        }
        private void txtbxMarks_TextChanged(object sender, EventArgs e)
        {
            if (txtbxMarks.Text == string.Empty)
            {// check is empty
                labelmarkssingnal.Text = "Enter the marks";
                check_M = false;
            }
            if (txtbxMarks.Text.Any(ch => !char.IsDigit(ch)))
            {//check isSpecialCharactor
                labelmarkssingnal.Text = "Allowed characters: 1-9";
                check_M = false;
            }
            else
            {//ready for storage or action
                labelmarkssingnal.Text = " ";
                check_M = true;
            }
        }
        private void txtbxWeightage_TextChanged(object sender, EventArgs e)
        {
            if (txtbxWeightage.Text == string.Empty)
            {// check is empty
                lblWsignla.Text = "Enter the marks";
                check_W = false;
            }
            if (txtbxWeightage.Text.Any(ch => !char.IsDigit(ch)))
            {//check isSpecialCharactor
                lblWsignla.Text = "Allowed characters: 1-9";
                check_W = false;
            }
            else
            {//ready for storage or action
                lblWsignla.Text = " ";
                check_W = true;
            }
        }
        private void view()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Title,TotalMarks,TotalWeightage,DateCreated from Assessment order by Title", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAssessment.DataSource = null;
            dgvAssessment.DataSource = dt;
            dgvAssessment.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }
        private void ucAssessment_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            dgvAssessment.Columns.Add(Update);
            dgvAssessment.Columns.Add(Delete);
            view();
            check_update = false;
        }
        private void dgvAssessment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            title = dgvAssessment.Rows[dgvAssessment.CurrentCell.RowIndex].Cells[2].Value.ToString();
            marks = Convert.ToInt16(dgvAssessment.Rows[dgvAssessment.CurrentCell.RowIndex].Cells[3].Value.ToString());
            weightage = Convert.ToInt16(dgvAssessment.Rows[dgvAssessment.CurrentCell.RowIndex].Cells[4].Value.ToString());

            int index = dgvAssessment.CurrentCell.ColumnIndex;
            {

                if (index == 0)
                {
                    txtbxTitle.Text = title;
                    txtbxMarks.Text = marks.ToString();
                    txtbxWeightage.Text = weightage.ToString();
                    check_update = true;
                }
                else if (index == 1)
                {
                    id = getAssessmentId(title);


                    string c = checkForDel();

                    if (c != "1")
                    {
                        DelAssessment();
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("This will also delete Assessment Components", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DelAssessmentWithComponent();
                        DelAssessment();
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }
            }
        }
        private string checkForDel()
        {
            var con14 = Configuration.getInstance().getConnection();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from Assessment as a join AssessmentComponent as ac on a.Id = ac.AssessmentId where ac.AssessmentId ='{id}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
            string z = "";
            SqlDataReader reader = cmd14.ExecuteReader();
            while (reader.Read())
            {
                z = (reader.GetString(0));
            }
            reader.Close();
            cmd14.ExecuteNonQuery();
            return z;
        }
        private void DelAssessment()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM Assessment  where Id= @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        private void DelAssessmentWithComponent()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete sr FROM StudentResult as sr join AssessmentComponent as ac on sr.AssessmentComponentId = ac.Id  where ac.AssessmentId= @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("Delete FROM AssessmentComponent  where AssessmentId= @id", con1);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.ExecuteNonQuery();
        }
        private void dgvAssessment_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            title = dgvAssessment.Rows[e.RowIndex].Cells[2].Value.ToString();
            marks = Convert.ToInt16(dgvAssessment.Rows[e.RowIndex].Cells[3].Value.ToString());
            weightage = Convert.ToInt16(dgvAssessment.Rows[e.RowIndex].Cells[4].Value.ToString());

        }
        public static int getAssessmentId(string t)
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand($"Select Top(1) id from Assessment where  Title = '{t}'", con19);
            int count = (int)cmd19.ExecuteScalar();
            return int.Parse(count.ToString());
        }
    }
}
